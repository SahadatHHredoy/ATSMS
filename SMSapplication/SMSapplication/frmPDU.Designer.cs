namespace SMSapplication
{
    partial class frmPDU
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
            this.grpPorts = new System.Windows.Forms.GroupBox();
            this.panelPorts = new System.Windows.Forms.Panel();
            this.btnAddPort = new System.Windows.Forms.Button();
            this.lblPortNo = new System.Windows.Forms.Label();
            this.gboPortSettings = new System.Windows.Forms.GroupBox();
            this.txtApiLink = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBaseUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.txtWriteTimeOut = new System.Windows.Forms.TextBox();
            this.txtReadTimeOut = new System.Windows.Forms.TextBox();
            this.cboParityBits = new System.Windows.Forms.ComboBox();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnDeletePort = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnDialPad = new System.Windows.Forms.Button();
            this.btnInbox = new System.Windows.Forms.Button();
            this.grpPorts.SuspendLayout();
            this.gboPortSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPorts
            // 
            this.grpPorts.Controls.Add(this.panelPorts);
            this.grpPorts.Location = new System.Drawing.Point(12, 21);
            this.grpPorts.Name = "grpPorts";
            this.grpPorts.Size = new System.Drawing.Size(623, 386);
            this.grpPorts.TabIndex = 0;
            this.grpPorts.TabStop = false;
            this.grpPorts.Text = "Ports";
            // 
            // panelPorts
            // 
            this.panelPorts.AutoScroll = true;
            this.panelPorts.Location = new System.Drawing.Point(6, 17);
            this.panelPorts.Name = "panelPorts";
            this.panelPorts.Size = new System.Drawing.Size(611, 363);
            this.panelPorts.TabIndex = 0;
            // 
            // btnAddPort
            // 
            this.btnAddPort.Location = new System.Drawing.Point(396, 4);
            this.btnAddPort.Name = "btnAddPort";
            this.btnAddPort.Size = new System.Drawing.Size(75, 23);
            this.btnAddPort.TabIndex = 0;
            this.btnAddPort.Text = "Add Port";
            this.btnAddPort.UseVisualStyleBackColor = true;
            this.btnAddPort.Click += new System.EventHandler(this.btnAddPort_Click);
            // 
            // lblPortNo
            // 
            this.lblPortNo.AutoSize = true;
            this.lblPortNo.Location = new System.Drawing.Point(260, 9);
            this.lblPortNo.Name = "lblPortNo";
            this.lblPortNo.Size = new System.Drawing.Size(35, 13);
            this.lblPortNo.TabIndex = 1;
            this.lblPortNo.Text = "label1";
            // 
            // gboPortSettings
            // 
            this.gboPortSettings.Controls.Add(this.txtApiLink);
            this.gboPortSettings.Controls.Add(this.label10);
            this.gboPortSettings.Controls.Add(this.txtBaseUrl);
            this.gboPortSettings.Controls.Add(this.label1);
            this.gboPortSettings.Controls.Add(this.label8);
            this.gboPortSettings.Controls.Add(this.txtInterval);
            this.gboPortSettings.Controls.Add(this.txtWriteTimeOut);
            this.gboPortSettings.Controls.Add(this.txtReadTimeOut);
            this.gboPortSettings.Controls.Add(this.cboParityBits);
            this.gboPortSettings.Controls.Add(this.cboStopBits);
            this.gboPortSettings.Controls.Add(this.cboDataBits);
            this.gboPortSettings.Controls.Add(this.cboBaudRate);
            this.gboPortSettings.Controls.Add(this.label7);
            this.gboPortSettings.Controls.Add(this.label6);
            this.gboPortSettings.Controls.Add(this.label5);
            this.gboPortSettings.Controls.Add(this.label4);
            this.gboPortSettings.Controls.Add(this.label3);
            this.gboPortSettings.Controls.Add(this.label2);
            this.gboPortSettings.Location = new System.Drawing.Point(6, 413);
            this.gboPortSettings.Name = "gboPortSettings";
            this.gboPortSettings.Size = new System.Drawing.Size(623, 189);
            this.gboPortSettings.TabIndex = 1;
            this.gboPortSettings.TabStop = false;
            this.gboPortSettings.Text = "Port Settings";
            // 
            // txtApiLink
            // 
            this.txtApiLink.Location = new System.Drawing.Point(365, 141);
            this.txtApiLink.MaxLength = 5;
            this.txtApiLink.Name = "txtApiLink";
            this.txtApiLink.Size = new System.Drawing.Size(100, 20);
            this.txtApiLink.TabIndex = 28;
            this.txtApiLink.Text = "pdu-sms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(265, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Api Link";
            // 
            // txtBaseUrl
            // 
            this.txtBaseUrl.Location = new System.Drawing.Point(365, 115);
            this.txtBaseUrl.MaxLength = 5;
            this.txtBaseUrl.Name = "txtBaseUrl";
            this.txtBaseUrl.Size = new System.Drawing.Size(199, 20);
            this.txtBaseUrl.TabIndex = 26;
            this.txtBaseUrl.Text = "http://easybulksmsbd.com/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Base Url";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(233, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Time Interval(milli-sec)";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(365, 19);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 20);
            this.txtInterval.TabIndex = 23;
            this.txtInterval.Text = "1000";
            // 
            // txtWriteTimeOut
            // 
            this.txtWriteTimeOut.Location = new System.Drawing.Point(365, 47);
            this.txtWriteTimeOut.MaxLength = 5;
            this.txtWriteTimeOut.Name = "txtWriteTimeOut";
            this.txtWriteTimeOut.Size = new System.Drawing.Size(100, 20);
            this.txtWriteTimeOut.TabIndex = 13;
            this.txtWriteTimeOut.Text = "300";
            // 
            // txtReadTimeOut
            // 
            this.txtReadTimeOut.Location = new System.Drawing.Point(365, 78);
            this.txtReadTimeOut.MaxLength = 5;
            this.txtReadTimeOut.Name = "txtReadTimeOut";
            this.txtReadTimeOut.Size = new System.Drawing.Size(100, 20);
            this.txtReadTimeOut.TabIndex = 12;
            this.txtReadTimeOut.Text = "300";
            // 
            // cboParityBits
            // 
            this.cboParityBits.FormattingEnabled = true;
            this.cboParityBits.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None"});
            this.cboParityBits.Location = new System.Drawing.Point(106, 110);
            this.cboParityBits.Name = "cboParityBits";
            this.cboParityBits.Size = new System.Drawing.Size(121, 21);
            this.cboParityBits.TabIndex = 11;
            this.cboParityBits.Text = "None";
            // 
            // cboStopBits
            // 
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cboStopBits.Location = new System.Drawing.Point(106, 78);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(121, 21);
            this.cboStopBits.TabIndex = 10;
            this.cboStopBits.Text = "1";
            // 
            // cboDataBits
            // 
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cboDataBits.Location = new System.Drawing.Point(106, 46);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(121, 21);
            this.cboDataBits.TabIndex = 9;
            this.cboDataBits.Text = "8";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cboBaudRate.Location = new System.Drawing.Point(106, 19);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cboBaudRate.TabIndex = 8;
            this.cboBaudRate.Text = "115200";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Write Timeout";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Read Timeout";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Parity Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stop Bits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Bits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(644, 243);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 22;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(644, 286);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "Sync SMS";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(722, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Total Messages Sent :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1086, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(725, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(420, 563);
            this.listBox1.TabIndex = 23;
            // 
            // btnDeletePort
            // 
            this.btnDeletePort.Location = new System.Drawing.Point(315, 4);
            this.btnDeletePort.Name = "btnDeletePort";
            this.btnDeletePort.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePort.TabIndex = 27;
            this.btnDeletePort.Text = "Delete Port";
            this.btnDeletePort.UseVisualStyleBackColor = true;
            this.btnDeletePort.Click += new System.EventHandler(this.btnDeletePort_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(841, 17);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "0";
            // 
            // btnDialPad
            // 
            this.btnDialPad.Location = new System.Drawing.Point(554, 4);
            this.btnDialPad.Name = "btnDialPad";
            this.btnDialPad.Size = new System.Drawing.Size(75, 23);
            this.btnDialPad.TabIndex = 29;
            this.btnDialPad.Text = "Dial Pad";
            this.btnDialPad.UseVisualStyleBackColor = true;
            this.btnDialPad.Click += new System.EventHandler(this.btnDialPad_Click);
            // 
            // btnInbox
            // 
            this.btnInbox.Location = new System.Drawing.Point(477, 4);
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Size = new System.Drawing.Size(75, 23);
            this.btnInbox.TabIndex = 30;
            this.btnInbox.Text = "Inbox";
            this.btnInbox.UseVisualStyleBackColor = true;
            this.btnInbox.Click += new System.EventHandler(this.btnInbox_Click);
            // 
            // frmPDU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 614);
            this.Controls.Add(this.btnInbox);
            this.Controls.Add(this.btnDialPad);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnDeletePort);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblPortNo);
            this.Controls.Add(this.gboPortSettings);
            this.Controls.Add(this.btnAddPort);
            this.Controls.Add(this.grpPorts);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.Name = "frmPDU";
            this.Text = "SMS Application V2.0.7";
            this.Load += new System.EventHandler(this.frmPDU_Load);
            this.grpPorts.ResumeLayout(false);
            this.gboPortSettings.ResumeLayout(false);
            this.gboPortSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPorts;
        private System.Windows.Forms.Button btnAddPort;
        private System.Windows.Forms.Label lblPortNo;
        private System.Windows.Forms.GroupBox gboPortSettings;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.TextBox txtWriteTimeOut;
        private System.Windows.Forms.TextBox txtReadTimeOut;
        private System.Windows.Forms.ComboBox cboParityBits;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnDeletePort;
        private System.Windows.Forms.Panel panelPorts;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnDialPad;
        private System.Windows.Forms.Button btnInbox;
        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApiLink;
        private System.Windows.Forms.Label label10;
    }
}