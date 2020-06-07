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
    public partial class 删除课程信息窗口 : Form
    {
        private string c_num;
        public SqlConnection m_connection;

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
        public 删除课程信息窗口()
        {
            InitializeComponent();
        }

        private void quit_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void 删除课程信息窗口_Load(object sender, EventArgs e)
        {
            textBox1.Text = c_num;
        }

        private void Sure_button_Click(object sender, EventArgs e)
        {
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            string cmdText = "delete from 课程 where 课号='" + c_num + "'";
            SqlCommand DeleteCom = new SqlCommand(cmdText, m_connection);
            if (MessageBox.Show("删除课程将级联删除该课程选课记录！你确认删除本条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (DeleteCom.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("信息删除成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            else
            {
                MessageBox.Show("信息删除失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            m_connection.Close();
        }
    }
}
