using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using TestDbApp.Model;
using EntitySet = TestDbApp.EntityFrameworkBinding.EntitySet;

namespace TestDbApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Load += OnLoad;
            tv_Department.AfterSelect += TvDepartmentOnAfterSelect;
        }

        private void TvDepartmentOnAfterSelect(object sender, TreeViewEventArgs treeViewEventArgs)
        {
            var selectedNode = tv_Department.SelectedNode;
            Department selDepartment = selectedNode.Tag as Department;
            if(selDepartment == null) return;

            var employees = new List<Employee>();

            var l = entityDataSource1.EntitySets["Departments"].Cast<Department>().ToList();
            
            _getEmployees(employees, selDepartment, l);
            var bl = entityDataSource1.CreateView(employees);
            dgv_EmployeeToDepartment.DataSource = bl;
        }

        private void _getEmployees(List<Employee> employees, Department dep, IEnumerable<Department> departments)
        {
            var ds = (from Department d in departments
                         where d.ParentDepartmentID == dep.ID
                         select d);


            employees.AddRange(dep.Employees);
            foreach (var item in ds)
            {
                _getEmployees(employees, item, departments);
            }
        }

        private void OnLoad(object sender, EventArgs eventArgs)
        {
            var bind = new Binding("Tag", entityDataSource1, "Departments");
            tv_Department.DataBindings.Add(bind);
            _populateTreeView();
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
                var node = _getTreeNode(rootNode, departments);
                node.Expand();
                tv_Department.Nodes.Add(node);
            }
        }

        private TreeNode _getTreeNode(Department row, IEnumerable<Department> list)
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
                var chNode = _getTreeNode(item, list);
                chNode.Text = Convert.ToString(item.Name);
                node.Nodes.Add(chNode);
            }
            return node;
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
