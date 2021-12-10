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
    public partial class orderkz : Form
    {
        public static int a = 1001;
        public static string s3;
        public orderkz()
        {
            InitializeComponent();
            Table();//在最上面会失败
           //Table1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void order_Load(object sender, EventArgs e)
        {

        }
        //从数据库读取数据显示在表格控件中
        public void Table()
        {

            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from approval_sys.approval";
            IDataReader dc = dao.read(sql);
            string approval_id, applicant_id, applicant_name, approver_id, approver_name, process_id, status;
            while (dc.Read())
            {
                string s = dc[0].ToString();
                int temp = int.Parse(s);
                a = a > temp ? a : temp;        //确保a为最新订单号

                approval_id = dc[0].ToString();
                applicant_id = dc[1].ToString();
                applicant_name = dc[2].ToString();
                approver_id = dc[3].ToString();
                approver_name = dc[4].ToString();
                process_id = dc[5].ToString();
                status = dc[11].ToString();

                if (approver_id != Data.UID)//筛选自己的订单
                {
                    continue;
                }


                switch (dc[11])
                {
                    case -1:
                        status = "订单已取消";
                        break;
                    case 0:
                        status = "审批中";
                        break;
                    case 1:
                        status = "审批通过";
                        break;
                    case 2:
                        status = "审批驳回";
                        break;
                }

                string[] table = { approval_id, applicant_id, applicant_name, approver_id, approver_name, process_id, status };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();    //获取订单号
                label3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr = MessageBox.Show("是否确认通过申请？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"update approval set _status = 0 where approval_id = '{id}'";
                    //string sql1 = $"update application_details set _status = -1 where apply_id = '{id}'";
                    Dao login = new Dao();
                    if (login.Execute(sql) > 0)
                    {
                        MessageBox.Show("操作成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                    }
                    login.DaoClose();
                }

            }
            catch
            {

            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();    //获取订单号
                label3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr = MessageBox.Show("是否确认打回申请？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"update approval set _status = 2 where approval_id = '{id}'";
                    //string sql1 = $"update application_details set _status = -1 where apply_id = '{id}'";
                    Dao login = new Dao();
                    if (login.Execute(sql) > 0)
                    {
                        MessageBox.Show("操作成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                    }

                    Dao dao = new Dao();//驳回原因
                    sql = $"update approval set reject_reason = '{textBox3.Text}' where approval_id = '{id}'";
                    int n1 = dao.Execute(sql);
                    if (n1 > 0)
                    {
                        MessageBox.Show("添加成功");
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                    login.DaoClose();
                }


            }
            catch
            {

            }


        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)//订单号查询
        {

            Tableid();
        }
        public void Tableid()//精准查询订单号
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql2 = $"select * from approval_sys.approval where approval_id ='{textBox1.Text}'";

            IDataReader dc = dao.read(sql2);
            string approval_id, applicant_id, applicant_name, approver_id, approver_name, process_id, status;
            while (dc.Read())
            {

                approval_id = dc[0].ToString();
                applicant_id = dc[1].ToString();
                applicant_name = dc[2].ToString();
                approver_id = dc[3].ToString();
                approver_name = dc[4].ToString();
                process_id = dc[5].ToString();
                status = dc[11].ToString();

                if (approver_id != Data.UID)//筛选自己的订单
                {
                    continue;
                }


                switch (dc[11])
                {
                    case -1:
                        status = "订单已取消";
                        break;
                    case 0:
                        status = "审批中";
                        break;
                    case 1:
                        status = "审批通过";
                        break;
                    case 2:
                        status = "审批驳回";
                        break;
                }

                string[] table = { approval_id, applicant_id, applicant_name, approver_id, approver_name, process_id, status };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();

          
        }
        public void TableName()//模糊查询申请者名字
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql2 = $"select * from approval_sys.approval where applicant_name like '%{textBox2.Text}%'";

            IDataReader dc = dao.read(sql2);
            string approval_id, applicant_id, applicant_name, approver_id, approver_name, process_id, status;
            while (dc.Read())
            {

                approval_id = dc[0].ToString();
                applicant_id = dc[1].ToString();
                applicant_name = dc[2].ToString();
                approver_id = dc[3].ToString();
                approver_name = dc[4].ToString();
                process_id = dc[5].ToString();
                status = dc[11].ToString();

                if (approver_id != Data.UID)//筛选自己的订单
                {
                    continue;
                }


                switch (dc[11])
                {
                    case -1:
                        status = "订单已取消";
                        break;
                    case 0:
                        status = "审批中";
                        break;
                    case 1:
                        status = "审批通过";
                        break;
                    case 2:
                        status = "审批驳回";
                        break;
                }

                string[] table = { approval_id, applicant_id, applicant_name, approver_id, approver_name, process_id, status };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TableName();
        }

        private void button4_Click(object sender, EventArgs e)//刷新
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";

        }
    }
}
