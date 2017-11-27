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
            this.tb_user = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.l_user = new System.Windows.Forms.Label();
            this.l_password = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_server = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_database = new System.Windows.Forms.TextBox();
            this.chb_SSPI = new System.Windows.Forms.CheckBox();
            this.m_oPicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_oPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.m_OK.Click += new System.EventHandler(this.OkClick);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // tb_user
            // 
            resources.ApplyResources(this.tb_user, "tb_user");
            this.tb_user.Name = "tb_user";
            this.tb_user.TextChanged += new System.EventHandler(this.TbUserTextChanged);
            // 
            // tb_password
            // 
            resources.ApplyResources(this.tb_password, "tb_password");
            this.tb_password.Name = "tb_password";
            this.tb_password.TextChanged += new System.EventHandler(this.TbPasswordTextChanged);
            // 
            // l_user
            // 
            resources.ApplyResources(this.l_user, "l_user");
            this.l_user.Name = "l_user";
            // 
            // l_password
            // 
            resources.ApplyResources(this.l_password, "l_password");
            this.l_password.Name = "l_password";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tb_server
            // 
            resources.ApplyResources(this.tb_server, "tb_server");
            this.tb_server.Name = "tb_server";
            this.tb_server.TextChanged += new System.EventHandler(this.TbServerTextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tb_database
            // 
            resources.ApplyResources(this.tb_database, "tb_database");
            this.tb_database.Name = "tb_database";
            this.tb_database.TextChanged += new System.EventHandler(this.TbDatabaseTextChanged);
            // 
            // chb_SSPI
            // 
            resources.ApplyResources(this.chb_SSPI, "chb_SSPI");
            this.chb_SSPI.Checked = true;
            this.chb_SSPI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_SSPI.Name = "chb_SSPI";
            this.chb_SSPI.UseVisualStyleBackColor = true;
            this.chb_SSPI.CheckStateChanged += new System.EventHandler(this.ChbSspiCheckStateChanged);
            // 
            // Login
            // 
            this.AcceptButton = this.m_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.chb_SSPI);
            this.Controls.Add(this.tb_database);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_server);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.m_oPicturePanel);
            this.Controls.Add(this.l_user);
            this.Controls.Add(this.l_password);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel m_oPicturePanel;
        private System.Windows.Forms.PictureBox m_oPicture;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_OK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label l_user;
        private System.Windows.Forms.Label l_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_server;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_database;
        private System.Windows.Forms.CheckBox chb_SSPI;
    }
}