using System.Diagnostics;

namespace About
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        // <summary>
        // single line of text to show in the application title section of the about box dialog
        // </summary>
        // <remarks>
        // defaults to "%title%" 
        // %title% = Assembly: AssemblyTitle
        // </remarks>
        public string AppTitle
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                if (value == string.Empty)
                {
                    lblTitle.Visible = false;
                }
                else
                {
                    lblTitle.Visible = true;
                    lblTitle.Text = ReplaceTokens(lblTitle.Text, value);
                }            
            }
        }

        // <summary>
        // single line of text to show in the description section of the about box dialog
        // </summary>
        // <remarks>
        // defaults to "%description%"
        // %description% = Assembly: AssemblyDescription
        // </remarks>
        public string AppDescription
        {
            get
            {
                return lblDescription.Text;
            }
            set
            {
                if (value == string.Empty)
                {
                    lblDescription.Visible = false;
                }
                else
                {
                    lblDescription.Visible = true;
                    lblDescription.Text = ReplaceTokens(lblDescription.Text, value);
                }
            }
        }

        // <summary>
        // single line of text to show in the version section of the about dialog
        // </summary>
        // <remarks>
        // defaults to "Version %version%"
        // %version% = Assembly: AssemblyVersion
        // </remarks>
        public string AppVersion
        {
            get
            {
                return lblVersion.Text;
            }
            set
            {
                if (value == string.Empty)
                {
                    lblVersion.Visible = false;
                }
                else
                {
                    lblVersion.Visible = true;
                    lblVersion.Text = ReplaceTokens(lblVersion.Text, value);
                }
            }
        }

        // <summary>
        // single line of text to show in the copyright section of the about dialog
        // </summary>
        // <remarks>
        // defaults to "Copyright © %year%, %company%"
        // %company% = Assembly: AssemblyCompany
        // %year% = current 4-digit year
        // </remarks>
        public string AppCopyright
        {
            get
            {
                return lblCopyright.Text;
            }
            set
            {
                if (value == string.Empty)
                {
                    lblCopyright.Visible = false;
                }
                else
                {
                    lblCopyright.Visible = true;
                    lblCopyright.Text = ReplaceTokens(lblCopyright.Text, value);
                }
            }
        }

        // <summary>
        // multiple lines of miscellaneous text to show in rich text box
        // </summary>
        // <remarks>
        // defaults to "%product% is %copyright%, %trademark%"
        // %product% = Assembly: AssemblyProduct
        // %copyright% = Assembly: AssemblyCopyright
        // %trademark% = Assembly: AssemblyTrademark
        // </remarks>
        public string AppInfoMore
        {
            get
            {
                return rchInfoMore.Text;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    rchInfoMore.Visible = false;
                }
                else
                {
                    rchInfoMore.Visible = true;
                    rchInfoMore.Text = ReplaceTokens(rchInfoMore.Text, value);
                }
            }
        }

        /// <summary>
        /// single line of text to show in the builddate section of the about dialog
        /// </summary>
        // <remarks>
        // defaults to "Built on %builddate%"
        // </remarks>
        public string AppBuildDate
        {
            get
            {
                return lblBuildDate.Text;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    lblBuildDate.Visible = false;
                }
                else
                {
                    lblBuildDate.Visible = true;
                    lblBuildDate.Text = ReplaceTokens(lblBuildDate.Text, value);
                }
            }
        }

        public string[] AppLinkInfo
        {
            get
            {
                string[] result = new string[4];
                result[0] = linkLabel1.Text;
                result[1] = linkLabel2.Text;
                result[2] = linkLabel3.Text;
                result[3] = linkLabel4.Text;

                return result;
            }
            set
            {
                if (value == null || value[0] == null || value[0] == string.Empty)
                {
                    pcbIcon1.Image = null;
                    linkLabel1.Visible = false;
                }
                else
                {
                    int index = SearchImageSocialNerwork(value[0]);
                    if (index > 0) { pcbIcon1.Image = imgList.Images[index]; }
                    pcbIcon1.Visible = true;
                    linkLabel1.Visible = true;
                    linkLabel1.Text = value[0];
                }

                if (value == null || value[1] == null || value[1] == string.Empty)
                {
                    pcbIcon2.Image = null;
                    linkLabel2.Visible = false;
                }
                else
                {
                    pcbIcon2.Image = imgList.Images[SearchImageSocialNerwork(value[1])];
                    pcbIcon2.Visible = true;
                    linkLabel2.Visible = true;
                    linkLabel2.Text = value[1];
                }

                if (value == null || value[2] == null || value[2] == string.Empty)
                {
                    pcbIcon3.Image = null;
                    linkLabel3.Visible = false;
                }
                else
                {
                    pcbIcon3.Image = imgList.Images[SearchImageSocialNerwork(value[2])];
                    pcbIcon3.Visible = true;
                    linkLabel3.Visible = true;
                    linkLabel3.Text = value[2];
                }

                if (value == null || value[3] == null || value[3] == string.Empty)
                {
                    pcbIcon4.Image = null;
                    linkLabel4.Visible = false;
                }
                else
                {
                    pcbIcon4.Image = imgList.Images[SearchImageSocialNerwork(value[3])];
                    pcbIcon4.Visible = true;
                    linkLabel4.Visible = true;
                    linkLabel4.Text = value[3];
                }
            }
        }

        // <summary>
        // perform assemblyinfo to string replacements on labels
        // </summary>
        private string ReplaceTokens(string text, string value)
        {
            text = text.Replace("%title%", value);
            text = text.Replace("%copyright%", value);
            text = text.Replace("%description%", value);
            text = text.Replace("%company%", value);
            text = text.Replace("%info%", value);
            text = text.Replace("%trademark%", value);
            text = text.Replace("%year%", value);
            text = text.Replace("%version%", value);
            text = text.Replace("%builddate%", value);
            return text;
        }

        private int SearchImageSocialNerwork(string value)
        {
            Dictionary<int, string> socialNetwork = new Dictionary<int, string>()
            {
                [0] = "github",
                [1] = "mailto",
                [2] = "jurasskpark.ru",
                [3] = "youtube"
            };

            for (int i = 0; i < socialNetwork.Count; i++)
            {
                string word = socialNetwork[i];
                int index = value.IndexOf(word);
                if (index >= 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl(linkLabel1.Text.Trim());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl(linkLabel2.Text.Trim());
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl(linkLabel3.Text.Trim());
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl(linkLabel4.Text.Trim());
        }

        private void OpenUrl(string url)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = url,
                };
                Process.Start(processStartInfo);
            }
            catch { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
