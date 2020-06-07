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
    public partial class 删除学生学籍窗口 : Form
    {

        private string stu_num;
        public SqlConnection m_connection;

        public string Stu_Num
        {
            set
            {
                stu_num = value;
            }
            get
            {
                return stu_num;
            }
        }
       
        public 删除学生学籍窗口()
        {
            InitializeComponent();
        }
        private void Sure_button_Click(object sender, EventArgs e)
        {
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            string cmdText = "delete from 学生 where 学号='" + stu_num + "'";
            SqlCommand DeleteCom = new SqlCommand(cmdText, m_connection);
            if (MessageBox.Show("你确认删除本条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (DeleteCom.ExecuteNonQuery() > 0) 
                {
                    MessageBox.Show("信息删除成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            else
            {
                MessageBox.Show("信息删除失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            m_connection.Close();
        }

        private void quit_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //  m_connection.Close();
          //  浏览学籍信息窗口 ScanForm = new 浏览学籍信息窗口();
            //DialogResult re = ScanForm.ShowDialog();
        }

        private void Load_delete(object sender, EventArgs e)
        {
            textBox1.Text = stu_num;
        }
    }
}
