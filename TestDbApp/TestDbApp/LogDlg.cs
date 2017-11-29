using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestDbApp
{
    public partial class LogDlg : Form
    {
        public LogDlg(Exception exc)
        {
            InitializeComponent();
            rtb_log.Text = _recoverError(exc);
        }

        private static string _recoverError(Exception exc)
        {
            if (exc == null) { return string.Empty; }

            var dbEnityExc = exc as DbEntityValidationException;
            if (dbEnityExc != null)
            {
                return _showEntityValidationError(dbEnityExc);
            }
            return exc.Message + _recoverError(exc.InnerException);
        }

        private static string _showEntityValidationError(DbEntityValidationException dbEnityExc)
        {
            if (!dbEnityExc.EntityValidationErrors.Any())
                return string.Empty;
            var errorsMsg = new StringBuilder();
            foreach (var eve in dbEnityExc.EntityValidationErrors)
            {
                if (!eve.ValidationErrors.Any())
                    continue;
                foreach (var ve in eve.ValidationErrors)
                {
                    var line = $"Свойство: {ve.PropertyName}, "
                             + $"Значение: {eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName)}, "
                             + $"Ошибка: {ve.ErrorMessage}";
                    errorsMsg.AppendLine(line);
                }
            }
            return errorsMsg.ToString();
        }
    }
}
