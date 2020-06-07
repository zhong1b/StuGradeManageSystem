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
    public partial class 修改学生学籍窗口 : Form
    {
        private string st_num;
        private string st_name;
        private string st_class;
        private string st_sex;
        private string st_major;
        //private string st_phone;
        private SqlConnection m_connection;
        

        public string Stu_Num
        {
            set
            {
                st_num = value;
            }
            get
            {
                return st_num;
            }
        }
        public string Stu_Name
        {
            set
            {
                st_name = value;
            }
            get
            {
                return st_name;
            }
        }
        public string Stu_Class
        {
            set
            {
                st_class = value;
            }
            get
            {
                return st_class;
            }
        }
        public string Stu_Sex
        {
            set
            {
                st_sex = value;
            }
            get
            {
                return st_sex;
            }
        }
        public string Stu_Major
        {
            set
            {
                st_major = value;
            }
            get
            {
                return st_major;
            }
        }
        //public string Stu_Phone
        //{
        //    set
        //    {
        //        st_phone = value;
        //    }
        //    get
        //    {
        //        return st_phone;
        //    }
        //}
        public 修改学生学籍窗口()
        {
            InitializeComponent();
        }
        private void 修改_load(object sender, EventArgs e)
        {
            textBox1.Text = st_num;
            textBox2.Text = st_name;
            textBox3.Text = st_sex;
            textBox4.Text = st_class;
            textBox5.Text = st_major;
            //textBox6.Text = st_phone;
            textBox1.ReadOnly = true;

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
        private void Sure_Botton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("学号不能为空!!");
                textBox1.Focus();//鼠标制定textBox1中
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("姓名不能为空!!");
                textBox2.Focus();//鼠标制定textBox1中
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("性别不能为空!!");
                textBox3.Focus();//鼠标制定textBox1中
                return;
            }
            if (textBox3.Text != "男" && textBox3.Text != "女")
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
                textBox5.Focus();//鼠标制定textBox1中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            if(sdnoIsExists(textBox5.Text) == false)
            {
                MessageBox.Show("院号不存在!!");
                textBox5.Focus();//鼠标制定textBox1中
                return;
            }
            string cmdText = "update 学生 set 学号='" + textBox1.Text + "',姓名='" + textBox2.Text +
                "',性别='" + textBox3.Text + "',班级='" + textBox4.Text + "',院号='" + textBox5.Text +
                "' where 学号='" + st_num + "'";
            SqlCommand UpdateCom = new SqlCommand(cmdText, m_connection);
            if (UpdateCom.ExecuteNonQuery() > 0)//
            {
                MessageBox.Show("信息修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                m_connection.Close();
            }
            else
            {
                MessageBox.Show("信息修改失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                m_connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //  m_connection.Close();
          //  浏览学籍信息窗口 ScanForm = new 浏览学籍信息窗口();
            //DialogResult re = ScanForm.ShowDialog();
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

    }
}

