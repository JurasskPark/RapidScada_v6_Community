using BrightIdeasSoftware;
using Microsoft.Win32;
using Scada.Comm.Drivers.DrvModbusCM;
using Scada.Comm.Drivers.DrvModbusCM.View;
using Scada.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmCommand5_6_15_16 : Form
    {
        public FrmCommand5_6_15_16()
        {
            InitializeComponent();
        }

        #region Variables

        #region Form

        public FrmConfig frmParentGloabal;              // global general form
        public bool boolParent = false;                 // сhild startup flag
        public bool modified;                           // the configuration was modified

        #endregion Form

        #region Command

        ProjectCommand currentCommand = new ProjectCommand();

        Decimal RegisterCountOldValue = new Decimal(0);

        #endregion Command

        #endregion Variables

        #region Load

        public FrmCommand5_6_15_16(ulong function = 0, bool hasParent = true)
        {
            currentCommand = new ProjectCommand();
            currentCommand.FunctionCode = function;
            InitializeComponent();
            FormatWindow(hasParent);
        }

        public FrmCommand5_6_15_16(ProjectNodeData ProjectNodeData)
        {
            currentCommand = ProjectNodeData.Command;
            InitializeComponent();
            FormatWindow(true);
        }

        public FrmCommand5_6_15_16(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            currentCommand = ProjectNodeData.Command;
            InitializeComponent();
            FormatWindow(hasParent);
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                btnSave.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;
                TopLevel = false;
            }
        }


        private void FrmCommand_Load(object sender, EventArgs e)
        {
            ConfigToControls();
            this.ActiveControl = txtName;
        }


        private void ConfigToControls()
        {
            txtName.Text = currentCommand.Name;
            ckbEnabled.Checked = currentCommand.Enabled;
            txtCode.Text = currentCommand.Code;

            nudRegisterStartAddress.Value = currentCommand.RegisterStartAddress;

            //Костыль, т.к. сначала по умолчанию принимаем, что есть т.е. с 0
            nudRegisterCount.Minimum = 0;
            nudRegisterCount.Value = currentCommand.RegisterCount;
            //А вот потом говорим, что так делать нельзя :)
            nudRegisterCount.Minimum = 1; 

            //Сначала подставляем значения, а потом делаем поиск по index 
            try
            {
                cmbFunctionCode.SelectedIndex = cmbFunctionCode.FindString("(" + currentCommand.FunctionCode.ToString().PadLeft(2, '0') + ")");
            }
            catch 
            { 
                cmbFunctionCode.SelectedIndex = 0;
            }

            txtRegistersWriteData.Text = HEX_STRING.BYTEARRAY_TO_HEXSTRING(currentCommand.RegisterWriteData);

            this.olvRegistersWrite.ClearObjects();
            if (currentCommand.ListRegistersWriteData != null && currentCommand.ListRegistersWriteData.Count > 0)
            {
                this.olvRegistersWrite.AddObjects(currentCommand.ListRegistersWriteData);
                this.olvRegistersWrite.AutoResizeColumns();
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

            if (txtName.Text == "")
            {
                MessageBox.Show(DriverDictonary.WarningEmpty);
                return;
            }

            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
            frmParentGloabal.trvProject.LabelEdit = true;
            frmParentGloabal.trvProject.SelectedNode.BeginEdit();
            TreeNode stn = frmParentGloabal.trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            projectNodeData.Command = currentCommand;
            stn.Tag = projectNodeData;
            stn.Text = currentCommand.Name;

            string imageKey = stn.ImageKey;
            int imageIndex = stn.ImageIndex;

            imageKey = ProjectCommand.KeyImageName(currentCommand.FunctionCode, currentCommand.Enabled);

            currentCommand.KeyImage = imageKey;
            stn.ImageKey = imageKey;
            stn.SelectedImageKey = imageKey;

            frmParentGloabal.trvProject.SelectedNode.EndEdit(true);
            frmParentGloabal.trvProject.LabelEdit = false;

            Modified = false;
 
        }

        //Сохранение данных
        private void ControlsToConfig()
        {
            currentCommand.Name = txtName.Text;
            currentCommand.Enabled = ckbEnabled.Checked;
            //Код функции
            try
            {
                string permennaya = cmbFunctionCode.Items[cmbFunctionCode.SelectedIndex].ToString().Trim();
                //Ищем последовательность в цифрах
                Regex regex = new Regex(@"([A-Fa-f0-9][A-Fa-f0-9])");
                Match match = regex.Match(permennaya);
                if (match.Success)
                {
                    //Получили match.Value со значением
                    currentCommand.FunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }
            currentCommand.RegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
        }

        #endregion Save

        #region Form
        /// <summary>
        /// Gets or sets a value indicating whether the configuration was modified.
        /// </summary>
        private bool Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                btnSave.Enabled = modified;
            }
        }

        /// <summary>
        /// Indication of a component change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_Changed(object sender, EventArgs e)
        {
            Modified = true;
        }
        #endregion Form

        #region Изменение Функции
        private void cmbFunctionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Код функции
            try
            {
                string permennaya = cmbFunctionCode.Items[cmbFunctionCode.SelectedIndex].ToString().Trim();
                //Ищем последовательность в цифрах
                Regex regex = new Regex(@"([A-Fa-f0-9][A-Fa-f0-9])");
                Match match = regex.Match(permennaya);
                if (match.Success)
                {
                    //Получили match.Value со значением
                     currentCommand.FunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }

 
            //Генерация имени
            GenerateName();
        }
        #endregion Изменение Функции

        #region Изменение Начального адреса регистра

        private void nudRegisterStartAddress_ValueChanged(object sender, EventArgs e)
        {
            currentCommand.RegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt64(nudRegisterCount.Value);
            GenerateName();
        }

        #endregion Изменение Начального адреса регистра

        #region Изменение количества регистров
        private void nudRegisterCount_ValueChanged(object sender, EventArgs e)
        {
            // Получаем текущее значение
            decimal newValue = nudRegisterCount.Value;

            // Сравниваем значения
            if (RegisterCountOldValue > newValue)
            {
                // Значение уменьшилось (нажата стрелка вниз)
                // MessageBox.Show("Значение уменьшилось");
                RegistersWriteDataDelete();
            }
            else if (RegisterCountOldValue < newValue)
            {
                // Значение увеличилось (нажата стрелка вверх)
                // MessageBox.Show("Значение увеличилось");
                RegistersWriteDataAdd();
            }

            // Сохраняем текущее значение для следующей проверки
            RegisterCountOldValue = newValue;

            currentCommand.RegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt64(nudRegisterCount.Value);
            GenerateName();
        }
        #endregion Изменение количества регистров

        #region Генерация имени команды
        private void GenerateName()
        {
            txtName.Text = currentCommand.GenerateName();
        }

        #endregion Генерация имени команды

        private void GenerateRegistersWriteData()
        {

        }

        private void RegistersWriteDataAdd()
        {
            if (this.currentCommand.ListRegistersWriteData != null)
            {
                ProjectRegisterWriteData register = new ProjectRegisterWriteData();
                this.currentCommand.ListRegistersWriteData.Add(register);
            }

            olvRegistersWrite.Objects = this.currentCommand.ListRegistersWriteData;
            olvRegistersWrite.AutoResizeColumns();
            olvRegistersWrite.BuildList();
        }

        private void RegistersWriteDataDelete()
        {
            if (this.currentCommand.ListRegistersWriteData != null && this.currentCommand.ListRegistersWriteData.Count() > 0)
            {
                this.currentCommand.ListRegistersWriteData.RemoveAt(this.currentCommand.ListRegistersWriteData.Count() - 1);
            }

            olvRegistersWrite.Objects = this.currentCommand.ListRegistersWriteData;
        }
    }

}
