using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            entityDataSource_Org.SavingChanges += EntityDataSourceOrgOnSavingChanges;
            tv_Department.AfterSelect += TvDepartmentOnAfterSelect;
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
            PopulateTreeView();

            if (tv_Department.Nodes.Count <= 0) return;
            
            tv_Department.SelectedNode = tv_Department.TopNode;
            BindingEmployeeDetails(bindSrc_DepartmentToEmployee);
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

        private void EntityDataSourceOrgOnSavingChanges(object sender, CancelEventArgs cancelEventArgs)
        {
            var dialogRes = MessageBox.Show(this, "Сохранить данные?", "Сохранение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dialogRes != DialogResult.Yes)
            {
                cancelEventArgs.Cancel = true;
                BtnCancel_Click(sender, EventArgs.Empty);
            }
           
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            entityDataSource_Org.SaveChanges();
            TvDepartmentOnAfterSelect(null, new TreeViewEventArgs(tv_Department.SelectedNode));
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            entityDataSource_Org.CancelChanges();
            bindSrc_DepartmentToEmployee.CancelEdit();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            entityDataSource_Org.Refresh();
            
            //_populateTreeView();
            TvDepartmentOnAfterSelect(sender, new TreeViewEventArgs(tv_Department.SelectedNode));

        }

        private void TvDepartmentOnAfterSelect(object sender, TreeViewEventArgs treeViewEventArgs)
        {
            var selectedNode = tv_Department.SelectedNode;
            Department selDepartment = selectedNode.Tag as Department;
            if (selDepartment == null) return;

            var employees = new List<Employee>();
         
            bindSrc_DepartmentToEmployee.Clear();
            GetEmployees(employees, selDepartment);
            if (!employees.Any()) return;

            var blEmployees = entityDataSource_Org.CreateView(employees);
            bindSrc_DepartmentToEmployee.DataSource = blEmployees;
        }

        #endregion

        #region Methods

        private static void GetEmployees(List<Employee> employees, Department dep)
        {
            employees.AddRange(dep.Employees);
            foreach (var childDep in dep.Children)
            {
                GetEmployees(employees, childDep);
            }
        }

        private void BindingEmployeeDetails(object dataSource)
        {
            dgv_EmployeeToDepartment.DataSource = dataSource;
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

        private void PopulateTreeView()
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

        private static TreeNode GetTreeNode(Department dep, IEnumerable<Department> list)
        {
            Guid.TryParse(dep.DepartmentId.ToString(), out Guid nodeID);
            var node = new TreeNode
                       {
                           Text = Convert.ToString(dep.Name),
                           Tag = dep
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
