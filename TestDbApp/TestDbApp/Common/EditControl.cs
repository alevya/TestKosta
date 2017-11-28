using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TestDbApp.Common
{
    public partial class EditControl : UserControl
    {
        private readonly ToolTip _toolTip;

        public EditControl()
        {
            InitializeComponent();
            if(DesignMode)
                return;

            _toolTip = new ToolTip();
            tb_value.HandleCreated += TbValueOnHandleCreated;
            tb_value.HandleDestroyed += TbValueOnHandleDestroyed;
        }

        #region Properties

        [Description("Максимальная длина поля ввода")]
        public int MaxLen
        {
            get => tb_value.MaxLength;
            set => tb_value.MaxLength = value;
        }

        [Description("Обязательное поле")]
        public bool IsRequed { get; set; }

        [Browsable(false)]
        public bool Multiline
        {
            get => tb_value.Multiline;
            set => tb_value.Multiline = value;
        }

        [Description("Имя поля для привязки к источнику данных")]
        public string AttributeName { get; set; }

        public object Value { get => tb_value.Text; set => tb_value.Text = value as string;
        }
        #endregion

        #region Events

        private void TbValueOnHandleCreated(object sender, EventArgs eventArgs)
        {
            tb_value.Validating += TbValueOnValidating;
            tb_value.KeyPress += TbValueOnKeyPress;
            tb_value.TextChanged += TbValueOnTextChanged;
        }

        private void TbValueOnHandleDestroyed(object sender, EventArgs eventArgs)
        {
            tb_value.Validating -= TbValueOnValidating;
            tb_value.KeyPress -= TbValueOnKeyPress;
            tb_value.TextChanged -= TbValueOnTextChanged;
        }

        private void TbValueOnTextChanged(object sender, EventArgs eventArgs)
        {
            //_validate(sender as Control);
        }

        private void TbValueOnKeyPress(object sender, KeyPressEventArgs keyPressEventArgs)
        {
            //_key_press_validate(tb_value, keyPressEventArgs);
        }

        private void TbValueOnValidating(object sender, CancelEventArgs cancelEventArgs)
        {
            _validate(cancelEventArgs, sender as Control);
        }
        #endregion

        #region Methods

        //private void _key_press_validate(Control control, KeyPressEventArgs e)
        //{
          
        //}

        private void _validate(CancelEventArgs e, Control ctrl)
        {
            e.Cancel = !_validate(ctrl);
        }

        private bool _validate(Control control)
        {
            if (IsRequed && tb_value.Text == string.Empty)
            {
                l_required.Visible = true;
                //_toolTip.AutoPopDelay = 2000;
                //_toolTip.InitialDelay = 1000;
                //_toolTip.ReshowDelay = 500;
                //_toolTip.IsBalloon = true;
                //_toolTip.ShowAlways = true;
                //_toolTip.Show(string.Empty, tb_value, 0);
                //var p = new Point(tb_value.Width, tb_value.Height / 10);
                //_toolTip.Show("Обязательное поле", tb_value, p);
                //return false;
            }
            else
            {
                l_required.Visible = false;
                //_toolTip.ShowAlways = false;
                //_toolTip.Hide(tb_value);
            }
            
            return true;
        }

        #endregion

       
    }
}
