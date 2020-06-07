using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XJManageSystem
{
    public partial class 删除用户窗口 : Form
    {
        public SqlConnection m_connection;
        public 删除用户窗口()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_id.Text == "")
            {
                MessageBox.Show("用户名不能为空!!");
                textBox_id.Focus();//光标在textBox1中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            if(userIsExists(textBox_id.Text) == false)
            {
                MessageBox.Show("用户名不存在!!");
                textBox_id.Focus();//光标在textBox1中
                return;
            }
            string stuText = "delete from 用户 where 用户名='" + textBox_id.Text + "'";
            SqlCommand InsertNewStu = new SqlCommand(stuText, m_connection);
            if (InsertNewStu.ExecuteNonQuery() > 0)//
            {
                MessageBox.Show("用户删除成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("用户删除失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            m_connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="stu_num"></param>
        /// <returns></returns>
        private bool userIsExists(string u_num)
        {
            string comstr = String.Format("select count(*) from 用户 where 用户名='{0}'", u_num);
            SqlCommand tempcom = new SqlCommand(comstr, m_connection);
            string temp = tempcom.ExecuteScalar().ToString();
            if (temp != "0")
            {
                return true;
            }
            return false;
        }
    }
}
