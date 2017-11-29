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
    /// <summary>
    /// Компонент DataSource, который инкапсулирует EntityFramework DbContext
    /// </summary>
    /// <remarks>
    /// Для целей привязки компонент EntityDataSource соответствует DataSet и
    /// EntitySets соответствуют содержащимся таблицам данных.
    /// </remarks>
    public partial class EntityDataSource : Component, IListSource, IExtenderProvider
    {
        private DbContext _ctx;
        private readonly EntitySetCollection _entSets = new EntitySetCollection();
        private Type _ctxType;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EntityDataSource"/>.
        /// </summary>
        public EntityDataSource()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EntityDataSource"/>.
        /// </summary>
        public EntityDataSource(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Object model

        /// <summary>
        /// Получает или задает тип DbContext для использования в качестве источника данных.
        /// </summary>
        /// <remarks>
        /// Это свойство можно установить во время разработки. 
        /// Как только оно будет установлено,
        /// компонент автоматически создаст DbContext соответствующего типа.
        /// </remarks>
        [TypeConverter(typeof(DbContextTypeConverter))]
        public Type DbContextType
        {
            get => _ctxType;
            set
            {
                if (_ctxType == value) return;
                OnDbContextTypeChanging(EventArgs.Empty);
                _ctx = null;
                _ctxType = value;
                GenerateEntitySets(_ctxType);

                OnDbContextTypeChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NameOrConnectionString { get; set; }

        /// <summary>
        /// Получает или задает DbContext, используемый в качестве источника данных.
        /// </summary>
        [Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DbContext DbContext
        {
            get
            {
                if (_ctx != null || _ctxType == null || DesignMode) return _ctx;
                try
                {
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
                GenerateEntitySets(_ctxType);

                OnDbContextChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Получает набор EntitySet, доступных в этом EntityDataSource.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EntitySetCollection EntitySets => _entSets;

        /// <summary>
        /// Сохраняет все изменения, внесенные во все наборы объектов обратно в базу данных.
        /// </summary>
        public int SaveChanges()
        {
            var e = new CancelEventArgs();
            OnSavingChanges(e);

            int count = 0;
            if (e.Cancel) return count;
            try
            {
                count = _ctx.SaveChanges();
                Debug.WriteLine($"Сохранено {count} записей.");

                OnSavedChanges(e);
            }
            catch (Exception x)
            {
                OnDataError(new DataErrorEventArgs(x));
            }

            return count;
        }

        /// <summary>
        /// Отменяет все изменения, внесенные во все наборы объектов.
        /// </summary>
        public void CancelChanges()
        {
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
                }
                catch (Exception x)
                {
                    OnDataError(new DataErrorEventArgs(x));
                }

                OnCanceledChanges(EventArgs.Empty);
            }
            Debug.WriteLine("Все изменения отменены.");
        }

        /// <summary>
        /// Обновляет все представления, загружая их данные из базы данных.
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
        /// Получает словарь поиска для определенного типа элемента.
        /// </summary>
        /// <param name="elementType">Тип элемента для возврата словаря поиска.</param>
        /// <returns>Словарь поиска для данного типа элемента.</returns>
        /// <remarks>
        /// <para>Словарь поиска содержит ключи, соответствующие элементам в списке и
        /// значения, которые содержат строковое представление элементов.</para>
        /// <para>Когда списки объектов сортируются по столбцу, содержащему ссылки на сущности, 
        /// словарь поиска используется для предоставления порядка сортировки. 
        /// Например, если вы сортируете список продуктов по категориям, карта данных, связанная со списком
        /// категорий, определяет порядок сравнения категорий при сортировке.</para>
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
        /// Создает IBindingList на основе заданного запроса.
        /// </summary>
        /// <param name="query"><see cref="IEnumerable"/> используется как источник данных для списка.</param>
        /// <returns>Возвращает <see cref="IBindingList"/> который обеспечивает сортируемое / фильтруемое представление данных.</returns>
        public IBindingList CreateView(IEnumerable query)
        {
            var type = typeof(object);
            foreach (var item in query)
            {
                type = item.GetType();
                break;
            }
            var listType = typeof(EntityBindingList<>);
            listType = listType.MakeGenericType(type);
            var list = (IEntityBindingList)Activator.CreateInstance(listType, this, query, type.Name);
            return list;
        }

        /// <summary>
        /// Возвращает значение, определяющее, находится ли компонент в режиме разработки.
        /// </summary>
        protected internal new bool DesignMode => base.DesignMode;

        #endregion

        /// <summary>
        /// Заполняет коллекцию EntitySets из текущего домена DomainContext
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
        /// Возникает до изменения  <see cref="DbContextType"/>
        /// </summary>
        public event EventHandler DbContextTypeChanging;

        /// <summary>
        /// Вызывает <see cref="DbContextTypeChanging"/> событие.
        /// </summary>
        protected virtual void OnDbContextTypeChanging(EventArgs e)
        {
            DbContextTypeChanging?.Invoke(this, e);
        }

        /// <summary>
        /// Возникает после изменения <see cref="DbContextType"/>
        /// </summary>
        public event EventHandler DbContextTypeChanged;

        /// <summary>
        /// Вызывает <see cref="DbContextTypeChanged"/> событие
        /// </summary>
        protected virtual void OnDbContextTypeChanged(EventArgs e)
        {
            DbContextTypeChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Возникает до изменения  <see cref="DbContext"/>
        /// </summary>
        public event EventHandler DbContextChanging;

        /// <summary>
        /// Вызывает <see cref="DbContextChanging"/> событие
        /// </summary>
        protected virtual void OnDbContextChanging(EventArgs e)
        {
            DbContextChanging?.Invoke(this, e);
        }

        /// <summary>
        /// Возникает после изменения <see cref="DbContext"/>
        /// </summary>
        public event EventHandler DbContextChanged;

        /// <summary>
        /// Вызывает <see cref="DbContextChanged"/> событие.
        /// </summary>
        protected virtual void OnDbContextChanged(EventArgs e)
        {
            DbContextChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Происходит до того, как изменения будут сохранены в базе данных.
        /// </summary>
        public event CancelEventHandler SavingChanges;

        /// <summary>
        /// Вызывает <see cref="SavingChanges"/> событие.
        /// </summary>
        protected virtual void OnSavingChanges(CancelEventArgs e)
        {
            SavingChanges?.Invoke(this, e);
        }

        /// <summary>
        /// Происходит после сохранения изменений в базе данных.
        /// </summary>
        public event EventHandler SavedChanges;

        /// <summary>
        /// Вызывает <see cref="SavedChanges"/> событие.
        /// </summary>
        protected virtual void OnSavedChanges(EventArgs e)
        {
            SavedChanges?.Invoke(this, e);
        }

        /// <summary>
        /// Возникает до отмены изменений, а значения перезагружаются из базы данных.
        /// </summary>
        public event CancelEventHandler CancelingChanges;

        /// <summary>
        /// Вызов <see cref="CancelingChanges"/> события.
        /// </summary>
        protected virtual void OnCancelingChanges(CancelEventArgs e)
        {
            CancelingChanges?.Invoke(this, e);
        }

        /// <summary>
        /// Происходит после отмены изменений и перезагрузки значений из базы данных.
        /// </summary>
        public event EventHandler CanceledChanges;

        /// <summary>
        /// Вызывает <see cref="CanceledChanges"/> событие.
        /// </summary>
        protected virtual void OnCanceledChanges(EventArgs e)
        {
            CanceledChanges?.Invoke(this, e);
        }

        /// <summary>
        /// Происходит до того, как значения обновляются из базы данных.
        /// </summary>
        public event CancelEventHandler Refreshing;

        /// <summary>
        /// Вызов <see cref="Refreshing"/> события.
        /// </summary>
        protected virtual void OnRefreshing(CancelEventArgs e)
        {
            Refreshing?.Invoke(this, e);
        }

        /// <summary>
        /// Происходит после обновления значений из базы данных.
        /// </summary>
        public event EventHandler Refreshed;

        /// <summary>
        /// Вызов <see cref="Refreshed"/> события.
        /// </summary>
        protected virtual void OnRefreshed(EventArgs e)
        {
            Refreshed?.Invoke(this, e);
        }

        /// <summary>
        /// Происходит при обнаружении ошибки при загрузке данных или сохранении данных в базу данных.
        /// </summary>
        public event EventHandler<DataErrorEventArgs> DataError;

        /// <summary>
        /// Вызов <see cref="DataError"/> события.
        /// </summary>
        protected virtual void OnDataError(DataErrorEventArgs e)
        {
            DataError?.Invoke(this, e);
            if (!e.Handled)
            {
                throw e.Exception;
            }
        }

        #endregion

        #region IListSource Implements

        bool IListSource.ContainsListCollection => true;

        IList IListSource.GetList()
        {
            var list = new List<EntitySetTypeDescriptor> {new EntitySetTypeDescriptor(this)};
            return list;
        }

        #endregion

        #region  IExtenderProvider Implements

        /// <summary>
        ///  Можно расширить элемент управления DataGridView.
        /// </summary>
        /// <param name="extendee"></param>
        /// <returns></returns>
        bool IExtenderProvider.CanExtend(object extendee)
        {
            if (!(extendee is Control)) return false;
            for (var type = extendee.GetType(); type != null; type = type.BaseType)
            {
                if (type == typeof(DataGridView))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Установка карты данных для столбцов элемента управления DataGridView.</summary>
        /// 
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
        /// Возвращает значение, определяющее, включены ли карты данных для данного элемента управления DataGridView
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), DefaultValue(false)]
        public bool GetAutoLookup(Control grid)
        {
            return _autoLookup.ContainsKey(grid);
        }

        private readonly Dictionary<Control, bool> _autoLookup = new Dictionary<Control, bool>();

        private static void EnableAutoLookup(Control control, bool map)
        {
            var ctlType = control.GetType();
            var dsChanged = ctlType.GetEvent("DataSourceChanged");
            var dmChanged = ctlType.GetEvent("DataMemberChanged");
            var bcChanged = ctlType.GetEvent("BindingContextChanged");

            if (dsChanged == null || dmChanged == null || bcChanged == null)
            {
                throw new Exception("Невозможно подключить обработчики событий для этого элемента управления.");
            }

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

        private static void CustomizeGrid(IDisposable ctl)
        {
            dynamic grid = ctl;
            if (grid.DataSource == null || grid.BindingContext == null) return;
            CurrencyManager cm = null;
            try
            {
                cm = grid.BindingContext[grid.DataSource, grid.DataMember] as CurrencyManager;
            }
            catch
            {
                // ignored
            }

            var list = cm?.List as IEntityBindingList;

            if (cm != null && (list == null && cm.List is BindingSource))
            {
                list = ((BindingSource)(cm.List)).List as IEntityBindingList;
            }

            if (list?.DataSource == null) return;
            var entType = list.ElementType;
            var entDataSource = list.DataSource;
            
            var dgv = ctl as DataGridView;
            if (dgv != null)
            {
                CustomizeDataGridView(dgv, entType, entDataSource);
            }
        }

        private static void CustomizeDataGridView(DataGridView dgv, Type entType, EntityDataSource entDataSource)
        {

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
        public DataErrorEventArgs(Exception x)
        {
            Exception = x;
        }

        public Exception Exception { get; set; }
        public bool Handled { get; set; }
    }

}
