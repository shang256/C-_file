using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialComm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.CustomFormat = "yyyy-MM-dd,HH:mm:ss";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            byte[] setTime = new byte[8];
            int temp;
            string str1;
            str1 = dtpTime.Value.Year.ToString();//获取“年”
            temp = int.Parse(str1.Substring(2, 2));//转换成整型time，Substring(2, 2)分割字符串
            setTime[7] = Hexttobcd(Convert.ToByte(temp));

            setTime[6] = 0x01;//获取星期

            str1 = dtpTime.Value.Month.ToString();//获取“月”
            temp = int.Parse(str1);//转换成整型time
            setTime[5] = Hexttobcd(Convert.ToByte(temp));

            str1 = dtpTime.Value.Day.ToString();//获取“日”
            temp = int.Parse(str1);//转换成整型time
            setTime[4] = Hexttobcd(Convert.ToByte(temp));

            str1 = dtpTime.Value.Hour.ToString();//获取“时”
            temp = int.Parse(str1);//转换成整型time
            setTime[3] = Hexttobcd(Convert.ToByte(temp));

            str1 = dtpTime.Value.Minute.ToString();//获取“分”
            temp = int.Parse(str1);//转换成整型time
            setTime[2] = Hexttobcd(Convert.ToByte(temp));

            str1 = dtpTime.Value.Second.ToString();//获取“秒”
            temp = int.Parse(str1);//转换成整型time
            setTime[1] = Hexttobcd(Convert.ToByte(temp));

            setTime[0] = 0x01;

            Form1.news(setTime);//跨窗体调用第四步
        }
        public byte Hexttobcd(byte Hexvalue) 
        {
            int test;
            test = ((int)Hexvalue / 10) * 16 + Hexvalue % 10 ;
            return Convert.ToByte(test);
        
        }
    }
}
