namespace OxyPlotterTest
{
    partial class frmTestOxyPlot
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
            this.cmdShowPlot = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdShowPlot
            // 
            this.cmdShowPlot.Location = new System.Drawing.Point(24, 69);
            this.cmdShowPlot.Margin = new System.Windows.Forms.Padding(4);
            this.cmdShowPlot.Name = "cmdShowPlot";
            this.cmdShowPlot.Size = new System.Drawing.Size(149, 30);
            this.cmdShowPlot.TabIndex = 8;
            this.cmdShowPlot.Text = "&Show Plot";
            this.cmdShowPlot.Click += new System.EventHandler(this.cmdShowPlot_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(13, 13);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(361, 48);
            this.txtInfo.TabIndex = 7;
            this.txtInfo.Text = "Hold down the control key, then click the Edit menu.  Now choose \'Add Sample Data" +
    "\'";
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(211, 69);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(149, 30);
            this.cmdExit.TabIndex = 6;
            this.cmdExit.Text = "E&xit";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // frmTestOxyPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 123);
            this.Controls.Add(this.cmdShowPlot);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.cmdExit);
            this.Name = "frmTestOxyPlot";
            this.Text = "frmTestOxyPlot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdShowPlot;
        internal System.Windows.Forms.TextBox txtInfo;
        internal System.Windows.Forms.Button cmdExit;
    }
}