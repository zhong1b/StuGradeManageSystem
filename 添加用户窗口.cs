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
    public partial class 添加用户窗口 : Form
    {
        public 添加用户窗口()
        {
            InitializeComponent();
        }
        public SqlConnection m_connection;
        private void sure_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不能为空!!");
                textBox1.Focus();//光标在textBox1中
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空!!");
                textBox2.Focus();//光标在textBox1中
                return;
            }
            if (Encoding.Default.GetByteCount(textBox1.Text) > 15)
            {
                MessageBox.Show("用户名过长!!");
                textBox1.Focus();//设置焦点,让光标停留在user_textBox上，可以输入
                return;
            }
            if (Encoding.Default.GetByteCount(textBox2.Text) > 15)
            {
                MessageBox.Show("密码过长!!");
                textBox2.Focus();//设置焦点,让光标停留在passcode_textBox上，可以输入
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("用户类型不能为空!!");
                comboBox1.Focus();//光标在textBox1中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            if(userIsExists(textBox1.Text) == true)
            {
                MessageBox.Show("用户名已经存在!!");
                textBox1.Focus();//光标在textBox1中
                return;
            }
            string stuText = "insert into 用户 values('" + textBox1.Text + "','" +
                textBox2.Text + "','" + comboBox1.Text + "')";
            SqlCommand InsertNewStu = new SqlCommand(stuText, m_connection);
            if (InsertNewStu.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("用户添加成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("用户添加失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            m_connection.Close();
        }

        private void qiut_button_Click(object sender, EventArgs e)
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
