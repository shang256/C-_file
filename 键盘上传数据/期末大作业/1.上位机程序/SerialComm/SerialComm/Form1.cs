using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

namespace SerialComm
{
    public partial class Form1 : Form
    {
        private Queue<double> dataQueue = new Queue<double>(1);
        private int keyv = 0;
        private int num = 5;//每次删除增加几个点
        bool flag = false;
        private delegate void SafeCallDelegate(string text);
        public Form1()
        {
            InitializeComponent();
            InitChart();
            //设置串口接收响应事件
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            //串口数据接收事件 //设置串口编码格式为gb2312 
            serialPort1.Encoding = Encoding.GetEncoding("GB2312");  // 设置串口的编码
            Control.CheckForIllegalCrossThreadCalls = false;  // 忽略多线程
            //串口接收编码 
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false; 


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 12; i++) {
                CmbSeria1Num.Items.Add("COM" + i.ToString());
            }
            CmbSeria1Num.Text = "COM1";//默认值COM1
            CmbBaudrate.Text = "9600";//默认值9600
            //串口接收见事件检查
           // serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        private void BtnOpenSerial_Click(object sender, EventArgs e)
        {
            if (CmbBaudrate.Text == "" || CmbSeria1Num.Text == "") {
                MessageBox.Show("请选择串口号和波特率！");
            }
            try
            {
                serialPort1.PortName = CmbSeria1Num.Text; //端口号 
                serialPort1.BaudRate = Convert.ToInt32(CmbBaudrate.Text); 

                serialPort1.Open();
                BtnOpenSerial.Enabled = false;
                BtnCloseSerial.Enabled = true;
            }
            catch
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void BtnCloseSerial_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                BtnOpenSerial.Enabled = true;
                BtnCloseSerial.Enabled = false;
            }
            catch {
                MessageBox.Show("无法关闭串口");
            }
        }

        private void CmbSeria1Num_SelectedValueChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = CmbSeria1Num.Text.ToString();
        }

        private void CmbBaudrate_SelectedValueChanged(object sender, EventArgs e)
        {
            string str;
            str=CmbBaudrate.Text.ToString();
            serialPort1.BaudRate = Convert.ToInt32(str);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            //发送数据的字节数组
            byte[] Data = new byte[1]; //单字节发数据
            if (serialPort1.IsOpen) 
            {
                if (TxtSend.Text != "") 
                { //发送数据类型为字符型 
                    if (!sendHEX.Checked) 
                    { 
                        try { 
                            //向串口写入字符串数据 
                            serialPort1.Write(TxtSend.Text); 
                            //serialPort1.WriteLine();
                            //字符串写入 
                            } catch { MessageBox.Show("串口数据写入错误", "错误");
                     }
                 }else //数据模式 
                 {//发送数据类型为数值类型 
                      try //如果此时用户输入字符串中含有非法字符（字母，汉字，符号等等，try，catch块可以捕捉并提示） 
                      {
                          for (int i = 0; i < (TxtSend.Text.Length - TxtSend.Text.Length % 2) / 2; i++)//转换偶数个
                          {
                              Data[0] = Convert.ToByte(TxtSend.Text.Substring(i * 2, 2), 16);//转换
                                serialPort1.Write(Data, 0, 1);
                          }
                          if (TxtSend.Text.Length % 2 != 0) 
                          {
                              Data[0] = Convert.ToByte(TxtSend.Text.Substring(TxtSend.Text.Length - 1, 1), 16);//单独处理最后一个字符 
                              serialPort1.Write(Data, 0, 1);  //写入 
                          } 
                           //Data = Convert.ToByte(textBox2.Text.Substring(textBox2.Text.Length - 1, 1), 16);
                       
                      } catch { 
                             MessageBox.Show("数据转换错误，请输入数字。", "错误");
                          }
                 }
              } 
        }
   }
       
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            if (!HEX.Checked)//如果接收模式为字符模式
            {
                CheckForIllegalCrossThreadCalls = false;
                string str = serialPort1.ReadExisting();//字符串方式读
                if (str.Contains("Key"))//判断是否含有相同字符串
                {
                    //
                    flag = true;
                    string result = System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");
                    keyv = Convert.ToInt32(result);
         
                }
                
                textBox.AppendText(str);//添加内容
            }
            else
            { //如果接收模式为数值接收
                byte data;
                CheckForIllegalCrossThreadCalls = false;
                data = (byte)serialPort1.ReadByte();//此处需要强制类型转换，将(int)类型数据转换为(byte类型数据，不必考虑是否会丢失数据
                string str = Convert.ToString(data, 16).ToUpper();//转换为大写十六进制字符串
                textBox.AppendText("0x" + (str.Length == 1 ? "0" + str : str) + " ");//空位补“0”   
                //上一句等同为：if(str.Length == 1)
                //                  str = "0" + str;
                //              else 
                //                  str = str;
                //              textBox1.AppendText("0x" + str);
             }
         }
       
        private void WriteTextSafe(string text) {
            if (this.textBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                this.Invoke(d, new object[] { text });
            }
            else {
                textBox.AppendText(text + "  ");
            }
        }

        private void TxtRecv_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textR_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        /////////////////////////////////////////////////*********************************************************
        /// <summary>
        /// 初始化图表
        /// </summary>
        private void InitChart()
        {
            //定义图表区域
            this.chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            this.chart1.ChartAreas.Add(chartArea1);



            //定义存储和显示点的容器
            this.chart1.Series.Clear();
            Series series1 = new Series("键值");
            series1.ChartArea = "C1";
            this.chart1.Series.Add(series1);

            //设置图表显示样式
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;
            this.chart1.ChartAreas[0].AxisY.Maximum = 20;
            this.chart1.ChartAreas[0].AxisX.Interval = num;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //设置标题
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("S01");
            this.chart1.Titles[0].Text = "键值显示";
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //设置图表显示样式
            this.chart1.Series[0].Color = Color.Red;
            this.chart1.Series[0].ChartType = SeriesChartType.Line;//线形状
            this.chart1.Series[0].Points.Clear();
        }

        //更新队列中的值
        private void UpdateQueueValue()
        {

            if (dataQueue.Count > 100)
            {
                //先出列
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
            }
            for (int i = 0; i < num; i++)
            {
                dataQueue.Enqueue(keyv);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag == true)
            {
                flag = false;
                UpdateQueueValue();
                this.chart1.Series[0].Points.Clear();
                for (int i = 0; i < dataQueue.Count; i++)
                {
                    this.chart1.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));//
                }
            }

        }
    }
}
