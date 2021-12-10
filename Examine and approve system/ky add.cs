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
    public partial class ky_add : Form
    {
       
        public ky_add()
        {
            InitializeComponent();
        }

        private void ky_add_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                orderky.a++;
                Dao dao = new Dao();
                string sql = $"insert into application_details(" +
                    $"apply_id," +
                    $"applicant_id," +
                    $"applicant_name," +
                    $"sum_price," +
                    $"apply_detail," +
                    $"dev_price," +
                    $"dev_name," +
                    $"dev_code," +
                    $"dev_num," +
                    $"_status" +
                    $") values('{orderky.a}','{Data.UID}','{Data.UName}','{0}','{textBox1.Text}','{textBox5.Text}','{textBox4.Text}','{textBox4.Text}','{textBox5.Text}','0')";
                /*string sql1 = 
                    $"insert into application_details(" +
                    $"apply_id," +
                    $"applicant_id," +
                    $"applicant_name," +
                    $"apply_detail," +
                    $"sum_price," +
                    $"status" +
                    $") values('{textBox1.Text}','{Data.UID}','{Data.UName}','{textBox4.Text}','{textBox6.Text}','{textBox7.Text}')";*/
                int n1 = dao.Execute(sql);
                if (n1 > 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
                Dao dao1 = new Dao();
                string sql2 = $"insert into approval(" +
                        $"approval_id," +
                        $"applicant_id," +
                        $"applicant_name," +
                        $"process_id," +
                        $"_status" +
                        $") values('{orderky.a}','{Data.UID}','{Data.UName}','0','{textBox7.Text}')";
                int n2 = dao1.Execute(sql2);
                if (n2 > 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }

            }
            
        }
        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
