using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDbApp.EntityFrameworkBinding;
using TestDbApp.Model;

namespace TestDbApp
{
    public partial class MainForm : Form
    {
        private readonly string _conString;
        public MainForm(string nameOrConnectionString)
        {
            InitializeComponent();
            Load += OnLoad;
            Closing += OnClosing;
            Closed += OnClosed;
            _conString = nameOrConnectionString;
            tv_Department.AfterSelect += TvDepartmentOnAfterSelect;
        }

        #region Events

        private async void OnLoad(object sender, EventArgs eventArgs)
        {
            dgv_EmployeeToDepartment.AutoGenerateColumns = false;
            Cursor = Cursors.WaitCursor;
            //Создание компонента для привязки к источнику данных
            entityDataSource_Org = new EntityDataSource(components)
            {
                NameOrConnectionString = _conString,
                DbContextType = typeof(TestDbContext)
            };
            entityDataSource_Org.DataError += EntityDataSourceOrgOnDataError;
            entityDataSource_Org.SavingChanges += EntityDataSourceOrgOnSavingChanges;

            await Task.Run(() => entityDataSource_Org.EntitySets["Departments"].Query.Load());
            var bind = new Binding("Tag", entityDataSource_Org, "Departments");
            tv_Department.DataBindings.Add(bind);
            PopulateTreeView();
            if (tv_Department.Nodes.Count <= 0)
            {
                Cursor = DefaultCursor;
                return;
            }
                
            await entityDataSource_Org.EntitySets["Employees"].Query.LoadAsync();
            dgv_EmployeeToDepartment.DataSource = entityDataSource_Org;
            dgv_EmployeeToDepartment.DataMember = "Employees";

            cb_DepartmentToEmployee.DataSource = entityDataSource_Org;

            cb_DepartmentToEmployee.DisplayMember = "Departments.Name";
            cb_DepartmentToEmployee.ValueMember = "Departments.DepartmentId";

            tv_Department.SelectedNode = tv_Department.TopNode;
            BindingEmployeeDetails(bindSrc_DepartmentToEmployee);
            Cursor = DefaultCursor;
        }

        /// <summary>
        /// Обработчик перед закрытием формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cancelEventArgs"></param>
        /// <remarks>
        /// Проверяется наличие несохраненных данных
        /// </remarks>
        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            if (entityDataSource_Org?.DbContext == null)
                return;
            var isModified = entityDataSource_Org.DbContext.ChangeTracker
                .Entries().Any(e => e.State == EntityState.Modified);
            if (!isModified) return;

            var dialogRes = MessageBox.Show(this, @"Есть несохраненные данные. Сохранить?", @"Выход",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            switch (dialogRes)
            {
                case DialogResult.Yes:
                    entityDataSource_Org.SaveChanges();
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    cancelEventArgs.Cancel = true;
                    break;
            }
        }
  
        private void OnClosed(object sender, EventArgs eventArgs)
        {
            entityDataSource_Org?.DbContext?.Dispose();
        }

        /// <summary>
        /// Обработчик ошибок при загрузке или сохранении в базу данных 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void EntityDataSourceOrgOnDataError(object sender, DataErrorEventArgs args)
        {
            //string msgError;
            //var inExc = args.Exception.InnerException;
            //if (inExc?.InnerException != null)
            //{
            //    msgError = inExc.InnerException.Message;
            //}
            //else
            //{
            //    msgError = args.Exception.Message;
            //}
            //MessageBox.Show(this, msgError, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            var logDlg = new LogDlg(args.Exception);
            logDlg.ShowDialog(this);
            args.Handled = true;
        }

        private void EntityDataSourceOrgOnSavingChanges(object sender, CancelEventArgs cancelEventArgs)
        {
            var isModified = entityDataSource_Org.DbContext.ChangeTracker
                .Entries().Any(e => e.State == EntityState.Modified);
            cancelEventArgs.Cancel = !isModified;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            var countSaved = entityDataSource_Org.SaveChanges();
            if(countSaved != 0)
                TvDepartmentOnAfterSelect(null, new TreeViewEventArgs(tv_Department.SelectedNode));
        }

        /// <summary>
        /// Обработчик события нажатия кнопки отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if(entityDataSource_Org.EntitySets["Employees"].List != null)
                entityDataSource_Org.CancelChanges();
            bindSrc_DepartmentToEmployee.CancelEdit();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки обновления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (entityDataSource_Org.EntitySets["Employees"].List != null)
                entityDataSource_Org.Refresh();
        }

        /// <summary>
        /// Обработчик после выбора узла дерева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="treeViewEventArgs"></param>
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

        /// <summary>
        /// Получение списка сотрудников по отделу
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="dep"></param>
        private static void GetEmployees(List<Employee> employees, Department dep)
        {
            employees.AddRange(dep.Employees);
            foreach (var childDep in dep.Children)
            {
                GetEmployees(employees, childDep);
            }
        }

        /// <summary>
        /// Привязка элементов управления к источнику данных 
        /// </summary>
        /// <param name="dataSource"></param>
        private void BindingEmployeeDetails(ICollection dataSource)
        {
            dgv_EmployeeToDepartment.DataSource = dataSource;
            if (dataSource == null || dataSource.Count == 0) return;

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

        /// <summary>
        /// Формирование дерева отделов 
        /// </summary>
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
            Guid.TryParse(dep.DepartmentId.ToString(), out Guid nodeId);
            var node = new TreeNode
                       {
                           Text = Convert.ToString(dep.Name),
                           Tag = dep
                       };
            var res = list.Where(department => department.ParentDepartmentID == nodeId);
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
