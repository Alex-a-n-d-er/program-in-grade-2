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
    public partial class orderListkz : Form
    {
        public int tlevel;
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from approval_sys.approval";
            IDataReader dc = dao.read(sql);
            string approval_id, applicant_id, applicant_name, approver_id, approver_name, process_id, status = "";
            while (dc.Read())
            {

                approval_id = dc[0].ToString();
                applicant_id = dc[1].ToString();
                applicant_name = dc[2].ToString();
                approver_id = dc[3].ToString();
                approver_name = dc[4].ToString();
                process_id = dc[5].ToString();
                status = dc[11].ToString();


                if (applicant_id != Data.UID)//筛选自己的订单
                {
                    continue;
                }

                int flag = 0;
                switch (dc[11])
                {
                    case -1:
                        status = "订单已取消";
                        break;
                    case 0:
                        status = "审批中";
                        flag = 1;
                        break;
                    case 1:
                        status = "审批通过";
                        break;
                    case 2:
                        status = "审批驳回";
                        break;
                }
                string[] table = { approval_id, applicant_id, applicant_name, approver_id, approver_name, process_id, status };
                if (flag == 0)
                {
                    dataGridView1.Rows.Add(table);
                }
            }
            dc.Close();
            dao.DaoClose();
        }
        public orderListkz(int s)
        {
            InitializeComponent();
            tlevel=s;
        }

        private void orderList_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
