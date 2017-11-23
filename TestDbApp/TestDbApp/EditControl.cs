using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TestDbApp
{
    public partial class EditControl : UserControl
    {
        private string _attributeName;
        private Type _dataSourceType;
        private BindingSource _bindingSource;

        public EditControl()
        {
            InitializeComponent();
            if(DesignMode)
                return;

            tb_value.HandleCreated += TbValueOnHandleCreated;
            tb_value.HandleDestroyed += TbValueOnHandleDestroyed;
        }

        #region Properties

        [Browsable(false)]
        public bool Multiline
        {
            get => tb_value.Multiline;
            set => tb_value.Multiline = value;
        }

        [Description("Имя поля для привязки к источнику данных")]
        public string AttributeName
        {
            get => _attributeName;
            set => _attributeName = value;
        }

        public object Value { get => tb_value.Text; set => tb_value.Text = value as string;
        }

        //[Description("Источник данных")]
        //[Bindable(true)]
        //[TypeConverter(typeof(BindingSource))]
        //public Type DataSourceType
        //{
        //    get => _dataSourceType;
        //    set
        //    {
        //        if(value == _dataSourceType) return;
        //        OnDataSourceTypeChanging(EventArgs.Empty);
        //        _bindingSource = null;
        //        _dataSourceType = value;
        //        OnDataSourceTypeChanged(EventArgs.Empty);
        //    }
        //}

        //[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public BindingSource BindingSource
        //{
        //    get
        //    {
        //        if (_bindingSource != null || _dataSourceType == null || DesignMode) return _bindingSource;
        //        try
        //        {
        //            BindingSource = Activator.CreateInstance(_dataSourceType) as BindingSource;
        //        }
        //        catch { }
        //        return _bindingSource;
        //    }
        //    set
        //    {
        //        if (Equals(_bindingSource, value)) return;

        //        OnBindingSourceChanging(EventArgs.Empty);

        //        _bindingSource = value;
        //        _dataSourceType = _bindingSource?.GetType();
        //        // generate object sets
        //        //GenerateEntitySets(_ctxType);

        //        OnBindingSourceChanged(EventArgs.Empty);
        //    }
        //}

        #endregion

        #region Event handlers

        private void TbValueOnHandleCreated(object sender, EventArgs eventArgs)
        {
            tb_value.TextChanged += TbValueOnTextChanged;
            tb_value.Validating += TbValueOnValidating;
            tb_value.KeyPress += TbValueOnKeyPress;
            tb_value.KeyUp += TbValueOnKeyUp;
        }

        private void TbValueOnTextChanged(object sender, EventArgs eventArgs)
        {
            
        }

        private void TbValueOnHandleDestroyed(object sender, EventArgs eventArgs)
        {
            tb_value.TextChanged -= TbValueOnTextChanged;
            tb_value.Validating -= TbValueOnValidating;
            tb_value.KeyPress -= TbValueOnKeyPress;
            tb_value.KeyUp -= TbValueOnKeyUp;
        }

        private void TbValueOnKeyPress(object sender, KeyPressEventArgs keyPressEventArgs)
        {
            //_key_press_validate(tb_value, keyPressEventArgs);
        }

        private void TbValueOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            
        }

        private void TbValueOnValidating(object sender, CancelEventArgs cancelEventArgs)
        {
            _validate(cancelEventArgs, sender as Control);
        }

        ///// <summary>
        ///// Occurs before the value of the <see cref="DataSourceType"/> property changes.
        ///// </summary>
        //public event EventHandler DataSourceTypeChanging;

        ///// <summary>
        ///// Raises the <see cref="DataSourceTypeChanging"/> event.
        ///// </summary>
        ///// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        //protected virtual void OnDataSourceTypeChanging(EventArgs e)
        //{
        //    DataSourceTypeChanging?.Invoke(this, e);
        //}

        ///// <summary>
        ///// Occurs after the value of the <see cref=""/> property changes.
        ///// </summary>
        //public event EventHandler DataSourceTypeChanged;

        ///// <summary>
        ///// Raises the <see cref="DataSourceTypeChanged"/> event.
        ///// </summary>
        ///// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        //protected virtual void OnDataSourceTypeChanged(EventArgs e)
        //{
        //    DataSourceTypeChanged?.Invoke(this, e);
        //}

        ///// <summary>
        ///// Occurs before the value of the <see cref="BindingSource"/> property changes.
        ///// </summary>
        //public event EventHandler BindingSourceChanging;

        ///// <summary>
        ///// Raises the <see cref=" BindingSourceChanging"/> event.
        ///// </summary>
        ///// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        //protected virtual void OnBindingSourceChanging(EventArgs e)
        //{
        //    BindingSourceChanging?.Invoke(this, e);
        //}

        ///// <summary>
        ///// Occurs after the value of the <see cref="BindingSource"/> property changes.
        ///// </summary>
        //public event EventHandler BindingSourceChanged;

        ///// <summary>
        ///// Raises the <see cref="BindingSourceChanged"/> event.
        ///// </summary>
        ///// <param name="e"><see cref="EventArgs"/> that contains the event parameters.</param>
        //protected virtual void OnBindingSourceChanged(EventArgs e)
        //{
        //    BindingSourceChanged?.Invoke(this, e);
        //}

        #endregion

        #region Methods

        /// <summary>
        /// Метод срабатывает только на те клавиши у которых есть символ и не даёт нам ввести (Буквы и разделитель, если он уже имеется в редактируемом поле)
        /// если контрол типа Decimal
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="e">Нажатая клавиша</param>
        private void _key_press_validate(Control control, KeyPressEventArgs e)
        {
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            //if (Attr.TypeName == DbType.Decimal)
            //{
                switch (e.KeyChar)
                {
                    case '.':
                        e.KeyChar = separator;
                        break;
                    case ',':
                        e.KeyChar = separator;
                        break;
                }
            if (char.IsDigit(e.KeyChar) || e.KeyChar == separator && control.Text.IndexOf(separator) == -1) return;
            if (e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            //}
        }

        private void _validate(CancelEventArgs e, Control ctrl)
        {
            e.Cancel = !_validate(ctrl);
        }

        private bool _validate(Control control)
        {
            ////if (this is CrossBase) return true;
            //if (control == null || attr == null) return false;
            //if (_value == null) return true;

            ////Мантис баг 1570 Химушкин А.С.
            ////Т.к. null и DbNull.Value  - это разные вещи, то пришлось дополнительно добавить проверку на значение DbNull.Value
            //// Строчка, которая была ранее:
            ////if ((_asIs == null) ? _value == null : _asIs.Equals(_value)) return true;
            ////Заменена на строчку ниже (теперь валидация/коммит значения не проходит):
            //if ((_asIs == null) ? _value == null || _value == DBNull.Value : _asIs.Equals(_value)) return true;


            //var result = false;
            //object formatted = DBNull.Value;
            //var typeName = attr.TypeName;

            //if (_value.Equals(string.Empty))
            //{
            //    /*
            //     * Мантис, # 1363, начало исправляющего кода
            //     * 26.06.2013 Химушкин А.С.
            //     * Теперь в поле, для "красного" товара принадлежащего инвойсу со статусом "передан на проверку"
            //     * вместо пустой строки, получаемой с БД, выводятся нули. 
            //     * Ранее выводилась пустая строка и происходил exception конвертирования формата на этапе запроса в базу.
            //     * Потому, что конвертирование пустой строки в десятиный формат невозможно.
            //     * Для инвойсов с другим статусом изменения не происходят.
            //     * P.S. Они и не происходили в момент регистрации ошибки.
            //     */
            //    formatted = typeName == DbType.Decimal ? new Decimal() : _value;
            //    /*
            //     * Мантис, # 1363, завершение исправляющего кода 
            //     * 26.06.2013 Химушкин А.С.
            //     */
            //    #region То, что было ранее вместо строки выше:
            //    /* formatted = _value;
            //     * 26.06.2013 Химушкин А.С.
            //     */
            //    #endregion То, что было ранее вместо строки выше:

            //    result = true;
            //}
            //else if (_value == DBNull.Value)
            //{
            //    result = true;
            //}
            //else
            //{
            //    switch (typeName)
            //    {
            //        case DbType.Decimal:
            //            if (_value.SafeConvert(typeof(decimal), out formatted))
            //                result = true;
            //            break;

            //        case DbType.Int32:
            //            if (_value.SafeConvert(typeof(int), out formatted))
            //            {
            //                result = true;
            //            }
            //            else
            //            {
            //                _showMessage(TypeCode.Int32);
            //            }
            //            break;

            //        case DbType.Boolean:
            //            if (_value.SafeConvert(typeof(bool), out formatted))
            //            {
            //                result = true;
            //            }
            //            else
            //            {
            //                _showMessage(TypeCode.Boolean);
            //            }
            //            break;

            //        default:
            //            formatted = _value;
            //            result = true;
            //            break;
            //    }

            //}

            //if (_asIs != null && _asIs.Equals(formatted)) return true;

            //if (!result) return false;

            //// дальше сомнительное место 5 return (на Validating был выход e.Cancel = false)
            //// в этом методе раньше возвращалось false, использовалось только на DateTimeBase
            //// ситуация невозможная? тогда лучше считать, что валидация не прошла. Андреев А.
            //var parent = _cross ?? _grid as ICross;

            //if (parent == null) { return true; }

            //var parentDataClass = parent.Class;
            //if (parentDataClass == null) { return true; }

            //var host = parentDataClass.Host;
            //if (host == null) { return true; }
            //if (Tag == null) { return true; }

            //var parentRow = parent.xRow;
            //if (parentRow == null) { return true; }

            //// верно для фильтров, если будут другие Fake, то возможно понадобятся изменения
            //if (isFake)
            //{
            //    var dateTimeBase = control as DateTimeBase;
            //    if (dateTimeBase != null)
            //    {
            //        var name = attr.Name + ";" + dateTimeBase.TypeOperator;
            //        _setValue(parentRow, name, formatted);
            //    }
            //    else
            //    {
            //        _setValue(parentRow, attr.Name, formatted);
            //    }

            //    DoValueChange();
            //}
            //else
            //{
            //    bgwParams updateParam = new bgwParams(ActionType.selfUpdate, _pk, attr, formatted);
            //    parentDataClass.ExecAsync(updateParam);
            //}
            //if (CtrlZTrack == null)
            //{
            //    CtrlZTrack = new CtrlZTracker(this);
            //}
            //CtrlZTrack.Push();
            //_asIs = _value;

            return true;
        }


        #endregion



    }
}
