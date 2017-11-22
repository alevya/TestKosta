using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDbApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tv_Department.HandleCreated += TvDepartmentOnHandleCreated;
        }

        private void TvDepartmentOnHandleCreated(object sender, EventArgs eventArgs)
        {
            Binding bind = new Binding("Tag", entityDataSource1, "Departments");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            entityDataSource1.SaveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            entityDataSource1.CancelChanges();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            entityDataSource1.Refresh();

        }

       
    }
}
