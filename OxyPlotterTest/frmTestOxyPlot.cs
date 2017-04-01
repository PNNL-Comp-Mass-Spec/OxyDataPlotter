using System;
using System.Windows.Forms;

namespace OxyPlotterTest
{
    public partial class frmTestOxyPlot : Form
    {
        private OxyDataPlotter.frmOxySpectrum mOxyPlot;

        public frmTestOxyPlot()
        {
            InitializeComponent();

            InitializeOxySpectrum();
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
    }
}
