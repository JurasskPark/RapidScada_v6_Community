using Scada.Comm.Drivers.DrvModbusCM;
using Scada.Comm.Drivers.DrvModbusCM.View;
using Scada.Forms;
using System.Data;

namespace DrvModbusCM.View.Forms.Log
{
    public partial class FrmLogs : Form
    {
        public FrmLogs()
        {
            InitializeComponent();
        }

        #region Variables
        public FrmStart formParent;                     // parent form
        public Project project;                         // the project configuration

        private DriverClient driverClient = new DriverClient();

        private Guid id;
        private string name;
        private bool logWrite = true;
        #endregion Variables




        #region Form Load
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void FrmLogs_Load(object sender, EventArgs e)
        {
            ConfigToControls();
            Translate();
        }

        #endregion Form Load

        #region Form Close
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>   
        private void FrmLogs_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlsToConfig();
        }
        #endregion Form Close

        #region Lang
        /// <summary>
        /// Translation of the form.
        /// <para>Перевод формы.</para>
        /// </summary>
        private void Translate()
        {
            // translate the form
            FormTranslator.Translate(this, GetType().FullName);
            // tranlaste the menu
            //FormTranslator.Translate(cmnuMenu, GetType().FullName);
        }

        #endregion Lang

        #region Control

        #endregion Control

        #region Config
        /// <summary>
        /// Sets the controls according to the configuration.
        /// <para>Устанавливает элементы управления в соответствии с конфигурацией.</para>
        /// </summary>
        public void ConfigToControls()
        {
            DriverClient.OnDebug = new DriverClient.DebugData(LogDriverClient);

            #region Combobox
            if (project.Driver.GroupChannel.Group != null && project.Driver.GroupChannel.Group.Count > 0)
            {

                DataTable dataTableChannels = new DataTable();
                dataTableChannels.TableName = "Data";
                dataTableChannels.Columns.Add("Id", typeof(Guid));
                dataTableChannels.Columns.Add("Name", typeof(string));

                foreach (ProjectChannel channel in project.Driver.GroupChannel.Group)
                {
                    dataTableChannels.Rows.Add(channel.ID, channel.Name.ToString());
                }

                cmbChannel.DataSource = dataTableChannels;
                cmbChannel.ValueMember = "Id";
                cmbChannel.DisplayMember = "Name";
                cmbChannel.SelectedIndex = 0;
                #endregion Combobox
            }            
        }

        /// <summary>
        /// Sets the configuration parameters according to the controls.
        /// <para>Устанавливает параметры конфигурации в соответствии с элементами управления.</para>
        /// </summary>
        private void ControlsToConfig()
        {

        }

        private void cmbChannel_MouseClick(object sender, MouseEventArgs e)
        {
            DriverClient.OnDebug -= new DriverClient.DebugData(LogDriverClient);
        }

        private void cmbChannel_MouseUp(object sender, MouseEventArgs e)
        {
            DriverClient.OnDebug += new DriverClient.DebugData(LogDriverClient);
        }

        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChannelSelect();
        }

        private void ChannelSelect()
        {
            try
            {
                System.Data.DataRowView dataRowView = (DataRowView)cmbChannel.SelectedItem;
                if (dataRowView != null &&
                    System.String.IsNullOrEmpty(Convert.ToString(dataRowView.Row.ItemArray[0]).Trim()) == false &&
                    System.String.IsNullOrEmpty(Convert.ToString(dataRowView.Row.ItemArray[1]).Trim()) == false
                    )
                {
                    id = DriverUtils.StringToGuid(Convert.ToString(dataRowView.Row.ItemArray[0]).Trim());
                    name = Convert.ToString(dataRowView.Row.ItemArray[1]).Trim();

                    LogClear();

                    DriverClient.OnDebug = new DriverClient.DebugData(LogDriverClient);
                }
            }
            catch { }
        }

        public void LogDriverClient(Guid id, string text)
        {
            if (logWrite)
            {
                if (this.id == id)
                {
                    Log(text);
                }
            }
        }

        public void Log(string text)
        {
            if (!IsHandleCreated)
            {
                this.CreateControl();
            }

            if (IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    fctLog.AppendText(@$"{text}" + Environment.NewLine);

                    if (fctLog.Lines.Count() > 200)
                    {
                        fctLog.Text = "";
                    }
                });
            }
            else
            {
                fctLog.AppendText(@$"{text}" + Environment.NewLine);

                if (fctLog.Lines.Count() > 200)
                {
                    fctLog.Text = "";
                }
            }
        }

        public void LogClear()
        {
            if (!IsHandleCreated)
            {
                this.CreateControl();
            }

            if (IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    fctLog.Text = string.Empty;
                });
            }
            else
            {
                fctLog.Text = string.Empty;
            }
        }
        #endregion Config 

        #region Driver Config



        #endregion Driver Config




        private void ckbPause_CheckedChanged(object sender, EventArgs e)
        {
            logWrite = !ckbPause.Checked;
        }
    }
}
