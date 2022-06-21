namespace SerialComm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.CmbSeria1Num = new System.Windows.Forms.ComboBox();
            this.CmbBaudrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnOpenSerial = new System.Windows.Forms.Button();
            this.BtnCloseSerial = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.TxtSend = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.String2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.HEX = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sendCHAR = new System.Windows.Forms.RadioButton();
            this.sendHEX = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // CmbSeria1Num
            // 
            this.CmbSeria1Num.FormattingEnabled = true;
            this.CmbSeria1Num.Location = new System.Drawing.Point(121, 78);
            this.CmbSeria1Num.Margin = new System.Windows.Forms.Padding(4);
            this.CmbSeria1Num.Name = "CmbSeria1Num";
            this.CmbSeria1Num.Size = new System.Drawing.Size(219, 23);
            this.CmbSeria1Num.TabIndex = 0;
            this.CmbSeria1Num.SelectedValueChanged += new System.EventHandler(this.CmbSeria1Num_SelectedValueChanged);
            // 
            // CmbBaudrate
            // 
            this.CmbBaudrate.FormattingEnabled = true;
            this.CmbBaudrate.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "115200"});
            this.CmbBaudrate.Location = new System.Drawing.Point(121, 140);
            this.CmbBaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.CmbBaudrate.Name = "CmbBaudrate";
            this.CmbBaudrate.Size = new System.Drawing.Size(219, 23);
            this.CmbBaudrate.TabIndex = 1;
            this.CmbBaudrate.SelectedValueChanged += new System.EventHandler(this.CmbBaudrate_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "串口号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "波特率";
            // 
            // BtnOpenSerial
            // 
            this.BtnOpenSerial.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOpenSerial.Location = new System.Drawing.Point(39, 341);
            this.BtnOpenSerial.Margin = new System.Windows.Forms.Padding(4);
            this.BtnOpenSerial.Name = "BtnOpenSerial";
            this.BtnOpenSerial.Size = new System.Drawing.Size(116, 49);
            this.BtnOpenSerial.TabIndex = 5;
            this.BtnOpenSerial.Text = "打开串口";
            this.BtnOpenSerial.UseVisualStyleBackColor = false;
            this.BtnOpenSerial.Click += new System.EventHandler(this.BtnOpenSerial_Click);
            // 
            // BtnCloseSerial
            // 
            this.BtnCloseSerial.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnCloseSerial.Location = new System.Drawing.Point(224, 341);
            this.BtnCloseSerial.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCloseSerial.Name = "BtnCloseSerial";
            this.BtnCloseSerial.Size = new System.Drawing.Size(116, 49);
            this.BtnCloseSerial.TabIndex = 6;
            this.BtnCloseSerial.Text = "关闭串口";
            this.BtnCloseSerial.UseVisualStyleBackColor = false;
            this.BtnCloseSerial.Click += new System.EventHandler(this.BtnCloseSerial_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.BtnSend);
            this.groupBox1.Controls.Add(this.TxtSend);
            this.groupBox1.Location = new System.Drawing.Point(376, 258);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(403, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送区";
            // 
            // BtnSend
            // 
            this.BtnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnSend.Location = new System.Drawing.Point(127, 104);
            this.BtnSend.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(131, 48);
            this.BtnSend.TabIndex = 1;
            this.BtnSend.Text = "发送";
            this.BtnSend.UseVisualStyleBackColor = false;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // TxtSend
            // 
            this.TxtSend.Location = new System.Drawing.Point(8, 26);
            this.TxtSend.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSend.Multiline = true;
            this.TxtSend.Name = "TxtSend";
            this.TxtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtSend.Size = new System.Drawing.Size(385, 70);
            this.TxtSend.TabIndex = 0;
            this.TxtSend.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.textBox);
            this.groupBox2.Location = new System.Drawing.Point(376, 22);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(403, 214);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收区";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.Window;
            this.textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox.Location = new System.Drawing.Point(8, 18);
            this.textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(387, 189);
            this.textBox.TabIndex = 9;
            this.textBox.TextChanged += new System.EventHandler(this.textR_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.String2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.HEX);
            this.panel1.Location = new System.Drawing.Point(39, 187);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 49);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // String2
            // 
            this.String2.AutoSize = true;
            this.String2.Location = new System.Drawing.Point(185, 12);
            this.String2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.String2.Name = "String2";
            this.String2.Size = new System.Drawing.Size(58, 19);
            this.String2.TabIndex = 1;
            this.String2.TabStop = true;
            this.String2.Text = "字符";
            this.String2.UseVisualStyleBackColor = true;
            this.String2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "接收区";
            // 
            // HEX
            // 
            this.HEX.AutoSize = true;
            this.HEX.Location = new System.Drawing.Point(64, 12);
            this.HEX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HEX.Name = "HEX";
            this.HEX.Size = new System.Drawing.Size(58, 19);
            this.HEX.TabIndex = 0;
            this.HEX.TabStop = true;
            this.HEX.Text = "数值";
            this.HEX.UseVisualStyleBackColor = true;
            this.HEX.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sendCHAR);
            this.panel2.Controls.Add(this.sendHEX);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(39, 258);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(303, 58);
            this.panel2.TabIndex = 2;
            // 
            // sendCHAR
            // 
            this.sendCHAR.AutoSize = true;
            this.sendCHAR.Location = new System.Drawing.Point(185, 26);
            this.sendCHAR.Margin = new System.Windows.Forms.Padding(4);
            this.sendCHAR.Name = "sendCHAR";
            this.sendCHAR.Size = new System.Drawing.Size(58, 19);
            this.sendCHAR.TabIndex = 2;
            this.sendCHAR.TabStop = true;
            this.sendCHAR.Text = "字符";
            this.sendCHAR.UseVisualStyleBackColor = true;
            this.sendCHAR.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // sendHEX
            // 
            this.sendHEX.AutoSize = true;
            this.sendHEX.Location = new System.Drawing.Point(65, 26);
            this.sendHEX.Margin = new System.Windows.Forms.Padding(4);
            this.sendHEX.Name = "sendHEX";
            this.sendHEX.Size = new System.Drawing.Size(58, 19);
            this.sendHEX.TabIndex = 1;
            this.sendHEX.TabStop = true;
            this.sendHEX.Text = "数值";
            this.sendHEX.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "发送区";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(809, 22);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(479, 425);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 472);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCloseSerial);
            this.Controls.Add(this.BtnOpenSerial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbBaudrate);
            this.Controls.Add(this.CmbSeria1Num);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "串口通信助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox CmbSeria1Num;
        private System.Windows.Forms.ComboBox CmbBaudrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnOpenSerial;
        private System.Windows.Forms.Button BtnCloseSerial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.TextBox TxtSend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton String2;
        private System.Windows.Forms.RadioButton HEX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton sendCHAR;
        private System.Windows.Forms.RadioButton sendHEX;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
    }
}

