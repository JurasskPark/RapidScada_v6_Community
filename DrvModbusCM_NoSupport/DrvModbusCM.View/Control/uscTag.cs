using Scada.Comm.Drivers.DrvModbusCM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscTag : UserControl
    {
        public uscTag()
        {
            InitializeComponent();
        }

        #region Variables

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
        private Guid deviceGroupTagID;
        public Guid DeviceGroupTagID
        {
            get { return deviceGroupTagID; }
            set { deviceGroupTagID = value; }
        }

        private Guid deviceTagID;
        public Guid DeviceTagID
        {
            get { return deviceTagID; }
            set { deviceTagID = value; }
        }

        //Иконка устройства
        private string deviceTagKeyImage;
        public string DeviceTagKeyImage
        {
            get { return deviceTagKeyImage; }
            set { deviceTagKeyImage = value; }
        }

        private string deviceTagAddress;
        public string DeviceTagAddress
        {
            get { return deviceTagAddress; }
            set { deviceTagAddress = value; }
        }

        private string deviceTagname;
        public string DeviceTagname
        {
            get { return deviceTagname; }
            set { deviceTagname = value; }
        }

        private string deviceTagCode;
        public string DeviceTagCode
        {
            get { return deviceTagCode; }
            set { deviceTagCode = value; }
        }

        private string deviceTagDescription;
        public string DeviceTagDescription
        {
            set { deviceTagDescription = value; }
            get { return deviceTagDescription; }
        }

        private object deviceTagType;
        public object DeviceTagType
        {
            set { deviceTagType = value; }
            get { return deviceTagType; }
        }

        private bool deviceTagEnabled;
        public bool DeviceTagEnabled
        {
            set { deviceTagEnabled = value; }
            get { return deviceTagEnabled; }
        }

        private string deviceTagSorting;
        public string DeviceTagSorting
        {
            set { deviceTagSorting = value; }
            get { return deviceTagSorting; }
        }

        private object deviceTagDataValue;
        public object DeviceTagDataValue
        {
            set { deviceTagDataValue = value; }
            get { return deviceTagDataValue; }
        }

        private DateTime deviceTagDateTime;
        public DateTime DeviceTagDateTime
        {
            set { deviceTagDateTime = value; }
            get { return deviceTagDateTime; }
        }

        private ushort deviceTagQuality;
        public ushort DeviceTagQuality
        {
            set { deviceTagQuality = value; }
            get { return deviceTagQuality; }
        }

        private float deviceTagCoefficient;
        public float DeviceTagCoefficient
        {
            get { return deviceTagCoefficient; }
            set { deviceTagCoefficient = value; }
        }

        private int deviceTagScaled;
        public int DeviceTagScaled
        {
            set { deviceTagScaled = value; }
            get { return deviceTagScaled; }
        }

        private float deviceTagScaledHigh;
        public float DeviceTagScaledHigh
        {
            get { return deviceTagScaledHigh; }
            set { deviceTagScaledHigh = value; }
        }

        private float deviceTagScaledLow;
        public float DeviceTagScaledLow
        {
            get { return deviceTagScaledLow; }
            set { deviceTagScaledLow = value; }
        }

        private float deviceTagRowHigh;
        public float DeviceTagRowHigh
        {
            get { return deviceTagRowHigh; }
            set { deviceTagRowHigh = value; }
        }

        private float deviceTagRowLow;
        public float DeviceTagRowLow
        {
            get { return deviceTagRowLow; }
            set { deviceTagRowLow = value; }
        }

        #endregion Variables

        #region Load

        public uscTag(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            DeviceID = MTNodeData.deviceTag.DeviceID;
            DeviceGroupTagID = MTNodeData.deviceTag.DeviceGroupTagID;
            DeviceTagID = MTNodeData.deviceTag.DeviceTagID;
            DeviceTagKeyImage = MTNodeData.deviceTag.DeviceTagKeyImage;

            DeviceTagname = MTNodeData.deviceTag.DeviceTagname;
            DeviceTagCode = MTNodeData.deviceTag.DeviceTagCode;
            DeviceTagAddress = MTNodeData.deviceTag.DeviceTagAddress;
            DeviceTagDescription = MTNodeData.deviceTag.DeviceTagDescription;
            DeviceTagEnabled = MTNodeData.deviceTag.DeviceTagEnabled;
            DeviceTagType = MTNodeData.deviceTag.DeviceTagType;
            DeviceTagSorting = MTNodeData.deviceTag.DeviceTagSorting;

            DeviceTagDataValue = MTNodeData.deviceTag.DeviceTagDataValue;
            DeviceTagQuality = MTNodeData.deviceTag.DeviceTagQuality;
            DeviceTagCoefficient = MTNodeData.deviceTag.DeviceTagCoefficient;
            DeviceTagScaled = MTNodeData.deviceTag.DeviceTagScaled;
            DeviceTagScaledHigh = MTNodeData.deviceTag.DeviceTagScaledHigh;
            DeviceTagScaledLow = MTNodeData.deviceTag.DeviceTagScaledLow;
            DeviceTagRowHigh = MTNodeData.deviceTag.DeviceTagRowHigh;
            DeviceTagRowLow = MTNodeData.deviceTag.DeviceTagRowLow;

            InitializeComponent();
            FormatWindow(true);
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.BorderStyle = BorderStyle.None;
                btnTagSave.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;
            }
        }

        private void uscTag_Load(object sender, EventArgs e)
        {
            ConfigToControls();
        }

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

            try
            {
                cmbTagType.Items.Clear();
                cmbTagType.Items.AddRange(Enum.GetNames(typeof(ProjectDeviceTag.DeviceTagFormatData)));
                cmbTagType.SelectedIndex = cmbTagType.FindString(DeviceTagType.ToString());
            }
            catch { }

            cmbScaled.SelectedIndex = DeviceTagScaled;
            txtLineScaledHigh.Text = DeviceTagScaledHigh.ToString();
            txtLineScaledLow.Text = DeviceTagScaledLow.ToString();
            txtLineScaledRowHigh.Text = DeviceTagRowHigh.ToString();
            txtLineScaledRowLow.Text = DeviceTagRowLow.ToString();
        }

        #endregion Load

        #region Save
        private void btnTagSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ControlsToConfig();

            if (DeviceTagname == "")
            {
                MessageBox.Show("Поле Наименование не может быть пустым");
                return;
            }

            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
            TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;

            projectNodeData.deviceTag.DeviceID = DeviceID;
            projectNodeData.deviceTag.DeviceGroupTagID = DeviceGroupTagID;
            projectNodeData.deviceTag.DeviceTagID = DeviceTagID;
            projectNodeData.deviceTag.DeviceTagname = DeviceTagname;
            projectNodeData.deviceTag.DeviceTagCode = DeviceTagCode;
            projectNodeData.deviceTag.DeviceTagCode = DeviceTagCode;
            projectNodeData.deviceTag.DeviceTagAddress = DeviceTagAddress;
            projectNodeData.deviceTag.DeviceTagDescription = DeviceTagDescription;
            projectNodeData.deviceTag.DeviceTagEnabled = DeviceTagEnabled;
            projectNodeData.deviceTag.DeviceTagType = DeviceTagType;
            projectNodeData.deviceTag.DeviceTagSorting = DeviceTagSorting;

            projectNodeData.deviceTag.DeviceTagCoefficient = DeviceTagCoefficient;
            projectNodeData.deviceTag.DeviceTagScaled = DeviceTagScaled;
            projectNodeData.deviceTag.DeviceTagScaledHigh = DeviceTagScaledHigh;
            projectNodeData.deviceTag.DeviceTagScaledLow = DeviceTagScaledLow;
            projectNodeData.deviceTag.DeviceTagRowHigh = DeviceTagRowHigh;
            projectNodeData.deviceTag.DeviceTagRowLow = DeviceTagRowLow;

            projectNodeData.deviceTag.DeviceTagKeyImage = stn.ImageKey = stn.SelectedImageKey = "tag_16.png";

            stn.Text = DeviceTagname;
            stn.Tag = projectNodeData;
        }

        private void ControlsToConfig()
        {
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

        private void btn_CalcLineScaled_Click(object sender, EventArgs e)
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
