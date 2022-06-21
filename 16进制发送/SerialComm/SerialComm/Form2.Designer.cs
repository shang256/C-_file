namespace SerialComm
{
    partial class Form2
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
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnSetTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(22, 54);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(200, 21);
            this.dtpTime.TabIndex = 0;
            this.dtpTime.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnSetTime
            // 
            this.btnSetTime.Location = new System.Drawing.Point(262, 52);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(75, 23);
            this.btnSetTime.TabIndex = 1;
            this.btnSetTime.Text = "设置时间";
            this.btnSetTime.UseVisualStyleBackColor = true;
            this.btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 262);
            this.Controls.Add(this.btnSetTime);
            this.Controls.Add(this.dtpTime);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnSetTime;
    }
}