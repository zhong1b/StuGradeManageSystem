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
using System.Text.RegularExpressions;

namespace XJManageSystem
{
    public partial class 添加学生学籍窗口 : Form
    {
        private string stu_num;
        private string stu_name;
        private string stu_class;
        private string stu_sex;
        private string stu_major;
        private string stu_phone;
        public SqlConnection m_connection;
        
        public 添加学生学籍窗口()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            stu_num = textBox1.Text;
        }   
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            stu_name = textBox2.Text;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            stu_sex = textBox3.Text;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            stu_class = textBox4.Text;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            stu_major = textBox5.Text;
        }
        //private void textBox6_TextChanged(object sender, EventArgs e)
        //{
        //    stu_phone = textBox6.Text;
        //}
        private void sure_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("学号不能为空!!");
                textBox1.Focus();//鼠标制定textBox1中
                return;
            }
            if (!IsNumber(textBox1.Text))
            {
                MessageBox.Show("学号输入错误!!");
                textBox1.Focus();//光标在textBox1中
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("姓名不能为空!!");
                textBox2.Focus();//鼠标制定textBox3中
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("性别不能为空!!");
                textBox3.Focus();//鼠标制定textBox3中
                return;
            }
            if(textBox3.Text != "男" && textBox3.Text != "女")
            {
                MessageBox.Show("性别填写错误（只能为男或女）!!");
                textBox3.Focus();//鼠标制定textBox3中
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("班级不能为空!!");
                textBox4.Focus();//鼠标制定textBox4中
                return;
            }
            if (!IsNumber(textBox4.Text))
            {
                MessageBox.Show("班级输入错误!!");
                textBox4.Focus();//光标在textBox1中
                return;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("院号不能为空!!");
                textBox5.Focus();//鼠标制定textBox5中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            if(snoIsExists(textBox1.Text) == true)
            {
                MessageBox.Show("学号已经存在!!");
                textBox1.Focus();//鼠标制定textBox1中
                return;
            }
            if (sdnoIsExists(textBox5.Text) == false)
            {
                MessageBox.Show("院号不存在!!");
                textBox5.Focus();//鼠标制定textBox1中
                return;
            }

            string stuText = "insert into 学生 values('" + textBox1.Text + "','" +
                textBox2.Text + "','" + textBox3.Text + "','"  + textBox4.Text + "','" + textBox5.Text + "')";
            SqlCommand InsertNewStu = new SqlCommand(stuText, m_connection);
            if(InsertNewStu.ExecuteNonQuery() > 0)//
            {
                MessageBox.Show("信息添加成功","",MessageBoxButtons.OK,MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("信息添加失败","",MessageBoxButtons.OK,MessageBoxIcon.None);
            }
            m_connection.Close();

        }

        private void qiut_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //  m_connection.Close();
          //  浏览学籍信息窗口 ScanForm = new 浏览学籍信息窗口();
            //DialogResult re = ScanForm.ShowDialog();
        }

        private void 添加学生学籍窗口_Load(object sender, EventArgs e)
        {

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

        /// <summary>
        /// 判断学号是否存在
        /// </summary>
        /// <param name="stu_num"></param>
        /// <returns></returns>
        private bool snoIsExists(string stu_num)
        {
            string comstr = String.Format("select count(*) from 学生 where 学号='{0}'", stu_num);
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
