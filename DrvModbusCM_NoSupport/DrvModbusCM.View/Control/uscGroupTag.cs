using Scada.Forms;
using System.Data;
using System.Reflection;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscGroupTag : UserControl
    {
        public uscGroupTag()
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

        private ListViewItem selectedItem;  //Выбранная запись
        public int indexSelect = 0;         //Номер индекса
        public int SortingMethod = 0;       //Способ Сортировки

        #region Группа тегов
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

        //Иконка устройства
        private string deviceGroupTagKeyImage;
        public string DeviceGroupTagKeyImage
        {
            get { return deviceGroupTagKeyImage; }
            set { deviceGroupTagKeyImage = value; }
        }

        //Название группы тегов
        private string deviceGroupTagName;
        public string DeviceGroupTagName
        {
            get { return deviceGroupTagName; }
            set { deviceGroupTagName = value; }
        }

        //Описание группы тегов
        private string deviceGroupTagDescription;
        public string DeviceGroupTagDescription
        {
            get { return deviceGroupTagDescription; }
            set { deviceGroupTagDescription = value; }
        }

        //Состояние группы тегов
        private bool deviceGroupTagEnabled;
        public bool DeviceGroupTagEnabled
        {
            get { return deviceGroupTagEnabled; }
            set { deviceGroupTagEnabled = value; }
        }

        ProjectDeviceTag newTag;
        ProjectDeviceTag changeTag;

        #endregion Группа тегов

        #region Список тегов

        private List<ProjectDeviceTag> deviceTags;
        public List<ProjectDeviceTag> DeviceTags
        {
            get { return deviceTags; }
            set { deviceTags = value; }
        }

        public static List<ProjectDeviceTag> Tags { get; set; }

        #endregion Список тегов

        #region Timer
        DateTime tmrEndTime = new DateTime();
        private bool tmrStatus = false;
        private string CountDownTimerString = string.Empty;
        private double TimeRefresh = 3000d;
        #endregion Timer

        #endregion Variables

        #region Splash
        FrmSplashScreen sf = new FrmSplashScreen();
        #endregion Splash

        #region TabHelper
        public TabControlHelper myHelper;
        #endregion TabHelper

        #region Load

        public uscGroupTag(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            DeviceID = MTNodeData.deviceGroupTag.DeviceID;
            DeviceGroupTagID = MTNodeData.deviceGroupTag.DeviceGroupTagID;

            DeviceGroupTagName = MTNodeData.deviceGroupTag.DeviceGroupTagName;
            DeviceGroupTagDescription = MTNodeData.deviceGroupTag.DeviceGroupTagDescription;
            DeviceGroupTagEnabled = MTNodeData.deviceGroupTag.DeviceGroupTagEnabled;

            if (MTNodeData.deviceGroupTag.DeviceTags == null)
            {
                DeviceTags = new List<ProjectDeviceTag>();
            }
            else
            {
                DeviceTags = MTNodeData.deviceGroupTag.DeviceTags;
            }

            InitializeComponent();
            FormatWindow(true);
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.BorderStyle = BorderStyle.None;
                btnGroupTagSave.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;

                // hide tab tag
                myHelper = new TabControlHelper(tabDeviceTag);
                myHelper.HidePage(tabTagAddEdit);

            }
        }

        private void uscGroupTag_Load(object sender, EventArgs e)
        {
            ConfigToControls();

            // turning on the timer
            ckbAutoRefreshListTags.Checked = true;
        }

        private void ConfigToControls()
        {
            txtNameGroupTag.Text = DeviceGroupTagName;

            //Теги
            if (DeviceTags != null)
            {
                //Обновление без мерцания
                Type type = lstTags.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(lstTags, true, null);

                this.lstTags.BeginUpdate();
                this.lstTags.Items.Clear();

                //Способ сортировки
                switch (SortingMethod)
                {
                    case 0: //По адресу (по умолчанию)
                        //var tmp_TagsSortAddress = from tag in DeviceTags orderby tag.TagAddress, tag.TagName ascending select tag;
                        //var tmp_TagsSortAddress = DeviceTags.OrderBy(a => a.TagAddress).ThenBy(a => a.TagName).ToList();

                        #region Отображение данные 
                        foreach (var tmpTag in DeviceTags)
                        {
                            if (tmpTag == null)
                            {
                                continue;
                            }

                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                        }
                        #endregion Отображение данные 
                        break;
                    case 1: //По адресу
                        var tmp_TagsSortAddressASC = from tag in DeviceTags orderby tag.DeviceTagAddress ascending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortAddressASC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                        }
                        #endregion Отображение данные 
                        break;
                    case -1:  //По адресу 
                        var tmp_TagsSortAddressDESC = from tag in DeviceTags orderby tag.DeviceTagAddress descending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortAddressDESC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                            #endregion Отображение данные 
                        }
                        break;
                    case 2:  //По названию
                        var tmp_TagsSortNameASC = from tag in DeviceTags orderby tag.DeviceTagname ascending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortNameASC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                            #endregion Отображение данные 
                        }
                        break;
                    case -2:  //По названию
                        var tmp_TagsSortNameDESC = from tag in DeviceTags orderby tag.DeviceTagname descending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortNameDESC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                            #endregion Отображение данные 
                        }
                        break;
                    case 3: //По описанию
                        var tmp_TagsSortDescriptionASC = from tag in DeviceTags orderby tag.DeviceTagDescription ascending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortDescriptionASC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                        }
                        #endregion Отображение данные 
                        break;
                    case -3: //По описанию
                        var tmp_TagsSortDescriptionDESC = from tag in DeviceTags orderby tag.DeviceTagDescription descending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortDescriptionDESC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                        }
                        #endregion Отображение данные 
                        break;
                    case 4: //По типу
                        var tmp_TagsSortTypeASC = from tag in DeviceTags orderby tag.DeviceTagType ascending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortTypeASC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                        }
                        #endregion Отображение данные 
                        break;
                    case -4: //По типу
                        var tmp_TagsSortTypeDESC = from tag in DeviceTags orderby tag.DeviceTagType descending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortTypeDESC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                        }
                        #endregion Отображение данные 
                        break;
                    case 5: //По значению
                        var tmp_TagsSortValueASC = from tag in DeviceTags orderby tag.DeviceTagDataValue ascending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortValueASC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                        }
                        #endregion Отображение данные 
                        break;
                    case -5: //По значению
                        var tmp_TagsSortValueDESC = from tag in DeviceTags orderby tag.DeviceTagDataValue descending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortValueDESC)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                        }
                        #endregion Отображение данные 
                        break;
                    default: //По адресу (по умолчанию)
                        var tmp_TagsSortDefault = from tag in DeviceTags orderby tag.DeviceTagAddress ascending select tag;

                        #region Отображение данные 
                        foreach (var tmpTag in tmp_TagsSortDefault)
                        {
                            //Вставили инфорамцию
                            this.lstTags.Items.Add(new ListViewItem()
                            {
                                //Название тега
                                Text = tmpTag.DeviceTagname,
                                SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(tmpTag.DeviceTagDataValue),
                                DriverUtils.NullToString(tmpTag.DeviceTagDateTime),
                                DriverUtils.NullToString(tmpTag.DeviceTagQuality),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription)
                            }
                            }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                        }
                        #endregion Отображение данные 
                        break;
                }
                this.lstTags.EndUpdate();
            }

            try
            {
                if (indexSelect < lstTags.Items.Count)
                {
                    //Прокручиваем
                    lstTags.EnsureVisible(indexSelect);
                    lstTags.TopItem = lstTags.Items[indexSelect];
                    //Делаем область активной
                    lstTags.Focus();
                    //Делаю нужный элемент выбранным
                    lstTags.Items[indexSelect].Selected = true;
                    lstTags.Select();
                }
            }
            catch { }
        }

        #endregion Load

        #region Save
        private void btnSaveGroupTag_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ControlsToConfig();

            if (DeviceGroupTagName == "")
            {
                MessageBox.Show("Поле Наименование не может быть пустым");
                return;
            }
            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
            TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            projectNodeData.deviceGroupTag.DeviceGroupTagID = DeviceGroupTagID;
            projectNodeData.deviceGroupTag.DeviceGroupTagName = DeviceGroupTagName;
            projectNodeData.deviceGroupTag.DeviceGroupTagDescription = DeviceGroupTagDescription;
            projectNodeData.deviceGroupTag.DeviceGroupTagEnabled = DeviceGroupTagEnabled;
            projectNodeData.deviceGroupTag.DeviceTags = DeviceTags;

            stn.Text = DeviceGroupTagName;
            stn.Tag = projectNodeData;

            stn.Nodes.Clear();
            FrmConfigForm frmConfigForm = new FrmConfigForm();

            foreach (ProjectDeviceTag projectDeviceTag in DeviceTags)
            {
                frmConfigForm.NodeDeviceTagAdd(projectDeviceTag, stn, null);
            }
        }

        private void ControlsToConfig()
        {
            DeviceGroupTagName = txtNameGroupTag.Text;
            DeviceTags = deviceTags;
        }
        #endregion Save

        #region Tag Refresh

        private void tolRegisterRefresh_Click(object sender, EventArgs e)
        {
            ConfigToControls();
        }

        #endregion  Tag Refresh

        #region Tag selection

        private void lstTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.ListView)sender).SelectedItems.Count > 0)
            {
                this.selectedItem = ((System.Windows.Forms.ListView)sender).SelectedItems[0];
            }
        }

        private void lstTags_MouseClick(object sender, MouseEventArgs e)
        {
            SelectTag();
        }

        private void SelectTag()
        {
            System.Windows.Forms.ListView lstTags = this.lstTags;
            if (lstTags.SelectedItems.Count <= 0)
            {
                return;
            }

            if (DeviceTags != null)
            {
                ListViewItem selectedIndex = lstTags.SelectedItems[0];
                indexSelect = lstTags.SelectedIndices[0];
                Guid SelectTagID = DriverUtils.StringToGuid(selectedIndex.Tag.ToString());

                ProjectDeviceTag tmpTag = DeviceTags.Find((Predicate<ProjectDeviceTag>)(r => r.DeviceTagID == SelectTagID));
            }
        }
        #endregion Tag selection

        #region Tag Add

        private void tolTagAdd_Click(object sender, EventArgs e)
        {
            TagAdd();
        }

        private void TagAdd()
        {
            try
            {
                newTag = new ProjectDeviceTag();

                newTag.DeviceID = DeviceID;
                newTag.DeviceGroupTagID = DeviceGroupTagID;
                newTag.DeviceTagID = Guid.NewGuid();
                newTag.DeviceTagname = "";
                newTag.DeviceTagCode = "";
                newTag.DeviceTagDescription = "";
                newTag.DeviceTagEnabled = true;
                newTag.DeviceTagSorting = "";
                newTag.DeviceTagDataValue = 0;
                newTag.DeviceTagQuality = 0;
                newTag.DeviceTagCoefficient = 1;
                newTag.DeviceTagScaled = 0;
                newTag.DeviceTagScaledHigh = 1000;
                newTag.DeviceTagScaledLow = 0;
                newTag.DeviceTagRowHigh = 1000;
                newTag.DeviceTagRowLow = 0;

                TagAddData(ref newTag);

                tmrTimer.Enabled = false;

                myHelper.ShowPage(tabTagAddEdit);
                myHelper.HidePage(tabTags);

            }
            catch { }
        }

        private void TagAddData(ref ProjectDeviceTag newTag)
        {
            btnTagAdd.Visible = true;
            btnTagChange.Visible = false;

            txtTagID.Text = newTag.DeviceTagID.ToString();
            ckbTagEnabled.Checked = newTag.DeviceTagEnabled;
            txtTagname.Text = newTag.DeviceTagname;
            txtTagCode.Text = newTag.DeviceTagCode;
            txtTagDescription.Text = newTag.DeviceTagDescription;
            txtTagAddress.Text = newTag.DeviceTagAddress;
            txtCoefficient.Text = newTag.DeviceTagCoefficient.ToString();
            txtTagSorting.Text = newTag.DeviceTagSorting;

            try
            {
                cmbTagType.Items.Clear();
                cmbTagType.Items.AddRange(Enum.GetNames(typeof(ProjectDeviceTag.DeviceTagFormatData)));
                if (newTag.DeviceTagType != null)
                {
                    cmbTagType.SelectedIndex = cmbTagType.FindString(newTag.DeviceTagType.ToString());
                }
            }
            catch { }

            cmbScaled.SelectedIndex = newTag.DeviceTagScaled;
            txtLineScaledHigh.Text = newTag.DeviceTagScaledHigh.ToString();
            txtLineScaledLow.Text = newTag.DeviceTagScaledLow.ToString();
            txtLineScaledRowHigh.Text = newTag.DeviceTagRowHigh.ToString();
            txtLineScaledRowLow.Text = newTag.DeviceTagRowLow.ToString();
        }

        private void btnTagAdd_Click(object sender, EventArgs e)
        {
            myHelper.ShowPage(tabTags);
            myHelper.HidePage(tabTagAddEdit);

            tmrTimer.Enabled = true;

            newTag.DeviceTagAddress = txtTagAddress.Text;
            newTag.DeviceTagname = txtTagname.Text;
            newTag.DeviceTagCode = txtTagCode.Text;
            newTag.DeviceTagDescription = txtTagDescription.Text;
            newTag.DeviceTagType = cmbTagType.Text;
            newTag.DeviceTagSorting = txtTagSorting.Text;

            newTag.DeviceTagCoefficient = Convert.ToSingle(txtCoefficient.Text);
            newTag.DeviceTagScaled = cmbScaled.SelectedIndex;
            newTag.DeviceTagScaledHigh = Convert.ToSingle(txtLineScaledHigh.Text);
            newTag.DeviceTagScaledLow = Convert.ToSingle(txtLineScaledLow.Text);
            newTag.DeviceTagRowHigh = Convert.ToSingle(txtLineScaledRowHigh.Text);
            newTag.DeviceTagRowLow = Convert.ToSingle(txtLineScaledRowLow.Text);

            DeviceTags.Add(newTag);

            ConfigToControls();
        }

        #endregion Tag Add

        #region Tag Change

        private void tolTagChange_Click(object sender, EventArgs e)
        {
            TagChange();
        }

        private void lstTags_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TagChange();
        }

        private void TagChange()
        {
            try
            {
                System.Windows.Forms.ListView lstTags = this.lstTags;
                if (lstTags.SelectedItems.Count <= 0)
                {
                    return;
                }

                if (DeviceTags != null)
                {
                    ListViewItem selectedIndex = lstTags.SelectedItems[0];
                    indexSelect = lstTags.SelectedIndices[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedIndex.Tag.ToString());
                    changeTag = DeviceTags.Find((Predicate<ProjectDeviceTag>)(r => r.DeviceTagID == SelectTagID));

                    TagChangeData(ref changeTag);

                    tmrTimer.Enabled = false;

                    myHelper.ShowPage(tabTagAddEdit);
                    myHelper.HidePage(tabTags);
                }
            }
            catch { }
        }

        private void TagChangeData(ref ProjectDeviceTag changeTag)
        {
            btnTagAdd.Visible = false;
            btnTagChange.Visible = true;

            txtTagID.Text = changeTag.DeviceTagID.ToString();
            ckbTagEnabled.Checked = changeTag.DeviceTagEnabled;
            txtTagname.Text = changeTag.DeviceTagname;
            txtTagCode.Text = changeTag.DeviceTagCode;
            txtTagDescription.Text = changeTag.DeviceTagDescription;
            txtTagAddress.Text = changeTag.DeviceTagAddress;
            txtCoefficient.Text = changeTag.DeviceTagCoefficient.ToString();
            txtTagSorting.Text = changeTag.DeviceTagSorting;

            try
            {
                cmbTagType.Items.Clear();
                cmbTagType.Items.AddRange(Enum.GetNames(typeof(ProjectDeviceTag.DeviceTagFormatData)));
                if (changeTag.DeviceTagType != null)
                {
                    cmbTagType.SelectedIndex = cmbTagType.FindString(changeTag.DeviceTagType.ToString());
                }
            }
            catch { }

            cmbScaled.SelectedIndex = changeTag.DeviceTagScaled;
            txtLineScaledHigh.Text = changeTag.DeviceTagScaledHigh.ToString();
            txtLineScaledLow.Text = changeTag.DeviceTagScaledLow.ToString();
            txtLineScaledRowHigh.Text = changeTag.DeviceTagRowHigh.ToString();
            txtLineScaledRowLow.Text = changeTag.DeviceTagRowLow.ToString();
        }

        private void btnTagChange_Click(object sender, EventArgs e)
        {
            myHelper.ShowPage(tabTags);
            myHelper.HidePage(tabTagAddEdit);

            tmrTimer.Enabled = true;

            changeTag.DeviceTagAddress = txtTagAddress.Text;
            changeTag.DeviceTagname = txtTagname.Text;
            changeTag.DeviceTagCode = txtTagCode.Text;
            changeTag.DeviceTagDescription = txtTagDescription.Text;
            changeTag.DeviceTagType = cmbTagType.Text;
            changeTag.DeviceTagSorting = txtTagSorting.Text;

            changeTag.DeviceTagCoefficient = Convert.ToSingle(txtCoefficient.Text);
            changeTag.DeviceTagScaled = cmbScaled.SelectedIndex;
            changeTag.DeviceTagScaledHigh = Convert.ToSingle(txtLineScaledHigh.Text);
            changeTag.DeviceTagScaledLow = Convert.ToSingle(txtLineScaledLow.Text);
            changeTag.DeviceTagRowHigh = Convert.ToSingle(txtLineScaledRowHigh.Text);
            changeTag.DeviceTagRowLow = Convert.ToSingle(txtLineScaledRowLow.Text);

            ConfigToControls();

            // scroll through
            this.lstTags.EnsureVisible(indexSelect);
            this.lstTags.TopItem = this.lstTags.Items[indexSelect];
            // making the area active
            this.lstTags.Focus();
            // making the desired element selected
            this.lstTags.Items[indexSelect].Selected = true;
            this.lstTags.Select();
        }

        #endregion Изменение тега

        #region Tag Cancel

        private void btnTagCancel_Click(object sender, EventArgs e)
        {
            myHelper.ShowPage(tabTags);
            myHelper.HidePage(tabTagAddEdit);

            tmrTimer.Enabled = true;

            newTag = new ProjectDeviceTag();
            changeTag = new ProjectDeviceTag();
        }

        #endregion Tag Cancel

        #region Tag Delete

        private void tolTagDelete_Click(object sender, EventArgs e)
        {
            TagDelete();
        }

        private void lstTags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TagDelete();
            }
        }

        private void TagDelete()
        {
            try
            {
                System.Windows.Forms.ListView lstTags = this.lstTags;
                if (lstTags.SelectedItems.Count <= 0)
                {
                    return;
                }

                if (DeviceTags != null)
                {
                    ListViewItem selectedIndex = lstTags.SelectedItems[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedIndex.Tag.ToString());

                    ProjectDeviceTag tmpTag = DeviceTags.Find((Predicate<ProjectDeviceTag>)(r => r.DeviceTagID == SelectTagID));
                    indexSelect = DeviceTags.IndexOf(DeviceTags.Where(n => n.DeviceTagID == SelectTagID).FirstOrDefault());

                    try
                    {
                        if (lstTags.Items.Count > 0)
                        {
                            DeviceTags.Remove(tmpTag);
                            lstTags.Items.Remove(this.selectedItem);
                        }

                        //Обновляем информацию
                        ConfigToControls();

                        //Прокручиваем
                        this.lstTags.EnsureVisible(indexSelect - 1);
                        this.lstTags.TopItem = this.lstTags.Items[indexSelect - 1];
                        //Делаем область активной
                        this.lstTags.Focus();
                        //Делаю нужный элемент выбранным
                        this.lstTags.Items[indexSelect - 1].Selected = true;
                        this.lstTags.Select();
                    }
                    catch { }
                }
            }
            catch { }
        }

        #endregion  Tag Delete

        #region Tag list delete
        private void tolTagDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceTags.Clear();

                ConfigToControls();
            }
            catch { }
        }
        #endregion Tag list delete

        #region Tag Up
        private void tolTagUp_Click(object sender, EventArgs e)
        {
            TagUp();
        }

        private void TagUp()
        {
            // an item must be selected
            System.Windows.Forms.ListView tmplstTags = this.lstTags;
            if (tmplstTags.SelectedItems.Count <= 0)
            {
                return;
            }

            if (lstTags.SelectedItems.Count > 0)
            {
                if (deviceTags != null)
                {
                    ListViewExtensions.MoveListViewItems(lstTags, MoveDirection.Up);
                    selectedItem = tmplstTags.SelectedItems[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedItem.Tag.ToString());

                    ProjectDeviceTag tmpTag = deviceTags.Find((Predicate<ProjectDeviceTag>)(r => r.DeviceTagID == SelectTagID));
                    indexSelect = deviceTags.IndexOf(deviceTags.Where(n => n.DeviceTagID == SelectTagID).FirstOrDefault());

                    if (indexSelect == 0)
                    {
                        return;
                    }
                    else
                    {
                        deviceTags.Reverse(indexSelect - 1, 2);
                    }
                }
            }


            //// an item must be selected
            //System.Windows.Forms.ListView lstTags = this.lstTags;
            //if (lstTags.SelectedItems.Count <= 0)
            //{
            //    return;
            //}

            //if (this.lstTags.SelectedItems.Count > 0)
            //{
            //    ListViewItem selected = lstTags.SelectedItems[0];
            //    Guid SelectTagID = DriverUtils.StringToGuid(selected.Tag.ToString());

            //    ProjectDeviceTag tmpTag = DeviceTags.Find((Predicate<ProjectDeviceTag>)(r => r.DeviceTagID == SelectTagID));
            //    indexSelect = DeviceTags.IndexOf(DeviceTags.Where(n => n.DeviceTagID == SelectTagID).FirstOrDefault());

            //    int total = this.lstTags.Items.Count;
            //    // if the item is right at the top, throw it right down to the bottom
            //    if (indexSelect == 0)
            //    {
            //        this.lstTags.Items.Remove(selected);
            //        this.lstTags.Items.Insert(total - 1, selected);
            //        //lstTags.SetSelected(total - 1, true);
            //    }
            //    else // to move the selected item upwards in the listbox
            //    {
            //        this.lstTags.Items.Remove(selected);
            //        this.lstTags.Items.Insert(indexSelect - 1, selected);
            //        //lstTags.SetSelected(index - 1, true);
            //    }
            //}
        }

        #endregion Tag Up

        #region Tag Down

        private void tolTagDown_Click(object sender, EventArgs e)
        {
            TagDown();
        }

        private void TagDown()
        {
            System.Windows.Forms.ListView tmplstTags = this.lstTags;
            if (tmplstTags.SelectedItems.Count <= 0)
            {
                return;
            }

            // an item must be selected
            if (lstTags.SelectedItems.Count > 0)
            {
                if (deviceTags != null)
                {
                    ListViewExtensions.MoveListViewItems(lstTags, MoveDirection.Down);

                    selectedItem = tmplstTags.SelectedItems[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedItem.Tag.ToString());

                    ProjectDeviceTag tmpTag = deviceTags.Find((Predicate<ProjectDeviceTag>)(r => r.DeviceTagID == SelectTagID));
                    indexSelect = deviceTags.IndexOf(deviceTags.Where(n => n.DeviceTagID == SelectTagID).FirstOrDefault());

                    if (indexSelect == deviceTags.Count - 1)
                    {
                        return;
                    }
                    else
                    {
                        deviceTags.Reverse(indexSelect, 2);
                    }
                }
            }


            //System.Windows.Forms.ListView lstTags = this.lstTags;
            //if (lstTags.SelectedItems.Count <= 0)
            //{
            //    return;
            //}


            //// an item must be selected
            //if (this.lstTags.SelectedItems.Count > 0)
            //{
            //    ListViewItem selected = lstTags.SelectedItems[0];
            //    Guid SelectTagID = DriverUtils.StringToGuid(selected.Tag.ToString());

            //    ProjectDeviceTag tmpTag = DeviceTags.Find((Predicate<ProjectDeviceTag>)(r => r.DeviceTagID == SelectTagID));
            //    indexSelect = DeviceTags.IndexOf(DeviceTags.Where(n => n.DeviceTagID == SelectTagID).FirstOrDefault());

            //    int total = this.lstTags.Items.Count;
            //    // if the item is last in the listbox, move it all the way to the top
            //    if (indexSelect == total - 1)
            //    {
            //        this.lstTags.Items.Remove(selected);
            //        this.lstTags.Items.Insert(0, selected);
            //    }
            //    else // to move the selected item downwards in the listbox
            //    {
            //        this.lstTags.Items.Remove(selected);
            //        this.lstTags.Items.Insert(indexSelect + 1, selected);
            //    }
            //}
        }

        #endregion Tag Down

        #region CSV
        //Загрузка данных из CSV
        private void tolDataLoadAsCSV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите загрузить\r\nданные из файла?", "Вопрос", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataLoadAsCSV();
            }
        }

        private void DataLoadAsCSV()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Загрузить данные...";
            OFD.Filter = "CSV (*.csv)|*.csv|Все файлы (*.*)|*.*";
            OFD.InitialDirectory = System.IO.Path.Combine(Application.StartupPath);

            if (OFD.ShowDialog() == DialogResult.OK && OFD.FileName != "")
            {
                try
                {
                    //Открываем
                    string FileName = OFD.FileName;
                    ProjectDeviceGroupTag deviceGroupTag = new ProjectDeviceGroupTag();

                    #region Загрузка
                    Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
                    splashthread.IsBackground = true;
                    splashthread.Start();

                    Application.DoEvents();
                    SplashScreen.UdpateStatusText(1, "Загрузка...");
                    SplashScreen.UdpateStatusText(2, "Считывание данных из файла:");
                    SplashScreen.UdpateStatusText(3, "");
                    Application.DoEvents();

                    DataTable data = CSV.Import(FileName, true, ";", "UTF8");
                    List<ProjectDeviceTag> tags = deviceGroupTag.ConvertDataTableToListTags(data);

                    foreach (ProjectDeviceTag tmpTag in tags)
                    {
                        DeviceTags.Add(tmpTag);
                    }

                    foreach (ProjectDeviceTag tmpTag in DeviceTags)
                    {
                        tmpTag.DeviceID = DeviceID;
                        tmpTag.DeviceGroupTagID = DeviceGroupTagID;
                    }

                    Application.DoEvents();
                    SplashScreen.CloseSplashScreen();
                    this.Show();
                    #endregion Загрузка

                    ConfigToControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные по причине:\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto END_VOID;
                }
            END_VOID:
                try { } catch { }
            }
        }

        //Сохранить данные как CSV
        private void tolDataSaveAsCSV_Click(object sender, EventArgs e)
        {
            DataSaveAsCSV();
        }

        private void DataSaveAsCSV()
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Title = "Выгрузить данные...";
            SFD.Filter = "CSV (*.csv)|*.csv|Все файлы (*.*)|*.*";
            SFD.InitialDirectory = System.IO.Path.Combine(Application.StartupPath);

            if (SFD.ShowDialog() == DialogResult.OK && SFD.FileName != "")
            {
                //Сохраняем
                string FileName = SFD.FileName;
                ProjectDeviceGroupTag projectDeviceGroupTag = new ProjectDeviceGroupTag();
                DataTable data = projectDeviceGroupTag.ConvertListTagsToDataTable(DeviceTags);

                CSV.Export(FileName, data, true, ";", "UTF8");
            }
        }

        #endregion CSV

        #region Timer

        private void lblTimerInfo_Click(object sender, EventArgs e)
        {
            nudTimerInfo.Value = Convert.ToUInt16(TimeRefresh);
            nudTimerInfo.Visible = true;
            btnTimerInfo.Visible = true;
        }

        private void btnTimerInfo_Click(object sender, EventArgs e)
        {
            TimeRefresh = Convert.ToDouble(nudTimerInfo.Value);
            nudTimerInfo.Visible = false;
            btnTimerInfo.Visible = false;
        }


        //Включаем и выключаем таймер
        private void ckbAutoRefreshListRegisters_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAutoRefreshListTags.Checked == true)
            {
                tmrEndTime = DateTime.Now.AddMilliseconds(TimeRefresh);
                tmrTimer.Enabled = true;
                tmrStatus = true;
            }
            else if (ckbAutoRefreshListTags.Checked == false)
            {
                tmrTimer.Enabled = false;
                tmrStatus = false;
            }
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan leftTime = tmrEndTime.Subtract(DateTime.Now);
            if (leftTime.TotalSeconds < 0)
            {
                CountDownTimerString = "00:00:00";
                lblTimerInfo.Text = CountDownTimerString;
                Refresh();
                tmrTimer.Stop();

                //Обновляем информацию
                tmrTimer_InfoDeviceTagRefresh();

                if (tmrStatus == true)
                {
                    tmrEndTime = DateTime.Now.AddMilliseconds(TimeRefresh);
                    tmrTimer.Enabled = true;
                }
            }
            else
            {
                CountDownTimerString = leftTime.Hours.ToString("00") + ":" + leftTime.Minutes.ToString("00") + ":" + leftTime.Seconds.ToString("00") + "." + leftTime.Milliseconds.ToString("000");
                lblTimerInfo.Text = CountDownTimerString;
                Refresh();
            }
        }

        void tmrTimer_InfoDeviceTagRefresh()
        {
            try
            {
                #region Перессчёт тега
                System.Windows.Forms.ListView lstTags = this.lstTags;

                //Обновление без мерцания
                Type type = this.lstTags.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(this.lstTags, true, (object[])null);

                for (int index = 0; index < lstTags.Items.Count; ++index)
                {
                    Application.DoEvents();
                    ListViewItem TagItem = lstTags.Items[index];
                    Guid SelectTagID = (Guid)TagItem.Tag;
                    ProjectDeviceTag tmpTag = DeviceTags.Find((Predicate<ProjectDeviceTag>)(r => r.DeviceTagID == SelectTagID));
                    if (tmpTag == null)
                    {
                        continue;
                    }

                    //Провели расчеты в классе Tag
                    //ProjectDeviceTag.GetValue(ref tmpTag);

                    //Обновили инфорамцию
                    TagItem.Text = tmpTag.DeviceTagname;
                    TagItem.Tag = tmpTag.DeviceTagID;
                    TagItem.SubItems[0].Text = DriverUtils.NullToString(tmpTag.DeviceTagname);
                    TagItem.SubItems[1].Text = DriverUtils.NullToString(tmpTag.DeviceTagType);
                    TagItem.SubItems[2].Text = DriverUtils.NullToString(tmpTag.DeviceTagDataValue);
                    TagItem.SubItems[3].Text = DriverUtils.NullToString(tmpTag.DeviceTagDateTime);
                    TagItem.SubItems[4].Text = DriverUtils.NullToString(tmpTag.DeviceTagQuality);
                    TagItem.SubItems[5].Text = DriverUtils.NullToString(tmpTag.DeviceTagDescription);
                    Application.DoEvents();
                }
                #endregion Перессчёт тега
            }
            catch
            { }
        }

        #endregion Timer

        #region Sorting
        private void tolTagSortDefault_Click(object sender, EventArgs e)
        {
            SortingMethod = 0;

            ConfigToControls();
        }

        private void tolTagSortTagAddress_Click(object sender, EventArgs e)
        {
            switch (SortingMethod)
            {
                case 0:
                    SortingMethod = 1;
                    break;
                case 1:
                    SortingMethod = -1;
                    break;
                case -1:
                    SortingMethod = 1;
                    break;
                default:
                    SortingMethod = 0;
                    break;
            }

            ConfigToControls();
        }

        private void tolTagSortTagName_Click(object sender, EventArgs e)
        {
            switch (SortingMethod)
            {
                case 0:
                    SortingMethod = 2;
                    break;
                case 2:
                    SortingMethod = -2;
                    break;
                case -2:
                    SortingMethod = 2;
                    break;
                default:
                    SortingMethod = 0;
                    break;
            }

            ConfigToControls();
        }

        private void tolTagSortTagAddressDescription_Click(object sender, EventArgs e)
        {
            switch (SortingMethod)
            {
                case 0:
                    SortingMethod = 3;
                    break;
                case 3:
                    SortingMethod = -3;
                    break;
                case -3:
                    SortingMethod = 3;
                    break;
                default:
                    SortingMethod = 0;
                    break;
            }

            ConfigToControls();
        }

        private void tolTagSortTagType_Click(object sender, EventArgs e)
        {
            switch (SortingMethod)
            {
                case 0:
                    SortingMethod = 4;
                    break;
                case 4:
                    SortingMethod = -4;
                    break;
                case -4:
                    SortingMethod = 4;
                    break;
                default:
                    SortingMethod = 0;
                    break;
            }

            ConfigToControls();
        }

        private void tolTagSortTagValue_Click(object sender, EventArgs e)
        {
            switch (SortingMethod)
            {
                case 0:
                    SortingMethod = 5;
                    break;
                case 5:
                    SortingMethod = -5;
                    break;
                case -5:
                    SortingMethod = 5;
                    break;
                default:
                    SortingMethod = 0;
                    break;
            }

            ConfigToControls();
        }

        #endregion Sorting

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

        //#region Импорт тегов из шаблона
        //private void tolTagImport_Click(object sender, EventArgs e)
        //{
        //    Tags_Import();
        //}

        //private void Tags_Import()
        //{
        //    try
        //    {
        //        List<ProjectDeviceTag> tmp_ListTag = new List<ProjectDeviceTag>();
        //        frm_GroupTagImport InputBox = new frm_GroupTagImport();
        //        InputBox.Tags = tmp_ListTag;
        //        InputBox.FormParent = this;
        //        InputBox.ShowDialog();

        //        if (InputBox.DialogResult == DialogResult.OK)
        //        {
        //            //Получаем количество записей и записываем в массив
        //            tmp_ListTag = InputBox.Tags;

        //            for (int i = 0; i < tmp_ListTag.Count; i++)
        //            {
        //                ProjectDeviceTag tmp_Tag = tmp_ListTag[i];
        //                tmp_Tag.TagID = Guid.NewGuid();
        //                ListTag.Add(tmp_Tag);
        //            }

        //            //Обновляем информацию
        //            SetConfig();
        //        }
        //    }
        //    catch { }
        //}

        //#endregion Импорт тегов из шаблона

    }
}
