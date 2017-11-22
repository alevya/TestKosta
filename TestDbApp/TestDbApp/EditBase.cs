using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TestDbApp
{
    public partial class EditBase : UserControl
    {
        private bool _fitSize = true;
        private Thread _scroller;
        private string _srolled;
        private string _virgin;
        private bool _stopScroller;
        private readonly ManualResetEvent _trigger = new ManualResetEvent(true);

        public EditBase()
        {
            InitializeComponent();
            HandleCreated += OnHandleCreated;
            HandleDestroyed += OnHandleDestroyed;
            tb_value.Validating += TbValueOnValidating;
            tb_value.TextChanged += TbValueOnTextChanged;
        }

        private void TbValueOnTextChanged(object sender, EventArgs eventArgs)
        {
        }


        private void TbValueOnValidating(object sender, CancelEventArgs cancelEventArgs)
        {
            
        }

        private void OnHandleDestroyed(object sender, EventArgs eventArgs)
        {
            if (_scroller == null) return;
            _stopScroller = true;
            _trigger.Set();
            _scroller.Join();
        }

        private void OnHandleCreated(object o, EventArgs eventArgs)
        {
            _virgin = label.Text;
            var textSize = string.IsNullOrEmpty(_virgin) ? new Size(0, 0) : TextRenderer.MeasureText(_virgin, Font);
            _fitSize = textSize.Width < label.Size.Width - tb_value.Size.Height;
        }


        public new ControlBindingsCollection DataBindings => tb_value.DataBindings;

        public Label LabelEditBase
        {
            get => label;
        }

        public string  LabelName
        {
            get => label.Text;
            set => label.Text = value;
        }

        private void _scrollCaption()
        {
            if (string.IsNullOrEmpty(_srolled)) { return; }

            string tempChar = string.Empty;

            while (!_stopScroller)
            {
                tempChar = _srolled.Substring(0, 1);
                _srolled = _srolled.Remove(0, 1) + tempChar;
                BeginInvoke(new EventHandler(_redrawCaption));
                Thread.Sleep(100);  //lowering this value with make the marquee scroll faster
                _trigger.WaitOne();
            }
        }

        void _redrawCaption(object sender, EventArgs e)
        {
            label.Text = _srolled;
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            if (_fitSize) { return; }
            if (_scroller == null) { return; }

            _trigger.Reset();
            _srolled = _virgin;

            BeginInvoke(new EventHandler(_redrawCaption));

        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            if (_fitSize) { return; }

            _srolled = _virgin + "   ";

            if (_scroller == null)
            {
                _scroller = new Thread(_scrollCaption);
                _scroller.Start();
            }
            _trigger.Set();
        }
    }
}
