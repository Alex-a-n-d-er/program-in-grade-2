using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examine_and_approve_system
{
  

    public partial class kz : Form
    {
        
        public kz()
        {
            InitializeComponent();
        }

        private void kz_Load(object sender, EventArgs e)
        {
            label4.Text = Data.UName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 订单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void 系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 待处理订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderkz order1 = new orderkz();
            order1.ShowDialog();
        }

        private void 订单审批历史ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int level = 2;
            orderListkz orderListkz1 = new orderListkz(level);
            orderListkz1.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
