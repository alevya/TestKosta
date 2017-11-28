namespace TestDbApp.Common
{
    partial class EditControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_value = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.l_required = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_value
            // 
            this.tb_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_value.Location = new System.Drawing.Point(0, 0);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(256, 20);
            this.tb_value.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tb_value);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.l_required);
            this.splitContainer1.Size = new System.Drawing.Size(285, 23);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 2;
            // 
            // l_required
            // 
            this.l_required.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_required.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_required.Location = new System.Drawing.Point(0, 0);
            this.l_required.Name = "l_required";
            this.l_required.Size = new System.Drawing.Size(25, 23);
            this.l_required.TabIndex = 0;
            this.l_required.Text = "!";
            this.l_required.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_required.Visible = false;
            // 
            // EditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditControl";
            this.Size = new System.Drawing.Size(285, 23);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_value;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label l_required;
    }
}
