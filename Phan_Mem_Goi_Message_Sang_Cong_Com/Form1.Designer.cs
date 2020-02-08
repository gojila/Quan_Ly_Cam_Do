namespace Phan_Mem_Goi_Message_Sang_Cong_Com
{
    partial class Form1
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
            this.serialPort1 = new System.IO.Ports.SerialPort();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComPortName = new System.Windows.Forms.TextBox();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 39);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(473, 20);
            this.txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(491, 37);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(12, 66);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(554, 96);
            this.txtReceive.TabIndex = 2;
            this.txtReceive.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Com Port Name:";
            // 
            // txtComPortName
            // 
            this.txtComPortName.Location = new System.Drawing.Point(102, 12);
            this.txtComPortName.Name = "txtComPortName";
            this.txtComPortName.Size = new System.Drawing.Size(155, 20);
            this.txtComPortName.TabIndex = 0;
            this.txtComPortName.Text = "COM1";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(330, 12);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(155, 20);
            this.txtBaudRate.TabIndex = 0;
            this.txtBaudRate.Text = "9600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud Rate:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(491, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 171);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtBaudRate);
            this.Controls.Add(this.txtComPortName);
            this.Controls.Add(this.txtMessage);
            this.Name = "Form1";
            this.Text = "Connect To Com Port";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComPortName;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
    }
}

