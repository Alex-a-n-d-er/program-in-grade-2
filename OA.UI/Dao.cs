using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OA.UI 
{
    class Dao
    {
        MySqlConnection sqlcon1;
        public MySqlConnection connect()
        {
            string constring = "datasource=localhost ; user = root; password = PINEKLLL4386_zjc; database = approval_sys;";
            sqlcon1 = new MySqlConnection(constring);
            sqlcon1.Open();
            return sqlcon1;
        }
        public MySqlCommand command(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)//更新操作，int是返回的行数的数据类型
        {
            return command(sql).ExecuteNonQuery();
        }
        public MySqlDataReader read(string sql)//读取操作
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sqlcon1.Close();//关闭数据库链接
        }
    }
}

/*
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OA.Models;
using OA.BLL;
using OA.Common;

namespace OA.UI
{
    public partial class login : Form
    {
        EmployeeManager employeeManager = new EmployeeManager();
        public void Login()
        {
            staff stf = new staff();
            stf.Idstaff = int.Parse(this.textid.Text.Trim());
            stf.Pswstaff = this.textpsw.Text;

            Config.LoginStaff = employeeManager.Login(stf);
            if (Config.LoginStaff != null)
            {
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败，请检查账号密码");
            }
        }
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textid.Text != "" && textpsw.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }

        private void textid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MessageBox.Show("成功退出");
            Application.Exit();
        }
    }
}
*/