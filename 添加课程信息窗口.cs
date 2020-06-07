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
using System.Text.RegularExpressions;

namespace XJManageSystem
{
    public partial class 添加课程信息窗口 : Form
    {
        private string c_num;
        private string c_name;
        private string c_cre;
        public SqlConnection m_connection;
        public 添加课程信息窗口()
        {
            InitializeComponent();
        }

        private void qiut_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            c_num = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            c_name = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            c_cre = textBox3.Text;
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
   

    /// <summary>
    /// 判断字符串是否是int/double
    /// </summary>
    public static bool IsIntOrDouble(string strNumber)
    {
        Regex objNotNumberPattern = new Regex("[^0-9.-]");
        Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
        Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
        const string strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
        const string strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
        Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
        return !objNotNumberPattern.IsMatch(strNumber) &&
               !objTwoDotPattern.IsMatch(strNumber) &&
               !objTwoMinusPattern.IsMatch(strNumber) &&
               objNumberPattern.IsMatch(strNumber);
    }
    private void sure_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("课号不能为空!!");
                textBox1.Focus();//光标在textBox1中
                return;
            }
            if (!IsNumber(textBox1.Text))
            {
                MessageBox.Show("课号输入错误!!");
                textBox1.Focus();//光标在textBox1中
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("课程名不能为空!!");
                textBox2.Focus();//光标在textBox2中
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("学分不能为空!!");
                textBox3.Focus();//光标在textBox3中
                return;
            }
            if(!IsIntOrDouble(textBox3.Text))
            {
                MessageBox.Show("学分输入错误!!");
                textBox3.Focus();//光标在textBox3中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            if (cnoIsExists(c_num) == true)
            {
                MessageBox.Show("此课程号已经存在！");
                textBox1.Focus();
                return;
            }

            string stuText = "insert into 课程 values('" + textBox1.Text + "','" +
                textBox2.Text + "','" +
                textBox3.Text + "')";
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
        /// 判断学院号是否存在
        /// </summary>
        /// <param name="stu_num"></param>
        /// <returns></returns>
        private bool cnoIsExists(string stu_num)
        {
            string comstr = String.Format("select count(*) from 课程 where 课号='{0}'", stu_num);
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
