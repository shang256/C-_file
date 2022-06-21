namespace SerialComm
{
    partial class Form3
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
            this.txtData1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtData2 = new System.Windows.Forms.TextBox();
            this.txtData3 = new System.Windows.Forms.TextBox();
            this.txtData4 = new System.Windows.Forms.TextBox();
            this.txtData5 = new System.Windows.Forms.TextBox();
            this.txtData6 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtData1
            // 
            this.txtData1.Location = new System.Drawing.Point(42, 86);
            this.txtData1.Name = "txtData1";
            this.txtData1.Size = new System.Drawing.Size(70, 21);
            this.txtData1.TabIndex = 0;
            this.txtData1.TextChanged += new System.EventHandler(this.txtData1_TextChanged);
            this.txtData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入三位数：最大255";
            // 
            // txtData2
            // 
            this.txtData2.Location = new System.Drawing.Point(118, 86);
            this.txtData2.Name = "txtData2";
            this.txtData2.Size = new System.Drawing.Size(70, 21);
            this.txtData2.TabIndex = 2;
            this.txtData2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData2_KeyPress);
            // 
            // txtData3
            // 
            this.txtData3.Location = new System.Drawing.Point(194, 86);
            this.txtData3.Name = "txtData3";
            this.txtData3.Size = new System.Drawing.Size(70, 21);
            this.txtData3.TabIndex = 3;
            this.txtData3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData3_KeyPress);
            // 
            // txtData4
            // 
            this.txtData4.Location = new System.Drawing.Point(270, 86);
            this.txtData4.Name = "txtData4";
            this.txtData4.Size = new System.Drawing.Size(70, 21);
            this.txtData4.TabIndex = 4;
            this.txtData4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData4_KeyPress);
            // 
            // txtData5
            // 
            this.txtData5.Location = new System.Drawing.Point(346, 86);
            this.txtData5.Name = "txtData5";
            this.txtData5.Size = new System.Drawing.Size(70, 21);
            this.txtData5.TabIndex = 5;
            this.txtData5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData5_KeyPress);
            // 
            // txtData6
            // 
            this.txtData6.Location = new System.Drawing.Point(422, 86);
            this.txtData6.Name = "txtData6";
            this.txtData6.Size = new System.Drawing.Size(70, 21);
            this.txtData6.TabIndex = 6;
            this.txtData6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData6_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(540, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "发送数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 279);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtData6);
            this.Controls.Add(this.txtData5);
            this.Controls.Add(this.txtData4);
            this.Controls.Add(this.txtData3);
            this.Controls.Add(this.txtData2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtData1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtData1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtData2;
        private System.Windows.Forms.TextBox txtData3;
        private System.Windows.Forms.TextBox txtData4;
        private System.Windows.Forms.TextBox txtData5;
        private System.Windows.Forms.TextBox txtData6;
        private System.Windows.Forms.Button button1;
    }
}