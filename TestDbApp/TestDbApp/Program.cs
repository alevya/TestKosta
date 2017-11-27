using System;
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

            var loginForm = new Login();
            var dRes = loginForm.ShowDialog();

            if(dRes == DialogResult.OK)
                Application.Run(new MainForm(loginForm.ConnectionString));
        }
    }
}
