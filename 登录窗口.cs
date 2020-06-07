using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace XJManageSystem
{
    public partial class 登录窗口 : Form
    {
         private string stuText;
        //private string password="blue";
        private SqlConnection m_connection;
        public 登录窗口()
        {
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            InitializeComponent();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OK_button_Click(object sender, EventArgs e)
        {

            if (user_textBox.Text == "")
            {
                MessageBox.Show("登录名不能为空!!");
                user_textBox.Focus();//设置焦点,让光标停留在user_textBox上，可以输入
                return;
            }
            if (password_textBox.Text == "")
            {
                MessageBox.Show("密码不能为空!!");
                password_textBox.Focus();
                return;
            }
            if (userType_comboBox.Text == "")
            {
                MessageBox.Show("用户类型不能为空!!");
                return;
            }
            if(!userIsExists(user_textBox.Text))
            {
                MessageBox.Show("用户不存在!!");
                return;
            }
            //  if (comboBox1.Text == "学生")
            //{
            //stuText = "select * from 用户 where 用户名='" + user_textBox.Text + "' and 密码 = '" +
            //    password_textBox.Text + "'and 用户类型='" + comboBox1.Text + "'";
            //Session.userid = user_textBox.Text;
            //Session.idpassword = password_textBox.Text;
            //Session.typename = comboBox1.Text;
            //SqlCommand SelectCom = new SqlCommand(stuText, m_connection);
            //string temp;
            //try
            //{
            //    temp = SelectCom.ExecuteScalar().ToString();
            //}
            //catch
            //{
            //    MessageBox.Show("用户名或密码错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            stuText = "select * from 用户 where 用户名='" + user_textBox.Text + "' and 密码 = '" +
                password_textBox.Text +  "'";
            Session.userid = user_textBox.Text;
            Session.idpassword = password_textBox.Text;
            Session.typename = userType_comboBox.Text;
            SqlCommand SelectCom = new SqlCommand(stuText, m_connection);
            string temp;
            try
            {
                temp = SelectCom.ExecuteScalar().ToString();
            }
            catch
            {
                MessageBox.Show("用户名或密码错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(temp != "")
            {
                stuText = "select * from 用户 where 用户名='" + user_textBox.Text + "' and 密码 = '" +
                password_textBox.Text + "'and 用户类型='" + userType_comboBox.Text + "'";
                string temp1;
                SqlCommand SelectCom1 = new SqlCommand(stuText, m_connection);
                try
                {
                    temp1 = SelectCom1.ExecuteScalar().ToString();
                }
                catch
                {
                    MessageBox.Show("用户类型错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (temp1 != "")
                {
                    this.Visible = false;
                    m_connection.Close();
                    菜单窗口 ScanForm = new 菜单窗口();
                    DialogResult re = ScanForm.ShowDialog();
                }
            }

            
            //    logintypname = "学生";

                
        }
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="user_name"><用户名></param>
        /// <returns>若用户存在返回true，否则返回false</returns>
        private bool userIsExists(string user_name)
        {
            //定义并初始化字符串SelectStr，内容为一条数据库查询语句
            //该语句功能：在用户表中查询用户名 = user_name 的用户数 
            string SelectStr = String.Format("select count(*) from 用户 where 用户名='{0}'", user_name);
            //定义并初始化具有查询文本的数据库指令SqlCommand对象
            SqlCommand SelectCom = new SqlCommand(SelectStr, m_connection);
            //定义字符串SelectResult，并将其初始化为数据库指令SelectCom执行的结果
            string SelectResult = SelectCom.ExecuteScalar().ToString();
            //如果用户表中用户名 = user_name 的用户数为0，该用户不存在，返回false
            if (SelectResult == "0")
            {
                return false;
            }
            //如果用户表中用户名 = user_name 的用户数不为0，该用户存在，返回true
            else
            {
                return true;
            }
        }

        private void qiut_button_click(object sender, EventArgs e)
        {
            m_connection.Close();//关闭数据库连接
            Application.Exit();
        }

        private void create_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            m_connection.Close();
            用户注册窗口 ScanForm = new 用户注册窗口();
            DialogResult re = ScanForm.ShowDialog();
        }

        private void 登录窗口_Load(object sender, EventArgs e)
        {
        
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void 登录窗口_Load_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
