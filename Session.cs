using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace XJManageSystem
{
    // Session作为一个静态类，用于保存用户登陆后的信息
    // 可以利用Session中存储的用户权限决定后面的显示界面

    public static class Session
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        public static string userid = "";
        /// <summary>
        /// 用户密码
        /// </summary>
        public static string idpassword = "";
        /// <summary>
        /// 用户权限
        /// </summary>
        public static string typename = "";
        /// <summary>
        /// 连接语句
        /// </summary>
        public static string connstr = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
        
        //重置用户信息
        public static void ReSetSession()
        {
            userid = "";
            idpassword = "";
            typename = "";
            connstr = "";
        }

    }
}


