using Scada.Comm.Devices;
using Scada.Comm.Drivers.DrvModbusCM.View;
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

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmTag : Form
    {
        public FrmTag()
        {
            InitializeComponent();
        }

        public FrmTag(ProjectTag tag, bool hasParent = false)
        {
            boolParent = false;
            currentTag = tag;
            InitializeComponent();

            FormatWindow(hasParent);
        }

        public FrmTag(ProjectNodeData ProjectNodeData)
        {
            boolParent = false;

            currentTag = ProjectNodeData.Tag;

            InitializeComponent();

            FormatWindow(true);
        }

        public FrmTag(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            boolParent = true;
            nodeData = ProjectNodeData;
            currentTag = ProjectNodeData.Tag;

            InitializeComponent();

            FormatWindow(hasParent);
        }

        #region Variables

        #region Form

        public FrmConfig frmParentGloabal;        // global general form
        public FrmGroupTag frmParent;             // usercontrol
        public bool boolParent = false;           // сhild startup flag

        public bool modified;                     // the configuration was modified

        #endregion Form

        #region Tag
        public ProjectNodeData nodeData;           // the node data
        public ProjectTag currentTag;              // the current tag

        #endregion Tag

        #endregion Variables

        #region Load

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
            txtTagID.Text = currentTag.ID.ToString();
            ckbTagEnabled.Checked = currentTag.Enabled;
            txtName.Text = currentTag.Name;
            txtTagCode.Text = currentTag.Code;
            txtTagDescription.Text = currentTag.Description;
            txtTagAddress.Text = currentTag.Address;
            txtTagCoefficient.Text = currentTag.Coefficient.ToString();

            txtTagSorting.Text = currentTag.Sorting;

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
                        if (dataRow.Row[0].ToString() == currentTag.CommandID.ToString())
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
                cmbTagType.Items.AddRange(Enum.GetNames(typeof(ProjectTag.FormatData)));
                if (currentTag.Format != null)
                {
                    cmbTagType.SelectedIndex = cmbTagType.FindString(currentTag.Format.ToString());
                }
            }
            catch { }

            cmbScaled.SelectedIndex = currentTag.Scaled;
            txtLineScaledHigh.Text = currentTag.ScaledHigh.ToString();
            txtLineScaledLow.Text = currentTag.ScaledLow.ToString();
            txtLineScaledRowHigh.Text = currentTag.RowHigh.ToString();
            txtLineScaledRowLow.Text = currentTag.RowLow.ToString();
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

                    if (prNodeData.NodeType == ProjectNodeType.Command)
                    {
                        projectCommands.Add((ProjectCommand)prNodeData.Command);
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

            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show(DriverDictonary.WarningEmpty);
                return;
            }

            if (boolParent == true)
            {
                //nodeData.Tag.DeviceID = DeviceID;
                //nodeData.Tag.DeviceGroupTagID = DeviceGroupTagID;
                nodeData.Tag.ID = currentTag.ID;
                nodeData.Tag.CommandID = currentTag.CommandID;

                nodeData.Tag.Name = currentTag.Name;
                nodeData.Tag.Code = currentTag.Code;
                nodeData.Tag.Address = currentTag.Address;
                nodeData.Tag.Description = currentTag.Description;
                nodeData.Tag.Enabled = currentTag.Enabled;
                nodeData.Tag.Format = currentTag.Format;
                nodeData.Tag.Sorting = currentTag.Sorting;

                nodeData.Tag.Coefficient = currentTag.Coefficient;
                nodeData.Tag.Scaled = currentTag.Scaled;
                nodeData.Tag.ScaledHigh = currentTag.ScaledHigh;
                nodeData.Tag.ScaledLow = currentTag.ScaledLow;
                nodeData.Tag.RowHigh = currentTag.RowHigh;
                nodeData.Tag.RowLow = currentTag.RowLow;

                nodeData.Tag.KeyImage = "tag_16.png";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void ControlsToConfig()
        {
            currentTag.CommandID = DriverUtils.StringToGuid(cmbTagCommand.SelectedValue.ToString());
            currentTag.Address = txtTagAddress.Text;
            currentTag.Name = txtName.Text;
            currentTag.Code = txtTagCode.Text;
            currentTag.Description = txtTagDescription.Text;
            currentTag.Format = (ProjectTag.FormatData)Enum.Parse(typeof(ProjectTag.FormatData), cmbTagType.Text);
            currentTag.Sorting = txtTagSorting.Text;

            currentTag.Coefficient = Convert.ToSingle(txtTagCoefficient.Text);
            currentTag.Scaled = cmbScaled.SelectedIndex;
            currentTag.ScaledHigh = Convert.ToSingle(txtLineScaledHigh.Text);
            currentTag.ScaledLow = Convert.ToSingle(txtLineScaledLow.Text);
            currentTag.RowHigh = Convert.ToSingle(txtLineScaledRowHigh.Text);
            currentTag.RowLow = Convert.ToSingle(txtLineScaledRowLow.Text);
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
