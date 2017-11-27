﻿using System;
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
    /// Exposes an DbSet in the current DbContext as a bindable data source.
    /// </summary>
    /// <remarks>
    /// This class implements the IListSource interface and returns an IBindingList 
    /// built on top of the underlying DbSet.
    /// </remarks>
    public class EntitySet : IListSource, IQueryable
    {
        private IQueryable _query;          // the value of the property
        private IEntityBindingList _list;   // default view for this set
        private readonly PropertyInfo _pi;           // the property on the object context that gets the objects in this set
        private ListDictionary _dctLookup;  // lookup dictionary (used to show and edit related entities in grid cells)

        /// <summary>
        /// Initializes a new instance of a <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="ds"><see cref="EntityDataSource"/> that owns the entities.</param>
        /// <param name="pi"><see cref="PropertyInfo"/> used to retrieve the set from the context.</param>
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
        /// Gets the <see cref="EntityDataSource"/> that owns this entity set.
        /// </summary>
        public EntityDataSource DataSource { get; }

        /// <summary>
        /// Gets the name of this entity set.
        /// </summary>
        public string Name => _pi?.Name;

        /// <summary>
        /// Gets the type of entity in this entity set.
        /// </summary>
        /// <remarks>
        /// Name chosen for consistency with EntitySet.ElementType 
        /// (EntityType would seem more appropriate).
        /// </remarks>
        public Type ElementType { get; }

        /// <summary>
        /// Gets the <see cref="IQueryable"/> object that retrieves the entities in this set.
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
        /// Gets a list of the entities in the set that have not been deleted or detached.
        /// </summary>
        public IEnumerable ActiveEntities => GetActiveEntities(Query);

        /// <summary>
        /// Gets a list of the entities in the set that have not been deleted or detached.
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
        /// Cancels any pending changes on this entity set.
        /// </summary>
        internal void CancelChanges()
        {
            if (_list == null || Query == null) return;
            var ctx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)DataSource.DbContext).ObjectContext;
            ctx.Refresh(RefreshMode.StoreWins, Query);
            _list.Refresh();
        }
        /// <summary>
        /// Refreshes this set's view by re-loading from the database.
        /// </summary>
        public void RefreshView()
        {
            if (_list == null || Query == null) return;
            var ctx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)DataSource.DbContext).ObjectContext;
            ctx.Refresh(RefreshMode.ClientWins, Query);
            _list.Refresh();
        }
        /// <summary>
        /// Gets an <see cref="IBindingListView"/> that can be used as a data source for bound controls.
        /// </summary>
        public IBindingListView List => GetBindingList();

        /// <summary>
        /// Gets a dictionary containing entities as keys and their string representation as values.
        /// </summary>
        /// <remarks>
        /// The data map is useful for displaying and editing entities in grid cells.
        /// </remarks>
        public ListDictionary LookupDictionary => _dctLookup ?? (_dctLookup = BuildLookupDictionary());

        #endregion

        //-------------------------------------------------------------------------
        #region IListSource Implements

        bool IListSource.ContainsListCollection => false;

        IList IListSource.GetList()
        {
            return GetBindingList();
        }

        // gets an IBindingListView for this entity set
        private IBindingListView GetBindingList()
        {
            if (_list != null) return _list;
            // create the list
            var listType = typeof(EntityBindingList<>);
            listType = listType.MakeGenericType(ElementType);
            _list = (IEntityBindingList)Activator.CreateInstance(listType, DataSource, Query, Guid.NewGuid().ToString());// this.Name);

            // and listen to changes in the new list
            _list.ListChanged += _list_ListChanged;
            return _list;
        }

        // update data map when list changes
        private void _list_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (_dctLookup == null) return;
            // clear old dictionary
            _dctLookup.Clear();

            // build new dictionary
            var map = BuildLookupDictionary(_list);
            foreach (var kvp in map)
            {
                _dctLookup.Add(kvp.Key, kvp.Value);
            }
        }

        // build a data map for this entity set
        private ListDictionary BuildLookupDictionary()
        {
            return BuildLookupDictionary(ActiveEntities);
        }

        private ListDictionary BuildLookupDictionary(IEnumerable entities)
        {
            // if the entity implements "ToString", then use it
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

            // use "DefaultProperty"
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

            // no default property: look for properties of type string with 
            // names that contain "Name" or "Description"
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
    /// Collection of EntitySet objects.
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
    /// Dictionary that implements IListSource (used for implementing lookup dictionaries)
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
