using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Examine_and_approve_system
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }
        public void Login()
        {
            if (ky.Checked == true)
            {
                Dao dao = new Dao();
             // string sql = "select * from eaas where id='"+textBox1.Text+"'and psw='"+textBox2.Text+"'";
             //   string sql2 = String.Format("select * from eaas where id='{0}' and psw='1'", textBox1.Text, textBox2.Text);
                string sql = $"select * from users where user_id='{textBox1.Text}'and password='{textBox2.Text}'and user_id<'2000'";
                MySqlDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID=dc["user_id"].ToString();
                    Data.UName = dc["username"].ToString();
                    MessageBox.Show("登陆成功");
                    ky ky1 = new ky();
                    this.Hide();                  
                    ky1.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
 
                }
                dao.DaoClose();
            }
           
            if (kz.Checked == true)
            {
                Dao dao = new Dao();
                // string sql = "select * from eaas where id='"+textBox1.Text+"'and psw='"+textBox2.Text+"'";
                //   string sql2 = String.Format("select * from eaas where id='{0}' and psw='1'", textBox1.Text, textBox2.Text);
                string sql = $"select * from users where user_id='{textBox1.Text}'and password='{textBox2.Text}'and user_id<'3000' and user_id>'1000'";
                MySqlDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["user_id"].ToString();
                    Data.UName = dc["username"].ToString();
                    MessageBox.Show("登陆成功");
                    kz kz1 = new kz();
                    this.Hide();
                    kz1.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                    
                }
                dao.DaoClose();
            }

            if (cz.Checked == true)
            {
                Dao dao = new Dao();
                // string sql = "select * from eaas where id='"+textBox1.Text+"'and psw='"+textBox2.Text+"'";
                //   string sql2 = String.Format("select * from eaas where id='{0}' and psw='1'", textBox1.Text, textBox2.Text);
                string sql = $"select * from users where user_id='{textBox1.Text}'and password='{textBox2.Text}'and user_id>='3000'";
                MySqlDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["user_id"].ToString();
                    Data.UName = dc["username"].ToString();
                    MessageBox.Show("登陆成功");
                    cz cz1 = new cz();
                    this.Hide();
                    cz1.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                    
                }
                dao.DaoClose();
            }
          //  MessageBox.Show("单选框请先选中");
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
