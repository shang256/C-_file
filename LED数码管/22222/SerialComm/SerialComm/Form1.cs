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
        bool t1 = false;
        bool display_smg = false;
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
                
                Head[0] = 0xAA;
                End[0] = 0xCC;
                End[1] = 0x33;

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(Head, 0, 1);
                    serialPort1.Write(Content, 0, Content.Length);
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



        private float X;//当前窗体的宽度
        private float Y;//当前窗体的高度
        private void setTag(Control cons)
        {

            //遍历窗体中的控件

            foreach (Control con in cons.Controls)
            {

                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size + ":" + con.Name;

                if (con.Controls.Count > 0)

                    setTag(con);

            }

        }
        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Visible = false;

            }
            //遍历窗体中的控件，重新设置控件的值

            foreach (Control con in cons.Controls)
            {

                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//获取控件的Tag属性值，并分割后存储字符串数组

                float a = Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度

                con.Width = (int)a;//宽度

                a = Convert.ToSingle(mytag[1]) * newy;//高度

                con.Height = (int)(a);

                a = Convert.ToSingle(mytag[2]) * newx;//左边距离

                con.Left = (int)(a);

                a = Convert.ToSingle(mytag[3]) * newy;//上边缘距离

                con.Top = (int)(a);

                Single currentSize = Convert.ToSingle(mytag[4]) * newx;//字体大小

                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);

                if (con.Controls.Count > 0)
                {

                    setControls(newx, newy, con);

                }

            }
            foreach (Control con in cons.Controls)
            {
                con.Visible = true;

            }
        }

        void modular_calEchoPhaseFromSignal1_Resize(object sender, EventArgs e)
        {

            float newx = (this.Width) / X; //窗体宽度缩放比例

            float newy = this.Height / Y;//窗体高度缩放比例

            setControls(newx, newy, this);//随窗体改变控件大小

            // this.Text = this.Width.ToString() + " " + this.Height.ToString();//窗体标题栏文本

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.Resize += new EventHandler(modular_calEchoPhaseFromSignal1_Resize);//窗体调整大小时引发事件

            X = this.Width;//获取窗体的宽度

            Y = this.Height;//获取窗体的高度

            setTag(this);//调用方法
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
/// <summary>
/// /////////////////////////////////////////////////////////////////////////
/// </summary>AA 03 CC 33 
/// <param name="sender"></param>
/// <param name="e"></param>
        private void LED_Click(object sender, EventArgs e)
        {         
            byte[] Head = new byte[1];
            byte[] End = new byte[2];
            byte[] Content = new byte[1];

            Head[0] = 0xAA;
            Content[0] = 0x03;
            End[0] = 0xCC;
            End[1] = 0x33;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(Head, 0, 1);
                serialPort1.Write(Content, 0, Content.Length);
                serialPort1.Write(End, 0, 2);
            }
            else
            {
                MessageBox.Show("请打开串口");
            }
            t1=!t1;
            if (t1 == false) LED.ForeColor = Color.Black;
            else LED.ForeColor = Color.Red;
        }
/// <summary>
        /// AA 04 CC 33 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void display_Click(object sender, EventArgs e)
        {
            byte[] Head = new byte[1];
            byte[] End = new byte[2];
            byte[] Content = new byte[1];

            Head[0] = 0xAA;
            Content[0] = 0x04;
            End[0] = 0xCC;
            End[1] = 0x33;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(Head, 0, 1);
                serialPort1.Write(Content, 0, Content.Length);
                serialPort1.Write(End, 0, 2);
            }
            else
            {
                MessageBox.Show("请打开串口");
            }
            display_smg = !display_smg;
            if (display_smg == false) display.ForeColor = Color.Black;
            else display.ForeColor = Color.Red;
        }
    }
}
