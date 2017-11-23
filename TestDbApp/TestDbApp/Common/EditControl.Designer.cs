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
            this.SuspendLayout();
            // 
            // tb_value
            // 
            this.tb_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_value.Location = new System.Drawing.Point(0, 0);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(285, 20);
            this.tb_value.TabIndex = 0;
            // 
            // EditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb_value);
            this.Name = "EditControl";
            this.Size = new System.Drawing.Size(285, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_value;
    }
}
