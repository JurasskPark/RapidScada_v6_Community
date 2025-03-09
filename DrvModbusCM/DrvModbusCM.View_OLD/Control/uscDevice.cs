using Scada.Comm.Drivers.DrvIEC61107.View;
using System.Reflection;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscDevice : UserControl
    {
        public uscDevice()
        {
            InitializeComponent();
        }

        #region Variables

        #region Form

        public FrmConfigForm frmParentGloabal;          // global general form
        public bool boolParent = false;                 // сhild startup flag
        public bool modified;                           // the configuration was modified

        #endregion Form

        #region Device

        ProjectDevice currentDevice;

        #endregion Device

        #region InputBox
        public ushort value = 0;
        #endregion InputBox

        #region Register

        private ushort register_start;
        private ushort register_count;

        #endregion Register

        #endregion Variables

        #region Load

        public uscDevice(ProjectNodeData ProjectNodeData)
        {
            currentDevice = ProjectNodeData.device;

            InitializeComponent();
            FormatWindow(true);

        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.BorderStyle = BorderStyle.None;
                btnSave.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;
            }
        }

        private void uscDevice_Load(object sender, EventArgs e)
        {
            // set the control values
            ConfigToControls();

            // enable timer
            ckbAutoRefreshListRegisters.Checked = true;
        }

        private void ConfigToControls()
        {
            txtDeviceID.Text = currentDevice.ID.ToString();
            numAddress.Value = currentDevice.Address;
            txtName.Text = currentDevice.Name;
            txtDescription.Text = currentDevice.Description;
            ckbEnabled.Checked = currentDevice.Enabled;

            nudDeviceRegistersBytes.Value = Convert.ToDecimal(currentDevice.DeviceRegistersBytes);
            nudDeviceGatewayRegistersBytes.Value = Convert.ToDecimal(currentDevice.DeviceGatewayRegistersBytes);

            cmbStatus.SelectedIndex = currentDevice.Status;
            ckbPollingOnScheduleStatus.Checked = currentDevice.PollingOnScheduleStatus;

            numIntervalPool.Value = currentDevice.IntervalPool;
            cmbTypeProtocol.SelectedIndex = currentDevice.TypeProtocol;

            txtDateTimeLastSuccessfully.Text = currentDevice.DateTimeLastSuccessfully.ToString();

            GetBuffer();
            //PollingOnScheduleStatusChecked();

            Modified = false;
        }

        #endregion Load

        #region Save

        private void btnDeviceSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            ControlsToConfig();

            if (Name == "")
            {
                MessageBox.Show(DriverDictonary.WarningEmpty);
                return;
            }

            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
            frmParentGloabal.trvProject.LabelEdit = true;
            frmParentGloabal.trvProject.SelectedNode.BeginEdit();
            TreeNode stn = frmParentGloabal.trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            projectNodeData.device = currentDevice;
            stn.Tag = projectNodeData;
            stn.Text = projectNodeData.device.Name;

            string imageKey = stn.ImageKey;
            int imageIndex = stn.ImageIndex;

            switch (currentDevice.Enabled)
            {
                case true:
                    imageKey = ListImages.ImageKey.Device;
                    break;
                case false:
                    imageKey = ListImages.ImageKey.DeviceOff;
                    break;
                default:
                    imageKey = ListImages.ImageKey.Device;
                    break;
            }

            currentDevice.KeyImage = imageKey;
            stn.ImageKey = imageKey;
            stn.SelectedImageKey = imageKey;

            frmParentGloabal.trvProject.SelectedNode.EndEdit(true);
            frmParentGloabal.trvProject.LabelEdit = false;

            Modified = false;
        }

        private void ControlsToConfig()
        {
            currentDevice.Name = txtName.Text;

            currentDevice.Address = Convert.ToUInt16(numAddress.Value);
            currentDevice.Description = txtDescription.Text;
            currentDevice.Enabled = ckbEnabled.Checked;

            currentDevice.DeviceRegistersBytes = Convert.ToInt32(nudDeviceRegistersBytes.Value);
            currentDevice.DeviceGatewayRegistersBytes = Convert.ToInt32(nudDeviceGatewayRegistersBytes.Value);

            currentDevice.Status = cmbStatus.SelectedIndex;
            currentDevice.PollingOnScheduleStatus = ckbPollingOnScheduleStatus.Checked;
            currentDevice.IntervalPool = Convert.ToInt32(numIntervalPool.Value);
            currentDevice.TypeProtocol = cmbTypeProtocol.SelectedIndex;

            currentDevice.DateTimeLastSuccessfully = DateTime.Parse(txtDateTimeLastSuccessfully.Text.Trim());
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

        #region Component

        private void PollingOnScheduleStatusChecked()
        {
            if (ckbPollingOnScheduleStatus.Checked == true)
            {
                numIntervalPool.Enabled = true;
            }
            else if (ckbPollingOnScheduleStatus.Checked == false)
            {
                numIntervalPool.Enabled = false;
            }
        }

        private void ckbPollingOnScheduleStatus_CheckedChanged(object sender, EventArgs e)
        {
            PollingOnScheduleStatusChecked();
        }

        private void lblStatus_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (cmbStatus.Enabled == false)
            {
                cmbStatus.Enabled = true;
            }
            else
            {
                cmbStatus.Enabled = false;
            }
        }

        #endregion Component

        #region Menu change Buffer
        private void tolRegisterChange_Click(object sender, EventArgs e)
        {
            string tabname = tabDeviceBuffer.SelectedTab.Text;
            if (tabname == "Coils")
            {
                Coils_Change();
            }
            else if (tabname == "Discrete Inputs")
            {
                DiscreteInputs_Change();
            }
            else if (tabname == "Holding Registers")
            {
                HoldingRegisters_Change();
            }
            else if (tabname == "Input Registers")
            {
                InputRegisters_Change();
            }
        }

        private void tolRegisterRefresh_Click(object sender, EventArgs e)
        {
            string tabname = tabDeviceBuffer.SelectedTab.Text;
            if (tabname == "Coils")
            {
                Coils_Refresh();
            }
            else if (tabname == "Discrete Inputs")
            {
                DiscreteInputs_Refresh();
            }
            else if (tabname == "Holding Registers")
            {
                HoldingRegisters_Refresh();
            }
            else if (tabname == "Input Registers")
            {
                InputRegisters_Refresh();
            }
        }

        #endregion Menu change Buffer

        #region Buffer
        private void numRegisterStart_ValueChanged(object sender, EventArgs e)
        {
            //tmr_Timer.Enabled = false;
            //tmr_Status = false;
            lstCoils.Items.Clear();
            lstDiscreteInputs.Items.Clear();
            lstHoldingRegisters.Items.Clear();
            lstInputRegisters.Items.Clear();

            register_start = Convert.ToUInt16(numRegisterStart.Value);

            GetBuffer();

            //tmr_Timer.Enabled = true;
            //tmr_Status = true;
        }

        private void GetBuffer()
        {
            register_start = (ushort)(Convert.ToUInt16(numRegisterStart.Value));

            //Coils
            if (currentDevice.ID != null)
            {
                //Обновление без мерцания
                Type type = lstCoils.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(lstCoils, true, null);

                this.lstCoils.BeginUpdate();
                this.lstCoils.Items.Clear();
                for (int index = 0; index < 1000; ++index)
                {
                    if (currentDevice.CoilsExists(Convert.ToUInt16(register_start * 1000 + index)))
                    {
                        this.lstCoils.Items.Add(new ListViewItem()
                        {
                            Text = (register_start * 1000 + index + 100000).ToString(),
                            SubItems = {
                                            currentDevice.GetBooleanCoil(Convert.ToUInt16(register_start * 1000 + index)).ToString()
                        }
                        });
                    }
                }
                this.lstCoils.EndUpdate();
            }

            //DiscreteInputs
            if (currentDevice.ID != null)
            {
                //Обновление без мерцания
                Type type = lstDiscreteInputs.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(lstDiscreteInputs, true, null);

                this.lstDiscreteInputs.BeginUpdate();
                this.lstDiscreteInputs.Items.Clear();
                for (int index = 0; index < 1000; ++index)
                {
                    if (currentDevice.DiscreteInputsExists(Convert.ToUInt16(register_start * 1000 + index)))
                    {
                        this.lstDiscreteInputs.Items.Add(new ListViewItem()
                        {
                            Text = (register_start * 1000 + index + 200000).ToString(),
                            SubItems = {
                                            currentDevice.GetBooleanDiscreteInput(Convert.ToUInt16(register_start * 1000 + index)).ToString()
                        }
                        });
                    }
                }
                this.lstDiscreteInputs.EndUpdate();
            }

            //HoldingRegisters
            if (currentDevice.ID != null)
            {
                //Обновление без мерцания
                Type type = lstHoldingRegisters.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(lstHoldingRegisters, true, null);

                this.lstHoldingRegisters.BeginUpdate();
                this.lstHoldingRegisters.Items.Clear();
                for (int index = 0; index < 1000; ++index)
                {
                    if (currentDevice.HoldingRegistersExists(Convert.ToUInt16(register_start * 1000 + index)))
                    {
                        this.lstHoldingRegisters.Items.Add(new ListViewItem()
                        {
                            Text = (register_start * 1000 + index + 300000).ToString(),
                            SubItems = {
                                            Convert.ToString((int)currentDevice.GetUlongHoldingRegister(Convert.ToUInt64(register_start * 1000 + index)), 2).PadLeft(32, '0').ToUpper(),
                                            currentDevice.GetUintHoldingRegister(Convert.ToUInt64(register_start * 1000 + index)).ToString("x4").ToUpper(),
                                            currentDevice.GetUlongHoldingRegister(Convert.ToUInt64(register_start * 1000 + index)).ToString("x8").ToUpper(),
                                            currentDevice.GetUlongHoldingRegister(Convert.ToUInt64(register_start * 1000 + index)).ToString(),
                                }
                        });
                    }
                }
                this.lstHoldingRegisters.EndUpdate();
            }

            //InputRegisters
            if (currentDevice.ID != null)
            {
                //Обновление без мерцания
                Type type = lstInputRegisters.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(lstInputRegisters, true, null);

                this.lstInputRegisters.BeginUpdate();
                this.lstInputRegisters.Items.Clear();
                for (int index = 0; index < 1000; ++index)
                {
                    if (currentDevice.InputRegistersExists(Convert.ToUInt16(register_start * 1000 + index)))
                    {
                        this.lstInputRegisters.Items.Add(new ListViewItem()
                        {
                            Text = (register_start * 1000 + index + 400000).ToString(),
                            SubItems = {
                                            Convert.ToString((int)currentDevice.GetUlongInputRegister(Convert.ToUInt64(register_start * 1000 + index)), 2).PadLeft(32, '0').ToUpper(),
                                            currentDevice.GetUintInputRegister(Convert.ToUInt64(register_start * 1000 + index)).ToString("x4").ToUpper(),
                                            currentDevice.GetUlongInputRegister(Convert.ToUInt64(register_start * 1000 + index)).ToString("x8").ToUpper(),
                                            currentDevice.GetUlongInputRegister(Convert.ToUInt64(register_start * 1000 + index)).ToString(),
                                }
                        });
                    }
                }
                this.lstInputRegisters.EndUpdate();
            }
        }


        #endregion Buffer

        //private void btnAddСhannel_Click(object sender, EventArgs e)
        //{
        //    Add();
        //}

        //private void Add()
        //{
        //    GetConfig();
        //    if (deviceName == "")
        //    {
        //        MessageBox.Show("Поле Наименование не может быть пустым");
        //        return;
        //    }
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnSaveСhannel_Click(object sender, EventArgs e)
        //{
        //    Save();
        //}

        //private void Save()
        //{
        //    GetConfig();
        //    if (deviceName == "")
        //    {
        //        MessageBox.Show("Поле Наименование не может быть пустым");
        //        return;
        //    }
        //    //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
        //    TreeNode stn = ((frm_MainForm)this.Parent.Parent.Parent.Parent.Parent).trv_Project.SelectedNode;
        //    ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
        //    projectNodeData.modbus_Device.ID= DeviceID;
        //    projectNodeData.modbus_device.Address = Address;
        //    projectNodeData.modbus_device.DeviceName = DeviceName;
        //    projectNodeData.modbus_device.Description = Description;
        //    projectNodeData.modbus_device.Enabled = Enabled;

        //    projectNodeData.modbus_device.PollingOnScheduleStatus = PollingOnScheduleStatus;
        //    projectNodeData.modbus_device.IntervalPool = IntervalPool;
        //    projectNodeData.modbus_device.TypeProtocol = TypeProtocol;

        //    projectNodeData.modbus_device.DateTimeLastSuccessfully = DateTimeLastSuccessfully;

        //    stn.Text = DeviceName;
        //    stn.Tag = projectNodeData;
        //}

        //private void btnCancelСhannel_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.Cancel;
        //    Close();
        //}

        #region Изменение буфера
        private void Coils_Change()
        {
            ListView lstcoils = this.lstCoils;
            if (lstcoils.SelectedItems.Count <= 0)
            {
                return;
            }

            if (currentDevice.ID != null)
            {
                ListViewItem selectedIndex = lstcoils.SelectedItems[0];

                int index = selectedIndex.Index;
                ushort index_RegAddr = (ushort)(register_start * 1000 + index);
                uint RegAddr_Value = Convert.ToUInt32(Convert.ToBoolean(selectedIndex.SubItems[1].Text));

                FrmRegisterInputValue InputBox = new FrmRegisterInputValue();
                InputBox.mode = 0;
                InputBox.value = RegAddr_Value;
                //InputBox.FormParent = this;
                InputBox.ShowDialog();

                if (InputBox.DialogResult == DialogResult.OK)
                {
                    //Записываем
                    bool bool_Value = Convert.ToBoolean(InputBox.value);
                    currentDevice.SetCoil(index_RegAddr, bool_Value);
                    //Обновляем информацию
                    GetBuffer();
                    //Прокручиваем
                    lstCoils.EnsureVisible(index);
                    lstCoils.TopItem = lstCoils.Items[index];
                    //Делаем область активной
                    lstCoils.Focus();
                    //Делаю нужный элемент выбранным
                    lstCoils.Items[index].Selected = true;
                    lstCoils.Select();
                }
            }
        }

        private void Coils_Refresh()
        {
            ListView lstcoils = this.lstCoils;
            if (lstcoils.SelectedItems.Count <= 0)
            {
                return;
            }

            if (currentDevice.ID != null)
            {
                ListViewItem selectedIndex = lstcoils.SelectedItems[0];
                int index = selectedIndex.Index;

                //Обновляем информацию
                GetBuffer();
                //Прокручиваем
                lstCoils.EnsureVisible(index);
                lstCoils.TopItem = lstCoils.Items[index];
                //Делаем область активной
                lstCoils.Focus();
                //Делаю нужный элемент выбранным
                lstCoils.Items[index].Selected = true;
                lstCoils.Select();
            }
        }

        private void DiscreteInputs_Change()
        {
            ListView lstdiscreteinputs = this.lstDiscreteInputs;
            if (lstdiscreteinputs.SelectedItems.Count <= 0)
            {
                return;
            }

            if (currentDevice.ID != null)
            {
                ListViewItem selectedIndex = lstdiscreteinputs.SelectedItems[0];

                int index = selectedIndex.Index;
                ushort index_RegAddr = (ushort)(register_start * 1000 + index);
                uint RegAddr_Value = Convert.ToUInt32(Convert.ToBoolean(selectedIndex.SubItems[1].Text));

                FrmRegisterInputValue InputBox = new FrmRegisterInputValue();
                InputBox.mode = 0;
                InputBox.value = RegAddr_Value;
                //InputBox.FormParent = this;
                InputBox.ShowDialog();

                if (InputBox.DialogResult == DialogResult.OK)
                {
                    //Записываем
                    bool bool_Value = Convert.ToBoolean(InputBox.value);
                    currentDevice.SetDiscreteInput(index_RegAddr, bool_Value);
                    //Обновляем информацию
                    GetBuffer();
                    //Прокручиваем
                    lstDiscreteInputs.EnsureVisible(index);
                    lstDiscreteInputs.TopItem = lstDiscreteInputs.Items[index];
                    //Делаем область активной
                    lstDiscreteInputs.Focus();
                    //Делаю нужный элемент выбранным
                    lstDiscreteInputs.Items[index].Selected = true;
                    lstDiscreteInputs.Select();
                }
            }
        }

        private void DiscreteInputs_Refresh()
        {
            ListView lstdiscreteinputs = this.lstDiscreteInputs;
            if (lstdiscreteinputs.SelectedItems.Count <= 0)
            {
                return;
            }

            if (currentDevice.ID != null)
            {
                ListViewItem selectedIndex = lstdiscreteinputs.SelectedItems[0];
                int index = selectedIndex.Index;

                //Обновляем информацию
                GetBuffer();
                //Прокручиваем
                lstDiscreteInputs.EnsureVisible(index);
                lstDiscreteInputs.TopItem = lstDiscreteInputs.Items[index];
                //Делаем область активной
                lstDiscreteInputs.Focus();
                //Делаю нужный элемент выбранным
                lstDiscreteInputs.Items[index].Selected = true;
                lstDiscreteInputs.Select();
            }
        }

        private void HoldingRegisters_Change()
        {
            ListView lstholdingregisters = this.lstHoldingRegisters;
            if (lstholdingregisters.SelectedItems.Count <= 0)
            {
                return;
            }

            if (currentDevice.ID != null)
            {
                ListViewItem selectedIndex = lstholdingregisters.SelectedItems[0];

                int index = selectedIndex.Index;
                ushort index_RegAddr = (ushort)(register_start * 1000 + index);
                ulong RegAddr_Value = Convert.ToUInt64(selectedIndex.SubItems[3].Text);

                FrmRegisterInputValue InputBox = new FrmRegisterInputValue();
                InputBox.mode = 1;
                InputBox.value = RegAddr_Value;
                //InputBox.FormParent = this;
                InputBox.ShowDialog();

                if (InputBox.DialogResult == DialogResult.OK)
                {
                    //Записываем
                    currentDevice.SetHoldingRegister(index_RegAddr, InputBox.value);
                    //Обновляем информацию
                    GetBuffer();
                    //Прокручиваем
                    lstHoldingRegisters.EnsureVisible(index);
                    lstHoldingRegisters.TopItem = lstHoldingRegisters.Items[index];
                    //Делаем область активной
                    lstHoldingRegisters.Focus();
                    //Делаю нужный элемент выбранным
                    lstHoldingRegisters.Items[index].Selected = true;
                    lstHoldingRegisters.Select();
                }
            }
        }

        private void HoldingRegisters_Refresh()
        {
            ListView lstholdingregisters = this.lstHoldingRegisters;
            if (lstholdingregisters.SelectedItems.Count <= 0)
            {
                return;
            }

            if (currentDevice.ID != null)
            {
                ListViewItem selectedIndex = lstholdingregisters.SelectedItems[0];
                int index = selectedIndex.Index;

                //Обновляем информацию
                GetBuffer();
                //Прокручиваем
                lstHoldingRegisters.EnsureVisible(index);
                lstHoldingRegisters.TopItem = lstHoldingRegisters.Items[index];
                //Делаем область активной
                lstHoldingRegisters.Focus();
                //Делаю нужный элемент выбранным
                lstHoldingRegisters.Items[index].Selected = true;
                lstHoldingRegisters.Select();
            }
        }

        private void InputRegisters_Change()
        {
            ListView lstinputregisters = this.lstInputRegisters;
            if (lstinputregisters.SelectedItems.Count <= 0)
            {
                return;
            }

            if (currentDevice.ID != null)
            {
                ListViewItem selectedIndex = lstinputregisters.SelectedItems[0];

                int index = selectedIndex.Index;
                ushort index_RegAddr = (ushort)(register_start * 1000 + index);
                ulong RegAddr_Value = Convert.ToUInt32(selectedIndex.SubItems[3].Text);

                FrmRegisterInputValue InputBox = new FrmRegisterInputValue();
                InputBox.mode = 1;
                InputBox.value = RegAddr_Value;
                //InputBox.FormParent = this;
                InputBox.ShowDialog();

                if (InputBox.DialogResult == DialogResult.OK)
                {
                    //Записываем
                    currentDevice.SetInputRegister(index_RegAddr, InputBox.value);
                    //Обновляем информацию
                    GetBuffer();
                    //Прокручиваем
                    lstInputRegisters.EnsureVisible(index);
                    lstInputRegisters.TopItem = lstInputRegisters.Items[index];
                    //Делаем область активной
                    lstInputRegisters.Focus();
                    //Делаю нужный элемент выбранным
                    lstInputRegisters.Items[index].Selected = true;
                    lstInputRegisters.Select();
                }
            }
        }

        private void InputRegisters_Refresh()
        {
            ListView lstinputregisters = this.lstInputRegisters;
            if (lstinputregisters.SelectedItems.Count <= 0)
            {
                return;
            }

            if (currentDevice.ID != null)
            {
                ListViewItem selectedIndex = lstinputregisters.SelectedItems[0];
                int index = selectedIndex.Index;

                //Обновляем информацию
                GetBuffer();
                //Прокручиваем
                lstInputRegisters.EnsureVisible(index);
                lstInputRegisters.TopItem = lstInputRegisters.Items[index];
                //Делаем область активной
                lstInputRegisters.Focus();
                //Делаю нужный элемент выбранным
                lstInputRegisters.Items[index].Selected = true;
                lstInputRegisters.Select();
            }
        }

        #endregion

        //private void lstCoils_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Coils_Change();
        //}

        //private void lstDiscreteInputs_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    DiscreteInputs_Change();
        //}

        //private void lstHoldingRegisters_DoubleClick(object sender, EventArgs e)
        //{
        //    HoldingRegisters_Change();
        //}

        //private void lstInputRegisters_DoubleClick(object sender, EventArgs e)
        //{
        //    InputRegisters_Change();
        //}





        //#region Поиск по буферу значений

        //static IEnumerable<bool> GenerateListBool(List<bool> array, int index)
        //{
        //    yield return array[index];
        //}

        //static IEnumerable<ushort> GenerateListUshort(List<ushort> array, int index)
        //{
        //    yield return array[index];
        //}

        //private void btnSearchValue_Click(object sender, EventArgs e)
        //{
        //    if (cmbTypeData.Text == "Coils")
        //    {
        //        //Делаем активной вкладкой
        //        tabDeviceBuffer.SelectedTab = tabCoils;

        //        int index = 0;
        //        List<bool> array = new List<bool>();

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            array.Add(DataCoils[i]);
        //        }

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            foreach (var elem in GenerateListBool(array, index))
        //            {
        //                var item = lstCoils.Items[i];
        //                if (item.SubItems[1].Text.ToLower().Contains("True".ToLower()))
        //                {
        //                    //Прокручиваем
        //                    lstCoils.EnsureVisible(i);
        //                    lstCoils.TopItem = lstCoils.Items[i];
        //                    //Делаем область активной
        //                    lstCoils.Focus();
        //                    //Делаю нужный элемент выбранным
        //                    lstCoils.Items[i].Selected = true;
        //                    lstCoils.Select();

        //                    DialogResult result = MessageBox.Show("Нашли на адресе " + item.SubItems[0].Text + " значение " + item.SubItems[1].Text + ". Ищем дальше?", "Поиск", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (result == DialogResult.Yes)
        //                    {

        //                    }
        //                    else if (result == DialogResult.No)
        //                    {
        //                        goto END;
        //                    }
        //                }

        //                if (array.Count - 1 == index)
        //                {
        //                    index = 0;
        //                    MessageBox.Show("Ничего не найдено!");
        //                }

        //                index++;
        //            }
        //        }
        //    }
        //    else if (cmbTypeData.Text == "Discrete Inputs")
        //    {
        //        tabDeviceBuffer.SelectedTab = tabDiscreteInputs;

        //        int index = 0;
        //        List<bool> array = new List<bool>();

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            array.Add(DataDiscreteInputs[i]);
        //        }

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            foreach (var elem in GenerateListBool(array, index))
        //            {
        //                var item = lstDiscreteInputs.Items[i];
        //                if (item.SubItems[1].Text.ToLower().Contains("True".ToLower()))
        //                {
        //                    //Прокручиваем
        //                    lstDiscreteInputs.EnsureVisible(i);
        //                    lstDiscreteInputs.TopItem = lstDiscreteInputs.Items[i];
        //                    //Делаем область активной
        //                    lstDiscreteInputs.Focus();
        //                    //Делаю нужный элемент выбранным
        //                    lstDiscreteInputs.Items[i].Selected = true;
        //                    lstDiscreteInputs.Select();

        //                    DialogResult result = MessageBox.Show("Нашли на адресе " + item.SubItems[0].Text + " значение " + item.SubItems[1].Text + ". Ищем дальше?", "Поиск", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (result == DialogResult.Yes)
        //                    {

        //                    }
        //                    else if (result == DialogResult.No)
        //                    {
        //                        goto END;
        //                    }
        //                }

        //                if (array.Count - 1 == index)
        //                {
        //                    index = 0;
        //                    MessageBox.Show("Ничего не найдено!");
        //                }

        //                index++;
        //            }
        //        }
        //    }
        //    else if (cmbTypeData.Text == "Holding Registers")
        //    {
        //        tabDeviceBuffer.SelectedTab = tabHoldingRegisters;

        //        string search_holdingregisters_value = string.Empty;

        //        frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //        InputBox.mode = 1;
        //        InputBox.value = 0;
        //        InputBox.FormParent = this;
        //        InputBox.ShowDialog();

        //        if (InputBox.DialogResult == DialogResult.OK)
        //        {
        //            uint tmp_uint = InputBox.value;
        //            search_holdingregisters_value = tmp_uint.ToString();
        //        }

        //        int index = 0;
        //        List<ushort> array = new List<ushort>();

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            array.Add(DataHoldingRegisters[i]);
        //        }

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            foreach (var elem in GenerateListUshort(array, index))
        //            {
        //                var item = lstHoldingRegisters.Items[i];
        //                if (item.SubItems[3].Text.ToLower().Equals(search_holdingregisters_value.ToLower()))
        //                {
        //                    //Прокручиваем
        //                    lstHoldingRegisters.EnsureVisible(i);
        //                    lstHoldingRegisters.TopItem = lstHoldingRegisters.Items[i];
        //                    //Делаем область активной
        //                    lstHoldingRegisters.Focus();
        //                    //Делаю нужный элемент выбранным
        //                    lstHoldingRegisters.Items[i].Selected = true;
        //                    lstHoldingRegisters.Select();

        //                    DialogResult result = MessageBox.Show("Нашли на адресе " + item.SubItems[0].Text + " значение " + item.SubItems[3].Text + ". Ищем дальше?", "Поиск", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (result == DialogResult.Yes)
        //                    {

        //                    }
        //                    else if (result == DialogResult.No)
        //                    {
        //                        goto END;
        //                    }
        //                }

        //                if (array.Count - 1 == index)
        //                {
        //                    index = 0;
        //                    MessageBox.Show("Ничего не найдено!");
        //                }

        //                index++;
        //            }
        //        }
        //    }
        //    else if (cmbTypeData.Text == "Input Registers")
        //    {
        //        tabDeviceBuffer.SelectedTab = tabInputRegisters;

        //        string search_inputregisters_value = string.Empty;

        //        frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //        InputBox.mode = 1;
        //        InputBox.value = 0;
        //        InputBox.FormParent = this;
        //        InputBox.ShowDialog();

        //        if (InputBox.DialogResult == DialogResult.OK)
        //        {
        //            uint tmp_uint = InputBox.value;
        //            search_inputregisters_value = tmp_uint.ToString();
        //        }

        //        int index = 0;
        //        List<ushort> array = new List<ushort>();

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            array.Add(DataInputRegisters[i]);
        //        }

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            foreach (var elem in GenerateListUshort(array, index))
        //            {
        //                var item = lstInputRegisters.Items[i];
        //                if (item.SubItems[3].Text.ToLower().Equals(search_inputregisters_value.ToLower()))
        //                {
        //                    //Прокручиваем
        //                    lstInputRegisters.EnsureVisible(i);
        //                    lstInputRegisters.TopItem = lstInputRegisters.Items[i];
        //                    //Делаем область активной
        //                    lstInputRegisters.Focus();
        //                    //Делаю нужный элемент выбранным
        //                    lstInputRegisters.Items[i].Selected = true;
        //                    lstInputRegisters.Select();

        //                    DialogResult result = MessageBox.Show("Нашли на адресе " + item.SubItems[0].Text + " значение " + item.SubItems[3].Text + ". Ищем дальше?", "Поиск", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (result == DialogResult.Yes)
        //                    {

        //                    }
        //                    else if (result == DialogResult.No)
        //                    {
        //                        goto END;
        //                    }
        //                }

        //                if (array.Count - 1 == index)
        //                {
        //                    index = 0;
        //                    MessageBox.Show("Ничего не найдено!");
        //                }

        //                index++;
        //            }
        //        }
        //    }

        //END: try { } catch { }

        //}

        //#endregion Поиск по буферу значений

        //#region CSV
        ////Загрузка данных из CSV
        //private void tolDataLoadAsCSV_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("Вы действительно хотите загрузить\r\nданные из файла?", "Вопрос", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //    {
        //        DataLoadAsCSV();
        //    }
        //}

        //private void DataLoadAsCSV()
        //{
        //    OpenFileDialog OFD = new OpenFileDialog();
        //    OFD.Title = "Загрузить данные...";
        //    OFD.Filter = "CSV (*.csv)|*.csv|Все файлы (*.*)|*.*";
        //    OFD.InitialDirectory = System.IO.Path.Combine(Application.StartupPath);

        //    if (OFD.ShowDialog() == DialogResult.OK && OFD.FileName != "")
        //    {
        //        try
        //        {
        //            //Открываем
        //            string FileName = OFD.FileName;
        //            MODBUS_DEVICE_BUFFER buffer = new MODBUS_DEVICE_BUFFER();

        //            #region Загрузка
        //            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
        //            splashthread.IsBackground = true;
        //            splashthread.Start();

        //            Application.DoEvents();
        //            SplashScreen.UdpateStatusText(1, "Загрузка...");
        //            SplashScreen.SetStatus("Считывание данных из файла:");
        //            SplashScreen.UdpateStatusText(3, "");
        //            Application.DoEvents();

        //            DataTable data = CSV.Import(FileName, true, ";", "UTF8");

        //            for (int i = 0; i < data.Rows.Count; i++)
        //            {
        //                DataRow tmp_DataRow = data.Rows[i];

        //                string RegisterType = tmp_DataRow.ItemArray[1].ToString();

        //                if (RegisterType == "CoilRegister")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        bool Value = (bool)Convert.ToBoolean(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetCoil(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "DiscreteInput")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        bool Value = (bool)Convert.ToBoolean(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetDiscreteInput(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "HoldingRegister")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        ushort Value = Convert.ToUInt16(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetHoldingRegister(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "InputRegister")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        ushort Value = Convert.ToUInt16(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetInputRegister(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "HoldingRegister4")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        uint Value = Convert.ToUInt32(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetHoldingRegister_4(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "InputRegister4")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        uint Value = Convert.ToUInt32(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetInputRegister_4(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }
        //            }

        //            Application.DoEvents();
        //            SplashScreen.CloseForm();
        //            this.Show();
        //            this.Activate();
        //            #endregion Загрузка

        //            SetConfig();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Не удалось загрузить данные по причине:\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            goto END_VOID;
        //        }
        //    END_VOID:
        //        try { } catch { }
        //    }
        //}

        ////Сохранить данные как CSV
        //private void tolDataSaveAsCSV_Click(object sender, EventArgs e)
        //{
        //    DataSaveAsCSV();
        //}

        //private void DataSaveAsCSV()
        //{
        //    SaveFileDialog SFD = new SaveFileDialog();
        //    SFD.Title = "Выгрузить данные...";
        //    SFD.Filter = "CSV (*.csv)|*.csv|Все файлы (*.*)|*.*";
        //    SFD.InitialDirectory = System.IO.Path.Combine(Application.StartupPath);

        //    if (SFD.ShowDialog() == DialogResult.OK && SFD.FileName != "")
        //    {
        //        //Сохраняем
        //        string FileName = SFD.FileName;

        //        MODBUS_DEVICE_BUFFER buffer = new MODBUS_DEVICE_BUFFER();
        //        DataTable data = buffer.ConvertRegistersToDataTable(ModbusDevice);

        //        CSV.Export(FileName, data, true, ";", "UTF8");
        //    }
        //}

        //#endregion CSV

        //#region Таймер
        ////Таймер
        //DateTime tmr_EndTime = new DateTime();
        //private bool tmr_Status = false;
        //private string CountDownTimerString = string.Empty;
        //private double TimeRefresh = 3000d;

        //private void lblTimerInfo_Click(object sender, EventArgs e)
        //{
        //    frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //    InputBox.mode = 1;
        //    InputBox.value = Convert.ToUInt16(TimeRefresh);
        //    InputBox.ShowDialog();

        //    if (InputBox.DialogResult == DialogResult.OK)
        //    {
        //        //Записываем
        //        TimeRefresh = Convert.ToDouble(InputBox.value);
        //    }
        //}

        ////Включаем и выключаем таймер
        //private void ckbAutoRefreshListRegisters_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (ckbAutoRefreshListRegisters.Checked == true)
        //    {
        //        tmr_EndTime = DateTime.Now.AddMilliseconds(TimeRefresh);
        //        tmr_Timer.Enabled = true;
        //        tmr_Status = true;
        //    }
        //    else if (ckbAutoRefreshListRegisters.Checked == false)
        //    {
        //        tmr_Timer.Enabled = false;
        //        tmr_Status = false;
        //    }
        //}

        //private void tmr_Timer_Tick(object sender, EventArgs e)
        //{
        //    TimeSpan leftTime = tmr_EndTime.Subtract(DateTime.Now);
        //    if (leftTime.TotalSeconds < 0)
        //    {
        //        CountDownTimerString = "00:00:00";
        //        lblTimerInfo.Text = CountDownTimerString;
        //        Refresh();
        //        tmr_Timer.Stop();
        //        //Обновляем информацию
        //        tmr_Timer_InfoDevice();

        //        if (tmr_Status == true)
        //        {
        //            tmr_EndTime = DateTime.Now.AddMilliseconds(TimeRefresh);
        //            tmr_Timer.Enabled = true;
        //        }
        //    }
        //    else
        //    {
        //        CountDownTimerString = leftTime.Hours.ToString("00") + ":" + leftTime.Minutes.ToString("00") + ":" + leftTime.Seconds.ToString("00") + "." + leftTime.Milliseconds.ToString("000");
        //        lblTimerInfo.Text = CountDownTimerString;
        //        Refresh();
        //    }
        //}

        //void tmr_Timer_InfoDevice()
        //{
        //    //Очищаем таблицу
        //    try
        //    {
        //        //register_start = Convert.ToUInt16(numRegisterStart.Value);
        //        //register_count = (ushort)(Convert.ToUInt16(numRegisterStop.Value) - Convert.ToInt16(numRegisterStart.Value));

        //        //Находим устройство
        //        MODBUS_DEVICE tmp_Device = CHANNEL.ModbusDevices.Find((Predicate<MODBUS_DEVICE>)(r => r.DeviceID.ToString() == DeviceID.ToString()));
        //        if (tmp_Device != null)
        //        {
        //            ModbusDevice.DataCoils = tmp_Device.DataCoils;
        //            ModbusDevice.DataDiscreteInputs = tmp_Device.DataDiscreteInputs;
        //            ModbusDevice.DataHoldingRegisters = tmp_Device.DataHoldingRegisters;
        //            ModbusDevice.DataInputRegisters = tmp_Device.DataInputRegisters;

        //            //Coils
        //            if (tmp_Device != null)
        //            {
        //                try
        //                {
        //                    ListView lstcoils = this.lstCoils;

        //                    //Обновление без мерцания
        //                    Type type = lstCoils.GetType();
        //                    PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                    propertyInfo.SetValue(lstCoils, true, null);

        //                    //ushort tmp_register_start = register_start;
        //                    for (int index = 0; index < 1000; ++index)
        //                    {
        //                        Application.DoEvents();
        //                        ListViewItem RegisterItem = lstcoils.Items[index];

        //                        //Обновили инфорамцию
        //                        if (ModbusDevice.CoilsExists(Convert.ToUInt16(register_start * 1000 + index)))
        //                        {
        //                            RegisterItem.Text = (register_start * 1000 + index + 100000).ToString();
        //                            RegisterItem.Tag = RegisterItem.Tag;
        //                            RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 100000).ToString());
        //                            RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(ModbusDevice.GetBooleanCoil(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                        }
        //                        Application.DoEvents();
        //                    }
        //                }
        //                catch (Exception ex) { Debuger.LogException(ex.ToString()); }
        //            }

        //            //DiscreteInputs
        //            if (tmp_Device != null)
        //            {
        //                try
        //                {
        //                    ListView lstdiscreteinputs = this.lstDiscreteInputs;

        //                    //Обновление без мерцания
        //                    Type type = lstDiscreteInputs.GetType();
        //                    PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                    propertyInfo.SetValue(lstDiscreteInputs, true, null);

        //                    //ushort tmp_register_start = register_start;
        //                    for (int index = 0; index < 1000; ++index)
        //                    {
        //                        Application.DoEvents();
        //                        ListViewItem RegisterItem = lstdiscreteinputs.Items[index];

        //                        //Обновили инфорамцию
        //                        if (ModbusDevice.CoilsExists(Convert.ToUInt16(register_start * 1000 + index)))
        //                        {
        //                            RegisterItem.Text = (register_start * 1000 + index + 200000).ToString();
        //                            RegisterItem.Tag = RegisterItem.Tag;
        //                            RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 200000).ToString());
        //                            RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(ModbusDevice.GetBooleanDiscreteInput(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                        }
        //                        Application.DoEvents();
        //                    }
        //                }
        //                catch (Exception ex) { Debuger.LogException(ex.ToString()); }
        //            }

        //            //HoldingRegisters
        //            if (tmp_Device != null)
        //            {
        //                try
        //                {
        //                    ListView lstholdingregisters = this.lstHoldingRegisters;

        //                    //Обновление без мерцания
        //                    Type type = lstHoldingRegisters.GetType();
        //                    PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                    propertyInfo.SetValue(lstHoldingRegisters, true, null);

        //                    //ushort tmp_register_start = register_start;
        //                    for (int index = 0; index < 1000; ++index)
        //                    {
        //                        Application.DoEvents();
        //                        ListViewItem RegisterItem = lstholdingregisters.Items[index];

        //                        //Обновили инфорамцию
        //                        if (ModbusDevice.HoldingRegistersExists(Convert.ToUInt16(register_start * 1000 + index)))
        //                        {
        //                            if (ModbusDevice.DeviceRegistersBytes == 0)
        //                            {
        //                                RegisterItem.Text = (register_start * 1000 + index + 300000).ToString();
        //                                RegisterItem.Tag = RegisterItem.Tag;
        //                                RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 300000).ToString());
        //                                RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(Convert.ToString((int)ModbusDevice.GetIntHoldingRegister(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(16, '0').ToUpper());
        //                                RegisterItem.SubItems[2].Text = NULLSTRING.NullToString(ModbusDevice.GetIntHoldingRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString("x4").ToUpper());
        //                                RegisterItem.SubItems[3].Text = NULLSTRING.NullToString(ModbusDevice.GetIntHoldingRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                            }
        //                            else if (ModbusDevice.DeviceRegistersBytes == 1)
        //                            {
        //                                RegisterItem.Text = (register_start * 1000 + index + 300000).ToString();
        //                                RegisterItem.Tag = RegisterItem.Tag;
        //                                RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 300000).ToString());
        //                                RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(Convert.ToString((int)ModbusDevice.GetUIntHoldingRegister_4(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(32, '0').ToUpper());
        //                                RegisterItem.SubItems[2].Text = NULLSTRING.NullToString(ModbusDevice.GetUIntHoldingRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString("x8").ToUpper());
        //                                RegisterItem.SubItems[3].Text = NULLSTRING.NullToString(ModbusDevice.GetUIntHoldingRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                            }
        //                        }
        //                        Application.DoEvents();
        //                    }
        //                }
        //                catch (Exception ex) { Debuger.LogException(ex.ToString()); }
        //            }

        //            //InputRegisters
        //            if (tmp_Device != null)
        //            {
        //                try
        //                {
        //                    ListView lstinputregisters = this.lstInputRegisters;

        //                    //Обновление без мерцания
        //                    Type type = lstInputRegisters.GetType();
        //                    PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                    propertyInfo.SetValue(lstInputRegisters, true, null);

        //                    //ushort tmp_register_start = register_start;
        //                    for (int index = 0; index < 1000; ++index)
        //                    {
        //                        Application.DoEvents();
        //                        ListViewItem RegisterItem = lstinputregisters.Items[index];

        //                        //Обновили инфорамцию
        //                        if (ModbusDevice.InputRegistersExists(Convert.ToUInt16(register_start * 1000 + index)))
        //                        {
        //                            if (ModbusDevice.DeviceRegistersBytes == 0)
        //                            {
        //                                RegisterItem.Text = (register_start * 1000 + index + 400000).ToString();
        //                                RegisterItem.Tag = RegisterItem.Tag;
        //                                RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 400000).ToString());
        //                                RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(Convert.ToString((int)ModbusDevice.GetIntInputRegister(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(16, '0').ToUpper());
        //                                RegisterItem.SubItems[2].Text = NULLSTRING.NullToString(ModbusDevice.GetIntInputRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString("x4").ToUpper());
        //                                RegisterItem.SubItems[3].Text = NULLSTRING.NullToString(ModbusDevice.GetIntInputRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                            }
        //                            else if (ModbusDevice.DeviceRegistersBytes == 1)
        //                            {
        //                                RegisterItem.Text = (register_start * 1000 + index + 400000).ToString();
        //                                RegisterItem.Tag = RegisterItem.Tag;
        //                                RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 400000).ToString());
        //                                RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(Convert.ToString((int)ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(32, '0').ToUpper());
        //                                RegisterItem.SubItems[2].Text = NULLSTRING.NullToString(ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString("x8").ToUpper());
        //                                RegisterItem.SubItems[3].Text = NULLSTRING.NullToString(ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                            }
        //                        }
        //                        Application.DoEvents();
        //                    }
        //                }
        //                catch (Exception ex) { Debuger.LogException(ex.ToString()); }
        //            }
        //        }
        //    }
        //    catch
        //    { }
        //}

        //#endregion Таймер

        //#region Обнуление регистров
        //private void tolRegistersResetToZero_Click(object sender, EventArgs e)
        //{
        //    RegistersResetToZero();
        //}

        //private void RegistersResetToZero()
        //{
        //    for (int index = 0; index <= 65535; ++index)
        //    {
        //        ModbusDevice.SetCoil(Convert.ToUInt16(index), false);
        //        ModbusDevice.SetDiscreteInput(Convert.ToUInt16(index), false);
        //        ModbusDevice.SetHoldingRegister(Convert.ToUInt16(index), (ushort)0);
        //        ModbusDevice.SetInputRegister(Convert.ToUInt16(index), (ushort)0);
        //        ModbusDevice.SetHoldingRegister_4(Convert.ToUInt16(index), (uint)0);
        //        ModbusDevice.SetInputRegister_4(Convert.ToUInt16(index), (uint)0);
        //    }

        //    GetConfig();
        //    SetConfig();
        //}
        //#endregion Обнуление регистров
    }
}
