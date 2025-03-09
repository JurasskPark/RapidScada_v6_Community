using Scada.Comm.Devices;
using Scada.Comm.Drivers.DrvModbusCM.View.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class FrmTag : Form
    {
        public FrmTag()
        {
            InitializeComponent();
        }

        #region Variables

        #region Form

        public FrmConfigForm frmParentGloabal;        // global general form
        public uscGroupTag uscParent;                 // usercontrol
        public bool boolParent = false;               // сhild startup flag

        public bool modified;                          // the configuration was modified

        #endregion Form

        private ProjectNodeData mtNodeData;
        public ProjectNodeData MTNodeData
        {
            get { return mtNodeData; }
            set { mtNodeData = value; }
        }

        //ID устройства
        private Guid deviceID;
        public Guid DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }

        //ID группы тегов
        private Guid groupTagID;
        public Guid DeviceGroupTagID
        {
            get { return groupTagID; }
            set { groupTagID = value; }
        }

        private Guid tagID;
        public Guid DeviceTagID
        {
            get { return tagID; }
            set { tagID = value; }
        }

        private Guid tagCommandID;
        public Guid DeviceTagCommandID
        {
            get { return tagCommandID; }
            set { tagCommandID = value; }
        }

        //Иконка устройства
        private string tagKeyImage;
        public string DeviceTagKeyImage
        {
            get { return tagKeyImage; }
            set { tagKeyImage = value; }
        }

        private string tagAddress;
        public string DeviceTagAddress
        {
            get { return tagAddress; }
            set { tagAddress = value; }
        }

        private string tagname;
        public string DeviceTagname
        {
            get { return tagname; }
            set { tagname = value; }
        }

        private string tagCode;
        public string DeviceTagCode
        {
            get { return tagCode; }
            set { tagCode = value; }
        }

        private string tagDescription;
        public string DeviceTagDescription
        {
            set { tagDescription = value; }
            get { return tagDescription; }
        }

        private object tagType;
        public object DeviceTagType
        {
            set { tagType = value; }
            get { return tagType; }
        }

        private bool tagEnabled;
        public bool DeviceTagEnabled
        {
            set { tagEnabled = value; }
            get { return tagEnabled; }
        }

        private string tagSorting;
        public string DeviceTagSorting
        {
            set { tagSorting = value; }
            get { return tagSorting; }
        }

        private object tagDataValue;
        public object DeviceTagDataValue
        {
            set { tagDataValue = value; }
            get { return tagDataValue; }
        }

        private DateTime tagDateTime;
        public DateTime DeviceTagDateTime
        {
            set { tagDateTime = value; }
            get { return tagDateTime; }
        }

        private ushort tagQuality;
        public ushort DeviceTagQuality
        {
            set { tagQuality = value; }
            get { return tagQuality; }
        }

        private float tagCoefficient;
        public float DeviceTagCoefficient
        {
            get { return tagCoefficient; }
            set { tagCoefficient = value; }
        }

        private int tagScaled;
        public int DeviceTagScaled
        {
            set { tagScaled = value; }
            get { return tagScaled; }
        }

        private float tagScaledHigh;
        public float DeviceTagScaledHigh
        {
            get { return tagScaledHigh; }
            set { tagScaledHigh = value; }
        }

        private float tagScaledLow;
        public float DeviceTagScaledLow
        {
            get { return tagScaledLow; }
            set { tagScaledLow = value; }
        }

        private float tagRowHigh;
        public float DeviceTagRowHigh
        {
            get { return tagRowHigh; }
            set { tagRowHigh = value; }
        }

        private float tagRowLow;
        public float DeviceTagRowLow
        {
            get { return tagRowLow; }
            set { tagRowLow = value; }
        }

        #endregion Variables

        #region Load

        public FrmTag(ProjectNodeData ProjectNodeData)
        {
            boolParent = false;

            MTNodeData = ProjectNodeData;

            DeviceID = MTNodeData.tag.DeviceID;
            DeviceGroupTagID = MTNodeData.tag.DeviceGroupTagID;
            DeviceTagID = MTNodeData.tag.DeviceTagID;
            DeviceTagCommandID = MTNodeData.tag.DeviceTagCommandID;
            DeviceTagKeyImage = MTNodeData.tag.KeyImage;

            DeviceTagname = MTNodeData.tag.DeviceTagName;
            DeviceTagCode = MTNodeData.tag.DeviceTagCode;
            DeviceTagAddress = MTNodeData.tag.DeviceTagAddress;
            DeviceTagDescription = MTNodeData.tag.DeviceTagDescription;
            DeviceTagEnabled = MTNodeData.tag.DeviceTagEnabled;
            DeviceTagType = MTNodeData.tag.DeviceTagType;
            DeviceTagSorting = MTNodeData.tag.DeviceTagSorting;

            DeviceTagDataValue = MTNodeData.tag.DeviceTagDataValue;
            DeviceTagQuality = MTNodeData.tag.DeviceTagQuality;
            DeviceTagCoefficient = MTNodeData.tag.DeviceTagCoefficient;
            DeviceTagScaled = MTNodeData.tag.DeviceTagScaled;
            DeviceTagScaledHigh = MTNodeData.tag.DeviceTagScaledHigh;
            DeviceTagScaledLow = MTNodeData.tag.DeviceTagScaledLow;
            DeviceTagRowHigh = MTNodeData.tag.DeviceTagRowHigh;
            DeviceTagRowLow = MTNodeData.tag.DeviceTagRowLow;

            InitializeComponent();

            FormatWindow(true);
        }

        public FrmTag(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            boolParent = true;

            MTNodeData = ProjectNodeData;

            DeviceID = MTNodeData.tag.DeviceID;
            DeviceGroupTagID = MTNodeData.tag.DeviceGroupTagID;
            DeviceTagID = MTNodeData.tag.DeviceTagID;
            DeviceTagCommandID = MTNodeData.tag.DeviceTagCommandID;
            DeviceTagKeyImage = MTNodeData.tag.KeyImage;

            DeviceTagname = MTNodeData.tag.DeviceTagName;
            DeviceTagCode = MTNodeData.tag.DeviceTagCode;
            DeviceTagAddress = MTNodeData.tag.DeviceTagAddress;
            DeviceTagDescription = MTNodeData.tag.DeviceTagDescription;
            DeviceTagEnabled = MTNodeData.tag.DeviceTagEnabled;
            DeviceTagType = MTNodeData.tag.DeviceTagType;
            DeviceTagSorting = MTNodeData.tag.DeviceTagSorting;

            DeviceTagDataValue = MTNodeData.tag.DeviceTagDataValue;
            DeviceTagQuality = MTNodeData.tag.DeviceTagQuality;
            DeviceTagCoefficient = MTNodeData.tag.DeviceTagCoefficient;
            DeviceTagScaled = MTNodeData.tag.DeviceTagScaled;
            DeviceTagScaledHigh = MTNodeData.tag.DeviceTagScaledHigh;
            DeviceTagScaledLow = MTNodeData.tag.DeviceTagScaledLow;
            DeviceTagRowHigh = MTNodeData.tag.DeviceTagRowHigh;
            DeviceTagRowLow = MTNodeData.tag.DeviceTagRowLow;

            InitializeComponent();

            FormatWindow(hasParent);
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;
                TopLevel = false;
            }
        }

        private void FrmTag_Load(object sender, EventArgs e)
        {
            ConfigToControls();
        }

        List<ProjectCommand> projectCommands = new List<ProjectCommand>();

        private void ConfigToControls()
        {
            txtTagID.Text = DeviceTagID.ToString();
            ckbTagEnabled.Checked = DeviceTagEnabled;
            txtTagname.Text = DeviceTagname;
            txtTagCode.Text = DeviceTagCode;
            txtTagDescription.Text = DeviceTagDescription;
            txtTagAddress.Text = DeviceTagAddress;
            txtTagCoefficient.Text = DeviceTagCoefficient.ToString();

            txtTagSorting.Text = DeviceTagSorting;

            //Commands
            try
            {
                #region Filling
                DataTable DataTableDeviceID = new DataTable();
                DataTableDeviceID.Columns.Add("ID", typeof(Guid));
                DataTableDeviceID.Columns.Add("CommandName", typeof(string));
                DataTableDeviceID.Rows.Add(null, "[" + DriverDictonary.EmptyWord + "]");

                FindCommandsNodes(frmParentGloabal.trvProject.Nodes);

                foreach (ProjectCommand findCommand in projectCommands)
                {

                    //if (findCommand.DeviceID == DeviceID)
                    //{
                    //    DataTableDeviceID.Rows.Add(findCommand.CommandID, findCommand.CommandName);
                    //}
                }

                cmbTagCommand.DataSource = DataTableDeviceID;
                cmbTagCommand.DisplayMember = "CommandName";
                cmbTagCommand.ValueMember = "ID";

                #endregion Filling

                #region Finding a value
                int indexFoundValue = 0;
                for (int i = 0; i < cmbTagCommand.Items.Count; i++)
                {
                    cmbTagCommand.SelectedIndex = i;
                    try
                    {
                        DataRowView dataRow = ((System.Data.DataRowView)cmbTagCommand.SelectedItem);
                        if (dataRow.Row[0].ToString() == DeviceTagCommandID.ToString())
                        {
                            indexFoundValue = i;
                        }
                    }
                    catch { }
                }
                cmbTagCommand.SelectedIndex = indexFoundValue;
                #endregion Finding a value
            }
            catch { }

            try
            {
                cmbTagType.Items.Clear();
                cmbTagType.Items.AddRange(Enum.GetNames(typeof(ProjectTag.DeviceTagFormatData)));
                if (DeviceTagType != null)
                {
                    cmbTagType.SelectedIndex = cmbTagType.FindString(DeviceTagType.ToString());
                }
            }
            catch { }

            cmbScaled.SelectedIndex = DeviceTagScaled;
            txtLineScaledHigh.Text = DeviceTagScaledHigh.ToString();
            txtLineScaledLow.Text = DeviceTagScaledLow.ToString();
            txtLineScaledRowHigh.Text = DeviceTagRowHigh.ToString();
            txtLineScaledRowLow.Text = DeviceTagRowLow.ToString();
        }

        private void FindCommandsNodes(TreeNodeCollection nodesCollection)
        {
            for (int i = 0; i < nodesCollection.Count; i++)
            {
                TreeNode node = nodesCollection[i];
                ProjectNodeData prNodeData = (ProjectNodeData)node.Tag;

                if (node.Tag != null)
                {
                    #region Device Command

                    if (prNodeData.nodeType == ProjectNodeType.Command)
                    {
                        projectCommands.Add((ProjectCommand)prNodeData.command);
                    }

                    #endregion Device Command
                }

                // add other node properties to serialize here  
                if (node.Nodes.Count > 0)
                {
                    FindCommandsNodes(node.Nodes);
                }
            }
        }

        #endregion Load

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ControlsToConfig();

            if (DeviceTagname == "")
            {
                MessageBox.Show(DriverDictonary.WarningEmpty);
                return;
            }

            if (boolParent == true)
            {
                MTNodeData.tag.DeviceID = DeviceID;
                MTNodeData.tag.DeviceGroupTagID = DeviceGroupTagID;
                MTNodeData.tag.DeviceTagID = DeviceTagID;
                MTNodeData.tag.DeviceTagCommandID = DeviceTagCommandID;

                MTNodeData.tag.DeviceTagName = DeviceTagname;
                MTNodeData.tag.DeviceTagCode = DeviceTagCode;
                MTNodeData.tag.DeviceTagCode = DeviceTagCode;
                MTNodeData.tag.DeviceTagAddress = DeviceTagAddress;
                MTNodeData.tag.DeviceTagDescription = DeviceTagDescription;
                MTNodeData.tag.DeviceTagEnabled = DeviceTagEnabled;
                MTNodeData.tag.DeviceTagType = DeviceTagType;
                MTNodeData.tag.DeviceTagSorting = DeviceTagSorting;

                MTNodeData.tag.DeviceTagCoefficient = DeviceTagCoefficient;
                MTNodeData.tag.DeviceTagScaled = DeviceTagScaled;
                MTNodeData.tag.DeviceTagScaledHigh = DeviceTagScaledHigh;
                MTNodeData.tag.DeviceTagScaledLow = DeviceTagScaledLow;
                MTNodeData.tag.DeviceTagRowHigh = DeviceTagRowHigh;
                MTNodeData.tag.DeviceTagRowLow = DeviceTagRowLow;

                MTNodeData.tag.KeyImage = "tag_16.png";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
                TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
                ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;

                projectNodeData.tag.DeviceID = DeviceID;
                projectNodeData.tag.DeviceGroupTagID = DeviceGroupTagID;
                projectNodeData.tag.DeviceTagID = DeviceTagID;
                projectNodeData.tag.DeviceTagCommandID = DeviceTagCommandID;

                projectNodeData.tag.DeviceTagName = DeviceTagname;
                projectNodeData.tag.DeviceTagCode = DeviceTagCode;
                projectNodeData.tag.DeviceTagCode = DeviceTagCode;
                projectNodeData.tag.DeviceTagAddress = DeviceTagAddress;
                projectNodeData.tag.DeviceTagDescription = DeviceTagDescription;
                projectNodeData.tag.DeviceTagEnabled = DeviceTagEnabled;
                projectNodeData.tag.DeviceTagType = DeviceTagType;
                projectNodeData.tag.DeviceTagSorting = DeviceTagSorting;

                projectNodeData.tag.DeviceTagCoefficient = DeviceTagCoefficient;
                projectNodeData.tag.DeviceTagScaled = DeviceTagScaled;
                projectNodeData.tag.DeviceTagScaledHigh = DeviceTagScaledHigh;
                projectNodeData.tag.DeviceTagScaledLow = DeviceTagScaledLow;
                projectNodeData.tag.DeviceTagRowHigh = DeviceTagRowHigh;
                projectNodeData.tag.DeviceTagRowLow = DeviceTagRowLow;

                projectNodeData.tag.KeyImage = stn.ImageKey = stn.SelectedImageKey = "tag_16.png";

                stn.Text = DeviceTagname;
                stn.Tag = projectNodeData;
            }
        }

        private void ControlsToConfig()
        {
            DeviceTagCommandID = DriverUtils.StringToGuid(cmbTagCommand.SelectedValue.ToString());
            DeviceTagAddress = txtTagAddress.Text;
            DeviceTagname = txtTagname.Text;
            DeviceTagCode = txtTagCode.Text;
            DeviceTagDescription = txtTagDescription.Text;
            DeviceTagType = cmbTagType.Text;
            DeviceTagSorting = txtTagSorting.Text;

            DeviceTagCoefficient = Convert.ToSingle(txtTagCoefficient.Text);
            DeviceTagScaled = cmbScaled.SelectedIndex;
            DeviceTagScaledHigh = Convert.ToSingle(txtLineScaledHigh.Text);
            DeviceTagScaledLow = Convert.ToSingle(txtLineScaledLow.Text);
            DeviceTagRowHigh = Convert.ToSingle(txtLineScaledRowHigh.Text);
            DeviceTagRowLow = Convert.ToSingle(txtLineScaledRowLow.Text);
        }
        #endregion Save

        #region Cancel

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion Cancel

        #region Scaled

        private void cmbScaled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbScaled.SelectedIndex == 0)
            {
                gpbLineScaled.Visible = false;
            }
            else if (cmbScaled.SelectedIndex > 0)
            {
                gpbLineScaled.Visible = true;
            }
        }

        private void btnCalcLineScaled_Click(object sender, EventArgs e)
        {
            try
            {
                float ScaledValue = Convert.ToSingle(txtValue.Text);
                float ScaledHigh = Convert.ToSingle(txtLineScaledHigh.Text);
                float ScaledLow = Convert.ToSingle(txtLineScaledLow.Text);
                float RowHigh = Convert.ToSingle(txtLineScaledRowHigh.Text);
                float RowLow = Convert.ToSingle(txtLineScaledRowLow.Text);

                lblLineScaledValue.Text = ScaledValue.ToString();
                lblScaledHighValue.Text = ScaledHigh.ToString();
                lblScaledLowValue.Text = ScaledLow.ToString();
                lblScaledLowValue_2.Text = ScaledLow.ToString();
                lblRowHighValue.Text = RowHigh.ToString();
                lblRowLowValue.Text = RowLow.ToString();
                lblRowLowValue_2.Text = RowLow.ToString();

                float Result = (((ScaledHigh - ScaledLow) / (RowHigh - RowLow)) * (ScaledValue - RowLow)) + ScaledLow;
                lblLineScaledResult.Text = Result.ToString();
            }
            catch { }
        }

        #endregion Scaled

    }
}
