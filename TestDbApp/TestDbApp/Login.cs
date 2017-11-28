using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDbApp
{
    /// <summary>
    /// Форма подключения к БД
    /// </summary>
    /// <remarks>
    /// По умолчанию строка подключения берется из файла конфигурации [Исполняемый файл приложения].config
    /// </remarks>
    public partial class Login : Form
    {
        public string ConnectionString { get; private set; }
        private string _server;
        private string _database;
        private string _pswd;
        private string _user;

        public Login()
        {
            InitializeComponent();
            _server = _database = _pswd = _user = string.Empty;

            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["TestDBConnectionString"].ConnectionString;
            }
            catch
            {
                // ignored
            }
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                tb_server.Enabled = false;
                tb_database.Enabled = false;
                chb_SSPI.Enabled = false;
            }
            ChbSspiCheckStateChanged(this, EventArgs.Empty);
        }

        #region Events

        private void TbServerTextChanged(object sender, EventArgs e)
        {
            _server = tb_server.Text;
        }

        private void TbDatabaseTextChanged(object sender, EventArgs e)
        {
            _database = tb_database.Text;
        }

        private void TbUserTextChanged(object sender, EventArgs e)
        {
            _user = tb_user.Text;
        }

        private void TbPasswordTextChanged(object sender, EventArgs e)
        {
            _pswd = tb_password.Text;
        }

        private void ChbSspiCheckStateChanged(object sender, EventArgs e)
        {
            tb_password.Enabled = !chb_SSPI.Checked;
            tb_user.Enabled = !chb_SSPI.Checked;
        }

        private async void OkClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                ConnectionString = chb_SSPI.Checked ? $"Data Source = {_server}; Initial Catalog = {_database}; Integrated Security = True" 
                                                    : $"Server={_server};Initial Catalog={_database};User ID={_user};Password={_pswd}";
            }

            Cursor = Cursors.WaitCursor;
            var result = await Task.Run(() => TryConnection());
            if (result)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(this, "Неудачная попытка подключения. Проверьте настройки подключения к базе данных", "Ошибка"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor = DefaultCursor;
        }

        #endregion

        #region Methods

        private bool TryConnection()
        {
            using (var dbContext = new Model.TestDbContext(ConnectionString))
            {
                return dbContext.Database.Exists();
            }
        }

        #endregion


    }
}