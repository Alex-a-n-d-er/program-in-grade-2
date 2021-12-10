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
    public partial class cz : Form
    {
        public cz()
        {
            InitializeComponent();
        }

        private void 订单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordercz ordercz1 = new ordercz();
            ordercz1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cz_Load(object sender, EventArgs e)
        {
            label4.Text = Data.UName;
        }
    }
}
