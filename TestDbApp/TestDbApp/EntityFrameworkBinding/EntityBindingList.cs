using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Diagnostics;

namespace TestDbApp.EntityFrameworkBinding
{
    /// <summary>
    /// IBindingList с поддержкой сортировки.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityBindingList<T> : BindingList<T>, ITypedList, IEntityBindingList where T : class
    {
        private readonly DbSet<T> _set;
        private readonly EntityCollection<T> _coll;
        private readonly IEnumerable _query;
        private readonly string _name;
        private PropertyDescriptor _sortProp;
        private ListSortDirection _sortDir;
        private bool _deferNotifications;
        private int _addingNew;

        /// <summary>
        /// Инициализирует новый экземпляр объекта,<see cref="EntityBindingList"/>.
        /// </summary>
        /// <param name="dataSource"><see cref="EntityDataSource"/> которому принадлежат сущности этого списка.</param>
        /// <param name="query"><see cref="IEnumerable"/> предоставляет сущности для этого списка.</param>
        /// <param name="name">Имя для идентификации этого списка в его родительском (для иерархической привязки).</param>
        public EntityBindingList(EntityDataSource dataSource, IEnumerable query, string name)
        {
            DataSource = dataSource;
            _set = query as DbSet<T>;
            _coll = query as EntityCollection<T>;
            _query = query;
            _name = name;

            if (dataSource != null && !dataSource.DesignMode)
            {
                Refresh();
            }
            else
            {
                try
                {
                    AddNew();
                }
                catch
                {
                    // ignored
                }
            }
        }
        /// <summary>
        /// Инициализирует новый экземпляр объекта,<see cref="EntityBindingList"/>.
        /// </summary>
        /// <param name="query"><see cref="IEnumerable"/> который предоставляет сущности для этого списка.</param>
        public EntityBindingList(IEnumerable query) : this(null, query, string.Empty) { }

        #region Object model

        /// <summary>
        /// Получает <see cref="EntityDataSource"/> которому принадлежат элементы в этом списке.
        /// </summary>
        public EntityDataSource DataSource { get; }

        /// <summary>
        /// Получает <see cref="Type"/> элементов списка.
        /// </summary>
        public Type ElementType => typeof(T);

        /// <summary>
        /// Обновляет список, перезагружая все элементы из исходного запроса.
        /// </summary>
        public void Refresh()
        {
            try
            {
                _deferNotifications = true;

                Clear();

                foreach (T item in EntitySet.GetActiveEntities(_query))
                {
                    if (ApplyFilter(item))
                    {
                        this.Add(item);
                    }
                }

                if (IsSortedCore)
                {
                    ApplySortCore(_sortProp, _sortDir);
                }
            }
            finally
            {
                _deferNotifications = false;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Вызывает <see cref="ListChanged"/> событие.
        /// </summary>
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (_deferNotifications) return;
            base.OnListChanged(e);

            if (_addingNew != 0) return;
            if (e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.ItemAdded)
            {
                if (_set == null && _query != null)
                {
                    Refresh();
                }

                if (_sortProp != null && Equals(e.PropertyDescriptor, _sortProp))
                {
                    ApplySortCore(_sortProp, _sortDir);
                }
            }
        }

        /// <summary>
        /// Добавляет новый элемент в конец коллекции.
        /// </summary>
        /// <returns>Элемент, добавленный в коллекцию.</returns>
        protected override object AddNewCore()
        {
            var newObject = base.AddNewCore() as T;

            if (_set != null)
            {
                if (newObject != null) _set.Add(newObject);
            }
            else
            {
                _coll?.Add(newObject);
            }

            return newObject;
        }

        /// <summary>
        /// Удаляет элемент по указанному индексу.
        /// </summary>
        /// <param name="index">индекс элемента для удаления.</param>
        protected override void RemoveItem(int index)
        {
            if (index > -1)
            {
                var item = this[index];

                if (_set != null)
                {
                    _set.Remove(item);

                    var ent = item as EntityObject;
                    if (ent != null)
                    {
                        Debug.Assert(
                            ent.EntityState == EntityState.Deleted ||
                            ent.EntityState == EntityState.Detached
                        );
                    }
                }
                else
                {
                    _coll?.Remove(item);
                }
            }

            base.RemoveItem(index);
        }

        /// <summary>
        /// Разрешить добавлять новые, только если у нас есть набор.
        /// </summary>
        bool IBindingList.AllowNew => _set != null || _coll != null;

        /// <summary>
        /// 
        /// </summary>
        bool IBindingList.AllowRemove => _set != null || _coll != null;

        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            // BindingList<T> возможно ошибка: EndNew вызывается дважды вместо одного раза
            _addingNew = 2;
            base.OnAddingNew(e);
        }
        public override void CancelNew(int itemIndex)
        {
            base.CancelNew(itemIndex);
            if (itemIndex > -1)
            {
                _addingNew--;
            }
        }
        public override void EndNew(int itemIndex)
        {
            base.EndNew(itemIndex);
            if (itemIndex <= -1) return;
            _addingNew--;
            if (_addingNew == 0 && _sortProp != null)
            {
                ApplySortCore(_sortProp, _sortDir);
            }
        }

        #endregion

        //----------------------------------------------------------------------------
        #region  Sorting 

        /// <summary>
        /// Возвращает значение, указывающее, поддерживает ли этот список сортировку.
        /// </summary>
        protected override bool SupportsSortingCore => true;

        /// <summary>
        /// Получает <see cref="PropertyDescriptor"/> ,который используется для сортировки списка.
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore => _sortProp;

        /// <summary>
        /// Получает <see cref="ListSortDirection"/> ,который используется для сортировки списка.
        /// </summary>
        protected override ListSortDirection SortDirectionCore => _sortDir;

        /// <summary>
        /// Возвращает значение, показывающее, отсортирован ли список.
        /// </summary>
        protected override bool IsSortedCore => _sortProp != null;

        /// <summary>
        /// Удаляет все сортировки, которые в настоящее время применяются к списку.
        /// </summary>
        protected override void RemoveSortCore()
        {
            _sortProp = null;
            Refresh();
        }

        /// <summary>
        /// Сортирует элементы в списке.
        /// </summary>
        /// <param name="prop"><see cref="PropertyDescriptor"/> свойство для сортировки.</param>
        /// <param name="direction"><see cref="ListSortDirection"/> направление сортировки.</param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var items = this.Items as List<T>;
            if (items != null)
            {
                ListDictionary map = null;
                if (DataSource != null && !prop.PropertyType.IsPrimitive) 
                {
                    map = DataSource.GetLookupDictionary(prop.PropertyType);
                }

                var pc = new PropertyComparer<T>(prop, direction, map);
                items.Sort(pc);
            }

            _sortProp = prop;
            _sortDir = direction;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private class PropertyComparer<TC> : IComparer<TC>
        {
            private readonly PropertyDescriptor _pd;
            private readonly ListSortDirection _direction;
            private readonly ListDictionary _map;

            public PropertyComparer(PropertyDescriptor pd, ListSortDirection direction, ListDictionary map)
            {
                _pd = pd;
                _direction = direction;
                _map = map;
            }
            public int Compare(TC x, TC y)
            {
                try
                {
                    var o1 = _pd.GetValue(x);
                    var o2 = _pd.GetValue(y);

                    if (_map != null)
                    {
                        o1 = _map[o1.ToString()];
                        o2 = _map[o2.ToString()];
                    }

                    var v1 = o1 as IComparable;
                    var v2 = o2 as IComparable;

                    int cmp =
                        v1 == null && v2 == null ? 0 :
                            v1 == null ? +1 :
                                v2 == null ? -1 :
                                    v1.CompareTo(v2);

                    return _direction == ListSortDirection.Ascending ? +cmp : -cmp;
                }
                catch
                {
                    Debug.Assert(false, "comparison failed?");
                    return 0; // comparison failed...
                }
            }
        }

        #endregion

        #region  ITypedList Implements

        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            var list = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(T)))
            {
                if (pd.ComponentType == typeof(EntityObject))
                {
                    continue;
                }

                var type = pd.PropertyType;
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    list.Add(new CollectionPropertyDescriptor(DataSource, pd));
                    continue;
                }
                
                list.Add(pd);
            }
            return new PropertyDescriptorCollection(list.ToArray());
        }

        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return _name;
        }

        #endregion
        
        #region  IBindingListView Implements

        private string _filter;
        private DataTable _dtFilter;
        void IBindingListView.ApplySort(ListSortDescriptionCollection sorts)
        {
            throw new NotImplementedException();
        }
        string IBindingListView.Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                UpdateFilterTable();
                Refresh();
            }
        }
        void IBindingListView.RemoveFilter()
        {
            _filter = null;
            Refresh();
        }
        ListSortDescriptionCollection IBindingListView.SortDescriptions => null;

        bool IBindingListView.SupportsAdvancedSorting => false;

        bool IBindingListView.SupportsFiltering => true;

        private bool ApplyFilter(T item)
        {
            bool pass = true;
            if (_dtFilter == null) return true;
            try
            {
                var row = _dtFilter.Rows[0];
                foreach (var pi in typeof(T).GetProperties())
                {
                    row[pi.Name] = pi.GetValue(item, null);
                }
                
                pass = (bool)row["_filter"];
            }
            catch
            {
                // ignored
            }
            return pass;
        }

        private void UpdateFilterTable()
        {
            _dtFilter = null;
            if (string.IsNullOrEmpty(_filter)) return;

            var dt = new DataTable();
            foreach (var pi in typeof(T).GetProperties())
            {
                var type = pi.PropertyType;
                var nt = Nullable.GetUnderlyingType(type);
                if (nt != null)
                {
                    type = nt;
                }
                dt.Columns.Add(pi.Name, type);
            }

            dt.Columns.Add("_filter", typeof(bool), _filter);

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }

            _dtFilter = dt;
        }

        #endregion
    }


    /// <summary>
    /// Дескриптор свойства, который преобразует свойства EntityCollection <T/> в
    /// свойства объекта EntityBindingList.
    /// </summary>
    internal class CollectionPropertyDescriptor : PropertyDescriptor
    {
        private readonly EntityDataSource _ds;
        private readonly PropertyDescriptor _pd;
        private readonly Type _listType;

        public CollectionPropertyDescriptor(EntityDataSource ds, PropertyDescriptor pd) : base(pd.Name, null)
        {
            _ds = ds;
            _pd = pd;
            var elementType = _pd.PropertyType.GetGenericArguments()[0];
            _listType = typeof(EntityBindingList<>);
            _listType = _listType.MakeGenericType(elementType);
        }
        public override string Name => _pd.Name;

        public override bool IsReadOnly => _pd.IsReadOnly;

        public override void ResetValue(object component)
        {
            _pd.ResetValue(component);
        }

        public override bool CanResetValue(object component)
        {
            return _pd.CanResetValue(component);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return _pd.ShouldSerializeValue(component);
        }

        public override Type ComponentType => _pd.ComponentType;

        public override Type PropertyType => _listType;

        public override object GetValue(object component)
        {
            return Activator.CreateInstance(_listType, _ds, (IEnumerable)_pd.GetValue(component), Name);
        }
        public override void SetValue(object component, object value)
        {
            _pd.SetValue(component, value);
            OnValueChanged(component, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Расширяет IBindingListView со свойствами и методами относительно набора объектов.
    /// </summary>
    public interface IEntityBindingList : IBindingListView
    {
        EntityDataSource DataSource { get; }
        Type ElementType { get; }
        void Refresh();
    }


}
