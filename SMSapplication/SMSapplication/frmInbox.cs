using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMSapplication
{
    public partial class frmInbox : Form
    {
        SerialPort sPort1 = new SerialPort();
        public int baudRate = 115200;
        public int dataBits = 8;
        public int readtimeOut = 7000;
        public int writeTimeOut = 7000;
        public int interval = 500;
        public frmInbox()
        {
            InitializeComponent();
        }

        private void frmInbox_Load(object sender, EventArgs e)
        {
            port1.Items.AddRange(SerialPort.GetPortNames());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = port1.Text;
            //ClosePort(sPort1);
            sPort1 = OpenPort(name, baudRate, dataBits, readtimeOut, writeTimeOut);
            ReadSMS(sPort1, port1);
        }
        public SerialPort OpenPort(string p_strPortName, int p_uBaudRate, int p_uDataBits, int p_uReadTimeout, int p_uWriteTimeout)
        {

            SerialPort port = new SerialPort();

            try
            {
                port.PortName = p_strPortName;                 //COM1
                port.BaudRate = p_uBaudRate;                   //9600
                port.DataBits = p_uDataBits;                   //8
                port.StopBits = StopBits.One;                  //1
                port.Parity = Parity.None;                     //None
                port.ReadTimeout = p_uReadTimeout;             //300
                port.WriteTimeout = p_uWriteTimeout;           //300
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;

                //SendKeys.Send("{ENTER}");
                if (port.IsOpen)
                {
                    ShowLog("#connection :: " + port.PortName + " ::Connected");
                }
            }
            catch (Exception ex)
            {
                ShowLog("#connection :: " + port.PortName + " ::" + ex.Message);
            }
            return port;
        }
        private void ReadSMS(SerialPort sPort, ComboBox port)
        {
            if (!sPort.IsOpen)
            {
                string name = "";
                if (port.InvokeRequired)
                {
                    port.Invoke(new MethodInvoker(delegate { name = port.Text; }));
                }
                else
                {
                    name = port.Text;
                }
                sPort = OpenPort(name, baudRate, dataBits, readtimeOut, writeTimeOut);
            }

            try
            {
                sPort.Write("AT" + (char)Keys.Enter);
                string buffer = string.Empty;
                do
                {
                    string t = sPort.ReadExisting();
                    buffer += t;

                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\nERROR\r\n"));

                if (buffer.EndsWith("\r\nERROR\r\n"))
                {

                    ShowLog("PORT :: Error");
                }
                sPort.Write("AT+CMGF=1" + (char)Keys.Enter);
                buffer = string.Empty;
                do
                {
                    string t = sPort.ReadExisting();
                    buffer += t;

                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\nERROR\r\n"));


                if (buffer.EndsWith("\r\nERROR\r\n"))
                {
                    ShowLog("FORMAT :: Error");
                }
            
                String command = "AT+CMGL=\"ALL\"";
                sPort.Write(command + (char)Keys.Enter);

                buffer = string.Empty;
                do
                {
                    string t = sPort.ReadExisting();
                    buffer += t;

                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\nERROR\r\n"));

                ShowLog(buffer);



            }
            catch (Exception ex)
            {
                ShowLog("Exception ::" + ex.Message);
                //
            }

        }
        public void ShowLog(string log)
        {



            listBox1.Items.Add(log);
            int visibleItems = listBox1.ClientSize.Height / listBox1.ItemHeight;
            listBox1.TopIndex = Math.Max(listBox1.Items.Count - visibleItems + 1, 0);


        }

        public void ClosePort(SerialPort port)
        {
            try
            {
                port.Close();
                ShowLog("Disconnect :: " + port.PortName);
            }
            catch (Exception ex)
            {
                ShowLog(ex.Message);
            }
        }

        private void frmInbox_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePort(sPort1);
        }
    }
}
