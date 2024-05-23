using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace RS232
{
    public partial class Form1 : Form
    {
        string ReceiveData = String.Empty;
        string TransmitData = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports) 
            {
                comboBox1.Items.Add(port);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;

        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            btnOn.Enabled = true;
            btnOff.Enabled = true;


            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select COM Port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if(serialPort1.IsOpen)
                    {
                        MessageBox.Show(" COM Ports is connected and ready for use ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        serialPort1.Open();
                        txtConn.BackColor = Color.Lime;
                        txtConn.Text = " Connecting...";
                        comboBox1.Enabled = false;
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("COM port is not found. Please check your COM or Cable.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        private void btnDisConn_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    txtConn.BackColor = Color.Red;
                    txtConn.Text = " Disconnected !";
                    comboBox1.Enabled = true;
                   
                }
                else
                {
                    MessageBox.Show(" COM Ports is disconnected and ready for use ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            btnon1.Enabled = true;
            btnoff1.Enabled = true;
            try
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "a";
                    serialPort1.Write(TransmitData);
                   
                }
                else
                {
                    MessageBox.Show(" COM Ports is disconnected and ready for use ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            btnon1.Enabled = false;
            btnoff1.Enabled = false;
            btnon2.Enabled = false;
            btnoff2.Enabled = false;

            try

            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "d";
                    serialPort1.Write(TransmitData);

                }
                else
                {
                    MessageBox.Show(" COM Ports is disconnected and ready for use ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReceiveData = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(DoupDate));
        }

        private void DoupDate(object sender, EventArgs e)
        {
            if( ReceiveData == "s")
            {
                pictureBox1.Image = RS232.Properties.Resources.ledon;
            }
            else if(ReceiveData == "f")
            {
                pictureBox1.Image = RS232.Properties.Resources.ledoff;
                pictureBox2.Image = RS232.Properties.Resources.ledoff;
                pictureBox4.Image = RS232.Properties.Resources.ledoff;
            }
            else if (ReceiveData == "h")
            {
                pictureBox2.Image = RS232.Properties.Resources.ledon;
            }
            else if (ReceiveData == "k")
            {
                pictureBox2.Image = RS232.Properties.Resources.ledoff;
                pictureBox4.Image = RS232.Properties.Resources.ledoff;
            }
            else if (ReceiveData == "x")
            {
                pictureBox4.Image = RS232.Properties.Resources.ledon;
            }
            else if (ReceiveData == "v")
            {
                pictureBox4.Image = RS232.Properties.Resources.ledoff;
            }
        }

        private void btnon1_Click(object sender, EventArgs e)
        {
            btnon2.Enabled = true;
            btnoff2.Enabled = true;
            try
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "g";
                    serialPort1.Write(TransmitData);

                }
                else
                {
                    MessageBox.Show(" COM Ports is disconnected and ready for use ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnoff1_Click(object sender, EventArgs e)
        {
            btnon2.Enabled = false;
            btnoff2.Enabled = false;
            try
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "j";
                    serialPort1.Write(TransmitData);

                }
                else
                {
                    MessageBox.Show(" COM Ports is disconnected and ready for use ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnon2_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "z";
                    serialPort1.Write(TransmitData);

                }
                else
                {
                    MessageBox.Show(" COM Ports is disconnected and ready for use ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnoff2_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "c";
                    serialPort1.Write(TransmitData);

                }
                else
                {
                    MessageBox.Show(" COM Ports is disconnected and ready for use ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to exits? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if ( serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
        }
}
    
}
