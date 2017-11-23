using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDbApp.Common;
using TestDbApp.Model;

namespace TestDbApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Load += OnLoad;
            tv_Department.AfterSelect += TvDepartmentOnAfterSelect;
            //bindSrc_DepartmentToEmployee.DataMemberChanged += BindSrcDepartmentToEmployeeOnDataMemberChanged;
            bindSrc_DepartmentToEmployee.CurrentItemChanged += BindSrcDepartmentToEmployeeOnCurrentItemChanged;
            bindSrc_DepartmentToEmployee.CurrentChanged += BindSrcDepartmentToEmployeeOnCurrentChanged;
          
            dtp_DateBirth.ValueChanged += DtpDateBirthOnValueChanged;

            EmployeeOfDepatmentNavigator.DataSource = bindSrc_DepartmentToEmployee;
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
            bindSrc_DepartmentToEmployee.DataSource = bindingList;
            dgv_EmployeeToDepartment.DataSource = bindSrc_DepartmentToEmployee; 
            
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
                _bindingEmployeeDetails();
            }
        }

        private void _bindingEmployeeDetails()
        {
            ec_FirstName.DataBindings.Add(new Binding("Value", bindSrc_DepartmentToEmployee, ec_FirstName.AttributeName));
            ec_SurName.DataBindings.Add(new Binding("Value", bindSrc_DepartmentToEmployee, ec_SurName.AttributeName));
            ec_Patronymic.DataBindings.Add(new Binding("Value", bindSrc_DepartmentToEmployee, ec_Patronymic.AttributeName));
            ec_DepartmentName.DataBindings.Add(new Binding("Value", bindSrc_DepartmentToEmployee, ec_DepartmentName.AttributeName));
            ec_Position.DataBindings.Add(new Binding("Value", bindSrc_DepartmentToEmployee, ec_Position.AttributeName));
            ec_DocNumber.DataBindings.Add(new Binding("Value", bindSrc_DepartmentToEmployee, ec_DocNumber.AttributeName));
            ec_DocSeries.DataBindings.Add(new Binding("Value", bindSrc_DepartmentToEmployee, ec_DocSeries.AttributeName));
            dtp_DateBirth.DataBindings.Add(new Binding("Text", bindSrc_DepartmentToEmployee, "DateOfBirth"));
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

       
    }
}
