using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TestDbApp.EntityFrameworkBinding
{
    public partial class EntityBindingNavigator : ToolStrip
    {
        private object _dataSource;
        private string _dataMember = string.Empty;
        private CurrencyManager _cm;
        private bool _showBtnNav, _showBtnAdd, _showBtnSave;

        private ToolStripButton _btnFirst, _btnPrev, _btnNext, _btnLast;
        private ToolStripLabel _lblCurrent;
        private ToolStripButton _btnSave, _btnUndo, _btnRefresh;
        private ToolStripButton _btnAdd, _btnRemove;
        private ToolStripSeparator _sepNav, _sepAddRemove;

        /// <summary>
        /// Initializes a new instance of a <see cref="EntityBindingNavigator"/>.
        /// </summary>
        public EntityBindingNavigator()
        {
            InitializeComponent();
            _InitializeComponent();
            Dock = DockStyle.Top;
            ShowNavigationButtons = ShowAddRemoveButtons = ShowSaveUndoRefreshButtons = true;
            UpdateUI();
        }

        #region Object model

        /// <summary>
        /// Gets or sets the data source for this navigator.
        /// </summary>
        [DefaultValue(null), AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => _dataSource;
            set
            {
                _dataSource = value;
                UpdateCurrencyManager();
            }
        }

        /// <summary>
        /// Gets or sets the specific list in a <see cref="DataSource"/> object that the navigator should display.
        /// </summary>
        [DefaultValue(""),
         Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]
        public string DataMember
        {
            get => _dataMember;
            set
            {
                _dataMember = value;
                UpdateCurrencyManager();
            }
        }

        /// <summary>
        /// Sets the DataSource and DataMember properties at the same time.
        /// </summary>
        public void SetDataBinding(object dataSource, string dataMember)
        {
            _dataSource = dataSource;
            _dataMember = dataMember;
            UpdateCurrencyManager();
        }

        /// <summary>
        /// Gets a reference to the list being managed by this navigator.
        /// </summary>
        [Browsable(false)]
        public IBindingList List => _cm?.List as IBindingList;

        /// <summary>
        /// Gets the item that is currently selected.
        /// </summary>
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object CurrentItem => _cm?.Current;

        /// <summary>
        /// Gets or sets the index of the item that is currently selected.
        /// </summary>
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public int Position
        {
            get { return _cm?.Position ?? -1; }
            set { if (_cm != null) _cm.Position = value; }
        }

        /// <summary>
        /// Gets or sets whether the control should display the navigation buttons.
        /// </summary>
        [DefaultValue(true)]
        public bool ShowNavigationButtons
        {
            get => _showBtnNav;
            set => _showBtnNav =
                _btnFirst.Visible =
                    _btnPrev.Visible =
                        _btnNext.Visible =
                            _lblCurrent.Visible =
                                _btnLast.Visible =
                                    _sepNav.Visible = value;
        }

        /// <summary>
        /// Gets or sets whether the control should display the add/remove item buttons.
        /// </summary>
        [DefaultValue(true)]
        public bool ShowAddRemoveButtons
        {
            get => _showBtnAdd;
            set => _showBtnAdd =
                _btnAdd.Visible =
                    _btnRemove.Visible =
                        _sepAddRemove.Visible = value;
        }

        /// <summary>
        /// Gets or sets whether the control should display the save/undo/refresh buttons.
        /// </summary>
        [DefaultValue(true)]
        public bool ShowSaveUndoRefreshButtons
        {
            get => _showBtnSave;
            set => _showBtnSave =
                _btnSave.Visible =
                    _btnUndo.Visible =
                        _btnRefresh.Visible = value;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the current item changes.
        /// </summary>
        public event EventHandler PositionChanged;

        /// <summary>
        /// Raises the <see cref="PositionChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPositionChanged(EventArgs e)
        {
            PositionChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when the current item changes.
        /// </summary>
        public event ListChangedEventHandler ListChanged;

        /// <summary>
        /// Raises the <see cref="ListChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnListChanged(ListChangedEventArgs e)
        {
            ListChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs before a new item is added to the list.
        /// </summary>
        public event CancelEventHandler AddingNew;

        /// <summary>
        /// Raises the <see cref="AddingNew"/> event.
        /// </summary>
        /// <param name="e"><see cref="CancelEventArgs"/> that contains the event parameters.</param>
        protected virtual void OnAddingNew(CancelEventArgs e)
        {
            AddingNew?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs after a new item is added to the list.
        /// </summary>
        public event EventHandler AddedNew;

        /// <summary>
        /// Raises the <see cref="AddedNew"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        protected virtual void OnAddedNew(EventArgs e)
        {
            AddedNew?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs before an item is removed from the list.
        /// </summary>
        public event CancelEventHandler RemovingItem;

        /// <summary>
        /// Raises the <see cref="RemovingItem"/> event.
        /// </summary>
        /// <param name="e"><see cref="CancelEventArgs"/> that contains the event parameters.</param>
        protected virtual void OnRemovingItem(CancelEventArgs e)
        {
            RemovingItem?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs after an item is removed from the list.
        /// </summary>
        public event EventHandler RemovedItem;

        /// <summary>
        /// Raises the <see cref="RemovedItem"/> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        protected virtual void OnRemovedItem(EventArgs e)
        {
            RemovedItem?.Invoke(this, e);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Update the internal CurrencyManager when the BindingContext changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
            UpdateCurrencyManager();
        }

        /// <summary>
        /// Gets or sets how the control is docked in the parent container.
        /// </summary>
        [DefaultValue(DockStyle.Top)]
        public override DockStyle Dock
        {
            get => base.Dock;
            set => base.Dock = value;
        }

        #endregion

        //-------------------------------------------------------------
        #region Implementation

        private void _InitializeComponent()
        {
            _btnFirst = new ToolStripButton("Первый");
            _btnFirst.Click += _btnFirst_Click;

            _btnPrev = new ToolStripButton("Предыдущий");
            _btnPrev.Click += _btnPrev_Click;

            _lblCurrent = new ToolStripLabel("0 of 0");
            
            _btnNext = new ToolStripButton("Следующий");
            _btnNext.Click += _btnNext_Click;

            _btnLast = new ToolStripButton("Последний");
            _btnLast.Click += _btnLast_Click;

            foreach (var btn in new[] { _btnFirst, _btnPrev, _btnNext, _btnLast })
            {
                btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
                Items.Add(btn);
            }
            Items.Insert(2, _lblCurrent);

            _sepNav = new ToolStripSeparator();
            Items.Add(_sepNav);

            _btnAdd = new ToolStripButton("Добавить");
            _btnAdd.Click += _btnAdd_Click;

            _btnRemove = new ToolStripButton("Удалить");
            _btnRemove.Click += _btnRemove_Click;

            foreach (var btn in new[] { _btnAdd, _btnRemove })
            {
                btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
                Items.Add(btn);
            }
            _sepAddRemove = new ToolStripSeparator();
            Items.Add(_sepAddRemove);

            _btnSave = new ToolStripButton("Записать");
            _btnSave.Click += _btnSave_Click;

            _btnUndo = new ToolStripButton("Отмена");
            _btnUndo.Click += _btnCancel_Click;

            _btnRefresh = new ToolStripButton("Обновить");
            _btnRefresh.Click += _btnRefresh_Click;

            foreach (var btn in new[] { _btnRefresh, _btnUndo, _btnSave })
            {
                btn.Alignment = ToolStripItemAlignment.Right;
                Items.Add(btn);
            }

            foreach (ToolStripItem item in Items)
            {
                item.Visible = true;
            }
        }

        // update UI when postion/list changes
        private void _cm_PositionChanged(object sender, EventArgs e)
        {
            UpdateUI();
            OnPositionChanged(e);
        }

        private void _cm_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.ItemChanged)
            {
                UpdateUI();
            }
            OnListChanged(e);
        }

        private void UpdateUI()
        {
            if (_cm != null)
            {
                _lblCurrent.Text = $@"{_cm.Position + 1} из {_cm.Count}";
                _btnFirst.Enabled = _btnPrev.Enabled = _cm.Position > 0;
                _btnLast.Enabled = _btnNext.Enabled = _cm.Position < _cm.Count - 1;

                var bl = _cm.List as IBindingList;
                _btnAdd.Enabled = bl != null && bl.AllowNew;
                _btnRemove.Enabled = bl != null && bl.AllowRemove;
            }
            else
            {
                _btnFirst.Enabled = _btnPrev.Enabled = false;
                _btnLast.Enabled = _btnNext.Enabled = false;
                _btnAdd.Enabled = _btnRemove.Enabled = false;
            }

            _btnSave.Enabled = _btnUndo.Enabled = _btnRefresh.Enabled = EntityDataSource != null;
        }

        // navigation
        private void _btnFirst_Click(object sender, EventArgs e)
        {
            if (_cm != null)
            {
                _cm.Position = 0;
            }
        }

        private void _btnPrev_Click(object sender, EventArgs e)
        {
            if (_cm != null && _cm.Position > 0)
            {
                _cm.Position--;
            }
        }
        void _btnNext_Click(object sender, EventArgs e)
        {
            if (_cm != null && _cm.Position < _cm.Count - 1)
            {
                _cm.Position++;
            }
        }
        void _btnLast_Click(object sender, EventArgs e)
        {
            if (_cm != null)
            {
                _cm.Position = _cm.Count - 1;
            }
        }

        // add/remove records
        private void _btnAdd_Click(object sender, EventArgs e)
        {
            var ce = new CancelEventArgs();
            OnAddingNew(ce);

            if (!(_cm?.List is IBindingList) || ce.Cancel) return;
            
            var bl = (IBindingList) _cm.List;
            var newItem = bl.AddNew();

            OnAddedNew(e);
            _cm.Position = bl.IndexOf(newItem);
        }

        private void _btnRemove_Click(object sender, EventArgs e)
        {
            var ce = new CancelEventArgs();
            OnRemovingItem(ce);

            if (_cm?.Current == null || !(_cm.List is IBindingList) || ce.Cancel) return;
            var bl = (IBindingList) _cm.List;
            bl.Remove(_cm.Current);

            OnRemovedItem(e);
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            EntityDataSource?.SaveChanges();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            EntityDataSource?.CancelChanges();
        }

        private void _btnRefresh_Click(object sender, EventArgs e)
        {
            EntityDataSource?.Refresh();
        }

        private void UpdateCurrencyManager()
        {
            if (_cm != null)
            {
                _cm.PositionChanged -= _cm_PositionChanged;
                _cm.ListChanged -= _cm_ListChanged;
            }

            _cm = null;
            if (DataSource != null && Parent != null && BindingContext != null)
            {
                try
                {
                    _cm = BindingContext[DataSource, DataMember] as CurrencyManager;
                }
                catch { }
            }

            if (_cm != null)
            {
                _cm.PositionChanged += _cm_PositionChanged;
                _cm.ListChanged += _cm_ListChanged;
            }
            UpdateUI();
        }

        private EntityDataSource EntityDataSource => _dataSource as EntityDataSource;

        #endregion
    }
}
