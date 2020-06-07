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
    public partial class 修改学生成绩窗口 : Form
    {
        private string stu_num;
        private string sub_num;
        private string stu_name;
        private string sub_name;
        private string grade;
        private SqlConnection m_connection;
        private string cmdText;
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
        public string Sub_Num
        {
            set
            {
                sub_num = value;
            }
            get
            {
                return sub_num;
            }
        }
        public string Stu_Name
        {
            set
            {
                stu_name = value;
            }
            get
            {
                return stu_name;
            }
        }
        public string Sub_Name
        {
            set
            {
                sub_name = value;
            }
            get
            {
                return sub_name;
            }
        }
        public string Grade
        {
            set
            {
                grade = value;
            }
            get
            {
                return grade;
            }
        }
        public 修改学生成绩窗口()
        {
            InitializeComponent();
        }
        private void 修改学生成绩窗口_Load(object sender, EventArgs e)
        {
            textBox1.Text = stu_num;
            textBox2.Text = sub_num;
            textBox3.Text = stu_name;
            textBox4.Text = sub_name;
            textBox5.Text = grade;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("学号不能为空!!");
                textBox1.Focus();//鼠标制定textBox1中
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("课号不能为空!!");
                textBox2.Focus();//鼠标制定textBox1中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                //MessageBox.Show("情况1!!");
                //textBox1.Focus();//鼠标制定textBox1中
                //return;
                cmdText = "update 选课 set 学号='" + textBox1.Text + "',课号='" + textBox2.Text +
                    "',成绩='" + DBNull.Value +
                "' where 学号='" + stu_num + "'and 课号='" + sub_num + "'";
            }
            else if (string.IsNullOrEmpty(textBox5.Text))
            {
                //MessageBox.Show("情况2!!");
                //textBox1.Focus();//鼠标制定textBox1中
                //return;
                cmdText = "update 选课 set 学号='" + textBox1.Text + "',课号='" + textBox2.Text +
                    "',成绩='" + DBNull.Value +
                "' where 学号='" + stu_num + "'and 课号='" + sub_num + "'";
            }
            else
            {
                //MessageBox.Show("情况3!!");
                //textBox1.Focus();//鼠标制定textBox1中
                //return;
                if (!IsNumber(textBox5.Text))
                {
                    MessageBox.Show("成绩中包含非法字符!!");
                    textBox5.Focus();//鼠标制定textBox5中
                    return;
                }
                else
                {
                    int grade = 0;
                    int.TryParse(textBox5.Text, out grade);
                    if (grade < 0 || grade > 100)
                    {
                        MessageBox.Show("成绩输入超出范围（0-100）!!");
                        textBox5.Focus();//鼠标制定textBox5中
                        return;
                    }
                    cmdText = "update 选课 set 学号='" + textBox1.Text + "',课号='" + textBox2.Text +
               "',成绩='" + textBox5.Text +
               "' where 学号='" + stu_num + "'and 课号='" + sub_num + "'";
                }
                
            }
           
            SqlCommand UpdateCom = new SqlCommand(cmdText, m_connection);
            //if (UpdateCom.ExecuteNonQuery() > 0)//
            if (UpdateCom.ExecuteNonQuery() > 0)

            {
                MessageBox.Show("成绩修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                m_connection.Close();
            }
            else
            {
                MessageBox.Show("成绩修改失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                m_connection.Close();
                
            }
        }
    }
}
