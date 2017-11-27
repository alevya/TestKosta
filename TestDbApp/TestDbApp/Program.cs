using System;
using System.Configuration;
using System.Windows.Forms;

namespace TestDbApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var connectionString = string.Empty;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["TestDBConnectionString"].ConnectionString;
            }
            catch
            {
                // ignored
            }


            var loginForm = new Login(connectionString);
            var dRes = loginForm.ShowDialog();

            if(dRes == DialogResult.OK)
                Application.Run(new MainForm(connectionString));
        }
    }
}
