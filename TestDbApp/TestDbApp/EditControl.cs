﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace TestDbApp
{
    public partial class EditControl : UserControl
    {
        public EditControl()
        {
            InitializeComponent();
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

        #endregion

        #region Event handlers

        private void TbValueOnHandleCreated(object sender, EventArgs eventArgs)
        {
            tb_value.Validating += TbValueOnValidating;
            tb_value.KeyPress += TbValueOnKeyPress;
            tb_value.KeyUp += TbValueOnKeyUp;
        }

        private void TbValueOnHandleDestroyed(object sender, EventArgs eventArgs)
        {
            tb_value.Validating -= TbValueOnValidating;
            tb_value.KeyPress -= TbValueOnKeyPress;
            tb_value.KeyUp -= TbValueOnKeyUp;
        }

        private void TbValueOnKeyPress(object sender, KeyPressEventArgs keyPressEventArgs)
        {
            _key_press_validate(tb_value, keyPressEventArgs);
        }

        private void TbValueOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            
        }

        private void TbValueOnValidating(object sender, CancelEventArgs cancelEventArgs)
        {
            _validate(cancelEventArgs, sender as Control);
        }



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
