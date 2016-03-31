using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graph = System.Windows.Forms.DataVisualization.Charting;

namespace CDJL_Project
{





    public partial class mainWindow : Form
    {


        List<NodeWindow> activeNodes = new List<NodeWindow>();
        Graph.Chart chart;
        Graph.Chart chart2;
        double xCoord = 0.0;
        Random random = new Random();
        Form winz = new Form();
        
        public mainWindow()
        {
            InitializeComponent();
            
            this.ClientSize = new System.Drawing.Size(800 ,720);
        }


        public static class Exchange
        {
            private static bool _outDataReady = false;
            private static object _outDataReadyLocker = new object();
            public static bool outDataReady
            {
                get { lock (_outDataReadyLocker) { return _outDataReady; } }
                set { lock (_outDataReadyLocker) { _outDataReady = value; } }
            }
            private static bool _inDataReady = false;
            private static object _inDataReadyLocker = new object();
            public static bool inDataReady
            {
                get { lock (_inDataReadyLocker) { return _inDataReady; } }
                set { lock (_inDataReadyLocker) { _inDataReady = value; } }
            }

            private static bool _queryData = false;
            private static object _queryDataLocker = new object();
            public static bool queryData
            {
                get { lock (_queryDataLocker) { return _queryData; } }
                set { lock (_queryDataLocker) { _queryData = value; } }
            }

            private static string _dataOut = string.Empty;
            private static object _dataOutLocker = new object();
            public static string dataOut
            {
                get { lock (_dataOutLocker) { return _dataOut; } }
                set { lock (_dataOutLocker) { _dataOut = value; } }
            }
            private static string _dataIn = string.Empty;
            private static object _dataInLocker = new object();
            public static string dataIn
            {
                get { lock (_dataInLocker) { return _dataIn; } }
                set { lock (_dataInLocker) { _dataIn = value; } }
            }
        }


        
        private void mainWindow_Load(object sender, EventArgs e)
        {
            
            // Create new Graph
            chart = new Graph.Chart();
            
            
            chart.Location = new System.Drawing.Point(0, 0);
            chart.Size = new System.Drawing.Size(320, 360);
            
            
            // Add a chartarea called "draw", add axes to it and color the area black
            chart.ChartAreas.Add("phMap");
            chart.BackColor = Color.Teal;

            chart.ChartAreas["phMap"].AxisX.Minimum = 0;
            chart.ChartAreas["phMap"].AxisX.Maximum = 100;
            chart.ChartAreas["phMap"].AxisX.Interval = 10;
            chart.ChartAreas["phMap"].AxisX.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["phMap"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            chart.ChartAreas["phMap"].AxisY.Minimum = -1;
            chart.ChartAreas["phMap"].AxisY.Maximum = 1;
            chart.ChartAreas["phMap"].AxisY.Interval = 0.1;
            chart.ChartAreas["phMap"].AxisY.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["phMap"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;

            
            chart.ChartAreas["phMap"].BackColor = Color.Black;
            
            
            // Create a new function series
            chart.Series.Add("MyFunc");
           
            // Set the type to line      
            chart.Series["MyFunc"].ChartType = Graph.SeriesChartType.Line;
            
            chart.Series["MyFunc"].Color = Color.Red;
            
            chart.Series["MyFunc"].BorderWidth = 3;
            

            
            
            
            //Controls.Add(chart);
            //Controls.Add(chart2);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            textBox1.Text = Exchange.dataIn;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            NodeWindow node = new NodeWindow();
            activeNodes.Add(node);

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TCP_socket sock = new TCP_socket();
        }

        
    }
}
     