namespace XJManageSystem
{
    partial class 查询学籍窗口
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(查询学籍窗口));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_snum = new System.Windows.Forms.TextBox();
            this.label_snum = new System.Windows.Forms.Label();
            this.textBox_sdept = new System.Windows.Forms.TextBox();
            this.textBox_class = new System.Windows.Forms.TextBox();
            this.textBox_sex = new System.Windows.Forms.TextBox();
            this.textBox_sname = new System.Windows.Forms.TextBox();
            this.label_sdept = new System.Windows.Forms.Label();
            this.label_class = new System.Windows.Forms.Label();
            this.label_sex = new System.Windows.Forms.Label();
            this.label_sname = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(495, 110);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_snum
            // 
            this.textBox_snum.Font = new System.Drawing.Font("幼圆", 15.75F, System.Drawing.FontStyle.Bold);
            this.textBox_snum.Location = new System.Drawing.Point(160, 65);
            this.textBox_snum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_snum.Name = "textBox_snum";
            this.textBox_snum.Size = new System.Drawing.Size(223, 36);
            this.textBox_snum.TabIndex = 11;
            // 
            // label_snum
            // 
            this.label_snum.AutoSize = true;
            this.label_snum.Font = new System.Drawing.Font("幼圆", 15.75F, System.Drawing.FontStyle.Bold);
            this.label_snum.Location = new System.Drawing.Point(47, 69);
            this.label_snum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_snum.Name = "label_snum";
            this.label_snum.Size = new System.Drawing.Size(99, 27);
            this.label_snum.TabIndex = 10;
            this.label_snum.Text = "学号：";
            // 
            // textBox_sdept
            // 
            this.textBox_sdept.Location = new System.Drawing.Point(124, 91);
            this.textBox_sdept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_sdept.Name = "textBox_sdept";
            this.textBox_sdept.Size = new System.Drawing.Size(203, 25);
            this.textBox_sdept.TabIndex = 19;
            // 
            // textBox_class
            // 
            this.textBox_class.Location = new System.Drawing.Point(124, 36);
            this.textBox_class.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_class.Name = "textBox_class";
            this.textBox_class.Size = new System.Drawing.Size(204, 25);
            this.textBox_class.TabIndex = 18;
            // 
            // textBox_sex
            // 
            this.textBox_sex.Location = new System.Drawing.Point(92, 91);
            this.textBox_sex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_sex.Name = "textBox_sex";
            this.textBox_sex.Size = new System.Drawing.Size(203, 25);
            this.textBox_sex.TabIndex = 17;
            // 
            // textBox_sname
            // 
            this.textBox_sname.Location = new System.Drawing.Point(92, 36);
            this.textBox_sname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_sname.Name = "textBox_sname";
            this.textBox_sname.Size = new System.Drawing.Size(203, 25);
            this.textBox_sname.TabIndex = 16;
            // 
            // label_sdept
            // 
            this.label_sdept.AutoSize = true;
            this.label_sdept.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_sdept.Location = new System.Drawing.Point(4, 91);
            this.label_sdept.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_sdept.Name = "label_sdept";
            this.label_sdept.Size = new System.Drawing.Size(104, 20);
            this.label_sdept.TabIndex = 15;
            this.label_sdept.Text = "所在学院:";
            // 
            // label_class
            // 
            this.label_class.AutoSize = true;
            this.label_class.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_class.Location = new System.Drawing.Point(4, 36);
            this.label_class.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_class.Name = "label_class";
            this.label_class.Size = new System.Drawing.Size(104, 20);
            this.label_class.TabIndex = 14;
            this.label_class.Text = "所在班级:";
            // 
            // label_sex
            // 
            this.label_sex.AutoSize = true;
            this.label_sex.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_sex.Location = new System.Drawing.Point(16, 90);
            this.label_sex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_sex.Name = "label_sex";
            this.label_sex.Size = new System.Drawing.Size(62, 20);
            this.label_sex.TabIndex = 13;
            this.label_sex.Text = "性别:";
            // 
            // label_sname
            // 
            this.label_sname.AutoSize = true;
            this.label_sname.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_sname.Location = new System.Drawing.Point(16, 35);
            this.label_sname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_sname.Name = "label_sname";
            this.label_sname.Size = new System.Drawing.Size(62, 20);
            this.label_sname.TabIndex = 12;
            this.label_sname.Text = "姓名:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(35, 196);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox_sname);
            this.splitContainer1.Panel1.Controls.Add(this.label_sname);
            this.splitContainer1.Panel1.Controls.Add(this.label_sex);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_sex);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label_class);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_sdept);
            this.splitContainer1.Panel2.Controls.Add(this.label_sdept);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_class);
            this.splitContainer1.Size = new System.Drawing.Size(715, 149);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(495, 381);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 49);
            this.button2.TabIndex = 21;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 查询学籍窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(881, 515);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label_snum);
            this.Controls.Add(this.textBox_snum);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "查询学籍窗口";
            this.Text = "查询学生学籍";
            this.Load += new System.EventHandler(this.查询学籍窗口_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_snum;
        private System.Windows.Forms.Label label_snum;
        private System.Windows.Forms.TextBox textBox_sdept;
        private System.Windows.Forms.TextBox textBox_class;
        private System.Windows.Forms.TextBox textBox_sex;
        private System.Windows.Forms.TextBox textBox_sname;
        private System.Windows.Forms.Label label_sdept;
        private System.Windows.Forms.Label label_class;
        private System.Windows.Forms.Label label_sex;
        private System.Windows.Forms.Label label_sname;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button2;
    }
}