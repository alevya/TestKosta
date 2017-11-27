using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Diagnostics;
using System.Windows.Forms;

namespace TestDbApp.EntityFrameworkBinding
{
    public partial class EntityDataSource : Component, IListSource, IExtenderProvider
    {
        private DbContext _ctx;
        private readonly EntitySetCollection _entSets = new EntitySetCollection();
        private Type _ctxType; // to support design-time

        public EntityDataSource()
        {
            InitializeComponent();
        }

        public EntityDataSource(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Object model

        /// <summary>
        /// Gets or sets the type of DbContext to use as a data source.
        /// </summary>
        /// <remarks>
        /// This property is normally set at design time. Once it is set, the 
        /// component will automatically create an DbContext of the appropriate type.
        /// </remarks>
        [TypeConverter(typeof(DbContextTypeConverter))]
        public Type DbContextType
        {
            get => _ctxType;
            set
            {
                if (value == _ctxType) return;
                OnDbContextTypeChanging(EventArgs.Empty);
                _ctx = null;
                _ctxType = value;

                // generate object sets (will re-create object context if appropriate)
                GenerateEntitySets(_ctxType);

                OnDbContextTypeChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NameOrConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the DbContext used as a data source.
        /// </summary>
        [Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DbContext DbContext
        {
            get
            {
                if (_ctx != null || _ctxType == null || DesignMode) return _ctx;
                try
                {
                    //DbContext = Activator.CreateInstance(_ctxType) as DbContext;
                    DbContext = Activator.CreateInstance(_ctxType, NameOrConnectionString) as DbContext;
                }
                catch
                {
                    // ignored
                }
                return _ctx;
            }
            set
            {
                if (Equals(_ctx, value)) return;
               
                OnDbContextChanging(EventArgs.Empty);

                _ctx = value;
                _ctxType = _ctx?.GetType();
                // generate object sets
                GenerateEntitySets(_ctxType);

                OnDbContextChanged(EventArgs.Empty);
            }
        }
        /// <summary>
        /// Gets the collection of EntitySets available in this EntityDataSource.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EntitySetCollection EntitySets => _entSets;

        /// <summary>
        /// Saves all changes made to all entity sets back to the database.
        /// </summary>
        public int SaveChanges()
        {
            var e = new CancelEventArgs();
            OnSavingChanges(e);

            // save the changes
            int count = 0;
            if (e.Cancel) return count;
            try
            {
                count = _ctx.SaveChanges();
                Debug.WriteLine($"Done. {count} changes saved.");

                OnSavedChanges(e);
            }
            catch (Exception x)
            {
                OnDataError(new DataErrorEventArgs(x));
            }

            return count;
        }

        /// <summary>
        /// Cancels all changes made to all entity sets.
        /// </summary>
        public void CancelChanges()
        {
            // notify
            var e = new CancelEventArgs();
            OnCancelingChanges(e);

            if (_ctx != null && !e.Cancel)
            {
                try
                {
                    foreach (var entSet in EntitySets)
                    {
                        entSet.CancelChanges();
                    }
                    //_ctx.AcceptAllChanges();
                }
                catch (Exception x)
                {
                    OnDataError(new DataErrorEventArgs(x));
                }

                OnCanceledChanges(EventArgs.Empty);
            }
            Debug.WriteLine("Done. All changes canceled.");
        }

        /// <summary>
        /// Refreshes all views by loading their data from the database.
        /// </summary>
        public void Refresh()
        {
            var e = new CancelEventArgs();
            OnRefreshing(e);

            if (e.Cancel) return;
            try
            {
                foreach (var entSet in EntitySets)
                {
                    entSet.RefreshView();
                }
            }
            catch (Exception x)
            {
                OnDataError(new DataErrorEventArgs(x));
            }

            OnRefreshed(EventArgs.Empty);
            Debug.WriteLine("Done. All views refreshed.");
        }

        /// <summary>
        /// Gets a lookup dictionary for a given element type.
        /// </summary>
        /// <param name="elementType">Type of element for which to return a lookup dictionary.</param>
        /// <returns>A lookup dictionary for a given element type.</returns>
        /// <remarks>
        /// <para>The lookup dictionary has keys that correspond to the items on a list and
        /// values that contain a string representation of the items.</para>
        /// <para>When lists of entities are sorted on a column that contains entity references, 
        /// the lookup dictionary is used to provide the sorting order. For example, if you sort a 
        /// list of products by category, the data map associated with the Categories list determines 
        /// the order in which the categories are compared while sorting.</para>
        /// </remarks>
        public ListDictionary GetLookupDictionary(Type elementType)
        {
            foreach (var es in EntitySets)
            {
                if (es.ElementType == elementType)
                {
                    return es.LookupDictionary;
                }
            }
            return null;
        }

        /// <summary>
        /// Creates an IBindingList based on a given query.
        /// </summary>
        /// <param name="query"><see cref="IEnumerable"/> used as a data source for the list.</param>
        /// <returns>An <see cref="IBindingList"/> that provides a sortable/filterable view of the data.</returns>
        public IBindingList CreateView(IEnumerable query)
        {
            // get the query type
            var type = typeof(object);
            foreach (var item in query)
            {
                type = item.GetType();
                break;
            }

            // create the binding list
            var listType = typeof(EntityBindingList<>);
            listType = listType.MakeGenericType(type);
            var list = (IEntityBindingList)Activator.CreateInstance(listType, this, query, type.Name);
            return list;
        }
        /// <summary>
        /// Gets a value that determines whether the component is in design mode.
        /// </summary>
        protected internal new bool DesignMode => base.DesignMode;

        #endregion

        /// <summary>
        /// Populates the EntitySets collection from the current DomainContext.
        /// </summary>
        private void GenerateEntitySets(Type ctxType)
        {
            _entSets.Clear();
            if (ctxType == null) return;
            foreach (var pi in ctxType.GetProperties())
            {
                var type = pi.PropertyType;
                if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(DbSet<>) ||
                    type.GetGenericArguments().Length != 1) continue;

                var objSet = new EntitySet(this, pi);
                _entSets.Add(objSet);
            }
        }

        //-------------------------------------------------------------------------
        #region Events

        /// <summary>
        /// Occurs before the value of the <see cref="DbContextType"/> property changes.
        /// </summary>
        public event EventHandler DbContextTypeChanging;

        /// <summary>
        /// Raises the <see cref="DbContextTypeChanging"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        protected virtual void OnDbContextTypeChanging(EventArgs e)
        {
            DbContextTypeChanging?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs after the value of the <see cref="DbContextType"/> property changes.
        /// </summary>
        public event EventHandler DbContextTypeChanged;

        /// <summary>
        /// Raises the <see cref="DbContextTypeChanged"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        protected virtual void OnDbContextTypeChanged(EventArgs e)
        {
            DbContextTypeChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs before the value of the <see cref="DbContext"/> property changes.
        /// </summary>
        public event EventHandler DbContextChanging;

        /// <summary>
        /// Raises the <see cref="DbContextChanging"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        protected virtual void OnDbContextChanging(EventArgs e)
        {
            DbContextChanging?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs after the value of the <see cref="DbContext"/> property changes.
        /// </summary>
        public event EventHandler DbContextChanged;

        /// <summary>
        /// Raises the <see cref="DbContextChanged"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        protected virtual void OnDbContextChanged(EventArgs e)
        {
            DbContextChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs before changes are saved to the database.
        /// </summary>
        public event CancelEventHandler SavingChanges;

        /// <summary>
        /// Raises the <see cref="SavingChanges"/> event.
        /// </summary>
        /// <param name="e"><see cref="CancelEventArgs"/> that contains the event parameters.</param>
        protected virtual void OnSavingChanges(CancelEventArgs e)
        {
            SavingChanges?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs after changes are saved to the database.
        /// </summary>
        public event EventHandler SavedChanges;

        /// <summary>
        /// Raises the <see cref="SavedChanges"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        protected virtual void OnSavedChanges(EventArgs e)
        {
            SavedChanges?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs before changes are canceled and values are reloaded from the database.
        /// </summary>
        public event CancelEventHandler CancelingChanges;
        /// <summary>
        /// Raises the <see cref="CancelingChanges"/> event.
        /// </summary>
        /// <param name="e"><see cref="CancelEventArgs"/> that contains the event parameters.</param>
        /// 
        protected virtual void OnCancelingChanges(CancelEventArgs e)
        {
            CancelingChanges?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs after changes are canceled and values are reloaded from the database.
        /// </summary>
        public event EventHandler CanceledChanges;

        /// <summary>
        /// Raises the <see cref="CanceledChanges"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        protected virtual void OnCanceledChanges(EventArgs e)
        {
            CanceledChanges?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs before values are refreshed from the database.
        /// </summary>
        public event CancelEventHandler Refreshing;

        /// <summary>
        /// Raises the <see cref="Refreshing"/> event.
        /// </summary>
        /// <param name="e"><see cref="CancelEventArgs"/> that contains the event parameters.</param>
        protected virtual void OnRefreshing(CancelEventArgs e)
        {
            Refreshing?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs after values are refreshed from the database.
        /// </summary>
        public event EventHandler Refreshed;

        /// <summary>
        /// Raises the <see cref="Refreshed"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        protected virtual void OnRefreshed(EventArgs e)
        {
            Refreshed?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when an error is detected while loading data from or saving data to the database.
        /// </summary>
        public event EventHandler<DataErrorEventArgs> DataError;

        /// <summary>
        /// Raises the <see cref="DataError"/> event.
        /// </summary>
        /// <param name="e"><see cref="DataErrorEventArgs"/> that contains the event parameters.</param>
        protected virtual void OnDataError(DataErrorEventArgs e)
        {
            DataError?.Invoke(this, e);
            if (!e.Handled)
            {
                throw e.Exception;
            }
        }

        #endregion

        //-------------------------------------------------------------------------
        #region IListSource Implements

        bool IListSource.ContainsListCollection => true;

        IList IListSource.GetList()
        {
            var list = new List<EntitySetTypeDescriptor> {new EntitySetTypeDescriptor(this)};
            return list;
        }

        #endregion

        //-------------------------------------------------------------------------
        #region  IExtenderProvider Implements

        /// <summary>
        /// We can extend DataGridView control.
        /// </summary>
        /// <param name="extendee"></param>
        /// <returns></returns>
        bool IExtenderProvider.CanExtend(object extendee)
        {
            if (!(extendee is Control)) return false;
            for (var type = extendee.GetType(); type != null; type = type.BaseType)
            {
                // DataGridView
                if (type == typeof(DataGridView))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Add or remove automatic data maps for the columns on a DataGridView control.
        /// </summary>
        /// <param name="grid">DataGridView control.</param>
        /// <param name="autoLookups">Whether to enable or disable automatic data maps for the columns on the <paramref name="grid"/> control.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAutoLookup(Control grid, bool autoLookups)
        {
            var oldAutoLookups = _autoLookup.ContainsKey(grid);
            if (oldAutoLookups == autoLookups) return;
            if (autoLookups)
            {
                _autoLookup.Add(grid, true);
            }
            else
            {
                _autoLookup.Remove(grid);
            }
            if (!DesignMode)
            {
                EnableAutoLookup(grid, autoLookups);
            }
        }

        /// <summary>
        /// Gets a value that determines whether automatic data maps are enabled for a given DataGridView control.
        /// </summary>
        /// <param name="grid">DataGridView control.</param>
        /// <returns>Whether automatic data maps are is enabled for the columns on the <paramref name="grid"/> control.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), DefaultValue(false)]
        public bool GetAutoLookup(Control grid)
        {
            return _autoLookup.ContainsKey(grid);
        }

        // enabled/disable automatic data maps for a control
        private readonly Dictionary<Control, bool> _autoLookup = new Dictionary<Control, bool>();

        private static void EnableAutoLookup(Control control, bool map)
        {
            // get event handlers
            var ctlType = control.GetType();
            var dsChanged = ctlType.GetEvent("DataSourceChanged");
            var dmChanged = ctlType.GetEvent("DataMemberChanged");
            var bcChanged = ctlType.GetEvent("BindingContextChanged");

            // sanity
            if (dsChanged == null || dmChanged == null || bcChanged == null)
            {
                throw new Exception("Cannot connect event handlers for this control.");
            }

            // connect/disconnect event handlers
            var handler = new EventHandler(control_DataSourceChanged);
            if (map)
            {
                dsChanged.AddEventHandler(control, handler);
                dmChanged.AddEventHandler(control, handler);
                bcChanged.AddEventHandler(control, handler);
            }
            else
            {
                dsChanged.RemoveEventHandler(control, handler);
                dmChanged.RemoveEventHandler(control, handler);
                bcChanged.RemoveEventHandler(control, handler);
            }
        }

        private static void control_DataSourceChanged(object sender, EventArgs e)
        {
            CustomizeGrid(sender as Control);
        }

        // customize the columns of a DataGridView control 
        private static void CustomizeGrid(IDisposable ctl)
        {
            dynamic grid = ctl;
            if (grid.DataSource == null || grid.BindingContext == null) return;
            // get currency manager
            CurrencyManager cm = null;
            try
            {
                cm = grid.BindingContext[grid.DataSource, grid.DataMember] as CurrencyManager;
            }
            catch { }

            // get source list from currency manager bound directly to EntityDataSource
            var list = cm?.List as IEntityBindingList;

            // if failed, try binding via BindingSource component
            if (cm != null && (list == null && cm.List is BindingSource))
            {
                list = ((BindingSource)(cm.List)).List as IEntityBindingList;
            }

            // customize the columns
            if (list?.DataSource == null) return;
            var entType = list.ElementType;
            var entDataSource = list.DataSource;

            // customize grid columns
            var dgv = ctl as DataGridView;
            if (dgv != null)
            {
                // customize DataGridView
                CustomizeDataGridView(dgv, entType, entDataSource);
            }
        }

        // customize the columns of a DataGridView
        private static void CustomizeDataGridView(DataGridView dgv, Type entType, EntityDataSource entDataSource)
        {
            // configure columns
            for (int colIndex = 0; colIndex < dgv.Columns.Count; colIndex++)
            {
                var c = dgv.Columns[colIndex];

                var pi = entType.GetProperty(c.DataPropertyName);
                if (pi == null) continue;
                var atts = pi.GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false);
                if (atts.Length > 0)
                {
                    var att = atts[0] as EdmScalarPropertyAttribute;
                    if (att != null && att.EntityKeyProperty)
                    {
                        c.ReadOnly = true;
                    }
                }

                var type = pi.PropertyType;
                if (type.IsPrimitive) continue;
                var map = entDataSource.GetLookupDictionary(type);
                if (map == null) continue;
                var col = new DataGridViewComboBoxColumn
                          {
                              HeaderText = c.HeaderText,
                              DataPropertyName = c.DataPropertyName,
                              Width = c.Width,
                              DefaultCellStyle = c.DefaultCellStyle,
                              DataSource = map,
                              ValueMember = "Key",
                              DisplayMember = "Value"
                          };
                dgv.Columns.RemoveAt(colIndex);
                dgv.Columns.Insert(colIndex, col);
            }
        }

        #endregion
    }

    public class DataErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="DataErrorEventArgs"/>.
        /// </summary>
        /// <param name="x"><see cref="Exception"/> that triggered the event.</param>
        public DataErrorEventArgs(Exception x)
        {
            Exception = x;
        }

        /// <summary>
        /// Gets or sets the <see cref="Exception"/> that triggered the event.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Whether the error was handled and the source exception should be ignored.
        /// </summary>
        public bool Handled { get; set; }
    }

}
