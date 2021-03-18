using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMSapplication
{
    public partial class frmRandomPort : Form
    {
        // Variable of Combo
        public static string[] portNames = new string[0];
        public static int noOfCombo = 0;
        public static int comboY = 0;

        public static List<SerialPort> ports = new List<SerialPort>();
      
        public frmRandomPort()
        {
            InitializeComponent();
        }

        private void frmRandomPort_Load(object sender, EventArgs e)
        {
            portNames = SerialPort.GetPortNames();
           // this.WindowState = FormWindowState.Maximized;
            AddInitialCombox();


        }




        #region Dynamic Combo Box
        public void AddInitialCombox()
        {
             comboY = grpPorts.Location.Y;

            while (noOfCombo < 15)
            {
                noOfCombo++;
                string name = "Combo" + noOfCombo;
                int divion = noOfCombo / 3;
                bool remainder = noOfCombo % 3==0;
                bool remainderM = noOfCombo % 2 == 0;
                int x = remainder?400: remainderM?200:  10;
                ComboBox comboBox = new ComboBox();
               
                comboBox.Location = new System.Drawing.Point(x, comboY);
                comboBox.Name = name;
                comboBox.Size = new System.Drawing.Size(150, 25);
                comboBox.Items.AddRange(portNames);
                grpPorts.Controls.Add(comboBox);
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
            if (remainder)
            {
                comboY = comboY + 30;
                grpPorts.Height = grpPorts.Height + 40;
            }
            comboBox.Location = new System.Drawing.Point(x, comboY);
            comboBox.Name = name;
            comboBox.Size = new System.Drawing.Size(150, 25);
            comboBox.Items.AddRange(portNames);
            grpPorts.Controls.Add(comboBox);
            lblPortNo.Text = noOfCombo.ToString();
            

        }
        #endregion
    }

}
