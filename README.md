# StuGradeManageSystem
1.首先利用备份好的文件“学生学籍管理系统.bak”将数据库“学生学籍管理系统”还原，保持数据库名为“学生学籍管理系统”不变
2.使用VS2017打开“源码_StuGradeManageSystem”文件夹下的 StudentGradeManageSystem.csproj，然后在“StudentGradeManageSystem"->“引用”的app.config文件中，将语句connectionString = "data source=127.0.0.1;initial Catalog=学生学籍管理系统;uid=sa;pwd=971221"中的971221改的你sa用户的密码（或者直接将你sa用户的密码改成971221，则不需改代码）
3.在VS2017中执行或运行“StudentGradeManageSystem”->"bin"->"Debug"目录中的“XJManageSystem.exe”文件即可（若修改了代码，请重新生成解决方案）
4. 运行后在登录界面有初始的管理员用户，请选择用户类型为“管理员”登录

备注：若运行无窗口没有任何反应，请打开SQL Sever控制程序，选SQL Sever网络配置->SQLEXPRESS协议，右键TCP/IP选择属性，在属性页面选“IP地址”，将IP1的IP地址改为127.0.0.1，将最后的IPAll的TCP端口改为1433，确定后重启TCP/IP，重启SQL Sever服务，之后应该就可以正常运行了。
