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
    public partial class Query_details : Form
    {
        public Query_details()
        {

            InitializeComponent();
            Table();
        }
        private void Query_details_Load(object sender, EventArgs e)
        {
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            Dao login = new Dao();
            string sql = $"select * from approval_sys.approval where approval_id='{orderky.id}'or approval_id = '{ordercz.id}'";             MySqlDataReader dc = login.read(sql);
    
            string approval_id, approver_name, process_id, create_time, modify_time, _status = "", reject_reason;
            while (dc.Read())
            {
                //string s = dc[0].ToString();
                //int temp = int.Parse(s);
                //a = a > temp ? a : temp;
                approval_id = dc[0].ToString();
                approver_name = dc[4].ToString();
                process_id = dc[5].ToString();
                create_time = dc[8].ToString();
                modify_time = dc[9].ToString();// DateTime.Now.ToString();
                reject_reason = dc[7].ToString();
                //dev_name = dc[6].ToString();
                switch (dc[11])
                {
                    case -1:
                        _status = "订单已取消";
                        break;
                    case 0:
                        _status = "审批中";
                        break;
                    case 1:
                        _status = "审批通过";
                        break;
                    case 2:
                        _status = "审批驳回";
                        break;
                }
                string[] table = { approval_id, approver_name, process_id, create_time, modify_time, _status, reject_reason };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            login.DaoClose();
        }
     
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Approval_System
{
    public partial class Query_details : Form
    {
        
    }
}
*/
