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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.TxtRecv = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbTime = new System.Windows.Forms.ToolStripButton();
            this.tsbEprom = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // CmbSeria1Num
            // 
            this.CmbSeria1Num.FormattingEnabled = true;
            this.CmbSeria1Num.Location = new System.Drawing.Point(91, 62);
            this.CmbSeria1Num.Name = "CmbSeria1Num";
            this.CmbSeria1Num.Size = new System.Drawing.Size(165, 20);
            this.CmbSeria1Num.TabIndex = 0;
            this.CmbSeria1Num.SelectedValueChanged += new System.EventHandler(this.CmbSeria1Num_SelectedValueChanged);
            // 
            // CmbBaudrate
            // 
            this.CmbBaudrate.FormattingEnabled = true;
            this.CmbBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "115200"});
            this.CmbBaudrate.Location = new System.Drawing.Point(91, 119);
            this.CmbBaudrate.Name = "CmbBaudrate";
            this.CmbBaudrate.Size = new System.Drawing.Size(165, 20);
            this.CmbBaudrate.TabIndex = 1;
            this.CmbBaudrate.SelectedValueChanged += new System.EventHandler(this.CmbBaudrate_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "串口号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "波特率";
            // 
            // BtnOpenSerial
            // 
            this.BtnOpenSerial.Location = new System.Drawing.Point(25, 205);
            this.BtnOpenSerial.Name = "BtnOpenSerial";
            this.BtnOpenSerial.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenSerial.TabIndex = 5;
            this.BtnOpenSerial.Text = "打开串口";
            this.BtnOpenSerial.UseVisualStyleBackColor = true;
            this.BtnOpenSerial.Click += new System.EventHandler(this.BtnOpenSerial_Click);
            // 
            // BtnCloseSerial
            // 
            this.BtnCloseSerial.Location = new System.Drawing.Point(149, 204);
            this.BtnCloseSerial.Name = "BtnCloseSerial";
            this.BtnCloseSerial.Size = new System.Drawing.Size(75, 23);
            this.BtnCloseSerial.TabIndex = 6;
            this.BtnCloseSerial.Text = "关闭串口";
            this.BtnCloseSerial.UseVisualStyleBackColor = true;
            this.BtnCloseSerial.Click += new System.EventHandler(this.BtnCloseSerial_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.BtnSend);
            this.groupBox1.Controls.Add(this.TxtSend);
            this.groupBox1.Location = new System.Drawing.Point(349, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送区";
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(59, 61);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 23);
            this.BtnSend.TabIndex = 1;
            this.BtnSend.Text = "发送";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // TxtSend
            // 
            this.TxtSend.Location = new System.Drawing.Point(6, 23);
            this.TxtSend.Name = "TxtSend";
            this.TxtSend.Size = new System.Drawing.Size(188, 21);
            this.TxtSend.TabIndex = 0;
            this.TxtSend.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtRecv);
            this.groupBox2.Location = new System.Drawing.Point(310, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 159);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收区";
            // 
            // TxtRecv
            // 
            this.TxtRecv.Location = new System.Drawing.Point(6, 20);
            this.TxtRecv.Multiline = true;
            this.TxtRecv.Name = "TxtRecv";
            this.TxtRecv.Size = new System.Drawing.Size(271, 133);
            this.TxtRecv.TabIndex = 0;
            this.TxtRecv.TextChanged += new System.EventHandler(this.TxtRecv_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbTime,
            this.tsbEprom});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(605, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbTime
            // 
            this.tsbTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTime.Image = ((System.Drawing.Image)(resources.GetObject("tsbTime.Image")));
            this.tsbTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTime.Name = "tsbTime";
            this.tsbTime.Size = new System.Drawing.Size(23, 22);
            this.tsbTime.Text = "toolStripButton1";
            this.tsbTime.Click += new System.EventHandler(this.tsbTime_Click);
            // 
            // tsbEprom
            // 
            this.tsbEprom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEprom.Image = ((System.Drawing.Image)(resources.GetObject("tsbEprom.Image")));
            this.tsbEprom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEprom.Name = "tsbEprom";
            this.tsbEprom.Size = new System.Drawing.Size(23, 22);
            this.tsbEprom.Text = "toolStripButton1";
            this.tsbEprom.Click += new System.EventHandler(this.tsbEprom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 378);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCloseSerial);
            this.Controls.Add(this.BtnOpenSerial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbBaudrate);
            this.Controls.Add(this.CmbSeria1Num);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox TxtRecv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbTime;
        private System.Windows.Forms.ToolStripButton tsbEprom;
    }
}

