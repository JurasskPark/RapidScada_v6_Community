namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscTag : UserControl
    {
        public uscTag()
        {
            InitializeComponent();
        }

        #region Variables

        #region Form

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

        public uscTag(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            DeviceID = MTNodeData.Tag.DeviceID;
            DeviceGroupTagID = MTNodeData.Tag.DeviceGroupTagID;
            DeviceTagID = MTNodeData.Tag.DeviceTagID;
            DeviceTagKeyImage = MTNodeData.Tag.KeyImage;

            DeviceTagname = MTNodeData.Tag.DeviceTagName;
            DeviceTagCode = MTNodeData.Tag.DeviceTagCode;
            DeviceTagAddress = MTNodeData.Tag.DeviceTagAddress;
            DeviceTagDescription = MTNodeData.Tag.DeviceTagDescription;
            DeviceTagEnabled = MTNodeData.Tag.DeviceTagEnabled;
            DeviceTagType = MTNodeData.Tag.DeviceTagType;
            DeviceTagSorting = MTNodeData.Tag.DeviceTagSorting;

            DeviceTagDataValue = MTNodeData.Tag.DeviceTagDataValue;
            DeviceTagQuality = MTNodeData.Tag.DeviceTagQuality;
            DeviceTagCoefficient = MTNodeData.Tag.DeviceTagCoefficient;
            DeviceTagScaled = MTNodeData.Tag.DeviceTagScaled;
            DeviceTagScaledHigh = MTNodeData.Tag.DeviceTagScaledHigh;
            DeviceTagScaledLow = MTNodeData.Tag.DeviceTagScaledLow;
            DeviceTagRowHigh = MTNodeData.Tag.DeviceTagRowHigh;
            DeviceTagRowLow = MTNodeData.Tag.DeviceTagRowLow;

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
                cmbTagType.Items.AddRange(Enum.GetNames(typeof(ProjectTag.DeviceTagFormatData)));
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

            projectNodeData.Tag.DeviceID = DeviceID;
            projectNodeData.Tag.DeviceGroupTagID = DeviceGroupTagID;
            projectNodeData.Tag.DeviceTagID = DeviceTagID;
            projectNodeData.Tag.DeviceTagName = DeviceTagname;
            projectNodeData.Tag.DeviceTagCode = DeviceTagCode;
            projectNodeData.Tag.DeviceTagCode = DeviceTagCode;
            projectNodeData.Tag.DeviceTagAddress = DeviceTagAddress;
            projectNodeData.Tag.DeviceTagDescription = DeviceTagDescription;
            projectNodeData.Tag.DeviceTagEnabled = DeviceTagEnabled;
            projectNodeData.Tag.DeviceTagType = DeviceTagType;
            projectNodeData.Tag.DeviceTagSorting = DeviceTagSorting;

            projectNodeData.Tag.DeviceTagCoefficient = DeviceTagCoefficient;
            projectNodeData.Tag.DeviceTagScaled = DeviceTagScaled;
            projectNodeData.Tag.DeviceTagScaledHigh = DeviceTagScaledHigh;
            projectNodeData.Tag.DeviceTagScaledLow = DeviceTagScaledLow;
            projectNodeData.Tag.DeviceTagRowHigh = DeviceTagRowHigh;
            projectNodeData.Tag.DeviceTagRowLow = DeviceTagRowLow;

            projectNodeData.Tag.KeyImage = stn.ImageKey = stn.SelectedImageKey = "tag_16.png";

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
