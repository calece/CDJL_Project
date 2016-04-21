namespace CDJL_Project
{
    partial class mainWindow
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Node0 = new System.Windows.Forms.Button();
            this.Node1 = new System.Windows.Forms.Button();
            this.Node2 = new System.Windows.Forms.Button();
            this.Node3 = new System.Windows.Forms.Button();
            this.Node4 = new System.Windows.Forms.Button();
            this.Node5 = new System.Windows.Forms.Button();
            this.Node6 = new System.Windows.Forms.Button();
            this.Node7 = new System.Windows.Forms.Button();
            this.Node8 = new System.Windows.Forms.Button();
            this.Node9 = new System.Windows.Forms.Button();
            this.Node10 = new System.Windows.Forms.Button();
            this.Node11 = new System.Windows.Forms.Button();
            this.Node12 = new System.Windows.Forms.Button();
            this.Node13 = new System.Windows.Forms.Button();
            this.Node14 = new System.Windows.Forms.Button();
            this.Node15 = new System.Windows.Forms.Button();
            this.Node16 = new System.Windows.Forms.Button();
            this.Node17 = new System.Windows.Forms.Button();
            this.Node18 = new System.Windows.Forms.Button();
            this.Node19 = new System.Windows.Forms.Button();
            this.Node20 = new System.Windows.Forms.Button();
            this.Node21 = new System.Windows.Forms.Button();
            this.Node22 = new System.Windows.Forms.Button();
            this.Node23 = new System.Windows.Forms.Button();
            this.Node24 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.initConnection = new System.Windows.Forms.Button();
            this.query = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 425);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 25);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.initConnection.Location = new System.Drawing.Point(150, 400);
            this.initConnection.Name = "connect";
            this.initConnection.Size = new System.Drawing.Size(75, 25);
            this.initConnection.TabIndex = 2;
            this.initConnection.Text = "Connect";
            this.initConnection.UseVisualStyleBackColor = true;
            this.initConnection.Click += new System.EventHandler(this.connect_Click);
            // 
            // button3
            // 
            this.query.Location = new System.Drawing.Point(50, 400);
            this.query.Name = "Query";
            this.query.Size = new System.Drawing.Size(75, 25);
            this.query.TabIndex = 3;
            this.query.Text = "Query";
            this.query.UseVisualStyleBackColor = true;
            this.query.Click += new System.EventHandler(this.query_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);



            this.Controls.Add(this.Node0);
            this.Controls.Add(this.Node1);
            this.Controls.Add(this.Node2);
            this.Controls.Add(this.Node3);
            this.Controls.Add(this.Node4);
            this.Controls.Add(this.Node5);
            this.Controls.Add(this.Node6);
            this.Controls.Add(this.Node7);
            this.Controls.Add(this.Node8);
            this.Controls.Add(this.Node9);
            this.Controls.Add(this.Node10);
            this.Controls.Add(this.Node11);
            this.Controls.Add(this.Node12);
            this.Controls.Add(this.Node13);
            this.Controls.Add(this.Node14);
            this.Controls.Add(this.Node15);
            this.Controls.Add(this.Node16);
            this.Controls.Add(this.Node17);
            this.Controls.Add(this.Node18);
            this.Controls.Add(this.Node19);
            this.Controls.Add(this.Node20);
            this.Controls.Add(this.Node21);
            this.Controls.Add(this.Node22);
            this.Controls.Add(this.Node23);
            this.Controls.Add(this.Node24);
            //Enable Array of Node Buttons
            int nodeX = 0;
            int nodeY = 0;
            int nodeNum = 1;

            foreach (System.Windows.Forms.Button button in this.Controls)
            {
                
                button.Location = new System.Drawing.Point(nodeX, nodeY);
                button.Name = "Sensor " + nodeNum;
                button.Size = new System.Drawing.Size(75, 75);
                button.TabIndex = nodeNum;
                button.Text = "Sensor" + nodeNum;
                button.UseVisualStyleBackColor = true;
                button.Click += new System.EventHandler(this.Node_Click);
                nodeNum += 1;
                if (nodeX <= 225)
                {
                    nodeX += 75;
                }
                else
                {
                    nodeY += 75;
                    nodeX = 0;
                }
            }


            this.Controls.Add(this.query);
            this.Controls.Add(this.initConnection);
            this.Controls.Add(this.textBox1);
            this.Name = "mainWindow";
            this.Text = "CDJL Environment Monitor";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button Node0;
        private System.Windows.Forms.Button Node1;
        private System.Windows.Forms.Button Node2;
        private System.Windows.Forms.Button Node3;
        private System.Windows.Forms.Button Node4;
        private System.Windows.Forms.Button Node5;
        private System.Windows.Forms.Button Node6;
        private System.Windows.Forms.Button Node7;
        private System.Windows.Forms.Button Node8;
        private System.Windows.Forms.Button Node9;
        private System.Windows.Forms.Button Node10;
        private System.Windows.Forms.Button Node11;
        private System.Windows.Forms.Button Node12;
        private System.Windows.Forms.Button Node13;
        private System.Windows.Forms.Button Node14;
        private System.Windows.Forms.Button Node15;
        private System.Windows.Forms.Button Node16;
        private System.Windows.Forms.Button Node17;
        private System.Windows.Forms.Button Node18;
        private System.Windows.Forms.Button Node19;
        private System.Windows.Forms.Button Node20;
        private System.Windows.Forms.Button Node21;
        private System.Windows.Forms.Button Node22;
        private System.Windows.Forms.Button Node23;
        private System.Windows.Forms.Button Node24;
        
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button initConnection;
        private System.Windows.Forms.Button query;





    }
}

