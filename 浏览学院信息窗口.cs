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
    public partial class 浏览学院信息窗口 : Form
    {
        private 添加学院信息窗口 FormAddN;
        private 修改学院信息窗口 FormModifyN;
        private 删除学院信息窗口 FormDeleteN;
        private SqlConnection m_connection;
        private string stuText;
        private int indexS = 0;
        public 浏览学院信息窗口()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void 浏览学院信息窗口_Load(object sender, EventArgs e)
        {
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            stuText = "select * from 学院";
            SqlDataAdapter da = new SqlDataAdapter(stuText, m_connection);
            DataSet ds = new DataSet("s");//创建dataset对象，调用指定数据集名称的构造函数
            da.Fill(ds, "stable");//使用SqlDataAdapter对象的fill方法填充数据集，填充到“stable“表
            //dataGridview控件绑定数据源
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "stable";
            m_connection.Close();
            if (Session.typename == "学生")
            {
                this.button1.Enabled = false;
                this.button2.Enabled = false;
                this.button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddN = new 添加学院信息窗口();
            DialogResult re = FormAddN.ShowDialog();
            //如果添加了学籍信息，更新浏览学籍信息界面
            if (DialogResult.OK == re)
            {
                SqlDataAdapter da = new SqlDataAdapter(stuText, m_connection);
                DataSet ds = new DataSet("s");//创建dataset对象，调用指定数据集名称的构造函数
                da.Fill(ds, "stable");//使用SqlDataAdapter对象的fill方法填充数据集，填充到“stable“表
                //dataGridView1.AutoGenerateColums = ture;
                //dataGridview控件绑定数据源
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "stable";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormModifyN = new 修改学院信息窗口();

            FormModifyN.Sd_Num = dataGridView1.Rows[indexS].Cells[0].Value.ToString();
            FormModifyN.Sd_Name = dataGridView1.Rows[indexS].Cells[1].Value.ToString();
            
            //FormModifyN.Stu_Major = dataGridView1.Rows[indexS].Cells[5].Value.ToString();
            DialogResult re = FormModifyN.ShowDialog();
            if (DialogResult.OK == re)
            {
                SqlDataAdapter da = new SqlDataAdapter(stuText, m_connection);
                DataSet ds = new DataSet("s");
                da.Fill(ds, "s");
                //dataGridView1.AutoGenerateColums = ture;
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "s";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDeleteN = new 删除学院信息窗口();
            FormDeleteN.Sd_Num = dataGridView1.Rows[indexS].Cells[0].Value.ToString();
            DialogResult re = FormDeleteN.ShowDialog();
            if (DialogResult.OK == re)
            {
                SqlDataAdapter da = new SqlDataAdapter(stuText, m_connection);
                DataSet ds = new DataSet("s");
                da.Fill(ds, "s");
                //dataGridView1.AutoGenerateColums = ture;
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "s";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexS = dataGridView1.CurrentCell.RowIndex;
        }
    }
}
