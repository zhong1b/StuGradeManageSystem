using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;


namespace XJManageSystem
{
    public partial class 菜单窗口 : Form
    {
        public 菜单窗口()
        {
            InitializeComponent();
        }
        

        private void 浏览学籍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
          //  m_connection.Close();
            浏览学籍信息窗口 ScanForm = new 浏览学籍信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 添加学籍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            添加学生学籍窗口 ScanForm = new 添加学生学籍窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 删除学籍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
         //   删除学生学籍窗口 ScanForm = new 删除学生学籍窗口();
           // DialogResult re = ScanForm.ShowDialog();
            浏览学籍信息窗口 ScanForm = new 浏览学籍信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 修改学籍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            浏览学籍信息窗口 ScanForm = new 浏览学籍信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 查询学籍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            查询学籍窗口 ScanForm = new 查询学籍窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 浏览成绩信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            浏览成绩信息窗口 ScanForm = new 浏览成绩信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 添加成绩信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            添加学生成绩窗口 ScanForm = new 添加学生成绩窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 删除成绩信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
          //  删除学生成绩窗口 ScanForm = new 删除学生成绩窗口();
            //DialogResult re = ScanForm.ShowDialog();
            浏览成绩信息窗口 ScanForm = new 浏览成绩信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 修改成绩信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            浏览成绩信息窗口 ScanForm = new 浏览成绩信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 查询成绩信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            查询成绩窗口 ScanForm = new 查询成绩窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            登录窗口 ScanForm = new 登录窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        //private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        public SqlConnection m_connection;
        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            添加用户窗口 ScanForm = new 添加用户窗口();
            DialogResult re = ScanForm.ShowDialog();

         }

        private void 菜单窗口_Load(object sender, EventArgs e)
        {
            if (Session.typename == "学生")
            {
                this.添加用户ToolStripMenuItem.Enabled = false;
                this.浏览学籍信息ToolStripMenuItem.Enabled = false;
                this.添加学籍信息ToolStripMenuItem.Enabled = false;
                this.删除学籍信息ToolStripMenuItem.Enabled = false;
                this.修改学籍信息ToolStripMenuItem.Enabled = false;
                this.浏览成绩信息ToolStripMenuItem.Enabled = false;
                this.添加成绩信息ToolStripMenuItem.Enabled = false;
                this.删除成绩信息ToolStripMenuItem.Enabled = false;
                this.修改成绩信息ToolStripMenuItem.Enabled = false;
                this.添加学院ToolStripMenuItem.Enabled = false;
                this.删除学院信息ToolStripMenuItem.Enabled = false;
                this.修改学院信息ToolStripMenuItem.Enabled = false;
                this.添加课程信息ToolStripMenuItem.Enabled = false;
                this.删除课程信息ToolStripMenuItem.Enabled = false;
                this.修改课程信息ToolStripMenuItem.Enabled = false;
                this.学科成绩分析ToolStripMenuItem.Enabled = false;
                this.删除用户ToolStripMenuItem.Enabled = false;
            }
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    this.Visible = true;
            //  m_connection.Close();
          //  综合查询窗口 ScanForm = new 综合查询窗口();
            //DialogResult re = ScanForm.ShowDialog();

        }

        private void 综合查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void 学籍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 菜单窗口_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            System.Environment.Exit(0);
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 浏览学院信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            浏览学院信息窗口 ScanForm = new 浏览学院信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }




        private void 添加学院ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            添加学院信息窗口 ScanForm = new 添加学院信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 删除学院信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            浏览学院信息窗口 ScanForm = new 浏览学院信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 修改学院信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            浏览学院信息窗口 ScanForm = new 浏览学院信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 浏览课程信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            浏览课程信息窗口 ScanForm = new 浏览课程信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 添加课程信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            添加课程信息窗口 ScanForm = new 添加课程信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 删除课程信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            浏览课程信息窗口 ScanForm = new 浏览课程信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 修改课程信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            浏览课程信息窗口 ScanForm = new 浏览课程信息窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 学生成绩分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            学生成绩分析窗口 ScanForm = new 学生成绩分析窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 学科成绩分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            学科成绩分析窗口 ScanForm = new 学科成绩分析窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //  m_connection.Close();
            删除用户窗口 ScanForm = new 删除用户窗口();
            DialogResult re = ScanForm.ShowDialog();
        }
    }
}
