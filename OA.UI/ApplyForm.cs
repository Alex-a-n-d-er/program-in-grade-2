using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OA.Common;
using OA.Models;
using OA.BLL;

namespace OA.UI
{

    public partial class ApplyForm : Form
    {
        public ApplyForm()
        {
            InitializeComponent();
        }
        ApplyManager applyManager = new ApplyManager();
        ProcessManager processManager = new ProcessManager();
        public BoxValue boxvalue;
        public string iduser;
        public ApplyForm(BoxValue boxValue, string idUser = null)
        {
            InitializeComponent();
            this.boxvalue = boxValue;
            this.iduser = idUser;
            this.label15.Text = Config.LoginStaff.Namestaff;
            this.label17.Text = Config.LoginStaff.Iddep.ToString();
        }

        private void ApplyForm_Load(object sender, EventArgs e)
        {
            switch (this.boxvalue) 
            {
                case BoxValue.垃圾箱:
                    break;
                case BoxValue.已归档:
                    break;
                case BoxValue.已批箱:
                    break;
                case BoxValue.待批箱:
                    this.groupBox2.Enabled = true;
                    approval Approval = new approval();
                    Approval = applyManager.GetApproval(Config.idapproval);
                    this.textBoxHeader.AppendText(Approval.Header);
                    this.textBoxLocate.AppendText(Approval.Locate);
                    this.textBoxNote.AppendText(Approval.Note);
                    this.textBoxArea.AppendText(Approval.Area.ToString());
                    break;
                case BoxValue.草稿箱:
                    approval Approval1 = new approval();
                    Approval1 = applyManager.GetApproval(Config.idapproval);
                    this.textBoxHeader.AppendText(Approval1.Header);
                    this.textBoxLocate.AppendText(Approval1.Locate);
                    this.textBoxNote.AppendText(Approval1.Note);
                    this.textBoxArea.AppendText(Approval1.Area.ToString());
                    this.groupBox1.Enabled = true;
                    break;
                default:
                    break;
            }

        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(this.textBoxHeader.Text!="" && this.textBoxNote.Text!=""&&this.textBoxArea.Text!="" && this.textBoxLocate.Text != "")
            {
                approval Approval = new approval();
                Approval.Idstaff = Config.LoginStaff.Idstaff;
                Approval.box = (int)BoxValue.草稿箱;
                Approval.Header = this.textBoxHeader.Text;
                Approval.Note = this.textBoxNote.Text;
                Approval.Area = double.Parse(this.textBoxArea.Text);
                Approval.Locate = this.textBoxLocate.Text;

                if (applyManager.Add(Approval))
                {
                    MessageBox.Show("保存成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！");

                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (this.textBoxHeader.Text != "" && this.textBoxNote.Text != "" && this.textBoxArea.Text != "" && this.textBoxLocate.Text != "")
            {
                approval Approval = new approval();
                Approval.Idstaff = Config.LoginStaff.Idstaff;
                Approval.box = (int)BoxValue.待批箱;
                Approval.Header = this.textBoxHeader.Text;
                Approval.Note = this.textBoxNote.Text;
                Approval.Area = double.Parse(this.textBoxArea.Text);
                Approval.Locate = this.textBoxLocate.Text;

                if (applyManager.Add(Approval))
                {
                    MessageBox.Show("提交成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("提交失败！");

                }
            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                process Process = new process();
                Process.comment = this.textBox1.Text;
                Process.idapply = Config.idapproval;
                Process.idmodel = "2";
                Process.processer = Config.LoginStaff.Idstaff;
                Process.status = 1;
                //Config.idprocess = Process.idprocess;
                //Config.Approval.box = 3;
                Dao dao = new Dao();
                string sql = $"UPDATE `oa`.`approval` SET `box` = '3' WHERE (`idapproval` = '{Config.idapproval}');";
                dao.Execute(sql);
                if (processManager.Add(Process))
                {
                    MessageBox.Show("保存成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
                
                dao.DaoClose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                process Process = new process();
                Process.comment = this.textBox1.Text;
                Process.idapply = Config.idapproval;
                Process.idmodel = "2";
                Process.processer = Config.LoginStaff.Idstaff;
                Process.status = 0;
                //Config.idprocess = Process.idprocess;
                //Config.Approval.box = 3;
                Dao dao = new Dao();
                string sql = $"UPDATE `oa`.`approval` SET `box` = '5' WHERE (`idapproval` = '{Config.idapproval}');";
                dao.Execute(sql);
                if (processManager.Add(Process))
                {
                    MessageBox.Show("保存成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }

                dao.DaoClose();
            }
        }
    }
}
