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
        Random rand = new Random();
        Timer timer = new Timer();
        TrackBar trackbar = new TrackBar();
        TextBox timerIntervalDisplay = new TextBox();
        Graph.Chart nodeChart;
        int localXCoord = 0;
        public double tempSensor = 0.0;
        public double humidSensor = 0.0;
        public int nodeNum;
        public NodeWindow(int nodeNumber)
        {
            window = new Form();//Initalize New Window

            this.timer.Tick += new System.EventHandler(this.updateChart);//Initalize and start timer
            this.trackbar.Scroll += new System.EventHandler(this.setIntervalSpeed);
            this.timer.Interval = 1000;
            timer.Start();
            this.trackbar.Minimum = 1000;
            this.trackbar.Maximum = 60000;
            nodeNum = nodeNumber;
            nodeChart = new Graph.Chart();
            window.Controls.Add(nodeChart);
            window.Controls.Add(trackbar);
            window.Controls.Add(timerIntervalDisplay);
            nodeChart.Dock = window.Dock;
            nodeChart.Location = new System.Drawing.Point(0, 0);
            nodeChart.Size = new System.Drawing.Size(300, 300);
            window.ClientSize = new System.Drawing.Size(300, 400);
            window.Text = "Sensor " + nodeNumber;
            trackbar.Dock = window.Dock;
            trackbar.Location = new System.Drawing.Point(0, 300);
            trackbar.Size = new System.Drawing.Size(300, 50);
            timerIntervalDisplay.Dock = window.Dock;
            timerIntervalDisplay.Location = new System.Drawing.Point(0, 350);
            timerIntervalDisplay.Size = new System.Drawing.Size(150, 50);
            timerIntervalDisplay.Text = "Interval Speed: 1 Seconds";
            nodeChart.ChartAreas.Add("SensorData");
            nodeChart.ChartAreas["SensorData"].AxisX.Minimum = 0;
            nodeChart.ChartAreas["SensorData"].AxisX.Maximum = 60;
            nodeChart.ChartAreas["SensorData"].AxisX.Interval = 5;
            nodeChart.ChartAreas["SensorData"].AxisX.MajorGrid.LineColor = Color.DarkGray;
            nodeChart.ChartAreas["SensorData"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            nodeChart.ChartAreas["SensorData"].AxisY.Minimum = 20;
            nodeChart.ChartAreas["SensorData"].AxisY.Maximum = 50;
            nodeChart.ChartAreas["SensorData"].AxisY.Interval = 5;
            nodeChart.ChartAreas["SensorData"].AxisY.MajorGrid.LineColor = Color.White;
            nodeChart.ChartAreas["SensorData"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            nodeChart.ChartAreas["SensorData"].BackColor = Color.Black;

            nodeChart.Series.Add("Temp");
            nodeChart.Series["Temp"].ChartType = Graph.SeriesChartType.Line;
            nodeChart.Series["Temp"].Color = Color.Red;
            nodeChart.Series["Temp"].BorderWidth = 3;

            nodeChart.Series.Add("Humid");
            nodeChart.Series["Humid"].ChartType = Graph.SeriesChartType.Line;
            nodeChart.Series["Humid"].Color = Color.Blue;
            nodeChart.Series["Humid"].BorderWidth = 3;


            window.Visible = true;
        }


        private void setIntervalSpeed(object sender, EventArgs e)
        {
            this.nodeChart.Series["Temp"].Points.Clear();
            this.nodeChart.Series["Humid"].Points.Clear();
            this.timer.Interval = this.trackbar.Value;
            this.timerIntervalDisplay.Text = "Interval Speed: " + (this.trackbar.Value / 1000).ToString() + " Seconds";
            localXCoord = 0;
        }

        private void updateChart(object sender, EventArgs e)
        {

            localXCoord++;
            CDJL_Project.mainWindow.Exchange.queryData = true;
            try
            {
                if (localXCoord > 60)
                {
                    this.nodeChart.Series["Temp"].Points.Clear();
                    this.nodeChart.Series["Humid"].Points.Clear();
                    localXCoord = 0;
                }
                nodeChart.Series["Temp"].Points.AddXY(localXCoord, tempSensor);
                nodeChart.Series["Humid"].Points.AddXY(localXCoord, humidSensor);
            }
            catch(NullReferenceException excep)
            {
                this.Close();
            }
    
        }

          


    }
}
