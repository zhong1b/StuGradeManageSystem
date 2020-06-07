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
    public partial class 查询成绩窗口 : Form
    {
        public SqlConnection connstring;
        public 查询成绩窗口()
        {
            InitializeComponent();
        }

        private void 查询成绩窗口_Load(object sender, EventArgs e)
        {

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
                MessageBox.Show("科目号不能为空!!");
                textBox2.Focus();//鼠标制定textBox2中
                return;
            }
            string connectionString = Session.connstr;
            connstring = new SqlConnection(connectionString);
            connstring.Open();//
            string stu_num = textBox1.Text;
            string sub_num = textBox2.Text;
            if (snoIsExists(stu_num) == false)
            {
                MessageBox.Show("学号不存在!!");
                textBox1.Focus();//鼠标制定textBox1中
                return;
            }
            if (cnoIsExists(sub_num) == false)
            {
                MessageBox.Show("课号不存在!!");
                textBox2.Focus();//鼠标制定textBox1中
                return;
            }
            string sql0 = "select 班级, 院号 from 学生 where 学号='" + textBox1.Text + "'";
            SqlDataReader myread0;
            SqlCommand comm0 = new SqlCommand(sql0, connstring);
            myread0 = comm0.ExecuteReader();
            string classnum = "", cologenum = "";
            if(myread0.HasRows)
            {
                while(myread0.Read())
                {
                    if(!(myread0["班级"] is DBNull))
                    {
                        classnum = myread0.GetString(0).ToString();
                     }
                    if (!(myread0["院号"] is DBNull))
                    {
                        cologenum = myread0.GetString(1).ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("没有这名学生", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            myread0.Close();
            //----------------------------------------------------------------------------------------
            string sql1 = "select 姓名,课程名,成绩 from 学生_成绩 where 学号='" + textBox1.Text + "'and 课号='" + textBox2.Text + "'";
            SqlDataReader myread1;
            SqlCommand comm1 = new SqlCommand(sql1, connstring);
            myread1 = comm1.ExecuteReader();
            if (myread1.HasRows)
            {
                while (myread1.Read())
                {
                    if (!(myread1["姓名"] is DBNull))
                    {
                        textBox3.Text = myread1.GetString(0).ToString();
                    }
                    if (!(myread1["课程名"] is DBNull))
                    {
                        textBox4.Text = myread1.GetString(1).ToString();
                    }
                    if (!(myread1["成绩"] is DBNull))
                    {
                        textBox5.Text = myread1.GetDouble(2).ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("该学生没有选这门课", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            myread1.Close();
            //--------------------------------------------------------------------------------------------
            string sql2 = "select 学生_成绩.学号,成绩,dense_rank() over(order by 成绩 desc) as rate_dense_rank " +
                "from 学生_成绩, 学生 where 课号='" + textBox2.Text + "' and 学生_成绩.学号=学生.学号 and 学生.班级=" + classnum;
            SqlDataReader myread2;
            SqlCommand comm2 = new SqlCommand(sql2, connstring);
            myread2 = comm2.ExecuteReader();
            if (myread2.HasRows)
            {
                while (myread2.Read())
                {
                    if (!(myread2["学号"] is DBNull))
                    {
                        if (myread2.GetString(0).ToString() == textBox1.Text)
                        {
                            textBox6.Text = myread2.GetInt64(2).ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("排序出错", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            //always call Close when done reading
            myread2.Close();
            //-------------------------------------------------------------------------------------
            string sql3 = "select 学生_成绩.学号,成绩,dense_rank() over(order by 成绩 desc) as rate_dense_rank " +
                "from 学生_成绩, 学生 where 课号='" + textBox2.Text + "' and 学生_成绩.学号=学生.学号 and 学生.院号=" + cologenum;
            SqlDataReader myread3;
            SqlCommand comm3 = new SqlCommand(sql3, connstring);
            myread3 = comm3.ExecuteReader();
            if (myread3.HasRows)
            {
                while (myread3.Read())
                {
                    if (!(myread3["学号"] is DBNull))
                    {
                        if (myread3.GetString(0).ToString() == textBox1.Text)
                        {
                            textBox7.Text = myread3.GetInt64(2).ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("排序出错", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            myread3.Close();
            //Close the connection when done with it
            connstring.Close();
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
        /// <summary>
        /// 判断课号是否存在
        /// </summary>
        /// <param name="stu_num"></param>
        /// <returns></returns>
        private bool cnoIsExists(string cno)
        {
            string comstr = String.Format("select count(*) from 课程 where 课号='{0}'", cno);
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
