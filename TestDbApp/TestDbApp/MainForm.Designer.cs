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
            this.splCnt_Organization = new System.Windows.Forms.SplitContainer();
            this.tc_Organization = new System.Windows.Forms.TabControl();
            this.tp_Department = new System.Windows.Forms.TabPage();
            this.splCnt = new System.Windows.Forms.SplitContainer();
            this.tv_Department = new System.Windows.Forms.TreeView();
            this.gb_Employee = new System.Windows.Forms.GroupBox();
            this.tb_Age = new System.Windows.Forms.TextBox();
            this.l_Age = new System.Windows.Forms.Label();
            this.lDepartment = new System.Windows.Forms.Label();
            this.lPosition = new System.Windows.Forms.Label();
            this.lSurName = new System.Windows.Forms.Label();
            this.lPatronymic = new System.Windows.Forms.Label();
            this.lFirstName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lDocNumber = new System.Windows.Forms.Label();
            this.lDocSeries = new System.Windows.Forms.Label();
            this.lDateOfBirth = new System.Windows.Forms.Label();
            this.dtp_DateBirth = new System.Windows.Forms.DateTimePicker();
            this.tp_Employee = new System.Windows.Forms.TabPage();
            this.p_Employee = new System.Windows.Forms.Panel();
            this.gb_EmployeeDetails = new System.Windows.Forms.GroupBox();
            this.tb_Department = new System.Windows.Forms.TextBox();
            this.l_Department = new System.Windows.Forms.Label();
            this.tb_Position = new System.Windows.Forms.TextBox();
            this.p_DocInfo = new System.Windows.Forms.Panel();
            this.l_DocNumber = new System.Windows.Forms.Label();
            this.l_DocSeries = new System.Windows.Forms.Label();
            this.tb_DocSeries = new System.Windows.Forms.TextBox();
            this.tb_DocNumber = new System.Windows.Forms.TextBox();
            this.l_Position = new System.Windows.Forms.Label();
            this.tb_Patronymic = new System.Windows.Forms.TextBox();
            this.l_Patronymic = new System.Windows.Forms.Label();
            this.tb_SurName = new System.Windows.Forms.TextBox();
            this.l_SurName = new System.Windows.Forms.Label();
            this.tb_FirstName = new System.Windows.Forms.TextBox();
            this.l_FirstName = new System.Windows.Forms.Label();
            this.l_DateOfBirth = new System.Windows.Forms.Label();
            this.dtp_DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.p_command = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bindSrc_DepartmentToEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.dgv_EmployeeToDepartment = new System.Windows.Forms.DataGridView();
            this.EmployeeOfDepatmentNavigator = new TestDbApp.EntityFrameworkBinding.EntityBindingNavigator();
            this.ec_DepartmentName = new TestDbApp.Common.EditControl();
            this.ec_Position = new TestDbApp.Common.EditControl();
            this.ec_Patronymic = new TestDbApp.Common.EditControl();
            this.ec_SurName = new TestDbApp.Common.EditControl();
            this.ec_FirstName = new TestDbApp.Common.EditControl();
            this.ec_DocSeries = new TestDbApp.Common.EditControl();
            this.ec_DocNumber = new TestDbApp.Common.EditControl();
            this.entityDataSource_Org = new TestDbApp.EntityFrameworkBinding.EntityDataSource(this.components);
            this.dgv_Employee = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfBirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docSeriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityBindingNavigator1 = new TestDbApp.EntityFrameworkBinding.EntityBindingNavigator();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymicDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfBirthDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docSeriesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splCnt_Organization)).BeginInit();
            this.splCnt_Organization.Panel1.SuspendLayout();
            this.splCnt_Organization.Panel2.SuspendLayout();
            this.splCnt_Organization.SuspendLayout();
            this.tc_Organization.SuspendLayout();
            this.tp_Department.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splCnt)).BeginInit();
            this.splCnt.Panel1.SuspendLayout();
            this.splCnt.Panel2.SuspendLayout();
            this.splCnt.SuspendLayout();
            this.gb_Employee.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tp_Employee.SuspendLayout();
            this.p_Employee.SuspendLayout();
            this.gb_EmployeeDetails.SuspendLayout();
            this.p_DocInfo.SuspendLayout();
            this.p_command.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc_DepartmentToEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeToDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employee)).BeginInit();
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
            this.splCnt_Organization.Size = new System.Drawing.Size(1271, 650);
            this.splCnt_Organization.SplitterDistance = 604;
            this.splCnt_Organization.TabIndex = 0;
            // 
            // tc_Organization
            // 
            this.tc_Organization.Controls.Add(this.tp_Department);
            this.tc_Organization.Controls.Add(this.tp_Employee);
            this.tc_Organization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Organization.Location = new System.Drawing.Point(0, 0);
            this.tc_Organization.Name = "tc_Organization";
            this.tc_Organization.SelectedIndex = 0;
            this.tc_Organization.Size = new System.Drawing.Size(1271, 604);
            this.tc_Organization.TabIndex = 0;
            // 
            // tp_Department
            // 
            this.tp_Department.Controls.Add(this.splCnt);
            this.tp_Department.Location = new System.Drawing.Point(4, 22);
            this.tp_Department.Name = "tp_Department";
            this.tp_Department.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Department.Size = new System.Drawing.Size(1263, 578);
            this.tp_Department.TabIndex = 0;
            this.tp_Department.Text = "Отделы";
            this.tp_Department.UseVisualStyleBackColor = true;
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
            this.splCnt.Panel2.Controls.Add(this.EmployeeOfDepatmentNavigator);
            this.splCnt.Panel2.Controls.Add(this.gb_Employee);
            this.splCnt.Size = new System.Drawing.Size(1257, 572);
            this.splCnt.SplitterDistance = 442;
            this.splCnt.TabIndex = 1;
            // 
            // tv_Department
            // 
            this.tv_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Department.Location = new System.Drawing.Point(0, 0);
            this.tv_Department.Name = "tv_Department";
            this.tv_Department.Size = new System.Drawing.Size(442, 572);
            this.tv_Department.TabIndex = 0;
            // 
            // gb_Employee
            // 
            this.gb_Employee.Controls.Add(this.tb_Age);
            this.gb_Employee.Controls.Add(this.l_Age);
            this.gb_Employee.Controls.Add(this.ec_DepartmentName);
            this.gb_Employee.Controls.Add(this.ec_Position);
            this.gb_Employee.Controls.Add(this.ec_Patronymic);
            this.gb_Employee.Controls.Add(this.ec_SurName);
            this.gb_Employee.Controls.Add(this.lDepartment);
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
            this.gb_Employee.Location = new System.Drawing.Point(0, 420);
            this.gb_Employee.Name = "gb_Employee";
            this.gb_Employee.Size = new System.Drawing.Size(811, 152);
            this.gb_Employee.TabIndex = 1;
            this.gb_Employee.TabStop = false;
            this.gb_Employee.Text = "Данные сотрудника";
            // 
            // tb_Age
            // 
            this.tb_Age.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Age.Location = new System.Drawing.Point(395, 117);
            this.tb_Age.Name = "tb_Age";
            this.tb_Age.Size = new System.Drawing.Size(49, 20);
            this.tb_Age.TabIndex = 47;
            this.tb_Age.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_Age
            // 
            this.l_Age.AutoSize = true;
            this.l_Age.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Age.Location = new System.Drawing.Point(274, 120);
            this.l_Age.Name = "l_Age";
            this.l_Age.Size = new System.Drawing.Size(115, 13);
            this.l_Age.TabIndex = 46;
            this.l_Age.Text = "Возраст (полных лет)";
            // 
            // lDepartment
            // 
            this.lDepartment.AutoSize = true;
            this.lDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDepartment.Location = new System.Drawing.Point(274, 62);
            this.lDepartment.Name = "lDepartment";
            this.lDepartment.Size = new System.Drawing.Size(38, 13);
            this.lDepartment.TabIndex = 41;
            this.lDepartment.Text = "Отдел";
            this.lDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lPosition
            // 
            this.lPosition.AutoSize = true;
            this.lPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPosition.Location = new System.Drawing.Point(274, 36);
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
            this.lPatronymic.Location = new System.Drawing.Point(16, 86);
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
            this.panel1.Location = new System.Drawing.Point(527, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 75);
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
            this.lDateOfBirth.Location = new System.Drawing.Point(16, 120);
            this.lDateOfBirth.Name = "lDateOfBirth";
            this.lDateOfBirth.Size = new System.Drawing.Size(86, 13);
            this.lDateOfBirth.TabIndex = 19;
            this.lDateOfBirth.Text = "Дата рождения";
            this.lDateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_DateBirth
            // 
            this.dtp_DateBirth.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.entityDataSource_Org, "Employees.DateOfBirth", true));
            this.dtp_DateBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtp_DateBirth.Location = new System.Drawing.Point(112, 120);
            this.dtp_DateBirth.Name = "dtp_DateBirth";
            this.dtp_DateBirth.Size = new System.Drawing.Size(148, 20);
            this.dtp_DateBirth.TabIndex = 18;
            // 
            // tp_Employee
            // 
            this.tp_Employee.Controls.Add(this.p_Employee);
            this.tp_Employee.Controls.Add(this.gb_EmployeeDetails);
            this.tp_Employee.Location = new System.Drawing.Point(4, 22);
            this.tp_Employee.Name = "tp_Employee";
            this.tp_Employee.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Employee.Size = new System.Drawing.Size(1263, 578);
            this.tp_Employee.TabIndex = 1;
            this.tp_Employee.Text = "Сотрудники";
            this.tp_Employee.UseVisualStyleBackColor = true;
            // 
            // p_Employee
            // 
            this.p_Employee.Controls.Add(this.dgv_Employee);
            this.p_Employee.Controls.Add(this.entityBindingNavigator1);
            this.p_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Employee.Location = new System.Drawing.Point(3, 3);
            this.p_Employee.Name = "p_Employee";
            this.p_Employee.Size = new System.Drawing.Size(974, 572);
            this.p_Employee.TabIndex = 2;
            // 
            // gb_EmployeeDetails
            // 
            this.gb_EmployeeDetails.Controls.Add(this.tb_Department);
            this.gb_EmployeeDetails.Controls.Add(this.l_Department);
            this.gb_EmployeeDetails.Controls.Add(this.tb_Position);
            this.gb_EmployeeDetails.Controls.Add(this.p_DocInfo);
            this.gb_EmployeeDetails.Controls.Add(this.l_Position);
            this.gb_EmployeeDetails.Controls.Add(this.tb_Patronymic);
            this.gb_EmployeeDetails.Controls.Add(this.l_Patronymic);
            this.gb_EmployeeDetails.Controls.Add(this.tb_SurName);
            this.gb_EmployeeDetails.Controls.Add(this.l_SurName);
            this.gb_EmployeeDetails.Controls.Add(this.tb_FirstName);
            this.gb_EmployeeDetails.Controls.Add(this.l_FirstName);
            this.gb_EmployeeDetails.Controls.Add(this.l_DateOfBirth);
            this.gb_EmployeeDetails.Controls.Add(this.dtp_DateOfBirth);
            this.gb_EmployeeDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.gb_EmployeeDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_EmployeeDetails.Location = new System.Drawing.Point(977, 3);
            this.gb_EmployeeDetails.Name = "gb_EmployeeDetails";
            this.gb_EmployeeDetails.Size = new System.Drawing.Size(283, 572);
            this.gb_EmployeeDetails.TabIndex = 3;
            this.gb_EmployeeDetails.TabStop = false;
            this.gb_EmployeeDetails.Text = "Данные сотрудника";
            // 
            // tb_Department
            // 
            this.tb_Department.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource_Org, "Employees.DepartmentName", true));
            this.tb_Department.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Department.Location = new System.Drawing.Point(125, 160);
            this.tb_Department.Name = "tb_Department";
            this.tb_Department.Size = new System.Drawing.Size(142, 20);
            this.tb_Department.TabIndex = 17;
            // 
            // l_Department
            // 
            this.l_Department.AutoSize = true;
            this.l_Department.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Department.Location = new System.Drawing.Point(23, 159);
            this.l_Department.Name = "l_Department";
            this.l_Department.Size = new System.Drawing.Size(38, 13);
            this.l_Department.TabIndex = 16;
            this.l_Department.Text = "Отдел";
            this.l_Department.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Position
            // 
            this.tb_Position.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource_Org, "Employees.Position", true));
            this.tb_Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Position.Location = new System.Drawing.Point(125, 134);
            this.tb_Position.Name = "tb_Position";
            this.tb_Position.Size = new System.Drawing.Size(142, 20);
            this.tb_Position.TabIndex = 15;
            // 
            // p_DocInfo
            // 
            this.p_DocInfo.BackColor = System.Drawing.SystemColors.Control;
            this.p_DocInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_DocInfo.Controls.Add(this.l_DocNumber);
            this.p_DocInfo.Controls.Add(this.l_DocSeries);
            this.p_DocInfo.Controls.Add(this.tb_DocSeries);
            this.p_DocInfo.Controls.Add(this.tb_DocNumber);
            this.p_DocInfo.Location = new System.Drawing.Point(6, 197);
            this.p_DocInfo.Name = "p_DocInfo";
            this.p_DocInfo.Size = new System.Drawing.Size(261, 76);
            this.p_DocInfo.TabIndex = 14;
            // 
            // l_DocNumber
            // 
            this.l_DocNumber.AutoSize = true;
            this.l_DocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_DocNumber.Location = new System.Drawing.Point(12, 16);
            this.l_DocNumber.Name = "l_DocNumber";
            this.l_DocNumber.Size = new System.Drawing.Size(98, 13);
            this.l_DocNumber.TabIndex = 10;
            this.l_DocNumber.Text = "Номер документа";
            this.l_DocNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_DocSeries
            // 
            this.l_DocSeries.AutoSize = true;
            this.l_DocSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_DocSeries.Location = new System.Drawing.Point(12, 42);
            this.l_DocSeries.Name = "l_DocSeries";
            this.l_DocSeries.Size = new System.Drawing.Size(95, 13);
            this.l_DocSeries.TabIndex = 8;
            this.l_DocSeries.Text = "Серия документа";
            this.l_DocSeries.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_DocSeries
            // 
            this.tb_DocSeries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource_Org, "Employees.DocNumber", true));
            this.tb_DocSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_DocSeries.Location = new System.Drawing.Point(114, 39);
            this.tb_DocSeries.Name = "tb_DocSeries";
            this.tb_DocSeries.Size = new System.Drawing.Size(142, 20);
            this.tb_DocSeries.TabIndex = 9;
            // 
            // tb_DocNumber
            // 
            this.tb_DocNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource_Org, "Employees.DocSeries", true));
            this.tb_DocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_DocNumber.Location = new System.Drawing.Point(114, 13);
            this.tb_DocNumber.Name = "tb_DocNumber";
            this.tb_DocNumber.Size = new System.Drawing.Size(142, 20);
            this.tb_DocNumber.TabIndex = 11;
            // 
            // l_Position
            // 
            this.l_Position.AutoSize = true;
            this.l_Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Position.Location = new System.Drawing.Point(23, 133);
            this.l_Position.Name = "l_Position";
            this.l_Position.Size = new System.Drawing.Size(65, 13);
            this.l_Position.TabIndex = 12;
            this.l_Position.Text = "Должность";
            this.l_Position.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Patronymic
            // 
            this.tb_Patronymic.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource_Org, "Employees.Patronymic", true));
            this.tb_Patronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Patronymic.Location = new System.Drawing.Point(125, 55);
            this.tb_Patronymic.Name = "tb_Patronymic";
            this.tb_Patronymic.Size = new System.Drawing.Size(142, 20);
            this.tb_Patronymic.TabIndex = 7;
            // 
            // l_Patronymic
            // 
            this.l_Patronymic.AutoSize = true;
            this.l_Patronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Patronymic.Location = new System.Drawing.Point(23, 58);
            this.l_Patronymic.Name = "l_Patronymic";
            this.l_Patronymic.Size = new System.Drawing.Size(54, 13);
            this.l_Patronymic.TabIndex = 6;
            this.l_Patronymic.Text = "Отчество";
            this.l_Patronymic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_SurName
            // 
            this.tb_SurName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource_Org, "Employees.SurName", true));
            this.tb_SurName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_SurName.Location = new System.Drawing.Point(125, 82);
            this.tb_SurName.Name = "tb_SurName";
            this.tb_SurName.Size = new System.Drawing.Size(142, 20);
            this.tb_SurName.TabIndex = 5;
            // 
            // l_SurName
            // 
            this.l_SurName.AutoSize = true;
            this.l_SurName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_SurName.Location = new System.Drawing.Point(21, 85);
            this.l_SurName.Name = "l_SurName";
            this.l_SurName.Size = new System.Drawing.Size(56, 13);
            this.l_SurName.TabIndex = 4;
            this.l_SurName.Text = "Фамилия";
            this.l_SurName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_FirstName
            // 
            this.tb_FirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource_Org, "Employees.FirstName", true));
            this.tb_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_FirstName.Location = new System.Drawing.Point(125, 29);
            this.tb_FirstName.Name = "tb_FirstName";
            this.tb_FirstName.Size = new System.Drawing.Size(142, 20);
            this.tb_FirstName.TabIndex = 3;
            // 
            // l_FirstName
            // 
            this.l_FirstName.AutoSize = true;
            this.l_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_FirstName.Location = new System.Drawing.Point(23, 32);
            this.l_FirstName.Name = "l_FirstName";
            this.l_FirstName.Size = new System.Drawing.Size(29, 13);
            this.l_FirstName.TabIndex = 2;
            this.l_FirstName.Text = "Имя";
            this.l_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_DateOfBirth
            // 
            this.l_DateOfBirth.AutoSize = true;
            this.l_DateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_DateOfBirth.Location = new System.Drawing.Point(23, 108);
            this.l_DateOfBirth.Name = "l_DateOfBirth";
            this.l_DateOfBirth.Size = new System.Drawing.Size(86, 13);
            this.l_DateOfBirth.TabIndex = 1;
            this.l_DateOfBirth.Text = "Дата рождения";
            this.l_DateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_DateOfBirth
            // 
            this.dtp_DateOfBirth.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.entityDataSource_Org, "Employees.DateOfBirth", true));
            this.dtp_DateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtp_DateOfBirth.Location = new System.Drawing.Point(125, 108);
            this.dtp_DateOfBirth.Name = "dtp_DateOfBirth";
            this.dtp_DateOfBirth.Size = new System.Drawing.Size(142, 20);
            this.dtp_DateOfBirth.TabIndex = 0;
            // 
            // p_command
            // 
            this.p_command.Controls.Add(this.btnSave);
            this.p_command.Controls.Add(this.btnRefresh);
            this.p_command.Controls.Add(this.btnCancel);
            this.p_command.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_command.Location = new System.Drawing.Point(974, 0);
            this.p_command.Name = "p_command";
            this.p_command.Size = new System.Drawing.Size(297, 42);
            this.p_command.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(209, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(109, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgv_EmployeeToDepartment
            // 
            this.dgv_EmployeeToDepartment.AutoGenerateColumns = false;
            this.dgv_EmployeeToDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmployeeToDepartment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.departmentIDDataGridViewTextBoxColumn1,
            this.surNameDataGridViewTextBoxColumn1,
            this.firstNameDataGridViewTextBoxColumn1,
            this.patronymicDataGridViewTextBoxColumn1,
            this.dateOfBirthDataGridViewTextBoxColumn1,
            this.docSeriesDataGridViewTextBoxColumn1,
            this.docNumberDataGridViewTextBoxColumn1,
            this.positionDataGridViewTextBoxColumn1,
            this.departmentDataGridViewTextBoxColumn1,
            this.departmentNameDataGridViewTextBoxColumn});
            this.dgv_EmployeeToDepartment.DataMember = "Employees";
            this.dgv_EmployeeToDepartment.DataSource = this.entityDataSource_Org;
            this.dgv_EmployeeToDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_EmployeeToDepartment.Location = new System.Drawing.Point(0, 25);
            this.dgv_EmployeeToDepartment.Name = "dgv_EmployeeToDepartment";
            this.dgv_EmployeeToDepartment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmployeeToDepartment.Size = new System.Drawing.Size(811, 395);
            this.dgv_EmployeeToDepartment.TabIndex = 0;
            // 
            // EmployeeOfDepatmentNavigator
            // 
            this.EmployeeOfDepatmentNavigator.Location = new System.Drawing.Point(0, 0);
            this.EmployeeOfDepatmentNavigator.Name = "EmployeeOfDepatmentNavigator";
            this.EmployeeOfDepatmentNavigator.Size = new System.Drawing.Size(811, 25);
            this.EmployeeOfDepatmentNavigator.TabIndex = 2;
            this.EmployeeOfDepatmentNavigator.Text = "entityBindingNavigator1";
            // 
            // ec_DepartmentName
            // 
            this.ec_DepartmentName.AttributeName = "DepartmentName";
            this.ec_DepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_DepartmentName.Location = new System.Drawing.Point(345, 55);
            this.ec_DepartmentName.Multiline = false;
            this.ec_DepartmentName.Name = "ec_DepartmentName";
            this.ec_DepartmentName.Size = new System.Drawing.Size(166, 22);
            this.ec_DepartmentName.TabIndex = 45;
            this.ec_DepartmentName.Value = "";
            // 
            // ec_Position
            // 
            this.ec_Position.AttributeName = "Position";
            this.ec_Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_Position.Location = new System.Drawing.Point(345, 29);
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
            this.ec_Patronymic.Location = new System.Drawing.Point(112, 86);
            this.ec_Patronymic.Multiline = false;
            this.ec_Patronymic.Name = "ec_Patronymic";
            this.ec_Patronymic.Size = new System.Drawing.Size(148, 22);
            this.ec_Patronymic.TabIndex = 43;
            this.ec_Patronymic.Value = "";
            // 
            // ec_SurName
            // 
            this.ec_SurName.AttributeName = "SurName";
            this.ec_SurName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_SurName.Location = new System.Drawing.Point(112, 29);
            this.ec_SurName.Multiline = false;
            this.ec_SurName.Name = "ec_SurName";
            this.ec_SurName.Size = new System.Drawing.Size(148, 20);
            this.ec_SurName.TabIndex = 42;
            this.ec_SurName.Value = "";
            // 
            // ec_FirstName
            // 
            this.ec_FirstName.AttributeName = "FirstName";
            this.ec_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_FirstName.Location = new System.Drawing.Point(112, 55);
            this.ec_FirstName.Multiline = false;
            this.ec_FirstName.Name = "ec_FirstName";
            this.ec_FirstName.Size = new System.Drawing.Size(148, 20);
            this.ec_FirstName.TabIndex = 36;
            this.ec_FirstName.Value = "";
            // 
            // ec_DocSeries
            // 
            this.ec_DocSeries.AccessibleName = "";
            this.ec_DocSeries.AttributeName = "DocSeries";
            this.ec_DocSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_DocSeries.Location = new System.Drawing.Point(116, 37);
            this.ec_DocSeries.Multiline = false;
            this.ec_DocSeries.Name = "ec_DocSeries";
            this.ec_DocSeries.Size = new System.Drawing.Size(148, 22);
            this.ec_DocSeries.TabIndex = 45;
            this.ec_DocSeries.Value = "";
            // 
            // ec_DocNumber
            // 
            this.ec_DocNumber.AccessibleName = "";
            this.ec_DocNumber.AttributeName = "DocNumber";
            this.ec_DocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ec_DocNumber.Location = new System.Drawing.Point(116, 7);
            this.ec_DocNumber.Multiline = false;
            this.ec_DocNumber.Name = "ec_DocNumber";
            this.ec_DocNumber.Size = new System.Drawing.Size(148, 22);
            this.ec_DocNumber.TabIndex = 44;
            this.ec_DocNumber.Value = "";
            // 
            // entityDataSource_Org
            // 
            this.entityDataSource_Org.DbContextType = typeof(TestDbApp.Model.TestDbContext);
            // 
            // dgv_Employee
            // 
            this.dgv_Employee.AutoGenerateColumns = false;
            this.dgv_Employee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Employee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.departmentIDDataGridViewTextBoxColumn,
            this.surNameDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.patronymicDataGridViewTextBoxColumn,
            this.dateOfBirthDataGridViewTextBoxColumn,
            this.docSeriesDataGridViewTextBoxColumn,
            this.docNumberDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.departmentDataGridViewTextBoxColumn});
            this.dgv_Employee.DataMember = "Employees";
            this.dgv_Employee.DataSource = this.entityDataSource_Org;
            this.dgv_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Employee.Location = new System.Drawing.Point(0, 25);
            this.dgv_Employee.Name = "dgv_Employee";
            this.dgv_Employee.Size = new System.Drawing.Size(974, 547);
            this.dgv_Employee.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // departmentIDDataGridViewTextBoxColumn
            // 
            this.departmentIDDataGridViewTextBoxColumn.DataPropertyName = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn.HeaderText = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn.Name = "departmentIDDataGridViewTextBoxColumn";
            this.departmentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // surNameDataGridViewTextBoxColumn
            // 
            this.surNameDataGridViewTextBoxColumn.DataPropertyName = "SurName";
            this.surNameDataGridViewTextBoxColumn.HeaderText = "SurName";
            this.surNameDataGridViewTextBoxColumn.Name = "surNameDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // patronymicDataGridViewTextBoxColumn
            // 
            this.patronymicDataGridViewTextBoxColumn.DataPropertyName = "Patronymic";
            this.patronymicDataGridViewTextBoxColumn.HeaderText = "Patronymic";
            this.patronymicDataGridViewTextBoxColumn.Name = "patronymicDataGridViewTextBoxColumn";
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            this.dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            this.dateOfBirthDataGridViewTextBoxColumn.HeaderText = "DateOfBirth";
            this.dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            this.dateOfBirthDataGridViewTextBoxColumn.Visible = false;
            // 
            // docSeriesDataGridViewTextBoxColumn
            // 
            this.docSeriesDataGridViewTextBoxColumn.DataPropertyName = "DocSeries";
            this.docSeriesDataGridViewTextBoxColumn.HeaderText = "DocSeries";
            this.docSeriesDataGridViewTextBoxColumn.Name = "docSeriesDataGridViewTextBoxColumn";
            this.docSeriesDataGridViewTextBoxColumn.Visible = false;
            // 
            // docNumberDataGridViewTextBoxColumn
            // 
            this.docNumberDataGridViewTextBoxColumn.DataPropertyName = "DocNumber";
            this.docNumberDataGridViewTextBoxColumn.HeaderText = "DocNumber";
            this.docNumberDataGridViewTextBoxColumn.Name = "docNumberDataGridViewTextBoxColumn";
            this.docNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Department";
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            this.departmentDataGridViewTextBoxColumn.Visible = false;
            // 
            // entityBindingNavigator1
            // 
            this.entityBindingNavigator1.DataMember = "Employees";
            this.entityBindingNavigator1.DataSource = this.entityDataSource_Org;
            this.entityBindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.entityBindingNavigator1.Name = "entityBindingNavigator1";
            this.entityBindingNavigator1.Size = new System.Drawing.Size(974, 25);
            this.entityBindingNavigator1.TabIndex = 1;
            this.entityBindingNavigator1.Text = "entityBindingNavigator1";
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            // 
            // departmentIDDataGridViewTextBoxColumn1
            // 
            this.departmentIDDataGridViewTextBoxColumn1.DataPropertyName = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn1.HeaderText = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn1.Name = "departmentIDDataGridViewTextBoxColumn1";
            // 
            // surNameDataGridViewTextBoxColumn1
            // 
            this.surNameDataGridViewTextBoxColumn1.DataPropertyName = "SurName";
            this.surNameDataGridViewTextBoxColumn1.HeaderText = "SurName";
            this.surNameDataGridViewTextBoxColumn1.Name = "surNameDataGridViewTextBoxColumn1";
            // 
            // firstNameDataGridViewTextBoxColumn1
            // 
            this.firstNameDataGridViewTextBoxColumn1.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn1.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn1.Name = "firstNameDataGridViewTextBoxColumn1";
            // 
            // patronymicDataGridViewTextBoxColumn1
            // 
            this.patronymicDataGridViewTextBoxColumn1.DataPropertyName = "Patronymic";
            this.patronymicDataGridViewTextBoxColumn1.HeaderText = "Patronymic";
            this.patronymicDataGridViewTextBoxColumn1.Name = "patronymicDataGridViewTextBoxColumn1";
            // 
            // dateOfBirthDataGridViewTextBoxColumn1
            // 
            this.dateOfBirthDataGridViewTextBoxColumn1.DataPropertyName = "DateOfBirth";
            this.dateOfBirthDataGridViewTextBoxColumn1.HeaderText = "DateOfBirth";
            this.dateOfBirthDataGridViewTextBoxColumn1.Name = "dateOfBirthDataGridViewTextBoxColumn1";
            // 
            // docSeriesDataGridViewTextBoxColumn1
            // 
            this.docSeriesDataGridViewTextBoxColumn1.DataPropertyName = "DocSeries";
            this.docSeriesDataGridViewTextBoxColumn1.HeaderText = "DocSeries";
            this.docSeriesDataGridViewTextBoxColumn1.Name = "docSeriesDataGridViewTextBoxColumn1";
            // 
            // docNumberDataGridViewTextBoxColumn1
            // 
            this.docNumberDataGridViewTextBoxColumn1.DataPropertyName = "DocNumber";
            this.docNumberDataGridViewTextBoxColumn1.HeaderText = "DocNumber";
            this.docNumberDataGridViewTextBoxColumn1.Name = "docNumberDataGridViewTextBoxColumn1";
            // 
            // positionDataGridViewTextBoxColumn1
            // 
            this.positionDataGridViewTextBoxColumn1.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn1.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn1.Name = "positionDataGridViewTextBoxColumn1";
            // 
            // departmentDataGridViewTextBoxColumn1
            // 
            this.departmentDataGridViewTextBoxColumn1.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn1.HeaderText = "Department";
            this.departmentDataGridViewTextBoxColumn1.Name = "departmentDataGridViewTextBoxColumn1";
            // 
            // departmentNameDataGridViewTextBoxColumn
            // 
            this.departmentNameDataGridViewTextBoxColumn.DataPropertyName = "DepartmentName";
            this.departmentNameDataGridViewTextBoxColumn.HeaderText = "DepartmentName";
            this.departmentNameDataGridViewTextBoxColumn.Name = "departmentNameDataGridViewTextBoxColumn";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 650);
            this.Controls.Add(this.splCnt_Organization);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Структура организации";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splCnt_Organization.Panel1.ResumeLayout(false);
            this.splCnt_Organization.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splCnt_Organization)).EndInit();
            this.splCnt_Organization.ResumeLayout(false);
            this.tc_Organization.ResumeLayout(false);
            this.tp_Department.ResumeLayout(false);
            this.splCnt.Panel1.ResumeLayout(false);
            this.splCnt.Panel2.ResumeLayout(false);
            this.splCnt.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splCnt)).EndInit();
            this.splCnt.ResumeLayout(false);
            this.gb_Employee.ResumeLayout(false);
            this.gb_Employee.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tp_Employee.ResumeLayout(false);
            this.p_Employee.ResumeLayout(false);
            this.p_Employee.PerformLayout();
            this.gb_EmployeeDetails.ResumeLayout(false);
            this.gb_EmployeeDetails.PerformLayout();
            this.p_DocInfo.ResumeLayout(false);
            this.p_DocInfo.PerformLayout();
            this.p_command.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc_DepartmentToEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeToDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EntityFrameworkBinding.EntityDataSource entityDataSource_Org;
        private System.Windows.Forms.SplitContainer splCnt_Organization;
        private System.Windows.Forms.TabControl tc_Organization;
        private System.Windows.Forms.TabPage tp_Department;
        private System.Windows.Forms.TabPage tp_Employee;
        private System.Windows.Forms.Panel p_Employee;
        private System.Windows.Forms.DataGridView dgv_Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docSeriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gb_EmployeeDetails;
        private System.Windows.Forms.Label l_FirstName;
        private System.Windows.Forms.Label l_DateOfBirth;
        private System.Windows.Forms.DateTimePicker dtp_DateOfBirth;
        private System.Windows.Forms.TextBox tb_Patronymic;
        private System.Windows.Forms.Label l_Patronymic;
        private System.Windows.Forms.TextBox tb_SurName;
        private System.Windows.Forms.Label l_SurName;
        private System.Windows.Forms.TextBox tb_FirstName;
        private System.Windows.Forms.TextBox tb_DocNumber;
        private System.Windows.Forms.Label l_DocNumber;
        private System.Windows.Forms.TextBox tb_DocSeries;
        private System.Windows.Forms.Label l_DocSeries;
        private System.Windows.Forms.Label l_Position;
        private System.Windows.Forms.Panel p_DocInfo;
        private System.Windows.Forms.TextBox tb_Position;
        private System.Windows.Forms.TreeView tv_Department;
        private System.Windows.Forms.TextBox tb_Department;
        private System.Windows.Forms.Label l_Department;
        private System.Windows.Forms.DataGridView dgv_EmployeeToDepartment;
        private System.Windows.Forms.SplitContainer splCnt;
        private System.Windows.Forms.GroupBox gb_Employee;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtp_DateBirth;
        private System.Windows.Forms.Panel p_command;
        private System.Windows.Forms.BindingSource bindSrc_DepartmentToEmployee;
        private EditControl ec_FirstName;
        private System.Windows.Forms.Label lFirstName;
        private System.Windows.Forms.Label lSurName;
        private System.Windows.Forms.Label lPatronymic;
        private System.Windows.Forms.Label lDepartment;
        private System.Windows.Forms.Label lPosition;
        private System.Windows.Forms.Label lDocNumber;
        private System.Windows.Forms.Label lDocSeries;
        private EditControl ec_SurName;
        private EditControl ec_Patronymic;
        private EditControl ec_DepartmentName;
        private EditControl ec_Position;
        private EditControl ec_DocSeries;
        private EditControl ec_DocNumber;
        private System.Windows.Forms.TextBox tb_Age;
        private System.Windows.Forms.Label l_Age;
        private EntityFrameworkBinding.EntityBindingNavigator EmployeeOfDepatmentNavigator;
        private EntityFrameworkBinding.EntityBindingNavigator entityBindingNavigator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn surNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymicDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn docSeriesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentNameDataGridViewTextBoxColumn;
    }
}

