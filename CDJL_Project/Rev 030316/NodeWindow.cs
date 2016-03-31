using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graph = System.Windows.Forms.DataVisualization.Charting;
namespace CDJL_Project
{
    public partial class NodeWindow : Form
    {
        Form window;
        Timer timer = new Timer();
        Graph.Chart nodeChart;
        int localXCoord = 0;
        public NodeWindow()
        {
            window = new Form();
            this.timer.Tick += new System.EventHandler(this.updateChart);
            timer.Start();
            nodeChart = new Graph.Chart();
            window.Controls.Add(nodeChart);
            nodeChart.Dock = window.Dock;
            nodeChart.Location = new System.Drawing.Point(0, 0);
            nodeChart.Size = new System.Drawing.Size(320, 180);
            window.ClientSize = new System.Drawing.Size(400, 400);
            nodeChart.ChartAreas.Add("phMap");
            nodeChart.ChartAreas["phMap"].AxisX.Minimum = 0;
            nodeChart.ChartAreas["phMap"].AxisX.Maximum = 100;
            nodeChart.ChartAreas["phMap"].AxisX.Interval = 10;
            nodeChart.ChartAreas["phMap"].AxisX.MajorGrid.LineColor = Color.White;
            nodeChart.ChartAreas["phMap"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            nodeChart.ChartAreas["phMap"].AxisY.Minimum = -1;
            nodeChart.ChartAreas["phMap"].AxisY.Maximum = 1;
            nodeChart.ChartAreas["phMap"].AxisY.Interval = 0.1;
            nodeChart.ChartAreas["phMap"].AxisY.MajorGrid.LineColor = Color.White;
            nodeChart.ChartAreas["phMap"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            nodeChart.ChartAreas["phMap"].BackColor = Color.Black;

            nodeChart.Series.Add("MyFunc");
            nodeChart.Series["MyFunc"].ChartType = Graph.SeriesChartType.Line;
            nodeChart.Series["MyFunc"].Color = Color.Red;
            nodeChart.Series["MyFunc"].BorderWidth = 3;


            window.Visible = true;
        }

        private void updateChart(object sender, EventArgs e)
        {

            localXCoord++;
            try
            {
                if (localXCoord > 100)
                {
                    nodeChart.Series["MyFunc"].Points.Clear();
                    localXCoord = 0;
                }
                nodeChart.Series["MyFunc"].Points.AddXY(localXCoord, Math.Sin(localXCoord));
            }
            catch(NullReferenceException excep)
            {
                this.Close();
            }
            
        }

        


    }
}
