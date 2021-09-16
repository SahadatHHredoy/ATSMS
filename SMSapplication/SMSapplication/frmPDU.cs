using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SMSapplication
{
    public partial class frmPDU : Form
    {
        public static string[] portNames = new string[0];
        public static int noOfCombo = 0;
        public static int comboY = 0;

        public static List<SerialPort> ports = new List<SerialPort>();
        public static List<System.Windows.Forms.Timer> timers = new List<System.Windows.Forms.Timer>();
        List<int> list = new List<int>();
        public int baudRate = 0;
        public int dataBits = 0;
        public int readtimeOut = 0;
        public int writeTimeOut = 0;
        public int interval = 500;


        //
        public char enterChar = (char)Keys.Enter;
        public frmPDU()
        {
            InitializeComponent();
        }

        private void frmPDU_Load(object sender, EventArgs e)
        {
            portNames = SerialPort.GetPortNames();
            btnDisconnect.Enabled = false;
            AddInitialCombox();

        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            baudRate = Convert.ToInt32(cboBaudRate.Text);
            dataBits = Convert.ToInt32(cboDataBits.Text);
            readtimeOut = Convert.ToInt32(txtReadTimeOut.Text);
            writeTimeOut = Convert.ToInt32(txtWriteTimeOut.Text);
            interval = Convert.ToInt32(txtInterval.Text);

            foreach (Control control in panelPorts.Controls)
            {
                if (control.Name.StartsWith("Combo"))
                {
                    var sPort = OpenPort(control.Text, baudRate, dataBits, readtimeOut, writeTimeOut);
                    if (sPort.IsOpen)
                    {
                        int cnt = Convert.ToInt32(lblConnect.Text);
                        cnt++;
                        lblConnect.Text = cnt.ToString();
                        ports.Add(sPort);
                        var timer = new System.Windows.Forms.Timer();
                        timer.Enabled = true;
                        timer.Interval = interval;
                        var myArg = new MyEventArgs();
                        myArg.sPort = sPort;
                        myArg.port = (ComboBox)control;
                        timer.Tick += (sendr, args) => Timer_Tick(sendr, myArg);
                        timers.Add(timer);
                        Thread.Sleep(interval);
                    }

                }
            }
            btnDisconnect.Enabled = true;
            btnOK.Enabled = false;
            btnAddPort.Enabled = false;
            btnDeletePort.Enabled = false;
            btnInbox.Enabled = false;
            btnDialPad.Enabled = false;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var args = (MyEventArgs)e;
            //var thread = new Thread(() => ShowLog(args.port.Name));
            var thread = new Thread(() => SendSms(args.sPort, args.port));
            thread.Start();
        }



        #region Sending Message
        private void SendSms(SerialPort sPort, ComboBox port)
        {

            string baseUrl = "http://easybulksmsbd.com/";
            string apiLink = "getList";
            Message[] messages = new Message[0];
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Blocking call!
            HttpResponseMessage result;
            if (!sPort.IsOpen)
            {
                string name = "";
                if (port.InvokeRequired)
                {
                    port.Invoke(new MethodInvoker(delegate { name = port.Text; }));
                }
                sPort = OpenPort(name, baudRate, dataBits, readtimeOut, writeTimeOut);
                if (!sPort.IsOpen)
                {
                    return;
                }
            }
            try
            {

                result = _client.GetAsync(apiLink).Result;
                if (result.IsSuccessStatusCode)
                {
                    messages = result.Content.ReadAsAsync<Message[]>().Result;
                }
                else
                {
                    ShowLog("Api:: no message found.");
                    return;
                }
            }
            catch (Exception r)
            {
                ShowLog("Api Format Error:::" + r.Message);
                return;
            }
            if (messages.Length > 0 && !list.Contains(messages[0].id))
            {
                list.Add(messages[0].id);
                try
                {

                    string buffer = string.Empty;
                    sPort.Write("AT+CMGF=0" + enterChar);
                    buffer = string.Empty;
                    do
                    {
                        string t = sPort.ReadExisting();
                        buffer += t;
                    }
                    while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\nERROR\r\n"));
                    if (buffer.EndsWith("\r\nERROR\r\n"))
                    {
                        list.Remove(messages[0].id);
                        return;
                        //ShowLog("SMS FORMAT ::" + sPort.PortName + "::Error");
                    }
                   // SMS Length with sms
                    bool isSent = true;
                    OutgoingSmsPdu[] pdus = null;
                    messages[0].text = messages[0].text.Replace("\r", " ");
                    messages[0].text = messages[0].text.Replace("\n", "");
                    bool unicode= messages[0].text.Any(s => s > 255);
                    pdus = SmartMessageFactory.CreateConcatTextMessage(messages[0].text, unicode, messages[0].mobile);
                    foreach (var pdu in pdus)
                    {
                        string pduCode = pdu.ToString();
                        int length = (pduCode.Length - 2) / 2;
                        String command = "AT+CMGS=" + length;
                        sPort.Write(command + (char)Keys.Enter);
                        sPort.Write(pduCode + (char)26);
                        buffer = string.Empty;
                        do
                        {
                            string t = sPort.ReadExisting();
                            buffer += t;
                        }
                        while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\nERROR\r\n"));
                        if (buffer.EndsWith("\r\nERROR\r\n"))
                        {
                            isSent = false;
                            //ShowLog("SMS ::" + sPort.PortName + "::: Error");
                            list.Remove(messages[0].id);
                            return;
                        }
                    }

                    if (isSent)
                    {

                        apiLink = "done/" + messages[0].id;
                        result = _client.GetAsync(apiLink).Result;
                        ShowLog("SMS:" + sPort.PortName + ":::" + messages[0].id + "::: Successfull");

                    }
                    else
                    {
                        list.Remove(messages[0].id);
                        return;
                    }
                }
                catch (Exception ex)
                {

                    ShowLog("Exception ::" + ex.Message);
                    list.Remove(messages[0].id);
                    return;
                    //
                }

            }
            else
            {
                ShowLog(sPort.PortName + ":: No Message Find");

            }

        }
        #endregion
        #region Port Connection
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


        public void ClosePort(SerialPort port)
        {
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                ShowLog("Disconnect :: " + port.PortName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort serial = (SerialPort)sender;
                string ex = serial.ReadExisting();
                if (ex.ToLower().Contains("ok"))
                {
                    //SendAck(mId);
                    //mId = 0;
                }
                string j = "#Real" + serial.PortName + " :: " + ex;
                ShowLog(j);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
        #region Dynamic Combo Box
        public void AddInitialCombox()
        {
            comboY = panelPorts.Location.Y;

            while (noOfCombo < 15)
            {
                noOfCombo++;
                string name = "Combo" + noOfCombo;
                int divion = noOfCombo / 3;
                bool remainder = noOfCombo % 3 == 0;
                bool remainderM = noOfCombo % 2 == 0;
                int x = remainder ? 400 : remainderM ? 200 : 10;
                ComboBox comboBox = new ComboBox();

                comboBox.Location = new System.Drawing.Point(x, comboY);
                comboBox.Name = name;
                comboBox.Size = new System.Drawing.Size(150, 25);
                comboBox.Items.AddRange(portNames);
                panelPorts.Controls.Add(comboBox);
                if (remainder)
                {
                    comboY = comboY + 30;

                }

            }

            lblPortNo.Text = noOfCombo.ToString();

        }

        private void btnAddPort_Click(object sender, EventArgs e)
        {
            noOfCombo++;
            string name = "Combo" + noOfCombo;
            int divion = noOfCombo / 3;
            bool remainder = noOfCombo % 3 == 0;
            bool remainderM = noOfCombo % 2 == 0;
            int x = remainder ? 400 : remainderM ? 200 : 10;
            ComboBox comboBox = new ComboBox();
            comboBox.Location = new System.Drawing.Point(x, comboY);
            comboBox.Name = name;
            comboBox.Size = new System.Drawing.Size(150, 25);
            comboBox.Items.AddRange(portNames);
            panelPorts.Controls.Add(comboBox);
            lblPortNo.Text = noOfCombo.ToString();
            if (remainder)
            {
                comboY = comboY + 30;
                //grpPorts.Height = grpPorts.Height + 40;
            }


        }
        private void btnDeletePort_Click(object sender, EventArgs e)
        {
            string name = "Combo" + noOfCombo;
            var control = panelPorts.Controls.Find(name, false).FirstOrDefault();
            if (control != null)
            {
                panelPorts.Controls.Remove(control);
                noOfCombo--;
            }

            lblPortNo.Text = noOfCombo.ToString();
        }
        #endregion
        #region Show Log
        public void ShowLog(string log)
        {
            //list.Add(0);
            if (!listBox1.InvokeRequired)
            {
                if (listBox1.Items.Count > 1000)
                {
                    listBox1.Items.Clear();
                }
                listBox1.Items.Add(log);
            }
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new MethodInvoker(delegate
                {
                    if (listBox1.Items.Count > 1000)
                    {
                        listBox1.Items.Clear();
                    }
                    listBox1.Items.Add(log);
                    int visibleItems = listBox1.ClientSize.Height / listBox1.ItemHeight;
                    listBox1.TopIndex = Math.Max(listBox1.Items.Count - visibleItems + 1, 0);
                }));
            }
            if (lblTotal.InvokeRequired)
            {
                lblTotal.Invoke(new MethodInvoker(delegate
                {

                    lblTotal.Text = list.Count.ToString();
                    //lblTotal.Text = Process.GetCurrentProcess().Threads.Count.ToString();
                }));
            }


        }



        #endregion

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            foreach (var timer in timers)
            {
                timer.Stop();
                timer.Enabled = false;
            }
            timers = new List<System.Windows.Forms.Timer>();
            foreach (var port in ports)
            {
                ClosePort(port);
            }
            ports = new List<SerialPort>();
            btnDisconnect.Enabled = false;
            btnOK.Enabled = true;
            btnAddPort.Enabled = true;
            btnDeletePort.Enabled = true;
            btnDialPad.Enabled = true;
            btnInbox.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            var frmInbox = new frmInbox();
            frmInbox.ShowDialog(this);
        }

        private void btnDialPad_Click(object sender, EventArgs e)
        {
            var frmDialPad = new frmDialPad();
            frmDialPad.ShowDialog(this);
        }
    }

}
