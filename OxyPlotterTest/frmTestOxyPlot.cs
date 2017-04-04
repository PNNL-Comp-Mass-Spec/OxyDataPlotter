using System;
using System.Windows.Forms;

namespace OxyPlotterTest
{
    public partial class frmTestOxyPlot : Form
    {
        private OxyDataPlotter.frmOxySpectrum mOxyPlot;

        private Timer mSetFocusTimer;

        public frmTestOxyPlot()
        {
            InitializeComponent();

            InitializeOxySpectrum();

            mSetFocusTimer = new Timer {
                Interval = 250
            };

            mSetFocusTimer.Tick += SetFocusTimer_Tick;
            mSetFocusTimer.Enabled = true;
        }

        private void InitializeOxySpectrum()
        {
            try
            {
                mOxyPlot = new OxyDataPlotter.frmOxySpectrum {
                    Text = "Test Plot"
                };

                mOxyPlot.Show();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error initializing CWSpectrumDLLNET.frmOxySpectrum: " + ex.Message);
            }
        }

        private void cmdShowPlot_Click(object sender, EventArgs e)
        {
            if (mOxyPlot == null)
                InitializeOxySpectrum();
            else
                mOxyPlot.Show();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception in cmdExit_Click: " + ex.Message);
            }
        }

        private void SetFocusTimer_Tick(object sender, EventArgs e)
        {
            mOxyPlot.BringToFront();
            mSetFocusTimer.Enabled = false;
        }

    }
}
