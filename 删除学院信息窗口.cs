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
    public partial class 删除学院信息窗口 : Form
    {
        private string sd_num;
        public SqlConnection m_connection;

        public string Sd_Num
        {
            set
            {
                sd_num = value;
            }
            get
            {
                return sd_num;
            }
        }
        public 删除学院信息窗口()
        {
            InitializeComponent();
        }

        private void quit_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Sure_button_Click(object sender, EventArgs e)
        {
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            string cmdText = "delete from 学院 where 院号='" + sd_num + "'";
            SqlCommand DeleteCom = new SqlCommand(cmdText, m_connection);
            if (MessageBox.Show("删除学院将级联删除该学院的学生！你确认删除本条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
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

        private void 删除学院信息窗口_Load(object sender, EventArgs e)
        {
            textBox1.Text = sd_num;
        }
    }
}
