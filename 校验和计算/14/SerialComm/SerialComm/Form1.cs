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

namespace SerialComm
{
    public delegate void Newsdelegate(byte[] Time);//跨窗体调用第一步
    public partial class Form1 : Form
    {
        private delegate void SafeCallDelegate(string text);
        public static Newsdelegate news;//跨窗体调用第三步
        public Form1()
        {
            InitializeComponent();
        }

        public void News(byte[] Time)//跨窗体调用第二步
        {
            Invoke(new Action(() => {
                byte[] Head = new byte[1];
                byte[] End=new byte[2];
                byte[] Content = Time;

                byte[] Black;
                int result=0;
                Head[0] = 0xAA;
                End[0] = 0xCC;
                End[1] = 0x33;
                //时间 数据长度 （设备号 数据包（8位）） 和校验 //数据长度 设备号在数据包第一位
                //     0x09     0x01, 0x00,0x00,0x00,0x00,0x00,0x00,0x00  0xxx;

                //FLASH 数据长度 （设备号 数据包（8位）） 和校验 //数据长度 设备号在数据包第一位
                //     0x08     0x02, 0x00,0x00,0x00,0x00,0x00,0x00       0xxx;
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(Head, 0, 1);
                    serialPort1.Write(Content, 0, Content.Length);
                    for (int i = 1; i < Content.Length; i++)
                    {
                        //result ^= Convert.ToByte(Content[i]);
                        result ^= Convert.ToInt32(Content[i]);
                    }
                    Black = BitConverter.GetBytes(result);
                    serialPort1.Write(Black, 0, 1);
                    serialPort1.Write(End, 0, 2);
                }
                else 
                {
                    MessageBox.Show("请打开串口");
                }
            
            }));
        
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 10; i++) {
                CmbSeria1Num.Items.Add("COM" + i.ToString());
            }
            CmbBaudrate.Items.Add("4800");
            news = News;//跨窗体调用第三步
        }

        private void BtnOpenSerial_Click(object sender, EventArgs e)
        {
            if (CmbBaudrate.Text == "" || CmbSeria1Num.Text == "") {
                MessageBox.Show("请选择串口号和波特率！");
            }

            try
            {
                serialPort1.Open();
                BtnOpenSerial.Enabled = false;
                BtnCloseSerial.Enabled = true;
            }
            catch {
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
            byte[] Head = new byte[1];
            byte[] End = new byte[2];

            Head[0] = 0xAA;
            End[0] = 0xCC;
            End[1] = Convert.ToByte(51);
            
            string str1;
            str1=TxtSend.Text.ToString();
            byte[] DataSend = Encoding.Default.GetBytes(str1);

            if (serialPort1.IsOpen) {
                if (TxtSend.Text != "")
                {
                    serialPort1.Write(Head, 0, 1);
                    serialPort1.Write(DataSend, 0, DataSend.Length);
                    serialPort1.Write(End, 0, 2);
                }
                else {
                    MessageBox.Show("不能发送空数据！");                
                }    
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //byte dataRecv;
            //dataRecv=(byte)serialPort1.ReadByte();
            //string strTemp;
            //strTemp = Convert.ToString(dataRecv,16).ToUpper();
          //  TxtRecv.AppendText(strTemp);//跨线程调用了，出错，改用委托安全调用
            //WriteTextSafe(strTemp);

            //为提高效率，一次性读出缓冲区字节
            byte[] data = new byte[serialPort1.ReadBufferSize];
            serialPort1.Read(data, 0, serialPort1.ReadBufferSize);
            string str = Encoding.Default.GetString(data);
            WriteTextSafe(str);

        }
        private void WriteTextSafe(string text) {
            if (this.TxtRecv.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                this.Invoke(d, new object[] { text });
            }
            else {
                TxtRecv.AppendText(text+"  ");
            }
        }

        private void TxtRecv_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsbTime_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbEprom_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();

        }
    }
}
