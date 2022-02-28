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
    public partial class Query_details : Form
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
            dataGridView1.Rows.Clear();//清空旧数据
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
                dataGridView1.Rows.Add(table);
            }

        }

        public void Tableid()//精准查询订单号
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql2 = $"SELECT * FROM oa.approval WHERE idapproval ='{Config.NumID}'";

            IDataReader dc = dao.read(sql2);
            string header, note, create_time, area, locate, idapproval, idstaff, box;
            while (dc.Read())
            {

                idapproval = dc[0].ToString();
                idstaff = dc[1].ToString();
                header = dc[2].ToString();
                note = dc[3].ToString();
                create_time = dc[4].ToString();
                area = dc[6].ToString();
                locate = dc[7].ToString();
                //box = dc[5].ToString();

                if (idstaff != Config.LoginStaff.Idstaff.ToString())//筛选自己的订单
                {
                    continue;
                }


                switch (dc[5].ToString())
                {
                    case "1":
                        box = "草稿箱";
                        break;
                    case "2":
                        box = "待批箱";
                        break;
                    case "3":
                        box = "已批箱";
                        break;
                    case "4":
                        box = "已归档";
                        break;
                    default:
                        box = "垃圾箱";
                        break;
                }

                string[] table = { header, note, create_time, area, locate, idapproval, idstaff, box };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
        }

        public void TableStaff()//精准查询订单号
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql2 = $"SELECT * FROM oa.approval WHERE idstaff ='{Config.NameOAP}'";

            IDataReader dc = dao.read(sql2);
            string header, note, create_time, area, locate, idapproval, idstaff, box;
            while (dc.Read())
            {

                idapproval = dc[0].ToString();
                idstaff = dc[1].ToString();
                header = dc[2].ToString();
                note = dc[3].ToString();
                create_time = dc[4].ToString();
                area = dc[6].ToString();
                locate = dc[7].ToString();
                //box = dc[5].ToString();

/*                if (idstaff != Config.LoginStaff.Idstaff.ToString())//筛选自己的订单
                {
                    continue;
                }*/


                switch (dc[5].ToString())
                {
                    case "1":
                        box = "草稿箱";
                        break;
                    case "2":
                        box = "待批箱";
                        break;
                    case "3":
                        box = "已批箱";
                        break;
                    case "4":
                        box = "已归档";
                        break;
                    default:
                        box = "垃圾箱";
                        break;
                }

                string[] table = { header, note, create_time, area, locate, idapproval, box };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
        }

        public void TableContent()//精准查询订单号
        {
            string sql2 = "";
            if (Config.NumID != null)
            {
                if(Config.InfList != null)
                {
                    if(Config.NameOAP != null)
                    {
                        sql2 = $"SELECT * FROM oa.approval WHERE header like '%{Config.InfList}%' AND idstaff ='{Config.NameOAP}' AND idapproval ='{Config.NumID}'";
                    }
                    else
                    {
                        sql2 = $"SELECT * FROM oa.approval WHERE header like '%{Config.InfList}%' AND idapproval ='{Config.NumID}'";
                    }
                }
                else
                {
                    if (Config.NameOAP != null)
                    {
                        sql2 = $"SELECT * FROM oa.approval WHERE idstaff ='{Config.NameOAP}' AND idapproval ='{Config.NumID}'";
                    }
                    else
                    {
                        sql2 = $"SELECT * FROM oa.approval WHERE idapproval ='{Config.NumID}'";
                    }
                }
            }
            else
            {
                if (Config.InfList != null)
                {
                    if (Config.NameOAP != null)
                    {
                        sql2 = $"SELECT * FROM oa.approval WHERE header like '%{Config.InfList}%' AND idstaff ='{Config.NameOAP}' ";
                    }
                    else
                    {
                        sql2 = $"SELECT * FROM oa.approval WHERE header like '%{Config.InfList}%'";
                    }
                }
                else
                {
                    if (Config.NameOAP != null)
                    {
                        sql2 = $"SELECT * FROM oa.approval WHERE idstaff ='{Config.NameOAP}'";
                    }
                }
            }
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();

            IDataReader dc = dao.read(sql2);
            string header, note, create_time, area, locate, idapproval, idstaff, box;
            while (dc.Read())
            {

                idapproval = dc[0].ToString();
                idstaff = dc[1].ToString();
                header = dc[2].ToString();
                note = dc[3].ToString();
                create_time = dc[4].ToString();
                area = dc[6].ToString();
                locate = dc[7].ToString();
                //box = dc[5].ToString();

                /*                if (idstaff != Config.LoginStaff.Idstaff.ToString())//筛选自己的订单
                                {
                                    continue;
                                }*/


                switch (dc[5].ToString())
                {
                    case "1":
                        box = "草稿箱";
                        break;
                    case "2":
                        box = "待批箱";
                        break;
                    case "3":
                        box = "已批箱";
                        break;
                    case "4":
                        box = "已归档";
                        break;
                    default:
                        box = "垃圾箱";
                        break;
                }

                string[] table = { header, note, create_time, area, locate, idapproval, box };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
        }

        public Query_details()
        {

            InitializeComponent();
            //Tableid();
            //TableStaff();
            TableContent();
        }
        private void Query_details_Load(object sender, EventArgs e)
        {
            button7.Text = Config.LoginStaff.Namestaff;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

