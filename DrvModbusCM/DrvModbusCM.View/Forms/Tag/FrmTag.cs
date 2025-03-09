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

        #region Variables

        #region Form

        public FrmConfig frmParentGloabal;        // global general form
        public FrmGroupTag frmParent;             // usercontrol
        public bool boolParent = false;           // сhild startup flag

        public bool modified;                     // the configuration was modified

        #endregion Form

        #region Tag

        ProjectTag currentTag;

        #endregion Tag

        #endregion Variables

        #region Load

        public FrmTag(ProjectNodeData ProjectNodeData)
        {
            boolParent = false;

            currentTag = ProjectNodeData.tag;
          
            InitializeComponent();

            FormatWindow(true);
        }

        public FrmTag(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            boolParent = true;

            currentTag = ProjectNodeData.tag;

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
            txtTagID.Text = currentTag.ID.ToString();
            ckbTagEnabled.Checked = currentTag.Enabled;
            txtTagname.Text = currentTag.Name;
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
                if (currentTag.TagType != null)
                {
                    cmbTagType.SelectedIndex = cmbTagType.FindString(currentTag.TagType.ToString());
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
            //ControlsToConfig();

            //if (txtName == "")
            //{
            //    MessageBox.Show(DriverDictonary.WarningEmpty);
            //    return;
            //}

            //if (boolParent == true)
            //{
            //    MTNodeData.tag.DeviceID = DeviceID;
            //    MTNodeData.tag.DeviceGroupTagID = DeviceGroupTagID;
            //    MTNodeData.tag.currentTag.ID = currentTag.ID;
            //    MTNodeData.tag.currentTag.CommandID = currentTag.CommandID;

            //    MTNodeData.tag.currentTag.Name = currentTag.name;
            //    MTNodeData.tag.currentTag.Code = currentTag.Code;
            //    MTNodeData.tag.currentTag.Code = currentTag.Code;
            //    MTNodeData.tag.currentTag.Address = currentTag.Address;
            //    MTNodeData.tag.currentTag.Description = currentTag.Description;
            //    MTNodeData.tag.currentTag.Enabled = currentTag.Enabled;
            //    MTNodeData.tag.currentTag.Type = currentTag.Type;
            //    MTNodeData.tag.currentTag.Sorting = currentTag.Sorting;

            //    MTNodeData.tag.currentTag.Coefficient = currentTag.Coefficient;
            //    MTNodeData.tag.currentTag.Scaled = currentTag.Scaled;
            //    MTNodeData.tag.currentTag.ScaledHigh = currentTag.ScaledHigh;
            //    MTNodeData.tag.currentTag.ScaledLow = currentTag.ScaledLow;
            //    MTNodeData.tag.currentTag.RowHigh = currentTag.RowHigh;
            //    MTNodeData.tag.currentTag.RowLow = currentTag.RowLow;

            //    MTNodeData.tag.KeyImage = "tag_16.png";

            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //else
            //{
            //    //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
            //    TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            //    ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;

            //    projectNodeData.tag.DeviceID = DeviceID;
            //    projectNodeData.tag.DeviceGroupTagID = DeviceGroupTagID;
            //    projectNodeData.tag.currentTag.ID = currentTag.ID;
            //    projectNodeData.tag.currentTag.CommandID = currentTag.CommandID;

            //    projectNodeData.tag.currentTag.Name = currentTag.name;
            //    projectNodeData.tag.currentTag.Code = currentTag.Code;
            //    projectNodeData.tag.currentTag.Code = currentTag.Code;
            //    projectNodeData.tag.currentTag.Address = currentTag.Address;
            //    projectNodeData.tag.currentTag.Description = currentTag.Description;
            //    projectNodeData.tag.currentTag.Enabled = currentTag.Enabled;
            //    projectNodeData.tag.currentTag.Type = currentTag.Type;
            //    projectNodeData.tag.currentTag.Sorting = currentTag.Sorting;

            //    projectNodeData.tag.currentTag.Coefficient = currentTag.Coefficient;
            //    projectNodeData.tag.currentTag.Scaled = currentTag.Scaled;
            //    projectNodeData.tag.currentTag.ScaledHigh = currentTag.ScaledHigh;
            //    projectNodeData.tag.currentTag.ScaledLow = currentTag.ScaledLow;
            //    projectNodeData.tag.currentTag.RowHigh = currentTag.RowHigh;
            //    projectNodeData.tag.currentTag.RowLow = currentTag.RowLow;

            //    projectNodeData.tag.KeyImage = stn.ImageKey = stn.SelectedImageKey = "tag_16.png";

            //    stn.Text = currentTag.name;
            //    stn.Tag = projectNodeData;
            //}
        }

        private void ControlsToConfig()
        {
            //currentTag.CommandID = DriverUtils.StringToGuid(cmbTagCommand.SelectedValue.ToString());
            //currentTag.Address = txtTagAddress.Text;
            //currentTag.name = txtTagname.Text;
            //currentTag.Code = txtTagCode.Text;
            //currentTag.Description = txtTagDescription.Text;
            //currentTag.Type = cmbTagType.Text;
            //currentTag.Sorting = txtTagSorting.Text;

            //currentTag.Coefficient = Convert.ToSingle(txtTagCoefficient.Text);
            //currentTag.Scaled = cmbScaled.SelectedIndex;
            //currentTag.ScaledHigh = Convert.ToSingle(txtLineScaledHigh.Text);
            //currentTag.ScaledLow = Convert.ToSingle(txtLineScaledLow.Text);
            //currentTag.RowHigh = Convert.ToSingle(txtLineScaledRowHigh.Text);
            //currentTag.RowLow = Convert.ToSingle(txtLineScaledRowLow.Text);
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
