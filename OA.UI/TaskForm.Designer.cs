
namespace OA.UI
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.业务处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSP = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewBox = new System.Windows.Forms.TreeView();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewApply = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApply)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.业务处理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1660, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 业务处理ToolStripMenuItem
            // 
            this.业务处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSP});
            this.业务处理ToolStripMenuItem.Name = "业务处理ToolStripMenuItem";
            this.业务处理ToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.业务处理ToolStripMenuItem.Text = "业务处理";
            this.业务处理ToolStripMenuItem.Click += new System.EventHandler(this.业务处理ToolStripMenuItem_Click);
            // 
            // tsmiSP
            // 
            this.tsmiSP.Name = "tsmiSP";
            this.tsmiSP.Size = new System.Drawing.Size(243, 44);
            this.tsmiSP.Text = "电信审批";
            this.tsmiSP.Click += new System.EventHandler(this.tsmiSP_Click);
            // 
            // treeViewBox
            // 
            this.treeViewBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewBox.Location = new System.Drawing.Point(3, 31);
            this.treeViewBox.Name = "treeViewBox";
            this.treeViewBox.Size = new System.Drawing.Size(336, 762);
            this.treeViewBox.TabIndex = 0;
            this.treeViewBox.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBox_AfterSelect);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(33, 691);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(126, 66);
            this.buttonCheck.TabIndex = 1;
            this.buttonCheck.Text = "查看详情";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCheck);
            this.groupBox1.Controls.Add(this.treeViewBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 796);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制台";
            // 
            // dataGridViewApply
            // 
            this.dataGridViewApply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApply.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridViewApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewApply.Location = new System.Drawing.Point(3, 31);
            this.dataGridViewApply.Name = "dataGridViewApply";
            this.dataGridViewApply.RowHeadersWidth = 82;
            this.dataGridViewApply.RowTemplate.Height = 37;
            this.dataGridViewApply.Size = new System.Drawing.Size(1304, 762);
            this.dataGridViewApply.TabIndex = 0;
            this.dataGridViewApply.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewApply_CellContentClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "订单号";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "位置";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "面积";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "时间";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "内容";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "标题";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewApply);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(350, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1310, 796);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "审批信息";
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1660, 835);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TaskForm";
            this.Text = "任务";
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApply)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 业务处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSP;
        private System.Windows.Forms.TreeView treeViewBox;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}