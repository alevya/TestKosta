using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDbApp.Common;
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
          
            dtp_DateBirth.ValueChanged += DtpDateBirthOnValueChanged;

            EmployeeOfDepatmentNavigator.DataSource = bindSrc_DepartmentToEmployee;

            //cb_Department.DataSource = entityDataSource_Org.EntitySets["Departments"].Cast<Department>().ToList();
            //cb_Department.DisplayMember = "Name";
            //cb_Department.ValueMember = "ID";
            //var bindEmpl = new Binding("SelectedValue", entityDataSource_Org, "Employees.DepartmentID", true);
            //bindEmpl.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            //bindEmpl.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            //cb_Department.DataBindings.Add(bindEmpl);
            //cb_Department.SelectedIndexChanged += CbDepartmentOnSelectedIndexChanged;
        }

        private void CbDepartmentOnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            var selected = cb_Department.SelectedItem;
        }

        private void EntityDataSourceOrgOnDataError(object sender, DataErrorEventArgs args)
        {
            string msgError = string.Empty;
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

        private void BindSrcDepartmentToEmployeeOnCurrentItemChanged(object sender, EventArgs eventArgs)
        {
            
        }

        private void DtpDateBirthOnValueChanged(object sender, EventArgs eventArgs)
        {
            //var dtBirth = dtp_DateBirth.Value;
            var diff = new DifferenceDate(dtp_DateBirth.Value, DateTime.Now);
            tb_Age.Text = Convert.ToString(diff.Years);
        }

        private void BindSrcDepartmentToEmployeeOnCurrentChanged(object sender, EventArgs eventArgs)
        {
            var currentEmpl = bindSrc_DepartmentToEmployee.Current as Employee;
            if(currentEmpl == null) return;

            //var dtBirth = currentEmpl.DateOfBirth;
            //var diff = new DifferenceDate(dtBirth, DateTime.Now);
            //tb_Age.Text = Convert.ToString(diff.Years);
        }

        private void TvDepartmentOnAfterSelect(object sender, TreeViewEventArgs treeViewEventArgs)
        {
            var selectedNode = tv_Department.SelectedNode;
            Department selDepartment = selectedNode.Tag as Department;
            if(selDepartment == null) return;

            var employees = new List<Employee>();
            var l = entityDataSource_Org.EntitySets["Departments"].Cast<Department>().ToList();

            GetEmployees(employees, selDepartment, l);
            var bindingList = entityDataSource_Org.CreateView(employees);
            var dlEmployee = entityDataSource_Org.GetLookupDictionary(typeof(Employee));
            var dlDepartment = entityDataSource_Org.GetLookupDictionary(typeof(Department));
            bindSrc_DepartmentToEmployee.DataSource = employees;//bindingList;
            dgv_EmployeeToDepartment.DataSource = bindSrc_DepartmentToEmployee;
            //dgv_EmployeeToDepartment.DataMember = "Employee";

        }

        private static void GetEmployees(List<Employee> employees, Department dep, IEnumerable<Department> departments)
        {
            var ds = from Department d in departments
                where d.ParentDepartmentID == dep.ID
                select d;

            employees.AddRange(dep.Employees);
            foreach (var item in ds)
            {
                GetEmployees(employees, item, departments);
            }
        }

        private void OnLoad(object sender, EventArgs eventArgs)
        {
            var bind = new Binding("Tag", entityDataSource_Org, "Departments");
            tv_Department.DataBindings.Add(bind);
            _populateTreeView();

            if (tv_Department.Nodes.Count > 0)
            {
                tv_Department.SelectedNode = tv_Department.Nodes[0];
                _bindingEmployeeDetails(bindSrc_DepartmentToEmployee);
            }
        }

        private void _bindingEmployeeDetails(object dataSource)
        {
            if(dataSource == null) return;
            ec_FirstName.DataBindings.Add(new Binding("Value", dataSource, ec_FirstName.AttributeName));
            ec_SurName.DataBindings.Add(new Binding("Value", dataSource, ec_SurName.AttributeName));
            ec_Patronymic.DataBindings.Add(new Binding("Value", dataSource, ec_Patronymic.AttributeName));
            //ec_DepartmentName.DataBindings.Add(new Binding("Value", dataSource, ec_DepartmentName.AttributeName));
            ec_Position.DataBindings.Add(new Binding("Value", dataSource, ec_Position.AttributeName));
            ec_DocNumber.DataBindings.Add(new Binding("Value", dataSource, ec_DocNumber.AttributeName));
            ec_DocSeries.DataBindings.Add(new Binding("Value", dataSource, ec_DocSeries.AttributeName));
            dtp_DateBirth.DataBindings.Add(new Binding("Text", dataSource, "DateOfBirth"));
            bindSrc_DepartmentToEmployee.DataMemberChanged += BindSrcDepartmentToEmployeeOnDataMemberChanged;
        }

        private void BindSrcDepartmentToEmployeeOnDataMemberChanged(object sender, EventArgs eventArgs)
        {
            
        }

        private void _populateTreeView()
        {
            var list = tv_Department.Tag as IEnumerable<Department>;
            if(list == null) return;

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
            Guid.TryParse(row.ID.ToString(), out Guid nodeID);
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            entityDataSource_Org.SaveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            entityDataSource_Org.CancelChanges();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            entityDataSource_Org.Refresh();

        }

        private void bindSrc_DepartmentToEmployee_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
