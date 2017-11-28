using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TestDbApp.EntityFrameworkBinding
{
    /// <summary>
    /// Предоставляет DbSet в текущем DbContext в качестве связующего источника данных.
    /// </summary>
    /// <remarks>
    /// Этот класс реализует интерфейс IListSource и возвращает IBindingList,
    /// построенный поверх базового DbSet.
    /// </remarks>
    public class EntitySet : IListSource, IQueryable
    {
        private IQueryable _query;          
        private IEntityBindingList _list;   
        private readonly PropertyInfo _pi;  
        private ListDictionary _dctLookup;  

        internal EntitySet(EntityDataSource ds, PropertyInfo pi)
        {
            var type = pi.PropertyType;
            Debug.Assert(
                type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                type.GetGenericArguments().Length == 1);

            DataSource = ds;
            _pi = pi;
            ElementType = type.GetGenericArguments()[0];
        }

        #region object model

        /// <summary>
        /// Получает <see cref="EntityDataSource"/> ,которому принадлежит этот набор сущностей.
        /// </summary>
        public EntityDataSource DataSource { get; }

        /// <summary>
        /// Получает имя этого набора объектов.
        /// </summary>
        public string Name => _pi?.Name;

        /// <summary>
        /// Возвращает тип объекта в этом наборе сущностей.
        /// </summary>
        public Type ElementType { get; }

        /// <summary>
        /// Получает объект <see cref="IQueryable"/> ,который извлекает объекты в этом наборе.
        /// </summary>
        public IQueryable Query
        {
            get
            {
                if (_query == null && DataSource.DbContext != null && _pi != null)
                {
                    _query = _pi.GetValue(DataSource.DbContext, null) as IQueryable;
                }
                return _query;
            }
        }

        /// <summary>
        /// Получает список объектов в наборе, которые не были удалены или отсоединены.
        /// </summary>
        public IEnumerable ActiveEntities => GetActiveEntities(Query);

        /// <summary>
        /// Получает список объектов в наборе, которые не были удалены или отсоединены.
        /// </summary>
        internal static IEnumerable GetActiveEntities(IEnumerable query)
        {
            if (query == null) yield break;
            foreach (var item in query)
            {
                var o = item as EntityObject;
                var state = o?.EntityState ?? EntityState.Unchanged;
                switch (state)
                {
                    case EntityState.Deleted:
                    case EntityState.Detached:
                        break;
                    default:
                        yield return item;
                        break;
                }
            }
        }

        /// <summary>
        /// Отменяет любые ожидающие изменения в этом объекте.
        /// </summary>
        internal void CancelChanges()
        {
            if (_list == null || Query == null) return;
            var ctx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)DataSource.DbContext).ObjectContext;
            ctx.Refresh(RefreshMode.StoreWins, Query);
            _list.Refresh();
        }

        /// <summary>
        /// Обновляет представление этого набора путем повторной загрузки из базы данных.
        /// </summary>
        public void RefreshView()
        {
            if (_list == null || Query == null) return;
            var ctx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)DataSource.DbContext).ObjectContext;
            ctx.Refresh(RefreshMode.ClientWins, Query);
            _list.Refresh();
        }

        /// <summary>
        /// Получает <see cref="IBindingListView"/> ,который может использоваться как источник данных для связанных элементов управления.
        /// </summary>
        public IBindingListView List => GetBindingList();

        /// <summary>
        /// Получает словарь, содержащий сущности как ключи, и их строковое представление как значения.
        /// </summary>
        public ListDictionary LookupDictionary => _dctLookup ?? (_dctLookup = BuildLookupDictionary());

        #endregion

        #region IListSource Implements

        bool IListSource.ContainsListCollection => false;

        IList IListSource.GetList()
        {
            return GetBindingList();
        }

        /// <summary>
        /// Получает IBindingListView для этого набора объектов
        /// </summary>
        /// <returns></returns>
        private IBindingListView GetBindingList()
        {
            if (_list != null) return _list;
            var listType = typeof(EntityBindingList<>);
            listType = listType.MakeGenericType(ElementType);
            _list = (IEntityBindingList)Activator.CreateInstance(listType, DataSource, Query, Guid.NewGuid().ToString());// this.Name);

            _list.ListChanged += _list_ListChanged;
            return _list;
        }

        private void _list_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (_dctLookup == null) return;
            _dctLookup.Clear();

            var map = BuildLookupDictionary(_list);
            foreach (var kvp in map)
            {
                _dctLookup.Add(kvp.Key, kvp.Value);
            }
        }

        private ListDictionary BuildLookupDictionary()
        {
            return BuildLookupDictionary(ActiveEntities);
        }

        private ListDictionary BuildLookupDictionary(IEnumerable entities)
        {
            var mi = ElementType.GetMethod("ToString");
            if (mi != null && mi.DeclaringType == ElementType)
            {
                var list = new List<KeyValuePair>();
                foreach (var item in entities)
                {
                    list.Add(new KeyValuePair(item, item.ToString()));
                }
                return BuildLookupDictionary(list);
            }
            
            var atts = ElementType.GetCustomAttributes(typeof(DefaultPropertyAttribute), false);
            if (atts.Length > 0)
            {
                var dpa = atts[0] as DefaultPropertyAttribute;
                if (dpa != null)
                {
                    var pi = ElementType.GetProperty(dpa.Name);
                    if (pi != null && pi.PropertyType == typeof(string))
                    {
                        var list = new List<KeyValuePair>();
                        foreach (var item in entities)
                        {
                            list.Add(new KeyValuePair(item, (string)pi.GetValue(item, null)));
                        }
                        return BuildLookupDictionary(list);
                    }
                }
            }
            
            foreach (var pi in ElementType.GetProperties())
            {
                if (pi.PropertyType != typeof(string)) continue;
                if (pi.Name.IndexOf("Name", StringComparison.OrdinalIgnoreCase) <= -1 &&
                    pi.Name.IndexOf("Description", StringComparison.OrdinalIgnoreCase) <= -1) continue;

                var list = new List<KeyValuePair>();
                foreach (var item in entities)
                {
                    list.Add(new KeyValuePair(item, (string)pi.GetValue(item, null)));
                }
                return BuildLookupDictionary(list);
            }
            return null;
        }

        private static ListDictionary BuildLookupDictionary(List<KeyValuePair> list)
        {
            list.Sort();
            var map = new ListDictionary();
            foreach (var kvp in list)
            {
                map.Add(kvp.Key, kvp.Value);
            }

            return map;
        }

        private class KeyValuePair : IComparable
        {
            public KeyValuePair(object key, string value)
            {
                Key = key;
                Value = value;
            }
            public object Key { get; }
            public string Value { get; }
            int IComparable.CompareTo(object obj)
            {
                return string.Compare(this.Value, ((KeyValuePair)obj).Value, StringComparison.OrdinalIgnoreCase);
            }
        }

        #endregion

        #region  IQueryable Implements

        Type IQueryable.ElementType => ElementType;

        Expression IQueryable.Expression => Query.Expression;

        IQueryProvider IQueryable.Provider => Query.Provider;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Query.GetEnumerator();
        }

        #endregion
    }

    /// <summary>
    /// Коллекция объектов EntitySet.
    /// </summary>
    public class EntitySetCollection : ObservableCollection<EntitySet>
    {
        public EntitySet this[string name]
        {
            get
            {
                var index = IndexOf(name);
                return index > -1 ? this[index] : null;
            }
        }
        public bool Contains(string name)
        {
            return IndexOf(name) > -1;
        }
        public int IndexOf(string name)
        {
            for (var i = 0; i < Count; i++)
            {
                if (this[i].Name == name)
                    return i;
            }
            return -1;
        }
    }
    /// <summary>
    /// Словарь, который реализует IListSource (используется для реализации словарей поиска)
    /// </summary>
    public class ListDictionary : Dictionary<object, string>, IListSource
    {
        public bool ContainsListCollection => throw new NotImplementedException();

        public IList GetList()
        {
            return this.ToList();
        }
    }

}
