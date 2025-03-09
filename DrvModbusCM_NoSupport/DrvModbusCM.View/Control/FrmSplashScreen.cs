using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class FrmSplashScreen : Form
    {
        delegate void StringParameterDelegate(int number, string Text);
        delegate void StringParameterWithStatusDelegate(int number, string Text, TypeOfMessage tom);
        delegate void SplashShowCloseDelegate();

        /// <summary>
        /// To ensure splash screen is closed using the API and not by keyboard or any other things
        /// </summary>
        bool CloseSplashScreenFlag = false;

        /// <summary>
        /// Base constructor
        /// </summary>
        public FrmSplashScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays the splashscreen
        /// </summary>
        public void ShowSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public void CloseSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }
            CloseSplashScreenFlag = true;
            this.Close();
        }

        /// <summary>
        /// Update text in default green color of success message
        /// </summary>
        /// <param name="Text">Message</param>
        public void UdpateStatusText(int line, string Text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateStatusText), new object[] { line, Text });
                return;
            }
            // Must be on the UI thread if we've got this far
            if (line == 1)
            {
                line1.ForeColor = Color.Black;
                line1.Text = Text;
            }
            else if (line == 2)
            {
                line2.ForeColor = Color.Black;
                line2.Text = Text;
            }
            else if (line == 3)
            {
                line3.ForeColor = Color.Black;
                line3.Text = Text;
            }
        }


        /// <summary>
        /// Update text with message color defined as green/yellow/red/ for success/warning/failure
        /// </summary>
        /// <param name="Text">Message</param>
        /// <param name="tom">Type of Message</param>
        public void UdpateStatusTextWithStatus(int line, string Text, TypeOfMessage tom)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterWithStatusDelegate(UdpateStatusTextWithStatus), new object[] { line, Text, tom });
                return;
            }
            // Must be on the UI thread if we've got this far
            switch (tom)
            {
                case TypeOfMessage.Error:
                    line1.ForeColor = Color.Red;
                    line2.ForeColor = Color.Red;
                    line3.ForeColor = Color.Red;
                    break;
                case TypeOfMessage.Warning:
                    line1.ForeColor = Color.OrangeRed;
                    line2.ForeColor = Color.OrangeRed;
                    line3.ForeColor = Color.OrangeRed;
                    break;
                case TypeOfMessage.Success:
                    line1.ForeColor = Color.Black;
                    line2.ForeColor = Color.Black;
                    line2.ForeColor = Color.Black;
                    break;
            }

            // Must be on the UI thread if we've got this far
            if (line == 1)
            {
                line1.Text = Text;
            }
            else if (line == 2)
            {
                line2.Text = Text;
            }
            else if (line == 3)
            {
                line3.Text = Text;
            }
        }

        /// <summary>
        /// Prevents the closing of form other than by calling the CloseSplashScreen function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseSplashScreenFlag == false)
                e.Cancel = true;
        }
    }
}
