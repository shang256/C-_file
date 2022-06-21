﻿using System;
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
            txtData2.MaxLength = 3;
            txtData3.MaxLength = 3;
            txtData4.MaxLength = 3;
            txtData5.MaxLength = 3;
            txtData6.MaxLength = 3;
            
        }

        private void txtData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 && (int)e.KeyChar!=8) || (int)e.KeyChar > 57)
            {
                MessageBox.Show("请输入数字");
                e.Handled = true;//表示已经处理，否则会一直弹出对话框

            }
        }

        private void txtData1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtData2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtData1_KeyPress(sender, e);
        }

        private void txtData3_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtData1_KeyPress(sender, e);
        }

        private void txtData4_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtData1_KeyPress(sender, e);
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
            byte[] storeData = new byte[8];
            storeData[0] = 0x08;
            storeData[1] = 0x02;
            if (txtData1.Text == "" || txtData2.Text == "" || txtData3.Text == "" || txtData4.Text == "" || txtData5.Text == ""
                || txtData6.Text == "")
            {
                MessageBox.Show("请输入内容");
            }
            else
            {
                temp = int.Parse(txtData1.Text);
                storeData[2] = Convert.ToByte(temp);

                temp = int.Parse(txtData2.Text);
                storeData[3] = Convert.ToByte(temp);

                temp = int.Parse(txtData3.Text);
                storeData[4] = Convert.ToByte(temp);

                temp = int.Parse(txtData4.Text);
                storeData[5] = Convert.ToByte(temp);

                temp = int.Parse(txtData5.Text);
                storeData[6] = Convert.ToByte(temp);

                temp = int.Parse(txtData6.Text);
                storeData[7] = Convert.ToByte(temp);

                Form1.news(storeData);
            }
        }
    }
}
