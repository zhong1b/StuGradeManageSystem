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
    public partial class 浏览成绩信息窗口 : Form
    {
        private 添加学生成绩窗口 FormAddN;
        private 修改学生成绩窗口 FormModifyN;
        private 删除学生成绩窗口 FormDeleteN;
        private SqlConnection m_connection;
        private string stuText;
        private int indexS = 0;
        public 浏览成绩信息窗口()
        {
            InitializeComponent();
        }
    
        private void cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            indexS = dataGridView1.CurrentCell.RowIndex;
        }
        private void 浏览成绩信息窗口_Load(object sender, EventArgs e)
        {
            
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            stuText = "select * from 学生_成绩";
            SqlDataAdapter da = new SqlDataAdapter(stuText, m_connection);
            DataSet ds = new DataSet("s");//创建dataset对象，调用指定数据集名称的构造函数
            da.Fill(ds, "stable");//使用SqlDataAdapter对象的fill方法填充数据集，填充到“stable“表
            //dataGridview控件绑定数据源
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "stable";
            m_connection.Close();
            //SqlDataAdapter da = new SqlDataAdapter(stuText, m_connection);
            //DataSet ds = new DataSet("s");
            //da.Fill(ds, "s");
            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "s";
            //m_connection.Close();

        }
        /// <summary>
        /// 添加 按钮 触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            FormAddN = new 添加学生成绩窗口();
            DialogResult re = FormAddN.ShowDialog();
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
        /// <summary>
        /// 修改 按钮 触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            FormModifyN = new 修改学生成绩窗口();
            FormModifyN.Stu_Num = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FormModifyN.Stu_Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            FormModifyN.Sub_Num = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            FormModifyN.Sub_Name = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            FormModifyN.Grade = dataGridView1.CurrentRow.Cells[4].Value.ToString();
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
        /// <summary>
        /// 删除按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            FormDeleteN = new 删除学生成绩窗口();
            FormDeleteN.Stu_Num = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FormDeleteN.Sub_Num = dataGridView1.CurrentRow.Cells[2].Value.ToString();
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }


    }
}
