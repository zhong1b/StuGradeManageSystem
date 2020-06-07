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
    public partial class 用户注册窗口 : Form
    {
        public 用户注册窗口()
        {
            InitializeComponent();
        }
        public SqlConnection m_connection;
        private void create_button_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text == "")
            {
                MessageBox.Show("用户名不能为空!!");
                textBox_id.Focus();//设置焦点,让光标停留在user_textBox上，可以输入
                return;
            }
            if (textBox_passcode.Text == "")
            {
                MessageBox.Show("密码不能为空!!");
                textBox_passcode.Focus();
                return;
            }
            if(Encoding.Default.GetByteCount(textBox_id.Text) > 15)
            {
                MessageBox.Show("用户名过长!!");
                textBox_id.Focus();//设置焦点,让光标停留在user_textBox上，可以输入
                return;
            }
            if (Encoding.Default.GetByteCount(textBox_passcode.Text) > 15)
            {
                MessageBox.Show("密码过长!!");
                textBox_passcode.Focus();//设置焦点,让光标停留在passcode_textBox上，可以输入
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            string stuText = "insert into 用户 values('" + textBox_id.Text + "','" +
                textBox_passcode.Text + "','" + "学生" + "')";
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

        private void quit_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            登录窗口 ScanForm = new 登录窗口();
            DialogResult re = ScanForm.ShowDialog();
        }
    }
}
