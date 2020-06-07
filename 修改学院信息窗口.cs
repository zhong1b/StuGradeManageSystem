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
    public partial class 修改学院信息窗口 : Form
    {
        private string sd_num;
        private string sd_name;
        private SqlConnection m_connection;

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
        public string Sd_Name
        {
            set
            {
                sd_name = value;
            }
            get
            {
                return sd_name;
            }
        }
        public 修改学院信息窗口()
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
                MessageBox.Show("院号不能为空!!");
                textBox1.Focus();//鼠标制定textBox1中
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("院名不能为空!!");
                textBox2.Focus();//鼠标制定textBox1中
                return;
            }
            string connectionString = Session.connstr;
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();
            string cmdText = "update 学院 set 院号='" + textBox1.Text + "',院名='" + textBox2.Text +
                "' where 院号='" + sd_num + "'";
            SqlCommand UpdateCom = new SqlCommand(cmdText, m_connection);
            //if (UpdateCom.ExecuteNonQuery() > 0)//
            if (UpdateCom.ExecuteNonQuery() > 0)

            {
                MessageBox.Show("学院信息修改成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                m_connection.Close();
            }
            else
            {
                MessageBox.Show("学院信息修改失败", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                m_connection.Close();

            }
        }

        private void 修改学院信息窗口_Load(object sender, EventArgs e)
        {
            textBox1.Text = sd_num;
            textBox2.Text = sd_name;
            textBox1.ReadOnly = true;
        }
    }
}
