/*
 * Created by: Syeda Anila Nusrat. 
 * Date: 1st August 2009
 * Time: 2:54 PM 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace SMSapplication
{
    public partial class SMSapplication : Form
    {
        List<int> list = new List<int>();
        SerialPort sPort1 = new SerialPort();
        SerialPort sPort2 = new SerialPort();
        SerialPort sPort3 = new SerialPort();
        SerialPort sPort4 = new SerialPort();
        SerialPort sPort5 = new SerialPort();
        SerialPort sPort6 = new SerialPort();
        SerialPort sPort7 = new SerialPort();
        SerialPort sPort8 = new SerialPort();
        public static int keyValue = 1;
        public int baudRate = 0;
        public int dataBits = 0;
        public int readtimeOut = 0;
        public int writeTimeOut = 0;
       public int interval = 500;
        public SMSapplication()
        {
            InitializeComponent();
        }
        #region System Begin
        private void SMSapplication_Load(object sender, EventArgs e)
        {
            if (Expire.IsValidate())
            {
                ShowLog("System Start");
                this.btnOK.Enabled = true;

            }
            else
            {
                ShowLog("System Fail");
                this.btnOK.Enabled = false;
            }
            AssignPort();



        }
        public void AssignPort()
        {


            port1.Items.AddRange(SerialPort.GetPortNames());
            port2.Items.AddRange(SerialPort.GetPortNames());
            port3.Items.AddRange(SerialPort.GetPortNames());
            port4.Items.AddRange(SerialPort.GetPortNames());
            port5.Items.AddRange(SerialPort.GetPortNames());
            port6.Items.AddRange(SerialPort.GetPortNames());
            port7.Items.AddRange(SerialPort.GetPortNames());
            port8.Items.AddRange(SerialPort.GetPortNames());

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

        #region Button Click
        private void btnOK_Click(object sender, EventArgs e)
        {

            //if (this.WindowState != FormWindowState.Minimized)
            //{
            //    this.WindowState = FormWindowState.Minimized;
            //}
            baudRate = Convert.ToInt32(cboBaudRate.Text);
            dataBits = Convert.ToInt32(cboDataBits.Text);
            readtimeOut = Convert.ToInt32(txtReadTimeOut.Text);
            writeTimeOut = Convert.ToInt32(txtWriteTimeOut.Text);
             interval = Convert.ToInt32(txtInterval.Text);
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
            timer5.Enabled = true;
            timer6.Enabled = true;
            timer7.Enabled = true;
            timer8.Enabled = true;
            btnOK.Enabled = false;
            timer1.Interval = interval;
            timer1.Tick += Timer1_Tick;
            Thread.Sleep(interval);

            timer2.Interval = interval;
            timer2.Tick += Timer2_Tick;
            Thread.Sleep(interval);

            timer3.Interval = interval;
            timer3.Tick += Timer3_Tick;

            Thread.Sleep(interval);
            timer4.Interval = interval;
            timer4.Tick += Timer4_Tick;
            Thread.Sleep(interval);
            timer5.Interval = interval;
            timer5.Tick += Timer5_Tick;
            Thread.Sleep(interval);
            timer6.Interval = interval;
            timer6.Tick += Timer6_Tick;
            Thread.Sleep(interval);
            timer7.Interval = interval;
            timer7.Tick += Timer7_Tick;
             Thread.Sleep(interval);
            timer8.Interval = interval;
            timer8.Tick += Timer8_Tick;
        }
        #endregion

   
        #region Timer1
        private void Timer1_Tick(object sender, EventArgs e)
        {
            var thread = new Thread(Thread1);
            thread.Start();
            //thread.Abort();


        }
       
        private void Thread1()
        {
            string name = "";
            if (port1.InvokeRequired)
            {
                port1.Invoke(new MethodInvoker(delegate { name = port1.Text; }));
            }
            sPort1= SMSSend(sPort1, name);
        }
        #endregion

        #region Timer2
        private void Timer2_Tick(object sender, EventArgs e)
        {

            var thread = new Thread(Thread2);
            thread.Start();
            //thread.Abort();

        }

        private void Thread2()
        {
            string name = "";
            if (port2.InvokeRequired)
            {
                port2.Invoke(new MethodInvoker(delegate { name = port2.Text; }));
            }
            sPort2= SMSSend(sPort2, name);
        }
        #endregion  
        
        #region Timer3
        private void Timer3_Tick(object sender, EventArgs e)
        {

            var thread = new Thread(Thread3);
            thread.Start();
            //thread.Abort();

        }
        private void Thread3()
        {
            string name = "";
            if (port3.InvokeRequired)
            {
                port3.Invoke(new MethodInvoker(delegate { name = port3.Text; }));
            }
            sPort3= SMSSend(sPort3, name);
        }
        #endregion 
        
        #region Timer4
        private void Timer4_Tick(object sender, EventArgs e)
        {

            var thread = new Thread(Thread4);
            thread.Start();
        }
        private void Thread4()
        {
            string name = "";
            if (port4.InvokeRequired)
            {
                port4.Invoke(new MethodInvoker(delegate { name = port4.Text; }));
            }
            sPort4= SMSSend(sPort4, name);
        }
        #endregion
        
        #region Timer5
        private void Timer5_Tick(object sender, EventArgs e)
        {

            var thread = new Thread(Thread5);
            thread.Start();
            //thread.Abort();

        }
        private void Thread5()
        {
            string name = "";
            if (port5.InvokeRequired)
            {
                port5.Invoke(new MethodInvoker(delegate { name = port5.Text; }));
            }
            sPort5= SMSSend(sPort5, name);
        }
        #endregion   


        #region Timer6
        private void Timer6_Tick(object sender, EventArgs e)
        {

            var thread = new Thread(Thread6);
            thread.Start();
            //thread.Abort();
            
        }
        private void Thread6()
        {
            string name = "";
            if (port6.InvokeRequired)
            {
                port6.Invoke(new MethodInvoker(delegate { name = port6.Text; }));
            }
            sPort6= SMSSend(sPort6, name);
        }
        #endregion 
        
        #region Timer7
        private void Timer7_Tick(object sender, EventArgs e)
        {

            var thread = new Thread(Thread7);
            thread.Start();
            //thread.Abort();

        }
        private void Thread7()
        {
            string name = "";
            if (port7.InvokeRequired)
            {
                port7.Invoke(new MethodInvoker(delegate { name = port7.Text; }));
            }
            sPort7= SMSSend(sPort7, name);
        }
        #endregion
        
        #region Timer8
        private void Timer8_Tick(object sender, EventArgs e)
        {

            var thread = new Thread(Thread8);
            thread.Start();
            //thread.Abort();

        }

        private void Thread8()
        {
            string name = "";
            if (port8.InvokeRequired)
            {
                port8.Invoke(new MethodInvoker(delegate { name = port8.Text; }));
            }
            sPort8 = SMSSend(sPort8, name);
        }
        #endregion





        #region Common Region
        public void ShowLog(string log)
        {
           
            if (listBox1.InvokeRequired)
            {
                    listBox1.Invoke(new MethodInvoker(delegate {
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
                lblTotal.Invoke(new MethodInvoker(delegate {

                    lblTotal.Text = list.Count.ToString();
                    //lblTotal.Text = Process.GetCurrentProcess().Threads.Count.ToString();
                }));
            } 
          
           
        }
        private SerialPort SMSSend(SerialPort port, string portName)
        {
            string baseUrl = "http://easybulksmsbd.com/";
            string apiLink = "getList";
            Message[] messages = new Message[0];
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage result = _client.GetAsync(apiLink).Result;  // Blocking call!
            if (result.IsSuccessStatusCode)
            {
                messages = result.Content.ReadAsAsync<Message[]>().Result;

            }
            if (messages.Length > 0 && !list.Contains(messages[0].id))
            {
                list.Add(messages[0].id);

                if (!port.IsOpen)
                {

                    port = OpenPort(portName, baudRate, dataBits, readtimeOut, writeTimeOut);
                }
                if (messages[0].mobile.Length > 11)
                {
                    messages[0].mobile = messages[0].mobile.Substring(3, messages[0].mobile.Length - 3);
                    messages[0].mobile = "0" + messages[0].mobile;
                }

                if (messages[0].mobile.Length == 11)
                {

                    try
                    {
                        port.Write("AT" + (char)Keys.Enter);
                        string buffer = string.Empty;
                        do
                        {
                            string t = port.ReadExisting();
                            buffer += t;

                        }
                        while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\nERROR\r\n"));

                        if (buffer.EndsWith("\r\nERROR\r\n"))
                        {

                            ShowLog(port.PortName + ":: AT :: Error");
                        }
                        port.Write("AT+CMGF=1" + (char)Keys.Enter);
                        buffer = string.Empty;
                        do
                        {
                            string t = port.ReadExisting();
                            buffer += t;

                        }
                        while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\nERROR\r\n"));


                        if (buffer.EndsWith("\r\nERROR\r\n"))
                        {
                            ShowLog(port.PortName + "::AT format :: Error");
                        }

                        String command = "AT+CMGS=\"" + messages[0].mobile + "\"";
                        port.Write(command + (char)Keys.Enter);
                        port.Write(messages[0].text.Replace("\r\n", ((char)Keys.Enter).ToString()) + (char)26);

                        buffer = string.Empty;
                        do
                        {
                            string t = port.ReadExisting();
                            buffer += t;

                        }
                        while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\nERROR\r\n"));
                        if (buffer.EndsWith("\r\nOK\r\n"))
                        {

                            apiLink = "done/" + messages[0].id;
                            result = _client.GetAsync(apiLink).Result;
                            ShowLog("SMS:" + port.PortName + ":::" + messages[0].mobile + "::: Successfull");

                        }
                        if (buffer.EndsWith("\r\nERROR\r\n"))
                        {
                            list.Remove(messages[0].id);
                            ShowLog("SMS ::" + port.PortName + "::: Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        list.Remove(messages[0].id);
                        ShowLog("Expection::" + ex.Message);
                        //
                    }
                }
                else
                {
                    apiLink = "done/" + messages[0].id;
                    result = _client.GetAsync(apiLink).Result;

                }
                // Blocking call!

            }
            else
            {
                ShowLog(port.PortName + "::: No Message Find");

            }
            return port;
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            ClosePort(sPort1);
            ClosePort(sPort2);
            ClosePort(sPort3);
            ClosePort(sPort4);
            ClosePort(sPort5);
            ClosePort(sPort6);
            ClosePort(sPort7);
            ClosePort(sPort8);
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();
            timer7.Stop();
            timer8.Stop();
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;
            timer7.Enabled = false;
            timer8.Enabled = false;
            btnOK.Enabled = true;
            ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;

            foreach (ProcessThread thread in currentThreads)
            {
                // Do whatever you need
                thread.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
      
    }
}