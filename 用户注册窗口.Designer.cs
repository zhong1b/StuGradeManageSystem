namespace XJManageSystem
{
    partial class 用户注册窗口
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(用户注册窗口));
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.textBox_passcode = new System.Windows.Forms.TextBox();
            this.create_button = new System.Windows.Forms.Button();
            this.quit_button = new System.Windows.Forms.Button();
            this.label_note = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(248, 102);
            this.textBox_id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(248, 25);
            this.textBox_id.TabIndex = 1;
            // 
            // label_id
            // 
            this.label_id.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_id.Location = new System.Drawing.Point(109, 102);
            this.label_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(131, 34);
            this.label_id.TabIndex = 4;
            this.label_id.Text = "用户名：";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_password.Location = new System.Drawing.Point(109, 180);
            this.label_password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(73, 20);
            this.label_password.TabIndex = 5;
            this.label_password.Text = "密 码:";
            // 
            // textBox_passcode
            // 
            this.textBox_passcode.Location = new System.Drawing.Point(248, 180);
            this.textBox_passcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_passcode.Name = "textBox_passcode";
            this.textBox_passcode.PasswordChar = '*';
            this.textBox_passcode.Size = new System.Drawing.Size(248, 25);
            this.textBox_passcode.TabIndex = 6;
            // 
            // create_button
            // 
            this.create_button.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.create_button.Location = new System.Drawing.Point(180, 291);
            this.create_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(100, 41);
            this.create_button.TabIndex = 10;
            this.create_button.Text = "注册";
            this.create_button.UseVisualStyleBackColor = true;
            this.create_button.Click += new System.EventHandler(this.create_button_Click);
            // 
            // quit_button
            // 
            this.quit_button.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quit_button.Location = new System.Drawing.Point(369, 291);
            this.quit_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quit_button.Name = "quit_button";
            this.quit_button.Size = new System.Drawing.Size(161, 41);
            this.quit_button.TabIndex = 11;
            this.quit_button.Text = "返回登陆界面";
            this.quit_button.UseVisualStyleBackColor = true;
            this.quit_button.Click += new System.EventHandler(this.quit_button_Click);
            // 
            // label_note
            // 
            this.label_note.AutoSize = true;
            this.label_note.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_note.Location = new System.Drawing.Point(109, 225);
            this.label_note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_note.Name = "label_note";
            this.label_note.Size = new System.Drawing.Size(305, 20);
            this.label_note.TabIndex = 12;
            this.label_note.Text = "(用户名和密码均不能超过15位)";
            // 
            // 用户注册窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 399);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.quit_button);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.textBox_passcode);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.textBox_id);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "用户注册窗口";
            this.Text = "用户注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textBox_passcode;
        private System.Windows.Forms.Button create_button;
        private System.Windows.Forms.Button quit_button;
        private System.Windows.Forms.Label label_note;
    }
}