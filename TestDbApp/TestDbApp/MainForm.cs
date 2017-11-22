using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
        }

        private void TvDepartmentOnAfterSelect(object sender, TreeViewEventArgs treeViewEventArgs)
        {
            var selectedNode = tv_Department.SelectedNode;
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
