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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tc_Organization = new System.Windows.Forms.TabControl();
            this.tp_Department = new System.Windows.Forms.TabPage();
            this.tp_Employee = new System.Windows.Forms.TabPage();
            this.p_Employee = new System.Windows.Forms.Panel();
            this.gb_EmployeeDetails = new System.Windows.Forms.GroupBox();
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tb_Position = new System.Windows.Forms.TextBox();
            this.p_EmployeeToDepartment = new System.Windows.Forms.Panel();
            this.p_Department = new System.Windows.Forms.Panel();
            this.tv_Department = new System.Windows.Forms.TreeView();
            this.tb_Department = new System.Windows.Forms.TextBox();
            this.l_Department = new System.Windows.Forms.Label();
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
            this.entityDataSource1 = new TestDbApp.EntityFrameworkBinding.EntityDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tc_Organization.SuspendLayout();
            this.tp_Department.SuspendLayout();
            this.tp_Employee.SuspendLayout();
            this.p_Employee.SuspendLayout();
            this.gb_EmployeeDetails.SuspendLayout();
            this.p_DocInfo.SuspendLayout();
            this.p_Department.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employee)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tc_Organization);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(887, 650);
            this.splitContainer1.SplitterDistance = 572;
            this.splitContainer1.TabIndex = 0;
            // 
            // tc_Organization
            // 
            this.tc_Organization.Controls.Add(this.tp_Department);
            this.tc_Organization.Controls.Add(this.tp_Employee);
            this.tc_Organization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Organization.Location = new System.Drawing.Point(0, 0);
            this.tc_Organization.Name = "tc_Organization";
            this.tc_Organization.SelectedIndex = 0;
            this.tc_Organization.Size = new System.Drawing.Size(887, 572);
            this.tc_Organization.TabIndex = 0;
            // 
            // tp_Department
            // 
            this.tp_Department.Controls.Add(this.p_Department);
            this.tp_Department.Controls.Add(this.p_EmployeeToDepartment);
            this.tp_Department.Location = new System.Drawing.Point(4, 22);
            this.tp_Department.Name = "tp_Department";
            this.tp_Department.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Department.Size = new System.Drawing.Size(879, 546);
            this.tp_Department.TabIndex = 0;
            this.tp_Department.Text = "Отделы";
            this.tp_Department.UseVisualStyleBackColor = true;
            // 
            // tp_Employee
            // 
            this.tp_Employee.Controls.Add(this.p_Employee);
            this.tp_Employee.Controls.Add(this.gb_EmployeeDetails);
            this.tp_Employee.Location = new System.Drawing.Point(4, 22);
            this.tp_Employee.Name = "tp_Employee";
            this.tp_Employee.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Employee.Size = new System.Drawing.Size(879, 546);
            this.tp_Employee.TabIndex = 1;
            this.tp_Employee.Text = "Сотрудники";
            this.tp_Employee.UseVisualStyleBackColor = true;
            // 
            // p_Employee
            // 
            this.p_Employee.Controls.Add(this.dgv_Employee);
            this.p_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Employee.Location = new System.Drawing.Point(3, 3);
            this.p_Employee.Name = "p_Employee";
            this.p_Employee.Size = new System.Drawing.Size(597, 540);
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
            this.gb_EmployeeDetails.Location = new System.Drawing.Point(600, 3);
            this.gb_EmployeeDetails.Name = "gb_EmployeeDetails";
            this.gb_EmployeeDetails.Size = new System.Drawing.Size(276, 540);
            this.gb_EmployeeDetails.TabIndex = 3;
            this.gb_EmployeeDetails.TabStop = false;
            this.gb_EmployeeDetails.Text = "Данные сотрудника";
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
            this.tb_DocSeries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Employees.DocNumber", true));
            this.tb_DocSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_DocSeries.Location = new System.Drawing.Point(114, 39);
            this.tb_DocSeries.Name = "tb_DocSeries";
            this.tb_DocSeries.Size = new System.Drawing.Size(142, 20);
            this.tb_DocSeries.TabIndex = 9;
            // 
            // tb_DocNumber
            // 
            this.tb_DocNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Employees.DocSeries", true));
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
            this.tb_Patronymic.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Employees.Patronymic", true));
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
            this.tb_SurName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Employees.SurName", true));
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
            this.tb_FirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Employees.FirstName", true));
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
            this.dtp_DateOfBirth.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.entityDataSource1, "Employees.DateOfBirth", true));
            this.dtp_DateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtp_DateOfBirth.Location = new System.Drawing.Point(125, 108);
            this.dtp_DateOfBirth.Name = "dtp_DateOfBirth";
            this.dtp_DateOfBirth.Size = new System.Drawing.Size(142, 20);
            this.dtp_DateOfBirth.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(709, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(604, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(501, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tb_Position
            // 
            this.tb_Position.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Employees.Position", true));
            this.tb_Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Position.Location = new System.Drawing.Point(125, 134);
            this.tb_Position.Name = "tb_Position";
            this.tb_Position.Size = new System.Drawing.Size(142, 20);
            this.tb_Position.TabIndex = 15;
            // 
            // p_EmployeeToDepartment
            // 
            this.p_EmployeeToDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_EmployeeToDepartment.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_EmployeeToDepartment.Location = new System.Drawing.Point(457, 3);
            this.p_EmployeeToDepartment.Name = "p_EmployeeToDepartment";
            this.p_EmployeeToDepartment.Size = new System.Drawing.Size(419, 540);
            this.p_EmployeeToDepartment.TabIndex = 0;
            // 
            // p_Department
            // 
            this.p_Department.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Department.Controls.Add(this.tv_Department);
            this.p_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Department.Location = new System.Drawing.Point(3, 3);
            this.p_Department.Name = "p_Department";
            this.p_Department.Size = new System.Drawing.Size(454, 540);
            this.p_Department.TabIndex = 1;
            // 
            // tv_Department
            // 
            this.tv_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Department.Location = new System.Drawing.Point(0, 0);
            this.tv_Department.Name = "tv_Department";
            this.tv_Department.Size = new System.Drawing.Size(452, 538);
            this.tv_Department.TabIndex = 0;
            // 
            // tb_Department
            // 
            this.tb_Department.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityDataSource1, "Employees.DepartmentName", true));
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
            this.dgv_Employee.DataSource = this.entityDataSource1;
            this.dgv_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Employee.Location = new System.Drawing.Point(0, 0);
            this.dgv_Employee.Name = "dgv_Employee";
            this.dgv_Employee.Size = new System.Drawing.Size(597, 540);
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
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(TestDbApp.Model.TestDbContext);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 650);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Структура организации";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tc_Organization.ResumeLayout(false);
            this.tp_Department.ResumeLayout(false);
            this.tp_Employee.ResumeLayout(false);
            this.p_Employee.ResumeLayout(false);
            this.gb_EmployeeDetails.ResumeLayout(false);
            this.gb_EmployeeDetails.PerformLayout();
            this.p_DocInfo.ResumeLayout(false);
            this.p_DocInfo.PerformLayout();
            this.p_Department.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EntityFrameworkBinding.EntityDataSource entityDataSource1;
        private System.Windows.Forms.SplitContainer splitContainer1;
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
        private System.Windows.Forms.Panel p_Department;
        private System.Windows.Forms.Panel p_EmployeeToDepartment;
        private System.Windows.Forms.TreeView tv_Department;
        private System.Windows.Forms.TextBox tb_Department;
        private System.Windows.Forms.Label l_Department;
    }
}

