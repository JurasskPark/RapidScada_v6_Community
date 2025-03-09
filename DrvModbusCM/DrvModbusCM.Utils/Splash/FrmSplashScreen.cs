using System.Collections;
using System.Drawing.Drawing2D;
using System.Xml;

namespace Splash
{
    public partial class SplashScreen : Form
    {
        #region Member Variables

        // Threading
        private static SplashScreen ms_frmSplash = null;
        private static Thread ms_oThread = null;

        // Fade in and fade out. Each time the timer runs, the fade in and fade out increases or decreases continuously.
        private double m_dblOpacityIncrement = .05;
        private double m_dblOpacityDecrement = .08;
        private const int m_TimerInterval = 50;

        // Status and progress bar
        private string m_sTitle;
        private string m_sStatus;
        private string m_sTimeRemaining;
        private double m_dblCompletionFraction = 0.0;
        private Rectangle m_rProgressRect;

        // Progress smoothing
        private double m_dblLastCompletionFraction = 0.0;
        private double m_dblPBIncrementPerTimerInterval = .015;

        // Self-calibration support
        private int m_iIndex = 1;
        private int m_iActualTicks = 0;
        private ArrayList m_alPreviousCompletionFraction;
        private ArrayList m_alActualTimes = new ArrayList();
        private DateTime m_dtStart;
        private bool m_bFirstLaunch = false;
        private bool m_bDTSet = false;

        #endregion Member Variables

        /// <summary>
        /// Base constructor
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();

            // Initialize transparency to fully transparent
            this.Opacity = 0.0;

            // Initialize transparency to fully transparent
            tmrTimer.Interval = m_TimerInterval;

            // Start Timer
            tmrTimer.Start();

            // Set the size of the startup window to the size of the background image
            //this.ClientSize = this.BackgroundImage.Size;
        }

        #region Public Static Methods
        /// <summary>
        /// Display the startup form. If the form does not exist, it will be displayed after creation.
        /// </summary>
        static public void ShowSplashScreen()
        {
            // Make sure startup creation is only loaded once
            if (ms_frmSplash != null)
                return;

            // Create a thread to update status
            ms_oThread = new Thread(() =>
            {
                ms_frmSplash = new SplashScreen();
                Application.Run(ms_frmSplash);
            })
            {
                IsBackground = true
            };

            // Set thread unit status
            ms_oThread.SetApartmentState(ApartmentState.STA);

            // Start thread
            ms_oThread.Start();

            // Wait for the startup form to be created
            while (ms_frmSplash == null || ms_frmSplash.IsHandleCreated == false)
            {
                Thread.Sleep(m_TimerInterval);
            }
        }

        // Close the form without setting the parent.
        static public void CloseSplashScreen()
        {
            if (ms_frmSplash != null && ms_frmSplash.IsDisposed == false)
            {
                // Make it start going away.
                ms_frmSplash.m_dblOpacityIncrement = -ms_frmSplash.m_dblOpacityDecrement;
            }
            ms_oThread = null;  // we don't need these any more.
            ms_frmSplash = null;
        }

        // A static method to set the title and update the reference.
        static public void SetTitle(string newTitle)
        {
            SetTitle(newTitle, true);
        }

        // A static method to set the title and optionally update the reference.
        // This is useful if you are in a section of code that has a variable
        // set of title string updates.  In that case, don't set the reference.
        static public void SetTitle(string newTitle, bool setReference)
        {
            if (ms_frmSplash == null)
                return;

            ms_frmSplash.m_sTitle = newTitle;

            if (setReference)
                ms_frmSplash.SetReferenceInternal();
        }



        // A static method to set the status and update the reference.
        static public void SetStatus(string newStatus)
        {
            SetStatus(newStatus, true);
        }

        // A static method to set the status and optionally update the reference.
        // This is useful if you are in a section of code that has a variable
        // set of status string updates.  In that case, don't set the reference.
        static public void SetStatus(string newStatus, bool setReference)
        {
            if (ms_frmSplash == null)
                return;

            ms_frmSplash.m_sStatus = newStatus;

            if (setReference)
                ms_frmSplash.SetReferenceInternal();
        }

        // Static method called from the initializing application to 
        // give the splash screen reference points.  Not needed if
        // you are using a lot of status strings.
        static public void SetReferencePoint()
        {
            if (ms_frmSplash == null)
                return;
            ms_frmSplash.SetReferenceInternal();

        }
        #endregion Public Static Methods

        #region Private Methods

        // Internal method for setting reference points.
        private void SetReferenceInternal()
        {
            if (m_bDTSet == false)
            {
                m_bDTSet = true;
                m_dtStart = DateTime.Now;
                ReadIncrements();
            }
            double dblMilliseconds = ElapsedMilliSeconds();
            m_alActualTimes.Add(dblMilliseconds);
            m_dblLastCompletionFraction = m_dblCompletionFraction;
            if (m_alPreviousCompletionFraction != null && m_iIndex < m_alPreviousCompletionFraction.Count)
                m_dblCompletionFraction = (double)m_alPreviousCompletionFraction[m_iIndex++];
            else
                m_dblCompletionFraction = (m_iIndex > 0) ? 1 : 0;
        }

        // Utility function to return elapsed Milliseconds since the 
        // SplashScreen was launched.
        private double ElapsedMilliSeconds()
        {
            TimeSpan ts = DateTime.Now - m_dtStart;
            return ts.TotalMilliseconds;
        }

        // Function to read the checkpoint intervals from the previous invocation of the
        // splashscreen from the XML file.
        private void ReadIncrements()
        {
            string sPBIncrementPerTimerInterval = SplashScreenXMLStorage.Interval;
            double dblResult;

            if (Double.TryParse(sPBIncrementPerTimerInterval, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out dblResult) == true)
                m_dblPBIncrementPerTimerInterval = dblResult;
            else
                m_dblPBIncrementPerTimerInterval = .0015;

            string sPBPreviousPctComplete = SplashScreenXMLStorage.Percents;

            if (sPBPreviousPctComplete != "")
            {
                string[] aTimes = sPBPreviousPctComplete.Split(null);
                m_alPreviousCompletionFraction = new ArrayList();

                for (int i = 0; i < aTimes.Length; i++)
                {
                    double dblVal;
                    if (Double.TryParse(aTimes[i], System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out dblVal) == true)
                        m_alPreviousCompletionFraction.Add(dblVal);
                    else
                        m_alPreviousCompletionFraction.Add(1.0);
                }
            }
            else
            {
                m_bFirstLaunch = true;
                m_sTimeRemaining = "";
            }
        }

        // Method to store the intervals (in percent complete) from the current invocation of
        // the splash screen to XML storage.
        private void StoreIncrements()
        {
            string sPercent = "";
            double dblElapsedMilliseconds = ElapsedMilliSeconds();
            for (int i = 0; i < m_alActualTimes.Count; i++)
            {
                sPercent += ((double)m_alActualTimes[i] / dblElapsedMilliseconds).ToString("0.####", System.Globalization.NumberFormatInfo.InvariantInfo) + " ";
            }

            SplashScreenXMLStorage.Percents = sPercent;

            m_dblPBIncrementPerTimerInterval = 1.0 / (double)m_iActualTicks;

            SplashScreenXMLStorage.Interval = m_dblPBIncrementPerTimerInterval.ToString("#.000000", System.Globalization.NumberFormatInfo.InvariantInfo);
        }

        public static SplashScreen GetSplashScreen()
        {
            return ms_frmSplash;
        }

        #endregion Private Methods

        #region Event Handlers
        // Tick Event handler for the Timer control.  Handle fade in and fade out and paint progress bar. 
        private void tmrTimer_Tick(object sender, System.EventArgs e)
        {
            this.lblTitle.Text = this.m_sTitle;
            this.lblStatus.Text = this.m_sStatus;

            // Calculate opacity
            if (m_dblOpacityIncrement > 0)      // Starting up splash screen
            {
                m_iActualTicks++;
                if (this.Opacity < 1)
                    this.Opacity += m_dblOpacityIncrement;
            }
            else // Closing down splash screen
            {
                if (this.Opacity > 0)
                    this.Opacity += m_dblOpacityIncrement;
                else
                {
                    StoreIncrements();
                    tmrTimer.Stop();
                    this.Close();
                }
            }

            // Paint progress bar
            if (m_bFirstLaunch == false && m_dblLastCompletionFraction < m_dblCompletionFraction)
            {
                m_dblLastCompletionFraction += m_dblPBIncrementPerTimerInterval;

                // Calculate the size of the current completion percentage and draw the rectangle accordingly
                int width = (int)Math.Floor(pnlStatus.ClientRectangle.Width * m_dblLastCompletionFraction);
                int height = pnlStatus.ClientRectangle.Height;
                int x = pnlStatus.ClientRectangle.X;
                int y = pnlStatus.ClientRectangle.Y;
                if (width > 0 && height > 0)
                {
                    this.m_rProgressRect = new Rectangle(x, y, width, height);
                    if (!pnlStatus.IsDisposed)
                    {
                        var g = pnlStatus.CreateGraphics();
                        var brBackground = new LinearGradientBrush(m_rProgressRect, Color.FromArgb(46, 136, 46), Color.FromArgb(46, 136, 46), LinearGradientMode.Horizontal);
                        g.FillRectangle(brBackground, m_rProgressRect);
                        g.Dispose();
                    }

                    //int iSecondsLeft = 1 + (int)(TIMER_INTERVAL * ((1.0 - m_dblLastCompletionFraction) / m_dblPBIncrementPerTimerInterval)) / 1000;
                    //m_sTimeRemaining = (iSecondsLeft == 1) ? string.Format("1 second remaining") : string.Format("{0} seconds remaining", iSecondsLeft);
                }
            }

            TimeSpan timeSpan = DateTime.Now - this.m_dtStart;
            m_sTimeRemaining = timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
            lblTime.Text = m_sTimeRemaining;
        }

        // Close the form if they double click on it.
        private void SplashScreen_DoubleClick(object sender, System.EventArgs e)
        {
            CloseSplashScreen();
        }
        #endregion Event Handlers
    }

    #region Auxiliary Classes 
    /// <summary>
    /// A specialized class for managing XML storage for the splash screen.
    /// </summary>
    internal class SplashScreenXMLStorage
    {
        private static string ms_StoredValues = "SplashScreen.xml";
        private static string ms_DefaultPercents = "";
        private static string ms_DefaultIncrement = ".015";


        // Get or set the string storing the percentage complete at each checkpoint.
        static public string Percents
        {
            get { return GetValue("Percents", ms_DefaultPercents); }
            set { SetValue("Percents", value); }
        }
        // Get or set how much time passes between updates.
        static public string Interval
        {
            get { return GetValue("Interval", ms_DefaultIncrement); }
            set { SetValue("Interval", value); }
        }

        // Store the file in a location where it can be written with only User rights. (Don't use install directory).
        static private string StoragePath
        {
            get { return Path.Combine(Application.UserAppDataPath, ms_StoredValues); }
        }

        // Helper method for getting inner text of named element.
        static private string GetValue(string name, string defaultValue)
        {
            if (!File.Exists(StoragePath))
                return defaultValue;

            try
            {
                XmlDocument docXML = new XmlDocument();
                docXML.Load(StoragePath);
                XmlElement elValue = docXML.DocumentElement.SelectSingleNode(name) as XmlElement;
                return (elValue == null) ? defaultValue : elValue.InnerText;
            }
            catch
            {
                return defaultValue;
            }
        }

        // Helper method for setting inner text of named element.  Creates document if it doesn't exist.
        static public void SetValue(string name, string stringValue)
        {
            try
            {
                XmlDocument docXML = new XmlDocument();
                XmlElement elRoot = null;
                if (!File.Exists(StoragePath))
                {
                    elRoot = docXML.CreateElement("root");
                    docXML.AppendChild(elRoot);
                }
                else
                {
                    docXML.Load(StoragePath);
                    elRoot = docXML.DocumentElement;
                }
                XmlElement value = docXML.DocumentElement.SelectSingleNode(name) as XmlElement;
                if (value == null)
                {
                    value = docXML.CreateElement(name);
                    elRoot.AppendChild(value);
                }
                value.InnerText = stringValue;
                docXML.Save(StoragePath);
            }
            catch { }
        }
    }
    #endregion Auxiliary Classes
}
