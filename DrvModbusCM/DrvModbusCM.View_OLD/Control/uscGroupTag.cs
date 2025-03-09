
using System.Data;
using System.Reflection;
using DrvModbusCM.Form.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscGroupTag : UserControl
    {
        public uscGroupTag()
        {
            InitializeComponent();
        }

        #region Variables

        #region Form
        public FrmConfigForm frmParentGloabal;        // global general form
        public uscGroupTag uscParent;                 // usercontrol

        public bool modified;                          // the configuration was modified

        #endregion Form

        #region Group Tags

        private ProjectNodeData mtNodeData;
        public ProjectNodeData MTNodeData
        {
            get { return mtNodeData; }
            set { mtNodeData = value; }
        }

        private ListViewItem selectedItem;  //Выбранная запись
        public int indexSelect = 0;         //Номер индекса
        public int SortingMethod = 0;       //Способ Сортировки

        private TabPage previusTab;         // previus tab

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

        //Иконка устройства
        private string groupTagKeyImage;
        public string KeyImage
        {
            get { return groupTagKeyImage; }
            set { groupTagKeyImage = value; }
        }

        //Название группы тегов
        private string groupTagName;
        public string GroupTagName
        {
            get { return groupTagName; }
            set { groupTagName = value; }
        }

        //Описание группы тегов
        private string groupTagDescription;
        public string DeviceGroupTagDescription
        {
            get { return groupTagDescription; }
            set { groupTagDescription = value; }
        }

        //Состояние группы тегов
        private bool groupTagEnabled;
        public bool DeviceGroupTagEnabled
        {
            get { return groupTagEnabled; }
            set { groupTagEnabled = value; }
        }

        // update
        private int groupTagUpdateRate;
        public int DeviceGroupTagUpdateRate
        {
            get { return groupTagUpdateRate; }
            set { groupTagUpdateRate = value; }
        }

        ProjectTag newTag;
        ProjectTag changeTag;

        #endregion Group Tags

        #region Список тегов

        private List<ProjectTag> tags;
        public List<ProjectTag> DeviceTags
        {
            get { return tags; }
            set { tags = value; }
        }

        public static List<ProjectTag> Tags { get; set; }

        public static List<ProjectTag> DefaultSortTags { get; set; }

        #endregion Список тегов

        #region Timer
        DateTime tmrEndTime = new DateTime();
        private bool tmrStatus = false;
        private string CountDownTimerString = string.Empty;
        private double TimeRefresh = 3000d;
        #endregion Timer

        #region Driver

        DriverClient client;

        #endregion Driver

        #region Modbus

        /// <summary>
        /// Item Value Result 
        /// </summary>
        private static object[] resultsValue;
        public static object[] ResultsValue
        {
            get { return resultsValue; }
            set { resultsValue = value; }
        }

        #endregion Modbus

        #region Splash
        SplashScreen fSS = new SplashScreen();
        Thread splashthread;
        #endregion Splash


        #region ListView

        private ColumnHeader SortingColumn = null;

        #endregion ListView

        #endregion Variables

        #region Splash
        SplashScreen sf = new SplashScreen();
        #endregion Splash

        #region TabHelper
        public TabControlHelper myHelper;
        #endregion TabHelper

        #region Load

        public uscGroupTag(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            //DeviceID = MTNodeData.groupTag.DeviceID;
            //DeviceGroupTagID = MTNodeData.groupTag.DeviceGroupTagID;

            GroupTagName = MTNodeData.groupTag.GroupTagName;
            DeviceGroupTagDescription = MTNodeData.groupTag.DeviceGroupTagDescription;
            DeviceGroupTagEnabled = MTNodeData.groupTag.DeviceGroupTagEnabled;

            if (MTNodeData.groupTag.DeviceTags == null)
            {
                DefaultSortTags = DeviceTags = new List<ProjectTag>();
            }
            else
            {
                DefaultSortTags = DeviceTags = MTNodeData.groupTag.DeviceTags;
            }

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

                // hide tab tag
                myHelper = new TabControlHelper(tabDeviceTag);
                myHelper.HideAllPages();
                ShowPage(tabTags);
                ShowPage(tabMonitoring);
                // activate tab
                tabDeviceTag.SelectTab(tabTags);

            }
        }

        private void uscGroupTag_Load(object sender, EventArgs e)
        {
            ConfigToControls();
            Modified = false;
        }

        private void ConfigToControls()
        {
            txtNameGroupTag.Text = GroupTagName;
            ckbEnabled.Checked = DeviceGroupTagEnabled;

            //Теги
            if (DeviceTags != null && DeviceTags.Count > 0)
            {
                //Обновление без мерцания
                Type type = lstTags.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(lstTags, true, null);

                this.lstTags.BeginUpdate();
                this.lstTags.Items.Clear();

                #region Отображение данных

                //Способ сортировки
                List<ProjectTag> DeviceTagsSort = new List<ProjectTag>();

                switch (SortingMethod)
                {
                    case 0: //По умолчанию
                        DeviceTagsSort = DefaultSortTags;
                        break;
                    case 1: //По адресу
                        DeviceTagsSort = DeviceTags.OrderBy(o => o.DeviceTagAddress).ToList();
                        break;
                    case -1:  //По адресу 
                        DeviceTagsSort = DeviceTags.OrderByDescending(o => o.DeviceTagAddress).ToList();
                        break;
                    case 2:  //По названию
                        DeviceTagsSort = DeviceTags.OrderBy(o => o.DeviceTagName).ToList();
                        break;
                    case -2:  //По названию
                        DeviceTagsSort = DeviceTags.OrderByDescending(o => o.DeviceTagName).ToList();
                        break;
                    case 3: //По описанию
                        DeviceTagsSort = DeviceTags.OrderBy(o => o.DeviceTagDescription).ToList();
                        break;
                    case -3: //По описанию
                        DeviceTagsSort = DeviceTags.OrderByDescending(o => o.DeviceTagDescription).ToList();
                        break;
                    case 4: //По типу
                        DeviceTagsSort = DeviceTags.OrderBy(o => o.DeviceTagType).ToList();
                        break;
                    case -4: //По типу
                        DeviceTagsSort = DeviceTags.OrderByDescending(o => o.DeviceTagType).ToList();
                        break;
                    case 5: //По значению
                        DeviceTagsSort = DeviceTags.OrderBy(o => o.DeviceTagDataValue).ToList();
                        break;
                    case -5: //По значению
                        DeviceTagsSort = DeviceTags.OrderByDescending(o => o.DeviceTagDataValue).ToList();
                        break;
                    default: //По  умолчанию
                        DeviceTagsSort = DefaultSortTags;
                        break;
                }

                foreach (var tmpTag in DeviceTagsSort)
                {
                    if (tmpTag == null)
                    {
                        continue;
                    }

                    //Вставили инфорамцию
                    this.lstTags.Items.Add(new ListViewItem()
                    {
                        //Название тега
                        Text = tmpTag.DeviceTagName,
                        SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.DeviceTagCode),
                                DriverUtils.NullToString(tmpTag.DeviceTagAddress),
                                DriverUtils.NullToString(tmpTag.DeviceTagDescription),
                                DriverUtils.NullToString(tmpTag.DeviceTagType),
                                DriverUtils.NullToString(DriverUtils.IsGuid(tmpTag.DeviceTagCommandID.ToString())),
                                DriverUtils.NullToString(tmpTag.DeviceTagEnabled),
                            }
                    }).Tag = tmpTag.DeviceTagID; //В Tag передаём ID тега..., чтобы можно было найти
                }
                #endregion Отображение данных

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            Modified = false;
            ConfigToControls();
        }

        private void Save()
        {
            ControlsToConfig();

            if (GroupTagName == "")
            {
                MessageBox.Show(DriverDictonary.WarningEmpty);
                return;
            }
            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
            TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            //projectNodeData.groupTag.DeviceGroupTagID = DeviceGroupTagID;
            //projectNodeData.groupTag.GroupTagName = GroupTagName;
            //projectNodeData.groupTag.DeviceGroupTagDescription = DeviceGroupTagDescription;
            //projectNodeData.groupTag.DeviceGroupTagEnabled = DeviceGroupTagEnabled;
            //projectNodeData.groupTag.DeviceTags = DeviceTags;

            stn.Text = GroupTagName;
            stn.Tag = projectNodeData;

            stn.Nodes.Clear();
            FrmConfigForm frmConfigForm = new FrmConfigForm();

            foreach (ProjectTag projectTag in DeviceTags)
            {
                frmConfigForm.NodeDeviceTagAdd(projectTag, stn, null);
            }
        }

        private void ControlsToConfig()
        {
            GroupTagName = txtNameGroupTag.Text;
            DeviceTags = tags;
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

        #region Tag Refresh

        private void tolRefresh_Click(object sender, EventArgs e)
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

                ProjectTag tmpTag = DeviceTags.Find((Predicate<ProjectTag>)(r => r.DeviceTagID == SelectTagID));
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
                newTag = new ProjectTag();

                newTag.DeviceID = DeviceID;
                newTag.DeviceGroupTagID = DeviceGroupTagID;
                newTag.DeviceTagID = Guid.NewGuid();
                newTag.DeviceTagName = "";
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
                newTag.KeyImage = "tag_16.png";

                // create
                ProjectNodeData ProjectNodeDataTag = new ProjectNodeData();
                ProjectNodeDataTag.tag = newTag;
                ProjectNodeDataTag.nodeType = ProjectNodeType.DeviceTag;
                // created a form
                FrmTag frmTag = new FrmTag(ref ProjectNodeDataTag, false);
                frmTag.frmParentGloabal = frmParentGloabal;
                // showing the form
                DialogResult dialog = frmTag.ShowDialog();
                // if you have closed the form, click OK
                if (DialogResult.OK == dialog)
                {
                    DeviceTags.Add(ProjectNodeDataTag.tag);

                    Modified = true;

                    ConfigToControls();
                }
            }
            catch { }
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
                    changeTag = DeviceTags.Find((Predicate<ProjectTag>)(r => r.DeviceTagID == SelectTagID));

                    // create
                    ProjectNodeData ProjectNodeDataTag = new ProjectNodeData();
                    ProjectNodeDataTag.tag = changeTag;
                    ProjectNodeDataTag.nodeType = ProjectNodeType.DeviceTag;
                    // created a form
                    FrmTag frmTag = new FrmTag(ref ProjectNodeDataTag, false);
                    frmTag.frmParentGloabal = frmParentGloabal;
                    // showing the form
                    DialogResult dialog = frmTag.ShowDialog();
                    // if you have closed the form, click OK
                    if (DialogResult.OK == dialog)
                    {
                        changeTag = ProjectNodeDataTag.tag;

                        Modified = true;

                        ConfigToControls();
                    }
                }
            }
            catch { }
        }
        #endregion Изменение тега

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

                    ProjectTag tmpTag = DeviceTags.Find((Predicate<ProjectTag>)(r => r.DeviceTagID == SelectTagID));
                    indexSelect = DeviceTags.IndexOf(DeviceTags.Where(n => n.DeviceTagID == SelectTagID).FirstOrDefault());

                    try
                    {
                        if (lstTags.Items.Count > 0)
                        {
                            DeviceTags.Remove(tmpTag);
                            lstTags.Items.Remove(this.selectedItem);
                        }

                        Modified = true;

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

                Modified = true;

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
                if (tags != null)
                {
                    ListViewExtensions.MoveListViewItems(lstTags, MoveDirection.Up);
                    selectedItem = tmplstTags.SelectedItems[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedItem.Tag.ToString());

                    ProjectTag tmpTag = tags.Find((Predicate<ProjectTag>)(r => r.DeviceTagID == SelectTagID));
                    indexSelect = tags.IndexOf(tags.Where(n => n.DeviceTagID == SelectTagID).FirstOrDefault());

                    if (indexSelect == 0)
                    {
                        return;
                    }
                    else
                    {
                        tags.Reverse(indexSelect - 1, 2);
                    }

                    Modified = true;
                }
            }
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
                if (tags != null)
                {
                    ListViewExtensions.MoveListViewItems(lstTags, MoveDirection.Down);

                    selectedItem = tmplstTags.SelectedItems[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedItem.Tag.ToString());

                    ProjectTag tmpTag = tags.Find((Predicate<ProjectTag>)(r => r.DeviceTagID == SelectTagID));
                    indexSelect = tags.IndexOf(tags.Where(n => n.DeviceTagID == SelectTagID).FirstOrDefault());

                    if (indexSelect == tags.Count - 1)
                    {
                        return;
                    }
                    else
                    {
                        tags.Reverse(indexSelect, 2);
                    }

                    Modified = true;
                }
            }
        }

        #endregion Tag Down

        #region CSV
        // loading data from CSV
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
                    ProjectGroupTag groupTag = new ProjectGroupTag();

                    #region Загрузка
                    Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
                    splashthread.IsBackground = true;
                    splashthread.Start();

                    Application.DoEvents();
                    SplashScreen.UdpateStatusText(1, "Загрузка...");
                    SplashScreen.SetStatus("Считывание данных из файла:");
                    SplashScreen.UdpateStatusText(3, "");
                    Application.DoEvents();

                    DataTable data = CSV.Import(FileName, true, ";", "UTF8");
                    List<ProjectTag> tags = groupTag.ConvertDataTableToListTags(data);

                    foreach (ProjectTag tmpTag in tags)
                    {
                        DeviceTags.Add(tmpTag);
                    }

                    foreach (ProjectTag tmpTag in DeviceTags)
                    {
                        tmpTag.DeviceID = DeviceID;
                        tmpTag.DeviceGroupTagID = DeviceGroupTagID;
                    }

                    Application.DoEvents();
                    SplashScreen.CloseForm();
                    this.Show();
                    #endregion Загрузка

                    Modified = true;

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

        // save data as CSV
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
                ProjectGroupTag projectGroupTag = new ProjectGroupTag();
                DataTable data = projectGroupTag.ConvertListTagsToDataTable(DeviceTags);

                CSV.Export(FileName, data, true, ";", "UTF8");
            }
        }

        #endregion CSV

        #region Timer

        private void lblTimerInfo_Click(object sender, EventArgs e)
        {
            //nudTimerInfo.Value = Convert.ToUInt16(TimeRefresh);
            //nudTimerInfo.Visible = true;
            //btnTimerInfo.Visible = true;
        }

        private void btnTimerInfo_Click(object sender, EventArgs e)
        {
            //TimeRefresh = Convert.ToDouble(nudTimerInfo.Value);
            //nudTimerInfo.Visible = false;
            //btnTimerInfo.Visible = false;
        }


        //Включаем и выключаем таймер
        private void ckbAutoRefreshListRegisters_CheckedChanged(object sender, EventArgs e)
        {
            //if (ckbAutoRefreshListTags.Checked == true)
            //{
            //    tmrEndTime = DateTime.Now.AddMilliseconds(TimeRefresh);
            //    tmrTimer.Enabled = true;
            //    tmrStatus = true;
            //}
            //else if (ckbAutoRefreshListTags.Checked == false)
            //{
            //    tmrTimer.Enabled = false;
            //    tmrStatus = false;
            //}
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan leftTime = tmrEndTime.Subtract(DateTime.Now);
            if (leftTime.TotalSeconds < 0)
            {
                CountDownTimerString = "00:00:00";
                //lblTimerInfo.Text = CountDownTimerString;
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
                //lblTimerInfo.Text = CountDownTimerString;
                Refresh();
            }
        }

        void tmrTimer_InfoDeviceTagRefresh()
        {
            try
            {
                #region Перессчёт тега
                System.Windows.Forms.ListView lstMonitoring = this.lstMonitoring;

                //Обновление без мерцания
                Type type = this.lstMonitoring.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(this.lstMonitoring, true, (object[])null);

                for (int index = 0; index < lstMonitoring.Items.Count; ++index)
                {
                    Application.DoEvents();
                    ListViewItem TagItem = lstMonitoring.Items[index];
                    Guid SelectTagID = (Guid)TagItem.Tag;
                    ProjectTag tmpTag = DeviceTags.Find((Predicate<ProjectTag>)(r => r.DeviceTagID == SelectTagID));
                    if (tmpTag == null)
                    {
                        continue;
                    }

                    //Провели расчеты в классе Tag
                    //ProjectTag.GetValue(ref tmpTag);

                    //Обновили инфорамцию
                    TagItem.Text = tmpTag.DeviceTagName;
                    TagItem.Tag = tmpTag.DeviceTagID;
                    TagItem.SubItems[0].Text = DriverUtils.NullToString(tmpTag.DeviceTagName);
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

        private void tolTagSortTagDescription_Click(object sender, EventArgs e)
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

        #region TabPage

        private void tabDeviceTag_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            previusTab = tabDeviceTag.SelectedTab;
        }

        private void tabDeviceTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabDeviceTag.SelectedTab == tabMonitoring)
                {
                    //#region Start OPC

                    //if (previusTab == tabTags)
                    //{
                    //    DeviceTagsToMonitoring();
                    //}

                    //if (device == null)
                    //{
                    //    return;
                    //}

                    //if (client.Server == null || !client.Server.IsConnected)
                    //{
                    //    fSS = new SplashScreen();
                    //    Thread splashthread = new Thread(new ThreadStart(fSS.ShowSplashScreen));
                    //    splashthread.IsBackground = true;
                    //    splashthread.Start();

                    //    Application.DoEvents();
                    //    fSS.UdpateStatusText(1, DriverDictonary.OPCInitialization);
                    //    Application.DoEvents();

                    //    //client = new DriverClient();
                    //    DriverClient.OnOPCData = new DriverClient.OPCData(ShowDataOPC);
                    //    DriverClient.OnDebug = new DriverClient.DebugData(LogGet);

                    //    client.DeviceGroupTags = (ProjectGroupTag)MTNodeData.groupTag;
                    //    client.GroupTypSubscription = DeviceGroupTagTypSubscription;
                    //    client.UserLogin = device.UserLogin;
                    //    client.UserPassword = device.UserPassword;
                    //    client.Domain = device.Domain;
                    //    client.ProxyAddress = device.ProxyAddress;
                    //    client.UrlOPC = device.UrlOPC;
                    //    client.SpecificationName = device.SpecificationName;
                    //    LogGet("[" + DriverDictonary.DriverClientDeviceTransmittingParameters + "]");
                    //    client.InitializingOPCserver();
                    //    LogGet("[" + DriverDictonary.DriverClientInitialization + "]");
                    //    if (client.InitializingOPCserver())
                    //    {
                    //        LogGet("[" + DriverDictonary.OPCInitialization + "][" + DriverDictonary.Successfully + "]");
                    //    }
                    //    else
                    //    {
                    //        LogGet("[" + DriverDictonary.OPCInitialization + "][" + DriverDictonary.Unsuccessful + "]");
                    //    }

                    //    Application.DoEvents();
                    //    fSS.CloseSplashScreen();
                    //    this.Show();
                    //}
                    //#endregion Start OPC

                    if (DeviceGroupTagEnabled)
                    {
                        tmrEndTime = DateTime.Now.AddMilliseconds(DeviceGroupTagUpdateRate);

                        if (DeviceGroupTagUpdateRate > 0)
                        {
                            tmrTimer.Interval = 100;
                            TimeRefresh = Convert.ToDouble(DeviceGroupTagUpdateRate);
                        }
                        else
                        {
                            tmrTimer.Interval = 100;
                            TimeRefresh = Convert.ToDouble(1000);
                        }

                        tmrTimer.Enabled = true;
                        tmrStatus = true;
                    }
                    else
                    {
                        tmrTimer.Enabled = false;
                        tmrStatus = false;
                    }


                }
                else if (tabDeviceTag.SelectedTab != tabMonitoring && tabDeviceTag.SelectedTab != tabLog)
                {
                    tmrTimer.Enabled = false;
                    tmrStatus = false;
                }
            }
            catch (Exception ex)
            {
                fSS.CloseSplashScreen();
                this.Show();

                MessageBox.Show(DriverUtils.InfoError(ex));
            }
        }


        private void DeviceTagsToMonitoring()
        {
            //Теги
            if (DeviceTags != null && DeviceTags.Count > 0)
            {
                //Обновление без мерцания
                Type type = lstMonitoring.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(lstMonitoring, true, null);

                this.lstMonitoring.BeginUpdate();
                this.lstMonitoring.Items.Clear();

                #region Отображение данные 
                lock (DeviceTags)
                {
                    foreach (var tmpTag in DeviceTags)
                    {
                        if (tmpTag == null)
                        {
                            continue;
                        }

                        //Вставили инфорамцию
                        this.lstMonitoring.Items.Add(new ListViewItem()
                        {
                            //Название тега
                            Text = tmpTag.DeviceTagName,
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

                    this.lstMonitoring.EndUpdate();
                }
            }
        }

        private void ShowPage(TabPage value)
        {
            myHelper.ShowPage(value);
        }

        private void HidePage(TabPage value)
        {
            myHelper.HidePage(value);
        }

        #endregion TabPage

        #region Timer

        //private void tmrTimer_Tick(object sender, EventArgs e)
        //{
        //try
        //{
        //    TimeSpan leftTime = tmrEndTime.Subtract(DateTime.Now);

        //    if (leftTime.TotalSeconds < 0)
        //    {
        //        CountDownTimerString = "00:00:00";
        //        lblTimer.Text = CountDownTimerString;

        //        tmrTimer.Stop();

        //        Application.DoEvents();
        //        //Обновляем информацию
        //        tmrTimer_InfoDeviceTagRefresh();
        //        Application.DoEvents();

        //        if (tmrStatus == true)
        //        {
        //            tmrEndTime = DateTime.Now.AddMilliseconds(TimeRefresh);
        //            tmrTimer.Enabled = true;
        //        }
        //    }
        //    else
        //    {
        //        CountDownTimerString = leftTime.Hours.ToString("00") + ":" + leftTime.Minutes.ToString("00") + ":" + leftTime.Seconds.ToString("00") + "." + leftTime.Milliseconds.ToString("000");
        //        lblTimer.Text = CountDownTimerString;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    LogGet(ex.ToString());
        //}
        //}

        //void tmrTimer_InfoDeviceTagRefresh()
        //{
        //    try
        //    {
        //        if (client == null)
        //        {
        //            return;
        //        }

        //        if (client.Server == null || !client.Server.IsConnected)
        //        {

        //            DriverClient.OnOPCData = new DriverClient.OPCData(ShowDataOPC);
        //            DriverClient.OnDebug = new DriverClient.DebugData(LogGet);

        //            client.DeviceGroupTags = (ProjectGroupTag)MTNodeData.groupTag;
        //            client.DeviceTags = DeviceTags;
        //            client.GroupTypSubscription = DeviceGroupTagTypSubscription;
        //            client.UserLogin = device.UserLogin;
        //            client.UserPassword = device.UserPassword;
        //            client.Domain = device.Domain;
        //            client.ProxyAddress = device.ProxyAddress;
        //            client.UrlOPC = device.UrlOPC;
        //            client.SpecificationName = device.SpecificationName;

        //            client.InitializingOPCserver();
        //        }

        //        // show data
        //        new Thread(new ThreadStart(delegate
        //        {
        //            ResultsValue = new TsCDaItemValueResult[0];
        //            ResultsValue = client.Run();

        //            Invoke(new MethodInvoker(delegate
        //            {
        //                ShowDataOPC(ResultsValue);
        //            }));

        //        })).Start();

        //    }
        //    catch (Exception ex)
        //    {
        //        LogGet(ex.ToString());
        //    }
        //}



        //public void ShowDataOPC(TsCDaItemValueResult[] ResultsValue)
        //{
        //    try
        //    {
        //        if (ResultsValue == null)
        //        {
        //            return;
        //        }

        //        System.Windows.Forms.ListView lstMonitoringTags = this.lstMonitoring;

        //        if (lstMonitoringTags.InvokeRequired)
        //        {
        //            lstMonitoringTags.Invoke((MethodInvoker)delegate ()
        //            {
        //                #region Update Info
        //                //Обновление без мерцания
        //                Type type = this.lstMonitoring.GetType();
        //                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                propertyInfo.SetValue(this.lstMonitoring, true, (object[])null);

        //                // convert to list
        //                List<TsCDaItemValueResult> findResults = ResultsValue.ToList();

        //                for (int index = 0; index < lstMonitoringTags.Items.Count; ++index)
        //                {
        //                    ListViewItem TagItem = lstMonitoringTags.Items[index];
        //                    Guid SelectTagID = (Guid)TagItem.Tag;
        //                    ProjectTag tmpTag = DeviceTags.Find((Predicate<ProjectTag>)(r => r.DeviceTagID == SelectTagID));
        //                    if (tmpTag == null)
        //                    {
        //                        continue;
        //                    }

        //                    TsCDaItemValueResult tmpResult = findResults.Find((Predicate<TsCDaItemValueResult>)(t => t.ItemName == tmpTag.DeviceTagAddress));
        //                    if (tmpResult == null)
        //                    {
        //                        LogGet("[Искали = " + DriverUtils.NullToString(tmpTag.DeviceTagAddress) + "][Ничего не нашли]");
        //                        continue;
        //                    }


        //                    if (tmpResult != null)
        //                    {
        //                        //Обновили инфорамцию
        //                        TagItem.Text = tmpTag.DeviceTagname;
        //                        TagItem.Tag = tmpTag.DeviceTagID;
        //                        try { TagItem.SubItems[0].Text = DriverUtils.NullToString(tmpTag.DeviceTagname); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        try { TagItem.SubItems[1].Text = DriverUtils.NullToString(tmpTag.DeviceTagType); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }

        //                        if (tmpTag.DeviceTagCoefficient != 1f || tmpTag.DeviceTagScaled == 1)
        //                        {
        //                            try { TagItem.SubItems[2].Text = ProjectTag.CalcLineScaled(DriverUtils.NullToString(tmpResult.Value), tmpTag.DeviceTagCoefficient, tmpTag.DeviceTagScaled, tmpTag.DeviceTagScaledHigh, tmpTag.DeviceTagScaledLow, tmpTag.DeviceTagRowHigh, tmpTag.DeviceTagRowLow).ToString(); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        }
        //                        else
        //                        {
        //                            try { TagItem.SubItems[2].Text = DriverUtils.NullToString(tmpResult.Value); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        }

        //                        try { TagItem.SubItems[3].Text = DriverUtils.NullToString(tmpResult.Timestamp); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        try { TagItem.SubItems[4].Text = DriverUtils.NullToString(tmpResult.Quality.QualityBits); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        try { TagItem.SubItems[5].Text = DriverUtils.NullToString(tmpTag.DeviceTagDescription); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                    }
        //                }
        //                #endregion Update Info
        //            });
        //        }
        //        else
        //        {
        //            try
        //            {
        //                #region Update Info
        //                //Обновление без мерцания
        //                Type type = this.lstMonitoring.GetType();
        //                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                propertyInfo.SetValue(this.lstMonitoring, true, (object[])null);

        //                // convert to list
        //                List<TsCDaItemValueResult> findResults = ResultsValue.ToList();

        //                for (int index = 0; index < lstMonitoringTags.Items.Count; ++index)
        //                {
        //                    ListViewItem TagItem = lstMonitoringTags.Items[index];
        //                    Guid SelectTagID = (Guid)TagItem.Tag;
        //                    ProjectTag tmpTag = DeviceTags.Find((Predicate<ProjectTag>)(r => r.DeviceTagID == SelectTagID));
        //                    if (tmpTag == null)
        //                    {
        //                        continue;
        //                    }

        //                    TsCDaItemValueResult tmpResult = findResults.Find((Predicate<TsCDaItemValueResult>)(t => t.ItemName == tmpTag.DeviceTagAddress));
        //                    if (tmpResult == null)
        //                    {
        //                        LogGet("[Искали = " + DriverUtils.NullToString(tmpTag.DeviceTagAddress) + "][Ничего не нашли]");
        //                        continue;
        //                    }


        //                    if (tmpResult != null)
        //                    {
        //                        //Обновили инфорамцию
        //                        TagItem.Text = tmpTag.DeviceTagname;
        //                        TagItem.Tag = tmpTag.DeviceTagID;
        //                        try { TagItem.SubItems[0].Text = DriverUtils.NullToString(tmpTag.DeviceTagname); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        try { TagItem.SubItems[1].Text = DriverUtils.NullToString(tmpTag.DeviceTagType); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }

        //                        if (tmpTag.DeviceTagCoefficient != 1f || tmpTag.DeviceTagScaled == 1)
        //                        {
        //                            try { TagItem.SubItems[2].Text = ProjectTag.CalcLineScaled(DriverUtils.NullToString(tmpResult.Value), tmpTag.DeviceTagCoefficient, tmpTag.DeviceTagScaled, tmpTag.DeviceTagScaledHigh, tmpTag.DeviceTagScaledLow, tmpTag.DeviceTagRowHigh, tmpTag.DeviceTagRowLow).ToString(); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        }
        //                        else
        //                        {
        //                            try { TagItem.SubItems[2].Text = DriverUtils.NullToString(tmpResult.Value); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        }

        //                        try { TagItem.SubItems[3].Text = DriverUtils.NullToString(tmpResult.Timestamp); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        try { TagItem.SubItems[4].Text = DriverUtils.NullToString(tmpResult.Quality.QualityBits); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                        try { TagItem.SubItems[5].Text = DriverUtils.NullToString(tmpTag.DeviceTagDescription); } catch (Exception ex) { LogGet("[" + DriverUtils.InfoError(ex) + "]"); }
        //                    }
        //                }
        //                #endregion Update Info
        //            }
        //            catch { }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogGet(DriverUtils.InfoError(ex));
        //    }
        //}

        #endregion Timer

        #region Sorting

        private void lstTags_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lstTags.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            lstTags.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);

            // Sort.
            lstTags.Sort();
        }

        private void lstMonitoring_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lstMonitoring.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            lstMonitoring.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);

            // Sort.
            lstMonitoring.Sort();
        }

        #endregion Sorting

        #region Log
        private void tolShowLog_Click(object sender, EventArgs e)
        {
            if (tolShowLog.Checked == true)
            {
                ShowPage(tabLog);
            }
            else
            {
                HidePage(tabLog);
            }
        }

        void LogGet(string text)
        {
            try
            {
                if (!IsHandleCreated)
                {
                    this.CreateControl();
                }

                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        rchLog.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + text + Environment.NewLine);
                        rchLog.ScrollToCaret();
                        rchLog.Focus();

                        //Если количество строк, больше 200, то очищаем RichTextBox
                        //Число 200 беретеся из Настроек
                        if (rchLog.Lines.Count() > 200)
                        {
                            rchLog.Text = "";
                        }
                    });
                }
                else
                {
                    rchLog.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + text + Environment.NewLine);
                    rchLog.ScrollToCaret();
                    rchLog.Focus();

                    //Если количество строк, больше 200, то очищаем RichTextBox
                    //Число 200 беретеся из Настроек
                    if (rchLog.Lines.Count() > 200)
                    {
                        rchLog.Text = "";
                    }
                }

                Debuger.Debug(text);

            }
            catch { }
        }

        #endregion Log

    }
}
