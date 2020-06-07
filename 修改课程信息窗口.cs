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
    public partial class 修改课程信息窗口 : Form
    {
        private string c_num;
        private string c_name;
        private string c_cre;
        private SqlConnection m_connection;

        public string C_Num
        {
            set
            {
                c_num = value;
            }
            get
            {
                return c_num;
            }
        }
        public string C_Name
        {
            set
            {
                c_name = value;
            }
            get
            {
                return c_name;
            }
        }
        public string C_Cre
        {
            set
            {
                c_cre = value;
            }
            get
            {
                return c_cre;
            }
        }
        public 修改课程信息窗口()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void 修改课程信息窗口_Load(object sender, EventArgs e)
        {
            textBox1.Text = c_num;
            textBox2.Text = c_name;
            textBox3.Text = c_cre;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("课号不能为空!!");
                textBox1.Focus();//光标制定textBox1中
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
                textBox2.Focus();//光标制定textBox1中
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("学分不能为空!!");
                textBox3.Focus();//光标制定textBox1中
                return;
            }
            if (!IsIntOrDouble(textBox3.Text))
            {
                MessageBox.Show("学分输入错误!!");
                textBox3.Focus();//光标在textBox3中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            string cmdText = "update 课程 set 课号='" + textBox1.Text + "',课程名='" + textBox2.Text + 
                "',学分='" + textBox3.Text +
                "' where 课号='" + c_num + "'";
            SqlCommand UpdateCom = new SqlCommand(cmdText, m_connection);
            //if (UpdateCom.ExecuteNonQuery() > 0)//
            if (UpdateCom.ExecuteNonQuery() > 0)

            {
                MessageBox.Show("课程信息修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                m_connection.Close();
            }
            else
            {
                MessageBox.Show("学院信息修改失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                m_connection.Close();

            }
        }
    }
}
