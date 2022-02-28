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
    public partial class MainForm : Form
    {
        ChartPieManager chartPieManager = new ChartPieManager();
        
        public void chart()
        {
            ChartHelper.AddSeries(chart1, "饼状图", SeriesChartType.Pie, Color.Lime, Color.Red, true);
            ChartHelper.SetStyle(chart1, Color.Transparent, Color.White);
            ChartHelper.SetLegend(chart1, Docking.Top, StringAlignment.Center, Color.Transparent, Color.Black);
            ChartHelper.SetTitle(chart1, "审批申请地区占比", new Font("微软雅黑", 12), Docking.Bottom, Color.Black);
            //int[] c= { };
            //string[] w = { };
            Dao dao = new Dao();
            string sql = $"select locate , count(*) AS count from oa.approval group by locate order by count DESC";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                string word = dc[0].ToString();

                string tmp = dc[1].ToString();
                int cnt = int.Parse(tmp);
                //c.Append(cnt);
                //w.Append(word);
                this.chart1.Series[0].Points.AddXY(word, cnt);
            }
            ChartHelper.AddSeries(chart2, "条形图", SeriesChartType.Pie, Color.Lime, Color.Red, true);
            ChartHelper.SetStyle(chart2, Color.Transparent, Color.White);
            ChartHelper.SetLegend(chart2, Docking.Top, StringAlignment.Center, Color.Transparent, Color.Black);
            ChartHelper.SetTitle(chart2, "每月审批申请数量", new Font("微软雅黑", 12), Docking.Bottom, Color.Black);
            string sql2 = $"select DATE_FORMAT(create_time, '%m') , count(*) AS count from oa.approval group by create_time order by create_time ASC";
            dc = dao.read(sql2);
            while (dc.Read())
            {
                string word = dc[0].ToString();
                int mon = int.Parse(word);
                string tmp = dc[1].ToString();
                int cnt = int.Parse(tmp);
                //c.Append(cnt);
                //w.Append(word);
                this.chart2.Series[0].Points.AddXY(mon, cnt);
            }

            ChartHelper.AddSeries(chart3, "条形图", SeriesChartType.Pie, Color.Lime, Color.Red, true);
            ChartHelper.SetStyle(chart3, Color.Transparent, Color.White);
            ChartHelper.SetLegend(chart3, Docking.Top, StringAlignment.Center, Color.Transparent, Color.Black);
            ChartHelper.SetTitle(chart3, "各地区审批用地面积", new Font("微软雅黑", 12), Docking.Bottom, Color.Black);
            string sql3 = $"select locate, sum(area) as area from oa.approval GROUP BY locate";
            dc = dao.read(sql3);
            while (dc.Read())
            {
                string word = dc[0].ToString();
                //int mon = int.Parse(word);
                string tmp = dc[1].ToString();
                int cnt = int.Parse(tmp);
                //c.Append(cnt);
                //w.Append(word);
                this.chart3.Series[0].Points.AddXY(word, cnt);
            }

            dc.Close();
            dao.DaoClose();
        }
        public MainForm()
        {
            InitializeComponent();
            chart();
        }
        public orderky taskform;
        bool flagt = false;
        bool flags = false;
        public select Selectt;
        private void TaskManager_Click(object sender, EventArgs e)
        {
            //TaskForm taskform = new TaskForm();
            taskform = new orderky();
            flagt = true;
            taskform.TopLevel = false;
            taskform.Parent = this.panelContent;
            if (flags) Selectt.Close();
            taskform.Show();
            taskform.BringToFront();
        }

        private void ToolStripMenuItemQ_Click(object sender, EventArgs e)
        {
            Selectt = new select();
            flags = true;
            Selectt.TopLevel = false;
            Selectt.Parent = this.panelContent;
            if (flagt) taskform.Close();
            Selectt.Show();
            Selectt.BringToFront();
            Selectt.Dock = DockStyle.Fill;
            Selectt.MaximizeBox = false;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
