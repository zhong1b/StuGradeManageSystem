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
    public partial class 学生成绩分析窗口 : Form
    {
        public SqlConnection connstring;
        public 学生成绩分析窗口()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("学号不能为空!!");
                textBox1.Focus();//光标制定textBox1中
                return;
            }
            string connectionString = Session.connstr;
            connstring = new SqlConnection(connectionString);
            connstring.Open();
            if(snoIsExists(textBox1.Text) == false)
            {
                MessageBox.Show("学号不存在!!");
                textBox1.Focus();//光标制定textBox1中
                return;
            }
            string stuText1 = "select 课号,课程名,成绩,学分 from 学生_成绩 where 学号= '" + textBox1.Text +"'";
            SqlDataAdapter da = new SqlDataAdapter(stuText1, connstring);
            DataSet ds = new DataSet("s");//创建dataset对象，调用指定数据集名称的构造函数
            da.Fill(ds, "stable");//使用SqlDataAdapter对象的fill方法填充数据集，填充到“stable“表
            //dataGridview控件绑定数据源
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "stable";

            string stuText2 = "select AVG(成绩) from 学生_成绩 where 学号= '" + textBox1.Text + "'";
            SqlDataReader myread;
            SqlCommand comm = new SqlCommand(stuText2, connstring);
            myread = comm.ExecuteReader();

            if (myread.HasRows)
            {
                while (myread.Read())
                {

                    textBox2.Text = myread.GetDouble(0).ToString("0.00");
                    textBox2.ReadOnly = true;
                    //if (!(myread["姓名"] is DBNull))
                    //{
                    //    textBox2.Text = myread.GetString(0).ToString();
                    //} 
                }
            }
            myread.Close();
            string stuText3 = "xuefenji '" + textBox1.Text + "'";
            SqlDataReader myread3;
            SqlCommand comm3 = new SqlCommand(stuText3, connstring);
            myread3 = comm3.ExecuteReader();
            while (myread3.Read())
            {

                textBox3.Text = myread3.GetDouble(0).ToString("0.00");
                textBox3.ReadOnly = true;

            }
            myread3.Close();
            //----------------------------------------------------------
            string sql0 = "select 班级, 院号 from 学生 where 学号='" + textBox1.Text + "'";
            SqlDataReader myread0;
            SqlCommand comm0 = new SqlCommand(sql0, connstring);
            myread0 = comm0.ExecuteReader();
            string classnum = "", cologenum = "";
            if (myread0.HasRows)
            {
                while (myread0.Read())
                {
                    if (!(myread0["班级"] is DBNull))
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
            //------------------------------------------------------------------------------
            string sql2 = "select 学生_学分积.学号,CreditInt,dense_rank() over(order by CreditInt desc) as rate_dense_rank " +
                "from 学生_学分积, 学生 where 学生_学分积.学号=学生.学号 and 学生.班级=" + classnum;
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
                            textBox4.Text = myread2.GetInt64(2).ToString();
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
            //-----------------------------------------------------------------------
            string sql4 = "select 学生_学分积.学号,CreditInt,dense_rank() over(order by CreditInt desc) as rate_dense_rank " +
               "from 学生_学分积, 学生 where 学生_学分积.学号=学生.学号 and 学生.院号=" + cologenum;
            SqlDataReader myread4;
            SqlCommand comm4 = new SqlCommand(sql4, connstring);
            myread4 = comm4.ExecuteReader();
            if (myread4.HasRows)
            {
                while (myread4.Read())
                {
                    if (!(myread4["学号"] is DBNull))
                    {
                        if (myread4.GetString(0).ToString() == textBox1.Text)
                        {
                            textBox5.Text = myread4.GetInt64(2).ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("排序出错", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            myread4.Close();
            connstring.Close();

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
