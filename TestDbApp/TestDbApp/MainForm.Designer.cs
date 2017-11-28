using TestDbApp.Common;

namespace TestDbApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splCnt_Organization = new System.Windows.Forms.SplitContainer();
            this.tc_Organization = new System.Windows.Forms.TabControl();
            this.tp_DepartmentToEmployees = new System.Windows.Forms.TabPage();
            this.splCnt = new System.Windows.Forms.SplitContainer();
            this.tv_Department = new System.Windows.Forms.TreeView();
            this.dgv_EmployeeToDepartment = new System.Windows.Forms.DataGridView();
            this.bindNav_EmployeeToDepartment = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindSrc_DepartmentToEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem1 = new System.Windows.Forms.ToolStripButton();
            this.gb_Employee = new System.Windows.Forms.GroupBox();
            this.cb_DepartmentToEmployee = new System.Windows.Forms.ComboBox();
            this.lDepartment = new System.Windows.Forms.Label();
            this.tb_Age = new System.Windows.Forms.TextBox();
            this.l_Age = new System.Windows.Forms.Label();
            this.lPosition = new System.Windows.Forms.Label();
            this.lSurName = new System.Windows.Forms.Label();
            this.lPatronymic = new System.Windows.Forms.Label();
            this.lFirstName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lDocNumber = new System.Windows.Forms.Label();
            this.lDocSeries = new System.Windows.Forms.Label();
            this.lDateOfBirth = new System.Windows.Forms.Label();
            this.dtp_DateBirth = new System.Windows.Forms.DateTimePicker();
            this.p_command = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ec_Position = new TestDbApp.Common.EditControl();
            this.ec_Patronymic = new TestDbApp.Common.EditControl();
            this.ec_SurName = new TestDbApp.Common.EditControl();
            this.ec_FirstName = new TestDbApp.Common.EditControl();
            this.ec_DocSeries = new TestDbApp.Common.EditControl();
            this.ec_DocNumber = new TestDbApp.Common.EditControl();
            ((System.ComponentModel.ISupportInitialize)(this.splCnt_Organization)).BeginInit();
            this.splCnt_Organization.Panel1.SuspendLayout();
            this.splCnt_Organization.Panel2.SuspendLayout();
            this.splCnt_Organization.SuspendLayout();
            this.tc_Organization.SuspendLayout();
            this.tp_DepartmentToEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splCnt)).BeginInit();
            this.splCnt.Panel1.SuspendLayout();
            this.splCnt.Panel2.SuspendLayout();
            this.splCnt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeToDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindNav_EmployeeToDepartment)).BeginInit();
            this.bindNav_EmployeeToDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc_DepartmentToEmployee)).BeginInit();
            this.gb_Employee.SuspendLayout();
            this.panel1.SuspendLayout();
            this.p_command.SuspendLayout();
            this.SuspendLayout();
            // 
            // splCnt_Organization
            // 
            this.splCnt_Organization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splCnt_Organization.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splCnt_Organization.IsSplitterFixed = true;
            this.splCnt_Organization.Location = new System.Drawing.Point(0, 0);
            this.splCnt_Organization.Name = "splCnt_Organization";
            this.splCnt_Organization.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splCnt_Organization.Panel1
            // 
            this.splCnt_Organization.Panel1.Controls.Add(this.tc_Organization);
            // 
            // splCnt_Organization.Panel2
            // 
            this.splCnt_Organization.Panel2.Controls.Add(this.p_command);
            this.splCnt_Organization.Size = new System.Drawing.Size(1403, 650);
            this.splCnt_Organization.SplitterDistance = 604;
            this.splCnt_Organization.TabIndex = 0;
            // 
            // tc_Organization
            // 
            this.tc_Organization.Controls.Add(this.tp_DepartmentToEmployees);
            this.tc_Organization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Organization.Location = new System.Drawing.Point(0, 0);
            this.tc_Organization.Name = "tc_Organization";
            this.tc_Organization.SelectedIndex = 0;
            this.tc_Organization.Size = new System.Drawing.Size(1403, 604);
            this.tc_Organization.TabIndex = 0;
            // 
            // tp_DepartmentToEmployees
            // 
            this.tp_DepartmentToEmployees.Controls.Add(this.splCnt);
            this.tp_DepartmentToEmployees.Location = new System.Drawing.Point(4, 22);
            this.tp_DepartmentToEmployees.Name = "tp_DepartmentToEmployees";
            this.tp_DepartmentToEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tp_DepartmentToEmployees.Size = new System.Drawing.Size(1395, 578);
            this.tp_DepartmentToEmployees.TabIndex = 0;
            this.tp_DepartmentToEmployees.Text = "Структура предприятия";
            this.tp_DepartmentToEmployees.UseVisualStyleBackColor = true;
            // 
            // splCnt
            // 
            this.splCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splCnt.Location = new System.Drawing.Point(3, 3);
            this.splCnt.Name = "splCnt";
            // 
            // splCnt.Panel1
            // 
            this.splCnt.Panel1.Controls.Add(this.tv_Department);
            // 
            // splCnt.Panel2
            // 
            this.splCnt.Panel2.Controls.Add(this.dgv_EmployeeToDepartment);
            this.splCnt.Panel2.Controls.Add(this.bindNav_EmployeeToDepartment);
            this.splCnt.Panel2.Controls.Add(this.gb_Employee);
            this.splCnt.Size = new System.Drawing.Size(1389, 572);
            this.splCnt.SplitterDistance = 488;
            this.splCnt.TabIndex = 1;
            // 
            // tv_Department
            // 
            this.tv_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Department.HideSelection = false;
            this.tv_Department.Location = new System.Drawing.Point(0, 0);
            this.tv_Department.Name = "tv_Department";
            this.tv_Department.Size = new System.Drawing.Size(488, 572);
            this.tv_Department.TabIndex = 0;
            // 
            // dgv_EmployeeToDepartment
            // 
            this.dgv_EmployeeToDepartment.AllowUserToAddRows = false;
            this.dgv_EmployeeToDepartment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_EmployeeToDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmployeeToDepartment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.SurName,
            this.Patronymic,
            this.Position});
            this.dgv_EmployeeToDepartment.DataMember = "Employees";
            this.dgv_EmployeeToDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_EmployeeToDepartment.Location = new System.Drawing.Point(0, 25);
            this.dgv_EmployeeToDepartment.Name = "dgv_EmployeeToDepartment";
            this.dgv_EmployeeToDepartment.ReadOnly = true;
            this.dgv_EmployeeToDepartment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmployeeToDepartment.Size = new System.Drawing.Size(897, 371);
            this.dgv_EmployeeToDepartment.TabIndex = 0;
            // 
            // bindNav_EmployeeToDepartment
            // 
            this.bindNav_EmployeeToDepartment.AddNewItem = null;
            this.bindNav_EmployeeToDepartment.BindingSource = this.bindSrc_DepartmentToEmployee;
            this.bindNav_EmployeeToDepartment.CountItem = this.bindingNavigatorCountItem1;
            this.bindNav_EmployeeToDepartment.DeleteItem = null;
            this.bindNav_EmployeeToDepartment.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.bindNav_EmployeeToDepartment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorAddNewItem1,
            this.bindingNavigatorDeleteItem1});
            this.bindNav_EmployeeToDepartment.Location = new System.Drawing.Point(0, 0);
            this.bindNav_EmployeeToDepartment.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bindNav_EmployeeToDepartment.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bindNav_EmployeeToDepartment.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bindNav_EmployeeToDepartment.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bindNav_EmployeeToDepartment.Name = "bindNav_EmployeeToDepartment";
            this.bindNav_EmployeeToDepartment.PositionItem = this.bindingNavigatorPositionItem1;
            this.bindNav_EmployeeToDepartment.Size = new System.Drawing.Size(897, 25);
            this.bindNav_EmployeeToDepartment.TabIndex = 3;
            this.bindNav_EmployeeToDepartment.Text = "навигация по сотрудникам";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem1.Text = "для {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem1
            // 
            this.bindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem1.Enabled = false;
            this.bindingNavigatorAddNewItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem1.Image")));
            this.bindingNavigatorAddNewItem1.Name = "bindingNavigatorAddNewItem1";
            this.bindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem1.Text = "Добавить";
            this.bindingNavigatorAddNewItem1.Visible = false;
            // 
            // bindingNavigatorDeleteItem1
            // 
            this.bindingNavigatorDeleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem1.Enabled = false;
            this.bindingNavigatorDeleteItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem1.Image")));
            this.bindingNavigatorDeleteItem1.Name = "bindingNavigatorDeleteItem1";
            this.bindingNavigatorDeleteItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem1.Text = "Удалить";
            this.bindingNavigatorDeleteItem1.Visible = false;
            // 
            // gb_Employee
            // 
            this.gb_Employee.Controls.Add(this.label1);
            this.gb_Employee.Controls.Add(this.cb_DepartmentToEmployee);
            this.gb_Employee.Controls.Add(this.lDepartment);
            this.gb_Employee.Controls.Add(this.tb_Age);
            this.gb_Employee.Controls.Add(this.l_Age);
            this.gb_Employee.Controls.Add(this.ec_Position);
            this.gb_Employee.Controls.Add(this.ec_Patronymic);
            this.gb_Employee.Controls.Add(this.ec_SurName);
            this.gb_Employee.Controls.Add(this.lPosition);
            this.gb_Employee.Controls.Add(this.lSurName);
            this.gb_Employee.Controls.Add(this.lPatronymic);
            this.gb_Employee.Controls.Add(this.lFirstName);
            this.gb_Employee.Controls.Add(this.ec_FirstName);
            this.gb_Employee.Controls.Add(this.panel1);
            this.gb_Employee.Controls.Add(this.lDateOfBirth);
            this.gb_Employee.Controls.Add(this.dtp_DateBirth);
            this.gb_Employee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gb_Employee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_Employee.Location = new System.Drawing.Point(0, 396);
            this.gb_Employee.Name = "gb_Employee";
            this.gb_Employee.Size = new System.Drawing.Size(897, 176);
            this.gb_Employee.TabIndex = 1;
            this.gb_Employee.TabStop = false;
            this.gb_Employee.Text = "Данные сотрудника";
            // 
            // cb_DepartmentToEmployee
            // 
            this.cb_DepartmentToEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_DepartmentToEmployee.Location = new System.Drawing.Point(395, 55);
            this.cb_DepartmentToEmployee.Name = "cb_DepartmentToEmployee";
            this.cb_DepartmentToEmployee.Size = new System.Drawing.Size(166, 21);
            this.cb_DepartmentToEmployee.TabIndex = 49;
            // 
            // lDepartment
            // 
            this.lDepartment.AutoSize = true;
            this.lDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDepartment.Location = new System.Drawing.Point(311, 57);
            this.lDepartment.Name = "lDepartment";
            this.lDepartment.Size = new System.Drawing.Size(38, 13);
            this.lDepartment.TabIndex = 48;
            this.lDepartment.Text = "Отдел";
            this.lDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Age
            // 
            this.tb_Age.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Age.Location = new System.Drawing.Point(463, 120);
            this.tb_Age.Name = "tb_Age";
            this.tb_Age.ReadOnly = true;
            this.tb_Age.Size = new System.Drawing.Size(49, 20);
            this.tb_Age.TabIndex = 47;
            this.tb_Age.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_Age
            // 
            this.l_Age.AutoSize = true;
            this.l_Age.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Age.Location = new System.Drawing.Point(310, 125);
            this.l_Age.Name = "l_Age";
            this.l_Age.Size = new System.Drawing.Size(115, 13);
            this.l_Age.TabIndex = 46;
            this.l_Age.Text = "Возраст (полных лет)";
            // 
            // lPosition
            // 
            this.lPosition.AutoSize = true;
            this.lPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPosition.Location = new System.Drawing.Point(310, 33);
            this.lPosition.Name = "lPosition";
            this.lPosition.Size = new System.Drawing.Size(65, 13);
            this.lPosition.TabIndex = 40;
            this.lPosition.Text = "Должность";
            this.lPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSurName
            // 
            this.lSurName.AutoSize = true;
            this.lSurName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSurName.Location = new System.Drawing.Point(16, 36);
            this.lSurName.Name = "lSurName";
            this.lSurName.Size = new System.Drawing.Size(56, 13);
            this.lSurName.TabIndex = 39;
            this.lSurName.Text = "Фамилия";
            this.lSurName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lPatronymic
            // 
            this.lPatronymic.AutoSize = true;
            this.lPatronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPatronymic.Location = new System.Drawing.Point(16, 93);
            this.lPatronymic.Name = "lPatronymic";
            this.lPatronymic.Size = new System.Drawing.Size(54, 13);
            this.lPatronymic.TabIndex = 38;
            this.lPatronymic.Text = "Отчество";
            this.lPatronymic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lFirstName
            // 
            this.lFirstName.AutoSize = true;
            this.lFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lFirstName.Location = new System.Drawing.Point(16, 62);
            this.lFirstName.Name = "lFirstName";
            this.lFirstName.Size = new System.Drawing.Size(29, 13);
            this.lFirstName.TabIndex = 37;
            this.lFirstName.Text = "Имя";
            this.lFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ec_DocSeries);
            this.panel1.Controls.Add(this.ec_DocNumber);
            this.panel1.Controls.Add(this.lDocNumber);
            this.panel1.Controls.Add(this.lDocSeries);
            this.panel1.Location = new System.Drawing.Point(576, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 75);
            this.panel1.TabIndex = 27;
            // 
            // lDocNumber
            // 
            this.lDocNumber.AutoSize = true;
            this.lDocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDocNumber.Location = new System.Drawing.Point(12, 11);
            this.lDocNumber.Name = "lDocNumber";
            this.lDocNumber.Size = new System.Drawing.Size(98, 13);
            this.lDocNumber.TabIndex = 43;
            this.lDocNumber.Text = "Номер документа";
            this.lDocNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDocSeries
            // 
            this.lDocSeries.AutoSize = true;
            this.lDocSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDocSeries.Location = new System.Drawing.Point(12, 44);
            this.lDocSeries.Name = "lDocSeries";
            this.lDocSeries.Size = new System.Drawing.Size(95, 13);
            this.lDocSeries.TabIndex = 42;
            this.lDocSeries.Text = "Серия документа";
            this.lDocSeries.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDateOfBirth
            // 
            this.lDateOfBirth.AutoSize = true;
            this.lDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDateOfBirth.Location = new System.Drawing.Point(16, 124);
            this.lDateOfBirth.Name = "lDateOfBirth";
            this.lDateOfBirth.Size = new System.Drawing.Size(86, 13);
            this.lDateOfBirth.TabIndex = 19;
            this.lDateOfBirth.Text = "Дата рождения";
            this.lDateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_DateBirth
            // 
            this.dtp_DateBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtp_DateBirth.Location = new System.Drawing.Point(127, 124);
            this.dtp_DateBirth.Name = "dtp_DateBirth";
            this.dtp_DateBirth.Size = new System.Drawing.Size(158, 20);
            this.dtp_DateBirth.TabIndex = 18;
            // 
            // p_command
            // 
            this.p_command.Controls.Add(this.btnSave);
            this.p_command.Controls.Add(this.btnRefresh);
            this.p_command.Controls.Add(this.btnCancel);
            this.p_command.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_command.Location = new System.Drawing.Point(1134, 0);
            this.p_command.Name = "p_command";
            this.p_command.Size = new System.Drawing.Size(269, 42);
            this.p_command.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(11, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(180, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(99, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "! - обязательные поля";
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "Имя";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 54;
            // 
            // SurName
            // 
            this.SurName.DataPropertyName = "SurName";
            this.SurName.HeaderText = "Фамилия";
            this.SurName.Name = "SurName";
            this.SurName.ReadOnly = true;
            this.SurName.Width = 81;
            // 
            // Patronymic
            // 
            this.Patronymic.DataPropertyName = "Patronymic";
            this.Patronymic.HeaderText = "Отчество";
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.ReadOnly = true;
            this.Patronymic.Width = 79;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            this.Position.HeaderText = "Должность";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.Width = 90;
            // 
            // ec_Position
            // 
            this.ec_Position.AttributeName = "Position";
            this.ec_Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_Position.IsRequed = true;
            this.ec_Position.Location = new System.Drawing.Point(395, 26);
            this.ec_Position.MaxLen = 50;
            this.ec_Position.Multiline = false;
            this.ec_Position.Name = "ec_Position";
            this.ec_Position.Size = new System.Drawing.Size(166, 22);
            this.ec_Position.TabIndex = 44;
            this.ec_Position.Value = "";
            // 
            // ec_Patronymic
            // 
            this.ec_Patronymic.AttributeName = "Patronymic";
            this.ec_Patronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_Patronymic.IsRequed = false;
            this.ec_Patronymic.Location = new System.Drawing.Point(127, 88);
            this.ec_Patronymic.MaxLen = 50;
            this.ec_Patronymic.Multiline = false;
            this.ec_Patronymic.Name = "ec_Patronymic";
            this.ec_Patronymic.Size = new System.Drawing.Size(158, 22);
            this.ec_Patronymic.TabIndex = 43;
            this.ec_Patronymic.Value = "";
            // 
            // ec_SurName
            // 
            this.ec_SurName.AttributeName = "SurName";
            this.ec_SurName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_SurName.IsRequed = true;
            this.ec_SurName.Location = new System.Drawing.Point(127, 27);
            this.ec_SurName.MaxLen = 50;
            this.ec_SurName.Multiline = false;
            this.ec_SurName.Name = "ec_SurName";
            this.ec_SurName.Size = new System.Drawing.Size(158, 25);
            this.ec_SurName.TabIndex = 42;
            this.ec_SurName.Value = "";
            // 
            // ec_FirstName
            // 
            this.ec_FirstName.AttributeName = "FirstName";
            this.ec_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_FirstName.IsRequed = true;
            this.ec_FirstName.Location = new System.Drawing.Point(127, 59);
            this.ec_FirstName.MaxLen = 50;
            this.ec_FirstName.Multiline = false;
            this.ec_FirstName.Name = "ec_FirstName";
            this.ec_FirstName.Size = new System.Drawing.Size(158, 23);
            this.ec_FirstName.TabIndex = 36;
            this.ec_FirstName.Value = "";
            // 
            // ec_DocSeries
            // 
            this.ec_DocSeries.AccessibleName = "";
            this.ec_DocSeries.AttributeName = "DocSeries";
            this.ec_DocSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_DocSeries.IsRequed = false;
            this.ec_DocSeries.Location = new System.Drawing.Point(143, 41);
            this.ec_DocSeries.MaxLen = 4;
            this.ec_DocSeries.Multiline = false;
            this.ec_DocSeries.Name = "ec_DocSeries";
            this.ec_DocSeries.Size = new System.Drawing.Size(82, 22);
            this.ec_DocSeries.TabIndex = 45;
            this.ec_DocSeries.Value = "";
            // 
            // ec_DocNumber
            // 
            this.ec_DocNumber.AccessibleName = "";
            this.ec_DocNumber.AttributeName = "DocNumber";
            this.ec_DocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_DocNumber.IsRequed = false;
            this.ec_DocNumber.Location = new System.Drawing.Point(143, 11);
            this.ec_DocNumber.MaxLen = 6;
            this.ec_DocNumber.Multiline = false;
            this.ec_DocNumber.Name = "ec_DocNumber";
            this.ec_DocNumber.Size = new System.Drawing.Size(82, 22);
            this.ec_DocNumber.TabIndex = 44;
            this.ec_DocNumber.Value = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 650);
            this.Controls.Add(this.splCnt_Organization);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестовое приложение";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splCnt_Organization.Panel1.ResumeLayout(false);
            this.splCnt_Organization.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splCnt_Organization)).EndInit();
            this.splCnt_Organization.ResumeLayout(false);
            this.tc_Organization.ResumeLayout(false);
            this.tp_DepartmentToEmployees.ResumeLayout(false);
            this.splCnt.Panel1.ResumeLayout(false);
            this.splCnt.Panel2.ResumeLayout(false);
            this.splCnt.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splCnt)).EndInit();
            this.splCnt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeToDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindNav_EmployeeToDepartment)).EndInit();
            this.bindNav_EmployeeToDepartment.ResumeLayout(false);
            this.bindNav_EmployeeToDepartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc_DepartmentToEmployee)).EndInit();
            this.gb_Employee.ResumeLayout(false);
            this.gb_Employee.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.p_command.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EntityFrameworkBinding.EntityDataSource entityDataSource_Org;
        private System.Windows.Forms.SplitContainer splCnt_Organization;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel p_command;
        private System.Windows.Forms.BindingSource bindSrc_DepartmentToEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn1;
        private System.Windows.Forms.TabControl tc_Organization;
        private System.Windows.Forms.TabPage tp_DepartmentToEmployees;
        private System.Windows.Forms.SplitContainer splCnt;
        private System.Windows.Forms.TreeView tv_Department;
        private System.Windows.Forms.DataGridView dgv_EmployeeToDepartment;
        private System.Windows.Forms.BindingNavigator bindNav_EmployeeToDepartment;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.GroupBox gb_Employee;
        private System.Windows.Forms.ComboBox cb_DepartmentToEmployee;
        private System.Windows.Forms.Label lDepartment;
        private System.Windows.Forms.TextBox tb_Age;
        private System.Windows.Forms.Label l_Age;
        private EditControl ec_Position;
        private EditControl ec_Patronymic;
        private EditControl ec_SurName;
        private System.Windows.Forms.Label lPosition;
        private System.Windows.Forms.Label lSurName;
        private System.Windows.Forms.Label lPatronymic;
        private System.Windows.Forms.Label lFirstName;
        private EditControl ec_FirstName;
        private System.Windows.Forms.Panel panel1;
        private EditControl ec_DocSeries;
        private EditControl ec_DocNumber;
        private System.Windows.Forms.Label lDocNumber;
        private System.Windows.Forms.Label lDocSeries;
        private System.Windows.Forms.Label lDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtp_DateBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn surNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymicDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn docSeriesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn surNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
    }
}

