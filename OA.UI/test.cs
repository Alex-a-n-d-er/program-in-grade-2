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
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;
namespace OA.UI
{
    public partial class orderky : Form
    {
        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201:                //鼠标左键按下的消息   
                    m.Msg = 0x00A1;         //更改消息为非客户区按下鼠标   
                    m.LParam = IntPtr.Zero; //默认值   
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内   
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        ApplyManager applyManager = new ApplyManager();
        public void Table(int n)
        {
            dataGridViewApply.Rows.Clear();//清空旧数据
            List<approval> list;

            if ((int)Config.LoginStaff.Idstaff >= 2000)
            {
                list = applyManager.GetApproval(n);
            }
            else
            {
                list = applyManager.GetApproval(n, Config.LoginStaff.Idstaff);
            }
            string header, note, crtime, area, locate, id;
            foreach (approval apl in list)
            {
                header = apl.Header;
                note = apl.Note;
                crtime = apl.Create_time.ToString();
                //box = apl.box.ToString();
                area = apl.Area.ToString();
                locate = apl.Locate;
                id = apl.Idapproval;
                string[] table = { header, note, crtime, area, locate, id };
                //MessageBox.Show(header);
                dataGridViewApply.Rows.Add(table);
            }

        }
        public orderky()
        {
            InitializeComponent();
            //Table();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        DictionariesManager dictionariesManager = new DictionariesManager();
        private void orderky_Load(object sender, EventArgs e)
        {
            List<dictionary> diclist = dictionariesManager.GetList("BoxValue");
            foreach (dictionary dict in diclist)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dict.Dicname;
                tn.Tag = dict.Iddictionary;
                this.treeViewBox.Nodes.Add(tn);
            }
            button1.Text = Config.LoginStaff.Namestaff;
        }
        public void Table()
        {


        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void button6_Click(object sender, EventArgs e)
        {

        }


        public void Tableid()//精准查询订单号
        {


        }
        public void TableName()//模糊查询申请者名字
        {

        }



        private void button5_Click(object sender, EventArgs e)
        {
            TableName();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            Tableid();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void treeViewBox_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str = e.Node.Tag.ToString();
            int n = int.Parse(str);
            //MessageBox.Show(str);
            Table(n);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            Config.idapproval = dataGridViewApply.SelectedRows[0].Cells[5].Value.ToString();    //获取订单号
                                                                                                //MessageBox.Show(id);
                                                                                                //label2.Text = dataGridViewApply.SelectedRows[0].Cells[0].Value.ToString();
            approval Approval = new approval();
            Approval = applyManager.GetApproval(Config.idapproval);
            ApplyForm applyForm = new ApplyForm();
            if (Approval.box == 1)
            {
                applyForm = new ApplyForm(Common.BoxValue.草稿箱);
            }
            else if (Approval.box == 2)
            {
                applyForm = new ApplyForm(Common.BoxValue.待批箱);
            }
            else if (Approval.box == 3)
            {
                applyForm = new ApplyForm(Common.BoxValue.已批箱);
            }
            else if (Approval.box == 4)
            {
                applyForm = new ApplyForm(Common.BoxValue.已归档);
            }
            else if (Approval.box == 5)
            {
                applyForm = new ApplyForm(Common.BoxValue.垃圾箱);
            }
            applyForm.Show();
        }

        private void tsmiSP_Click(object sender, EventArgs e)
        {
            ApplyForm applyform = new ApplyForm(Common.BoxValue.草稿箱);
            applyform.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridViewApply_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
