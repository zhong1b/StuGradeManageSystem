using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace XJManageSystem
{
    public partial class 添加学院信息窗口 : Form
    {
        private string sd_num;
        private string sd_name;
        public SqlConnection m_connection;
        public 添加学院信息窗口()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        private void sure_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("学院号不能为空!!");
                textBox1.Focus();//光标在textBox1中
                return;
            }
            if(!IsNumber(textBox1.Text))
            {
                MessageBox.Show("学院号输入错误!!");
                textBox1.Focus();//光标在textBox1中
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("学院名不能为空!!");
                textBox2.Focus();//光标在textBox1中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            if (sdnoIsExists(textBox1.Text) == true)
            {
                MessageBox.Show("此学院号已经存在！");
                textBox1.Focus();
                return;
            }
            
            string stuText = "insert into 学院 values('" + textBox1.Text + "','" +
                textBox2.Text  + "')";
            SqlCommand InsertNewStu = new SqlCommand(stuText, m_connection);
            if (InsertNewStu.ExecuteNonQuery() > 0)//
            {
                MessageBox.Show("信息添加成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("信息添加失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            m_connection.Close();
        }

        private void qiut_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        /// <summary>
        /// 判断学院号是否存在
        /// </summary>
        /// <param name="stu_num"></param>
        /// <returns></returns>
        private bool sdnoIsExists(string stu_num)
        {
            string comstr = String.Format("select count(*) from 学院 where 院号='{0}'", stu_num);
            SqlCommand tempcom = new SqlCommand(comstr, m_connection);
            string temp = tempcom.ExecuteScalar().ToString();
            if (temp != "0")
            {
                return true;
            }
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sd_num = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            sd_name = textBox2.Text;
        }
    }
}
