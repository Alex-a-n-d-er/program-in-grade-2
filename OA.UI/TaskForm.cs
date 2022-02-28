using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OA.BLL;
using OA.Models;
using OA.Common;

namespace OA.UI
{
    public partial class TaskForm : Form
    {
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
            foreach(approval apl in list)
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
        public TaskForm()
        {
            InitializeComponent();
            MessageBox.Show(Config.LoginStaff.Idstaff.ToString() + "WTF");
            //Table();
        }
        // 字典表业务管理类
        DictionariesManager dictionariesManager = new DictionariesManager();
        private void TaskForm_Load(object sender, EventArgs e)
        {
            List<dictionary> diclist = dictionariesManager.GetList("BoxValue");
            foreach(dictionary dict in diclist)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dict.Dicname;
                tn.Tag = dict.Iddictionary;
                this.treeViewBox.Nodes.Add(tn);
            }
        }

        private void tsmiSP_Click(object sender, EventArgs e)
        {
            ApplyForm applyform = new ApplyForm(Common.BoxValue.草稿箱);
            applyform.Show();
        }

        private void treeViewBox_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str = e.Node.Tag.ToString();
            int n = int.Parse(str);
            //MessageBox.Show(str);
            Table(n);

        }

        private void dataGridViewApply_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            Config.idapproval = dataGridViewApply.SelectedRows[0].Cells[5].Value.ToString();
            if (Config.idapproval!=null)
            {
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
            else
            {
                MessageBox.Show("请先选中!");
            }
/*            ApplyForm applyForm = new ApplyForm();
            this.Hide();
            applyForm.ShowDialog();
            this.Show();*/
        }

        private void 业务处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
