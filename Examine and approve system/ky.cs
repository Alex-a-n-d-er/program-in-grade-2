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

    public partial class ky : Form
    {
       // static public string n1;

    public ky()
        {
            InitializeComponent();
        }
    

    private void ky_Load(object sender, EventArgs e)
        {
            label4.Text = Data.UName;
        }

        private void 订单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 待处理订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* string str;
            MySqlConnection myconn=new MySqlConnection(); ;
            MySqlCommand mycmd = new MySqlCommand();
            str= "datasource=localhost ; user = root; password = 123456; database = approval_sys;";
            myconn.ConnectionString = str;
            myconn.Open();
            n1= "select max(approval_id) approval_id from approval_sys.approval";
            myconn.Close();*/
            orderky orderky1 = new orderky();
            orderky1.ShowDialog();

        }

       
        private void 订单审批历史ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderListky orderList1 = new orderListky(2);
            orderList1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
