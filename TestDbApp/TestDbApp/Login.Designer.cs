namespace TestDbApp
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.m_oPicturePanel = new System.Windows.Forms.Panel();
            this.m_oPicture = new System.Windows.Forms.PictureBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_OK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.l_service = new System.Windows.Forms.Label();
            this.tb_service = new System.Windows.Forms.TextBox();
            this.tp_login = new System.Windows.Forms.TabPage();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_user = new System.Windows.Forms.TextBox();
            this.tc_main = new System.Windows.Forms.TabControl();
            this.m_oPicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_oPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tp_login.SuspendLayout();
            this.tc_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_oPicturePanel
            // 
            this.m_oPicturePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_oPicturePanel.Controls.Add(this.m_oPicture);
            resources.ApplyResources(this.m_oPicturePanel, "m_oPicturePanel");
            this.m_oPicturePanel.Name = "m_oPicturePanel";
            // 
            // m_oPicture
            // 
            resources.ApplyResources(this.m_oPicture, "m_oPicture");
            this.m_oPicture.Name = "m_oPicture";
            this.m_oPicture.TabStop = false;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.TabStop = false;
            // 
            // m_OK
            // 
            resources.ApplyResources(this.m_OK, "m_OK");
            this.m_OK.Name = "m_OK";
            this.m_OK.TabStop = false;
            this.m_OK.Click += new System.EventHandler(this.m_OK_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // l_service
            // 
            resources.ApplyResources(this.l_service, "l_service");
            this.l_service.Name = "l_service";
            // 
            // tb_service
            // 
            resources.ApplyResources(this.tb_service, "tb_service");
            this.tb_service.Name = "tb_service";
            this.tb_service.TextChanged += new System.EventHandler(this.tb_service_TextChanged);
            // 
            // tp_login
            // 
            this.tp_login.Controls.Add(this.tb_user);
            this.tp_login.Controls.Add(this.tb_password);
            this.tp_login.Controls.Add(this.label2);
            this.tp_login.Controls.Add(this.label3);
            resources.ApplyResources(this.tp_login, "tp_login");
            this.tp_login.Name = "tp_login";
            this.tp_login.UseVisualStyleBackColor = true;
            // 
            // tb_password
            // 
            resources.ApplyResources(this.tb_password, "tb_password");
            this.tb_password.Name = "tb_password";
            this.tb_password.TextChanged += new System.EventHandler(this.tb_password_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tb_user
            // 
            resources.ApplyResources(this.tb_user, "tb_user");
            this.tb_user.Name = "tb_user";
            this.tb_user.TextChanged += new System.EventHandler(this.tb_user_TextChanged);
            // 
            // tc_main
            // 
            this.tc_main.Controls.Add(this.tp_login);
            resources.ApplyResources(this.tc_main, "tc_main");
            this.tc_main.Name = "tc_main";
            this.tc_main.SelectedIndex = 0;
            this.tc_main.TabStop = false;
            // 
            // Login
            // 
            this.AcceptButton = this.m_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.tc_main);
            this.Controls.Add(this.tb_service);
            this.Controls.Add(this.l_service);
            this.Controls.Add(this.m_oPicturePanel);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_OK);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.m_oPicturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_oPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tp_login.ResumeLayout(false);
            this.tp_login.PerformLayout();
            this.tc_main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel m_oPicturePanel;
        private System.Windows.Forms.PictureBox m_oPicture;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_OK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label l_service;
        private System.Windows.Forms.TextBox tb_service;
        private System.Windows.Forms.TabPage tp_login;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tc_main;
    }
}