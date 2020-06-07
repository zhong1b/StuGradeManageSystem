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
    public partial class 添加学生成绩窗口 : Form
    {
        private string stu_num;
        private string sub_num;
        private string stu_name;
        private string sub_name;
        private float grade;
        public SqlConnection m_connection;
        private string stuText;
        public 添加学生成绩窗口()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            stu_num = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            sub_num = textBox2.Text;
        }
        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{
        //    stu_name = textBox3.Text;
        //}
        //private void textBox4_TextChanged(object sender, EventArgs e)
        //{
        //    sub_name = textBox4.Text;
        //}
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            grade = Convert.ToSingle(textBox5.Text);
        }

        private void sure_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("学号不能为空!!");
                textBox1.Focus();//鼠标制定textBox1中
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("科目号不能为空!!");
                textBox2.Focus();//鼠标制定textBox1中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            if(snoIsExists(textBox1.Text) == false)
            {
                MessageBox.Show("学号不存在，请先添加该学生的学籍信息!!");
                return;
            }
            if (cnoIsExists(textBox2.Text) == false)
            {
                MessageBox.Show("课号不存在，请先添加该课程信息!!");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                stuText = "insert into 选课(学号,课号) values('" + textBox1.Text + "','" +
                textBox2.Text + "')";
            }
            else
            {
                if(!IsNumber(textBox5.Text))
                {
                    MessageBox.Show("成绩中包含非法字符!!");
                    textBox5.Focus();//鼠标制定textBox5中
                    return;
                }
                else
                {
                    int grade = 0;
                    int.TryParse(textBox5.Text, out grade);
                    if(grade < 0 || grade > 100)
                    {
                        MessageBox.Show("成绩输入超出范围（0-100）!!");
                        textBox5.Focus();//鼠标制定textBox5中
                        return;
                    }
                    stuText = "insert into 选课 values('" + textBox1.Text + "','" +
                    textBox2.Text + "','" + textBox5.Text + "')";
                }
                
            }
            
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
    /// <summary>
    /// 判断字符串是否每个字符都为数字
    /// </summary>
    /// <param name="str">待判断的字符串</param>
    /// <returns>若字符串中每个字符都为数字返回true，否则返回false</returns>
    public static bool IsNumber(string str)
    {
        //若字符串str为空或str中包含空白字符，返回false
        if (string.IsNullOrWhiteSpace(str))
        {
            return false;
        }
        const string pattern = "^[0-9]*$";
        Regex rx = new Regex(pattern);
        return rx.IsMatch(str);
    }

    private void qiut_button_Click(object sender, EventArgs e)
        {
            this.Visible = false ;
            //  m_connection.Close();
          //  浏览成绩信息窗口 ScanForm = new 浏览成绩信息窗口();
            //DialogResult re = ScanForm.ShowDialog();
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
            if(temp != "0")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断课号是否存在
        /// </summary>
        /// <param name="stu_num"></param>
        /// <returns></returns>
        private bool cnoIsExists(string cno)
        {
            string comstr = String.Format("select count(*) from 课程 where 课号='{0}'", cno);
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
