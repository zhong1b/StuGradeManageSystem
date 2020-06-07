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
    public partial class 综合查询窗口 : Form
    {

       // private string stuText;
        public 综合查询窗口()
        {
            InitializeComponent();
        }

        private void 综合查询窗口_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           // List<CtbBookInformation> cBooks = new List<CtbBookInformation>();
           // CtbBookInformationBLL cBookBll = new CtbBookInformationBLL();

            string sqlstr = "";

            if (checkBox1.Checked)
            {
                if (textBox1.Text != "")
                {
                    sqlstr = sqlstr + "and ss.stu_num=" + textBox1.Text + " ";
                }
            }
            if (checkBox2.Checked)
            {
                if (textBox2.Text != "")
                {
                    sqlstr = sqlstr + "and sub_num=" + textBox2.Text + " ";
                }
            }

            string connectionString = Session.connstr;
            SqlConnection connstring = new SqlConnection(connectionString);
         //   SqlConnection m_connection = new SqlConnection(connectionString);
            connstring.Open();//这是什么？
           // string stu_num = textBox1.Text;
            string sql =( "select ss.stu_num,sub_num,ss.stu_name,stu_local,stu_major,sub_name,grade from ss,sg where ss.stu_num=sg.stu_num "+sqlstr) ;
            //InitializeComponent();//这是什么？
           // SqlDataReader myread;
            SqlCommand comm = new SqlCommand(sql, connstring);
          //  myread = comm.ExecuteReader();
         //  if (comm.ExecuteNonQuery() <1)
          //  int i;
            //i = 
          /*  if (comm.ExecuteNonQuery()>0)
            {
                MessageBox.Show("信息查询失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("信息查询成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            */
          //  m_connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, connstring);
            DataSet ds = new DataSet("s");
            da.Fill(ds, "s");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "s";
            connstring.Close();
            // m_connection.Close();
          /*  if (sqlstr != "")
            {
                sqlstr = sqlstr.Remove(0, 4);//去掉字符串中最前面的and
                cBooks = cBookBll.GetModelList(sqlstr);
                if (cBooks.Count > 0)
                {
                    this.Columns.Clear();
                    this.dgvSearchResult.DataSource = cBooks;
                    this.dgvSearchResult.Columns["bookID"].HeaderText = "图书编号";
                    this.dgvSearchResult.Columns["bookSortID"].HeaderText = "图书类型编号";
                    this.dgvSearchResult.Columns["bookName"].HeaderText = "图书名称";
                    this.dgvSearchResult.Columns["bookAutor"].HeaderText = "图书作者";
                    this.dgvSearchResult.Columns["bookPublish"].HeaderText = "图书出版社";
                    this.dgvSearchResult.Columns["bookPubDate"].HeaderText = "出版日期";
                    this.dgvSearchResult.Columns["bookPrice"].HeaderText = "定价";
                    this.dgvSearchResult.Columns["bookSummary"].HeaderText = "内容摘要";
                    this.dgvSearchResult.Columns["bookRealNum"].HeaderText = "实际数量";
                    this.dgvSearchResult.Columns["bookLendNum"].HeaderText = "借出数量";
                    this.dgvSearchResult.Columns["bookResDate"].HeaderText = "卡片登记日期";
                }
                else
                {
                    MessageBox.Show("未查到相关信息！", "操作提示");
                }
            }
            else
            {
                sqlstr = "bookID>0";
                cBooks = cBookBll.GetModelList(sqlstr);
                if (cBooks.Count > 0)
                {
                    this.dgvSearchResult.Columns.Clear();
                    this.dgvSearchResult.DataSource = cBooks;
                    this.dgvSearchResult.Columns["bookID"].HeaderText = "图书编号";
                    this.dgvSearchResult.Columns["bookSortID"].HeaderText = "图书类型编号";
                    this.dgvSearchResult.Columns["bookName"].HeaderText = "图书名称";
                    this.dgvSearchResult.Columns["bookAutor"].HeaderText = "图书作者";
                    this.dgvSearchResult.Columns["bookPublish"].HeaderText = "图书出版社";
                    this.dgvSearchResult.Columns["bookPubDate"].HeaderText = "出版日期";
                    this.dgvSearchResult.Columns["bookPrice"].HeaderText = "定价";
                    this.dgvSearchResult.Columns["bookSummary"].HeaderText = "内容摘要";
                    this.dgvSearchResult.Columns["bookRealNum"].HeaderText = "实际数量";
                    this.dgvSearchResult.Columns["bookLendNum"].HeaderText = "借出数量";
                    this.dgvSearchResult.Columns["bookResDate"].HeaderText = "卡片登记日期";
                }
                else
                {
                    MessageBox.Show("未查到相关信息！", "操作提示");
                }
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
