using Scada.Comm.Drivers.DrvModbusCM;
using Scada.Comm.Drivers.DrvModbusCM.View;
using Scada.Forms;
using Scada.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private string id;
        private string name;
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
            #region Combobox
            DataTable dataTableChannels = new DataTable();
            dataTableChannels.TableName = "Data";
            dataTableChannels.Columns.Add("Id", typeof(string));
            dataTableChannels.Columns.Add("Name", typeof(string));

            foreach (ProjectChannel channel in project.Driver.GroupChannel.Group)
            {
                dataTableChannels.Rows.Add(channel.ID.ToString(), channel.Name.ToString());
            }

            cmbChannel.DataSource = dataTableChannels;
            cmbChannel.ValueMember = "Id";
            cmbChannel.DisplayMember = "Name";
            cmbChannel.SelectedIndex = 0;
            #endregion Combobox
        }

        /// <summary>
        /// Sets the configuration parameters according to the controls.
        /// <para>Устанавливает параметры конфигурации в соответствии с элементами управления.</para>
        /// </summary>
        private void ControlsToConfig()
        {

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
                    String.IsNullOrEmpty(Convert.ToString(dataRowView.Row.ItemArray[0]).Trim()) == false &&
                    String.IsNullOrEmpty(Convert.ToString(dataRowView.Row.ItemArray[1]).Trim()) == false
                    )
                {
                    id = Convert.ToString(dataRowView.Row.ItemArray[0]).Trim();
                    name = Convert.ToString(dataRowView.Row.ItemArray[1]).Trim();

                }
            }
            catch { }
        }
        #endregion Config 

        #region Driver Config



        #endregion Driver Config



    }
}
