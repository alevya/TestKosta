using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace TestDbApp
{
    public partial class Login : Form
    {

        #region Initialize

        private readonly IServiceContainer _host;
        private string _pswd;
        private string _user;
        private string _service;
        private string _email;
        private string _culture;

        private string _dataSourceVersion;
        private string _clientVersion;
        private bool _freeze;

        public Login()
        {
            _culture = Thread.CurrentThread.CurrentCulture.Name;

            InitializeComponent();
            tc_main.SelectedIndexChanged += tc_main_SelectedIndexChanged;

            this.Shown += Login_Shown;
        }

        void Login_Shown(object sender, EventArgs e)
        {
            tc_main.SelectedTab = tp_login;
            tb_password.Focus();
        }

        #endregion

        #region Events

        private void tc_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tc_main.SelectedIndex)
            {
                case 0: 
                    tb_user.Focus();
                    m_OK.Enabled = _readyToConnect(); 
                    break;

                case 1:
                    tb_email.Focus();
                    b_lost.Enabled = IsValidEmail(_email);
                    m_OK.Enabled = false;
                    break;
            }
        }


        void bwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(_user)) { return; }
            if (string.IsNullOrEmpty(_pswd)) { return; }
            if (string.IsNullOrEmpty(_service)) { return; }
        }

        private void bwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                DialogResult = DialogResult.OK;
                Close();
            
        }

        private void tb_user_TextChanged(object sender, EventArgs e)
        {
            m_OK.Enabled = _readyToConnect();
            _user = tb_user.Text;
        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {
            _pswd = tb_password.Text;
            m_OK.Enabled = _readyToConnect();
        }

        private void tb_service_TextChanged(object sender, EventArgs e)
        {
            _service = tb_service.Text;
            m_OK.Enabled = _readyToConnect();

            var root = _host.GetService<IXmlTree>();
            root.GetTree(Nodes.login).Dictionary[Nodes.service] = _service;
        }

        private void m_OK_Click(object sender, EventArgs e)
        {
            m_OK.Enabled = false;

            tb_user.ReadOnly = true;
            tb_password.ReadOnly = true;
            tb_service.ReadOnly = true;

            BackgroundWorker bwLogin = new BackgroundWorker();
            bwLogin.WorkerReportsProgress = true;
            bwLogin.WorkerSupportsCancellation = true;
            bwLogin.DoWork += new DoWorkEventHandler(bwLogin_DoWork);
            bwLogin.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwLogin_RunWorkerCompleted);
            bwLogin.RunWorkerAsync();
        }

        #endregion

        #region validators
        bool invalid = false;

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper);
            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                   RegexOptions.IgnoreCase);
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        private bool _readyToConnect()
        {
            if (string.IsNullOrEmpty(tb_user.Text)) { return false; }
            if (string.IsNullOrEmpty(tb_password.Text)) { return false; }
            if (string.IsNullOrEmpty(tb_service.Text)) { return false; }

            return true;
        }

        #endregion
    }
}