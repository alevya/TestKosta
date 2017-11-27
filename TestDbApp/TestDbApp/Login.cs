using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDbApp
{
    public partial class Login : Form
    {
        private string _pswd;
        private string _user;
        public string Culture { get; }

        public Login()
        {
            Culture = Thread.CurrentThread.CurrentCulture.Name;

            InitializeComponent();
            Shown += LoginShown;
        }

        private void LoginShown(object sender, EventArgs e)
        {
            tb_password.Focus();
        }

     
        #region Events
        private void TbUserTextChanged(object sender, EventArgs e)
        {
            _user = tb_user.Text;
        }

        private void TbPasswordTextChanged(object sender, EventArgs e)
        {
            _pswd = tb_password.Text;
        }

        private async void OkClick(object sender, EventArgs e)
        {
            m_OK.Enabled = false;

            tb_user.ReadOnly = true;
            tb_password.ReadOnly = true;
            var result = await Task.Run(() => TryConnection());
            
            if(result)
                DialogResult = DialogResult.OK;
            else
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(this, "Неудачная попытка подключения. Проверьте настройки подключения к базе данных", "Ошибка"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static bool TryConnection()
        {
            using (var dbContext = new Model.TestDbContext())
            {
                return dbContext.Database.Exists();
            }
        }

        #endregion
    }
}