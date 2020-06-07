using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
namespace XJManageSystem
{
    static class Program
    {

        /// <summary>
        /// 启动登陆窗口
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 登录窗口());
        }
    }
}
