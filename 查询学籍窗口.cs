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
    public partial class 查询学籍窗口 : Form
    {
        public SqlConnection connstring;
        public 查询学籍窗口()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_snum.Text == "")
            {
                MessageBox.Show("学号不能为空!!");
                textBox_snum.Focus();//光标停在textBox1中
                return;
            }
            string connectionString = Session.connstr;
            connstring = new SqlConnection(connectionString);
            connstring.Open();
            string stu_num = textBox_snum.Text;
            if(snoIsExists(stu_num) == false)
            {
                MessageBox.Show("学号不存在!!");
                textBox_snum.Focus();//鼠标制定textBox1中
                return;
            }
            //string sql = "select stu_num,stu_name,stu_local,stu_class,stu_major from ss where stu_num='" + textBox_snum.Text+ "'";
            string sql = "select * from 学籍信息 where 学号='" + textBox_snum.Text + "'";
            SqlDataReader myread;
            SqlCommand comm = new SqlCommand(sql, connstring);
            myread = comm.ExecuteReader();
            if (myread.HasRows)
            {
                while (myread.Read())
                {
                    textBox_snum.Text = myread.GetString(0).ToString();
                    if (!(myread["姓名"] is DBNull))
                    {
                        textBox_sname.Text = myread.GetString(1).ToString();
                    }
                    if (!(myread["性别"] is DBNull))
                    {
                        textBox_sex.Text = myread.GetString(2).ToString();
                    }
                    //if (!(myread["电话"] is DBNull))
                    //{
                    //    textBox_phone.Text = myread.GetString(3).ToString();
                    //}            
                    if(!(myread["所在班级"] is DBNull))
                    {
                        textBox_class.Text = myread.GetString(3).ToString();
                    }
                    if(!(myread["所在学院"] is DBNull))
                    {
                        textBox_sdept.Text = myread.GetString(4).ToString();
                    } 
                    
                }
            }
            else
            {
                MessageBox.Show("没有该生学籍情况", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            //always call Close when done reading
            myread.Close();
            //Close the connection when done with it
            connstring.Close();

        }

        private void 查询学籍窗口_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //  m_connection.Close();
         //   菜单窗口 ScanForm = new 菜单窗口();
           // DialogResult re = ScanForm.ShowDialog();
        }
        /// <summary>
        /// 判断学号是否存在
        /// </summary>
        /// <param name="stu_num"></param>
        /// <returns></returns>
        private bool snoIsExists(string stu_num)
        {
            string comstr = String.Format("select count(*) from 学生 where 学号='{0}'", stu_num);
            SqlCommand tempcom = new SqlCommand(comstr, connstring);
            string temp = tempcom.ExecuteScalar().ToString();
            if (temp != "0")
            {
                return true;
            }
            return false;
        }
    }
}
