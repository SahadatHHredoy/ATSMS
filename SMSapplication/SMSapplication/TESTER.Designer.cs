namespace SMSapplication
{
    partial class TESTER
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
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtI = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(334, 84);
            this.txtP.Multiline = true;
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(412, 58);
            this.txtP.TabIndex = 0;
            // 
            // txtL
            // 
            this.txtL.Location = new System.Drawing.Point(207, 84);
            this.txtL.Name = "txtL";
            this.txtL.Size = new System.Drawing.Size(100, 20);
            this.txtL.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Read Online";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtI
            // 
            this.txtI.Location = new System.Drawing.Point(83, 276);
            this.txtI.Multiline = true;
            this.txtI.Name = "txtI";
            this.txtI.Size = new System.Drawing.Size(290, 58);
            this.txtI.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(395, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Convert";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtO
            // 
            this.txtO.Location = new System.Drawing.Point(489, 276);
            this.txtO.Multiline = true;
            this.txtO.Name = "txtO";
            this.txtO.Size = new System.Drawing.Size(290, 58);
            this.txtO.TabIndex = 5;
            // 
            // TESTER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtO);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtI);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtL);
            this.Controls.Add(this.txtP);
            this.Name = "TESTER";
            this.Text = "TESTER";
            this.Load += new System.EventHandler(this.TESTER_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtI;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtO;
    }
}