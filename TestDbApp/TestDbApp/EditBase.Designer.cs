namespace TestDbApp
{
    partial class EditBase
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
            this.label = new System.Windows.Forms.Label();
            this.p_label = new System.Windows.Forms.Panel();
            this.p_text = new System.Windows.Forms.Panel();
            this.p_label.SuspendLayout();
            this.p_text.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_value
            // 
            this.tb_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_value.Location = new System.Drawing.Point(0, 0);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(78, 20);
            this.tb_value.TabIndex = 0;
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(97, 23);
            this.label.TabIndex = 1;
            this.label.Text = "label";
            this.label.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.label.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // p_label
            // 
            this.p_label.Controls.Add(this.label);
            this.p_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_label.Location = new System.Drawing.Point(0, 0);
            this.p_label.Name = "p_label";
            this.p_label.Size = new System.Drawing.Size(103, 23);
            this.p_label.TabIndex = 2;
            // 
            // p_text
            // 
            this.p_text.Controls.Add(this.tb_value);
            this.p_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_text.Location = new System.Drawing.Point(103, 0);
            this.p_text.Name = "p_text";
            this.p_text.Size = new System.Drawing.Size(78, 23);
            this.p_text.TabIndex = 3;
            // 
            // EditBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_text);
            this.Controls.Add(this.p_label);
            this.Name = "EditBase";
            this.Size = new System.Drawing.Size(181, 23);
            this.p_label.ResumeLayout(false);
            this.p_text.ResumeLayout(false);
            this.p_text.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_value;
        private System.Windows.Forms.Panel p_label;
        private System.Windows.Forms.Panel p_text;
        private System.Windows.Forms.Label label;
    }
}
