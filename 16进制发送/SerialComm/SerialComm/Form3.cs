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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txtData1.MaxLength = 3;//限制长度为3
            txtData2.MaxLength = 3;//限制长度为3
            txtData3.MaxLength = 3;//限制长度为3
            txtData4.MaxLength = 3;//限制长度为3
            txtData5.MaxLength = 3;//限制长度为3
            txtData6.MaxLength = 3;//限制长度为3

            
        }

        private void txtData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 && (int)e.KeyChar!=8) || (int)e.KeyChar > 57)
            {
                MessageBox.Show("请输入数字");
                e.Handled = true;//表示已经处理，否则会一直弹出对话框

            }
        }

        private void txtData2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtData1_KeyPress(sender, e);
        }

        private void txtData3_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtData1_KeyPress(sender,e);
        }

        private void txtData4_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtData1_KeyPress(sender,e);
        }

        private void txtData5_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtData1_KeyPress(sender, e);
        }

        private void txtData6_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtData1_KeyPress(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp;
            byte[] storceData = new byte[7];
            if (txtData1.Text == "" || txtData2.Text == "" || txtData3.Text == "" ||
                txtData4.Text == "" || txtData5.Text == "" || txtData6.Text == "")
            {
                MessageBox.Show("请输入内容");
            
            }
            storceData[0] = 0x02;
            temp = int.Parse(txtData1.Text);
            storceData[1] = Convert.ToByte(temp);

            temp = int.Parse(txtData2.Text);
            storceData[2] = Convert.ToByte(temp);

            temp = int.Parse(txtData3.Text);
            storceData[3] = Convert.ToByte(temp);

            temp = int.Parse(txtData4.Text);
            storceData[4] = Convert.ToByte(temp);

            temp = int.Parse(txtData5.Text);
            storceData[5] = Convert.ToByte(temp);

            temp = int.Parse(txtData6.Text);
            storceData[6] = Convert.ToByte(temp);
            
            Form1.news(storceData);
           
        }
       
    }
}
