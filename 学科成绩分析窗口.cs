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
    public partial class 学科成绩分析窗口 : Form
    {
        public SqlConnection connstring;
        public 学科成绩分析窗口()
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
                MessageBox.Show("课号不能为空!!");
                textBox1.Focus();//光标制定textBox1中
                return;
            }
            string connectionString = Session.connstr;
            connstring = new SqlConnection(connectionString);
            connstring.Open();
            if (cnoIsExists(textBox1.Text) == false)
            {
                MessageBox.Show("课号不存在!!");
                textBox1.Focus();//光标制定textBox1中
                return;
            }
            string stuText1 = "select 学号,姓名,成绩 from 学生_成绩 where 课号= '" + textBox1.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(stuText1, connstring);
            DataSet ds = new DataSet("s");//创建dataset对象，调用指定数据集名称的构造函数
            da.Fill(ds, "stable");//使用SqlDataAdapter对象的fill方法填充数据集，填充到“stable“表
            //dataGridview控件绑定数据源
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "stable";

            string stuText2 = "select AVG(成绩) avg from 学生_成绩 where 课号= '" + textBox1.Text + "'";
            SqlDataReader myread2;
            SqlCommand comm = new SqlCommand(stuText2, connstring);
            myread2 = comm.ExecuteReader();
            if (myread2.HasRows)
            {
                while (myread2.Read())
                {
                    if(myread2["avg"] is DBNull)
                    {
                        MessageBox.Show("此门课尚没有成绩信息!!");
                        textBox1.Focus();//光标制定textBox1中
                        return;
                    }
                    else
                    {
                        textBox2.Text = myread2.GetDouble(0).ToString("0.00");
                        textBox2.ReadOnly = true;
                    }
                    

                }
            }
            else
            {
                MessageBox.Show("此门课尚没有成绩信息!!");
                textBox1.Focus();//光标制定textBox1中
                return;
            }
            myread2.Close();
            
            connstring.Close();
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
