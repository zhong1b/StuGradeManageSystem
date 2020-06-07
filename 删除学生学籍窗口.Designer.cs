namespace XJManageSystem
{
    partial class 删除学生学籍窗口
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(删除学生学籍窗口));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Sure_button = new System.Windows.Forms.Button();
            this.quit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "请确认要删除学生的学号：";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(81, 78);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(340, 25);
            this.textBox1.TabIndex = 1;
            // 
            // Sure_button
            // 
            this.Sure_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Sure_button.Location = new System.Drawing.Point(172, 155);
            this.Sure_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Sure_button.Name = "Sure_button";
            this.Sure_button.Size = new System.Drawing.Size(135, 32);
            this.Sure_button.TabIndex = 2;
            this.Sure_button.Text = "确认";
            this.Sure_button.UseVisualStyleBackColor = true;
            this.Sure_button.Click += new System.EventHandler(this.Sure_button_Click);
            // 
            // quit_button
            // 
            this.quit_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quit_button.Location = new System.Drawing.Point(347, 156);
            this.quit_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quit_button.Name = "quit_button";
            this.quit_button.Size = new System.Drawing.Size(132, 31);
            this.quit_button.TabIndex = 3;
            this.quit_button.Text = "取消";
            this.quit_button.UseVisualStyleBackColor = true;
            this.quit_button.Click += new System.EventHandler(this.quit_button_Click);
            // 
            // 删除学生学籍窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 261);
            this.Controls.Add(this.quit_button);
            this.Controls.Add(this.Sure_button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "删除学生学籍窗口";
            this.Text = "删除窗口";
            this.Load += new System.EventHandler(this.Load_delete);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Sure_button;
        private System.Windows.Forms.Button quit_button;
    }
}