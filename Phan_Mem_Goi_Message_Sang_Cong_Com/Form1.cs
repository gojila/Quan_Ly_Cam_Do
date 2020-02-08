using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Goi_Message_Sang_Cong_Com
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = txtComPortName.Text;
                    serialPort1.BaudRate = Convert.ToInt32(txtBaudRate.Text);
                    serialPort1.Open();
                    MessageBox.Show(this, "Connect Success !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(txtMessage.Text);
                    txtReceive.Text += "\nSend: " + txtMessage.Text;
                }
                else
                {
                    MessageBox.Show(this, "Com port not open !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
