using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TestDbApp.EntityFrameworkBinding;
using TestDbApp.Model;

namespace TestDbApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Load += OnLoad;
            entityDataSource_Org.DataError += EntityDataSourceOrgOnDataError;
            tv_Department.AfterSelect += TvDepartmentOnAfterSelect;
            bindSrc_DepartmentToEmployee.DataMemberChanged += BindSrcDepartmentToEmployeeOnDataMemberChanged;
            bindSrc_DepartmentToEmployee.CurrentItemChanged += BindSrcDepartmentToEmployeeOnCurrentItemChanged;
            bindSrc_DepartmentToEmployee.CurrentChanged += BindSrcDepartmentToEmployeeOnCurrentChanged;
        }

        #region Events

        private void OnLoad(object sender, EventArgs eventArgs)
        {
            cb_DepartmentToEmployee.DataSource = entityDataSource_Org;
            cb_DepartmentToEmployee.DisplayMember = "Departments.Name";
            cb_DepartmentToEmployee.ValueMember = "Departments.DepartmentId";

            //---Привязка и заполнение дерева структуры предприятия
            var bind = new Binding("Tag", entityDataSource_Org, "Departments");
            tv_Department.DataBindings.Add(bind);
            _populateTreeView();

            if (tv_Department.Nodes.Count <= 0) return;
            tv_Department.SelectedNode = tv_Department.Nodes[0];
            _bindingEmployeeDetails(bindSrc_DepartmentToEmployee);
            //---
        }

        private void EntityDataSourceOrgOnDataError(object sender, DataErrorEventArgs args)
        {
            string msgError;
            var inExc = args.Exception.InnerException;
            if (inExc?.InnerException != null)
            {
                msgError = inExc.InnerException.Message;

            }
            else
            {
                msgError = args.Exception.Message;
            }
            MessageBox.Show(this, msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            args.Handled = true;
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            entityDataSource_Org.SaveChanges();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            entityDataSource_Org.CancelChanges();
        }

        private void _btnRefresh_Click(object sender, EventArgs e)
        {
            entityDataSource_Org.Refresh();

        }

        private void _bindSrc_DepartmentToEmployee_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void BindSrcDepartmentToEmployeeOnCurrentItemChanged(object sender, EventArgs eventArgs)
        {

        }

        private void BindSrcDepartmentToEmployeeOnCurrentChanged(object sender, EventArgs eventArgs)
        {
            var currentEmpl = bindSrc_DepartmentToEmployee.Current as Employee;
            if (currentEmpl == null) return;

        }

        private void TvDepartmentOnAfterSelect(object sender, TreeViewEventArgs treeViewEventArgs)
        {
            var selectedNode = tv_Department.SelectedNode;
            Department selDepartment = selectedNode.Tag as Department;
            if (selDepartment == null) return;

            var employees = new List<Employee>();
            var l = entityDataSource_Org.EntitySets["Departments"].Cast<Department>().ToList();

            bindSrc_DepartmentToEmployee.Clear();
            GetEmployees(employees, selDepartment, l);
            if (!employees.Any()) return;

            bindSrc_DepartmentToEmployee.DataSource = employees;
            dgv_EmployeeToDepartment.DataSource = bindSrc_DepartmentToEmployee;
        }

        #endregion

        #region Methods

        private static void GetEmployees(List<Employee> employees, Department dep, IEnumerable<Department> departments)
        {
            var ds = from Department d in departments
                where d.ParentDepartmentID == dep.DepartmentId
                select d;

            employees.AddRange(dep.Employees);
            foreach (var item in ds)
            {
                GetEmployees(employees, item, departments);
            }
        }



        private void _bindingEmployeeDetails(object dataSource)
        {
            if (dataSource == null) return;

            ec_FirstName.DataBindings.Add(new Binding("Value", dataSource, ec_FirstName.AttributeName, true));
            ec_SurName.DataBindings.Add(new Binding("Value", dataSource, ec_SurName.AttributeName, true));
            ec_Patronymic.DataBindings.Add(new Binding("Value", dataSource, ec_Patronymic.AttributeName, true));
            ec_Position.DataBindings.Add(new Binding("Value", dataSource, ec_Position.AttributeName, true));
            ec_DocNumber.DataBindings.Add(new Binding("Value", dataSource, ec_DocNumber.AttributeName, true));
            ec_DocSeries.DataBindings.Add(new Binding("Value", dataSource, ec_DocSeries.AttributeName, true));
            dtp_DateBirth.DataBindings.Add(new Binding("Value", dataSource, "DateOfBirth", true));
            tb_Age.DataBindings.Add(new Binding("Text", dataSource, "Age", true));

            //Binding ComboBox на вкладке <Структура предприятия> 
            var bindDepToEmpl =
                new Binding("SelectedValue", dataSource, "DepartmentID", true)
                {
                    DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
                    ControlUpdateMode = ControlUpdateMode.OnPropertyChanged
                };
            cb_DepartmentToEmployee.DataBindings.Add(bindDepToEmpl);
        }

        private void _populateTreeView()
        {
            var list = tv_Department.Tag as IEnumerable<Department>;
            if (list == null) return;

            var departments = list as IList<Department> ?? list.ToList();
            var rootNodes = departments.Where(department => department.ParentDepartmentID == Guid.Empty ||
                                                            department.ParentDepartmentID == null);
            foreach (var rootNode in rootNodes)
            {
                var node = GetTreeNode(rootNode, departments);
                node.Expand();
                tv_Department.Nodes.Add(node);
            }
        }

        private static TreeNode GetTreeNode(Department row, IEnumerable<Department> list)
        {
            Guid.TryParse(row.DepartmentId.ToString(), out Guid nodeID);
            var node = new TreeNode
                       {
                           Text = Convert.ToString(row.Name),
                           Tag = row
                       };
            var res = list.Where(department => department.ParentDepartmentID == nodeID);
            foreach (var item in res)
            {
                var chNode = GetTreeNode(item, list);
                chNode.Text = Convert.ToString(item.Name);
                node.Nodes.Add(chNode);
            }
            return node;
        }

        #endregion
    }
}
