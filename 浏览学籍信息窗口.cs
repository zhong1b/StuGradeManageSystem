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
    public partial class 浏览学籍信息窗口 : Form
    {
        private 添加学生学籍窗口 FormAddN;
        private 修改学生学籍窗口 FormModifyN;
        private 删除学生学籍窗口 FormDeleteN;
        private SqlConnection m_connection;
        private string stuText;
        private int indexS = 0;
        public 浏览学籍信息窗口()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击添加按钮，打开添加学生学籍窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_button_Click(object sender, EventArgs e)
        {
            FormAddN = new 添加学生学籍窗口();
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
        /// <summary>
        /// ”修改“按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modify_button_Click(object sender, EventArgs e)
        {
            FormModifyN = new 修改学生学籍窗口();

            FormModifyN.Stu_Num = dataGridView1.Rows[indexS].Cells[0].Value.ToString();
            FormModifyN.Stu_Name = dataGridView1.Rows[indexS].Cells[1].Value.ToString();
            FormModifyN.Stu_Sex = dataGridView1.Rows[indexS].Cells[2].Value.ToString();
            //FormModifyN.Stu_Phone = dataGridView1.Rows[indexS].Cells[3].Value.ToString();
            FormModifyN.Stu_Class = dataGridView1.Rows[indexS].Cells[3].Value.ToString();
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
        /// <summary>
        /// 删除 按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click_button(object sender, EventArgs e)
        {
           
            FormDeleteN = new 删除学生学籍窗口();
            FormDeleteN.Stu_Num = dataGridView1.Rows[indexS].Cells[0].Value.ToString();
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
        /// <summary>
        /// 退出浏览学籍信息窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quit_button_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Visible = false;
        }

        /// <summary>
        /// 加载窗口时连接数据库调用视图查询显示学籍信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 浏览学籍信息窗口_Load_1(object sender, EventArgs e)
        {
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            stuText = "select * from 学籍信息";
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
        /// 此事件在单元格的任何部分（包括边框和空白）被单击时发生。更新indexs为当前光标所在行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            indexS = dataGridView1.CurrentCell.RowIndex;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        //------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            查询学籍窗口 Form1 = new 查询学籍窗口();
            DialogResult re = Form1.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            浏览成绩信息窗口 Form1 = new 浏览成绩信息窗口();
            DialogResult re = Form1.ShowDialog();
        }
        
    }

}