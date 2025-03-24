using Scada.Comm.Devices;
using Scada.Data.Entities;
using Scada.Forms;
using Splash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmGroupTag : Form
    {
        public FrmGroupTag()
        {
            InitializeComponent();
        }

        #region Variables

        #region Form

        public FrmConfig frmParentGloabal;              // global general form
        public bool boolParent = false;                 // сhild startup flag
        public bool modified;                           // the configuration was modified

        #endregion Form

        #region Group Tag

        ProjectGroupTag currentGroupTag;

        #endregion  Group Tag

        #region List Tags

        List<ProjectTag> ListTags = new List<ProjectTag>();
        List<ProjectTag> ListTagsDefaultSort = new List<ProjectTag>();

        #endregion List Tags

        #region Tag

        ProjectTag newTag;
        ProjectTag changeTag;

        #endregion Tag

        #region ListView

        private ListViewItem selectedItem;  //Выбранная запись
        public int indexSelect = 0;         //Номер индекса
        public int SortingMethod = 0;       //Способ Сортировки

        private ColumnHeader SortingColumn = null;

        #endregion ListView

        #endregion Variables

        #region Load

        public FrmGroupTag(ProjectNodeData ProjectNodeData)
        {
            currentGroupTag = ProjectNodeData.GroupTag;

            InitializeComponent();
            FormatWindow(true);

        }

        public FrmGroupTag(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            currentGroupTag = ProjectNodeData.GroupTag;

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

        private void FrmGroupTag_Load(object sender, EventArgs e)
        {
            // set the control values
            ConfigToControls();

            // enable timer
            //ckbAutoRefreshListRegisters.Checked = true;
        }

        private void ConfigToControls()
        {
            txtName.Text = currentGroupTag.Name;
            ckbEnabled.Checked = currentGroupTag.Enabled;

            if (currentGroupTag.ListTags == null)
            {
                ListTagsDefaultSort = ListTags = new List<ProjectTag>();
            }
            else
            {
                ListTagsDefaultSort = ListTags = currentGroupTag.ListTags;
            }

            //Список тегов
            if (ListTags != null && ListTags.Count > 0)
            {
                //Обновление без мерцания
                Type type = lstTags.GetType();
                PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                propertyInfo.SetValue(lstTags, true, null);

                this.lstTags.BeginUpdate();
                this.lstTags.Items.Clear();

                #region Отображение данных

                //Способ сортировки
                List<ProjectTag> ListTagsSort = new List<ProjectTag>();

                switch (SortingMethod)
                {
                    case 0: //По умолчанию
                        ListTagsSort = ListTagsDefaultSort;
                        break;
                    case 1: //По адресу
                        ListTagsSort = ListTags.OrderBy(o => o.Address).ToList();
                        break;
                    case -1:  //По адресу 
                        ListTagsSort = ListTags.OrderByDescending(o => o.Address).ToList();
                        break;
                    case 2:  //По названию
                        ListTagsSort = ListTags.OrderBy(o => o.Name).ToList();
                        break;
                    case -2:  //По названию
                        ListTagsSort = ListTags.OrderByDescending(o => o.Name).ToList();
                        break;
                    case 3: //По описанию
                        ListTagsSort = ListTags.OrderBy(o => o.Description).ToList();
                        break;
                    case -3: //По описанию
                        ListTagsSort = ListTags.OrderByDescending(o => o.Description).ToList();
                        break;
                    case 4: //По типу
                        ListTagsSort = ListTags.OrderBy(o => o.TagType).ToList();
                        break;
                    case -4: //По типу
                        ListTagsSort = ListTags.OrderByDescending(o => o.TagType).ToList();
                        break;
                    case 5: //По значению
                        ListTagsSort = ListTags.OrderBy(o => o.DataValue).ToList();
                        break;
                    case -5: //По значению
                        ListTagsSort = ListTags.OrderByDescending(o => o.DataValue).ToList();
                        break;
                    default: //По  умолчанию
                        ListTagsSort = ListTagsDefaultSort;
                        break;
                }

                foreach (var tmpTag in ListTagsSort)
                {
                    if (tmpTag == null)
                    {
                        continue;
                    }

                    //Вставили инфорамцию
                    this.lstTags.Items.Add(new ListViewItem()
                    {
                        //Название тега
                        Text = tmpTag.Name,
                        SubItems =
                            {
                                //Добавляем параметры тега
                                DriverUtils.NullToString(tmpTag.Code),
                                DriverUtils.NullToString(tmpTag.Address),
                                DriverUtils.NullToString(tmpTag.Description),
                                DriverUtils.NullToString(tmpTag.TagType),
                                DriverUtils.NullToString(DriverUtils.IsGuid(tmpTag.CommandID.ToString())),
                                DriverUtils.NullToString(tmpTag.Enabled),
                            }
                    }).Tag = tmpTag.ID; //В Tag передаём ID тега..., чтобы можно было найти
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

            Modified = false;
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
            projectNodeData.GroupTag = currentGroupTag;
            stn.Tag = projectNodeData;
            stn.Text = projectNodeData.Device.Name;

            string imageKey = stn.ImageKey;
            int imageIndex = stn.ImageIndex;

            switch (currentGroupTag.Enabled)
            {
                case true:
                    imageKey = ListImages.ImageKey.GroupTag;
                    break;
                case false:
                    imageKey = ListImages.ImageKey.GroupTagOff;
                    break;
            }

            currentGroupTag.KeyImage = imageKey;
            stn.ImageKey = imageKey;
            stn.SelectedImageKey = imageKey;

            // удаляем теги
            stn.Nodes.Clear();
            // добавляем теги
            foreach (ProjectTag projectTag in currentGroupTag.ListTags)
            {
                frmParentGloabal.NodeDeviceTagAdd(projectTag, stn, null);
            }

            frmParentGloabal.trvProject.SelectedNode.EndEdit(true);
            frmParentGloabal.trvProject.LabelEdit = false;

            Modified = false;
        }

        private void ControlsToConfig()
        {
            currentGroupTag.Name = txtName.Text;
            currentGroupTag.Enabled = ckbEnabled.Checked;


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

        #endregion Component

        #region Tag


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

            if (ListTags != null)
            {
                ListViewItem selectedIndex = lstTags.SelectedItems[0];
                indexSelect = lstTags.SelectedIndices[0];
                Guid SelectTagID = DriverUtils.StringToGuid(selectedIndex.Tag.ToString());

                ProjectTag tmpTag = ListTags.Find((Predicate<ProjectTag>)(r => r.ID == SelectTagID));
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

                newTag.ParentID = currentGroupTag.ID;
                newTag.ID = Guid.NewGuid();
                newTag.Name = "";
                newTag.Code = "";
                newTag.Description = "";
                newTag.Enabled = true;
                newTag.Sorting = "";
                newTag.DataValue = 0;
                newTag.Quality = 0;
                newTag.Coefficient = 1;
                newTag.Scaled = 0;
                newTag.ScaledHigh = 1000;
                newTag.ScaledLow = 0;
                newTag.RowHigh = 1000;
                newTag.RowLow = 0;
                newTag.KeyImage = "tag_16.png";

                // create
                ProjectNodeData ProjectNodeDataTag = new ProjectNodeData();
                ProjectNodeDataTag.Tag = newTag;
                ProjectNodeDataTag.NodeType = ProjectNodeType.Tag;
                // created a form
                FrmTag frmTag = new FrmTag(ref ProjectNodeDataTag, false);
                frmTag.frmParentGloabal = frmParentGloabal;
                // showing the form
                DialogResult dialog = frmTag.ShowDialog();
                // if you have closed the form, click OK
                if (DialogResult.OK == dialog)
                {
                    ListTags.Add(ProjectNodeDataTag.Tag);

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

                if (ListTags != null)
                {
                    ListViewItem selectedIndex = lstTags.SelectedItems[0];
                    indexSelect = lstTags.SelectedIndices[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedIndex.Tag.ToString());
                    changeTag = ListTags.Find((Predicate<ProjectTag>)(r => r.ID == SelectTagID));

                    // create
                    ProjectNodeData ProjectNodeDataTag = new ProjectNodeData();
                    ProjectNodeDataTag.Tag = changeTag;
                    ProjectNodeDataTag.NodeType = ProjectNodeType.Tag;
                    // created a form
                    FrmTag frmTag = new FrmTag(ref ProjectNodeDataTag, false);
                    frmTag.frmParentGloabal = frmParentGloabal;
                    // showing the form
                    DialogResult dialog = frmTag.ShowDialog();
                    // if you have closed the form, click OK
                    if (DialogResult.OK == dialog)
                    {
                        changeTag = ProjectNodeDataTag.Tag;

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

                if (ListTags != null)
                {
                    ListViewItem selectedIndex = lstTags.SelectedItems[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedIndex.Tag.ToString());

                    ProjectTag tmpTag = ListTags.Find((Predicate<ProjectTag>)(r => r.ID == SelectTagID));
                    indexSelect = ListTags.IndexOf(ListTags.Where(n => n.ID == SelectTagID).FirstOrDefault());

                    try
                    {
                        if (lstTags.Items.Count > 0)
                        {
                            ListTags.Remove(tmpTag);
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
                ListTags.Clear();

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
                if (ListTags != null)
                {
                    ListViewExtensions.MoveListViewItems(lstTags, MoveDirection.Up);
                    selectedItem = tmplstTags.SelectedItems[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedItem.Tag.ToString());

                    ProjectTag tmpTag = ListTags.Find((Predicate<ProjectTag>)(r => r.ID == SelectTagID));
                    indexSelect = ListTags.IndexOf(ListTags.Where(n => n.ID == SelectTagID).FirstOrDefault());

                    if (indexSelect == 0)
                    {
                        return;
                    }
                    else
                    {
                        ListTags.Reverse(indexSelect - 1, 2);
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
                if (ListTags != null)
                {
                    ListViewExtensions.MoveListViewItems(lstTags, MoveDirection.Down);

                    selectedItem = tmplstTags.SelectedItems[0];
                    Guid SelectTagID = DriverUtils.StringToGuid(selectedItem.Tag.ToString());

                    ProjectTag tmpTag = ListTags.Find((Predicate<ProjectTag>)(r => r.ID == SelectTagID));
                    indexSelect = ListTags.IndexOf(ListTags.Where(n => n.ID == SelectTagID).FirstOrDefault());

                    if (indexSelect == ListTags.Count - 1)
                    {
                        return;
                    }
                    else
                    {
                        ListTags.Reverse(indexSelect, 2);
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
            if (MessageBox.Show(DriverPhrases.QuestionLoadCSV, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataLoadAsCSV();
            }
        }

        private void DataLoadAsCSV()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = DriverPhrases.TitleLoadCSV;
            OFD.Filter = DriverPhrases.FilterCSV;
            OFD.InitialDirectory = System.IO.Path.Combine(Application.StartupPath);

            if (OFD.ShowDialog() == DialogResult.OK && OFD.FileName != "")
            {
                try
                {
                    //Открываем
                    string FileName = OFD.FileName;
                    ProjectGroupTag groupTag = new ProjectGroupTag();

                    #region Загрузка
                    SplashScreen.ShowSplashScreen();
                    SplashScreen.SetTitle("Загрузка...");
                    SplashScreen.SetStatus("Считывание данных из файла:");

                    DataTable data = CSV.Import(FileName, true, ";", "UTF8");
                    List<ProjectTag> tags = groupTag.ConvertDataTableToListTags(data);

                    foreach (ProjectTag tmpTag in tags)
                    {
                        ListTags.Add(tmpTag);
                    }

                    foreach (ProjectTag tmpTag in ListTags)
                    {
                        tmpTag.ParentID = currentGroupTag.ID;
                    }

                    SplashScreen.CloseSplashScreen();
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
            SFD.Title = DriverPhrases.TitleSaveCSV;
            SFD.Filter = DriverPhrases.FilterCSV;
            SFD.InitialDirectory = System.IO.Path.Combine(Application.StartupPath);

            if (SFD.ShowDialog() == DialogResult.OK && SFD.FileName != "")
            {
                //Сохраняем
                string FileName = SFD.FileName;
                ProjectGroupTag projectGroupTag = new ProjectGroupTag();
                DataTable data = projectGroupTag.ConvertListTagsToDataTable(ListTags);

                CSV.Export(FileName, data, true, ";", "UTF8");
            }
        }

        #endregion CSV

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

        #region Sorting

        //private void lstTags_ColumnClick(object sender, ColumnClickEventArgs e)
        //{
        //    // Get the new sorting column.
        //    ColumnHeader new_sorting_column = lstTags.Columns[e.Column];

        //    // Figure out the new sorting order.
        //    System.Windows.Forms.SortOrder sort_order;
        //    if (SortingColumn == null)
        //    {
        //        // New column. Sort ascending.
        //        sort_order = SortOrder.Ascending;
        //    }
        //    else
        //    {
        //        // See if this is the same column.
        //        if (new_sorting_column == SortingColumn)
        //        {
        //            // Same column. Switch the sort order.
        //            if (SortingColumn.Text.StartsWith("> "))
        //            {
        //                sort_order = SortOrder.Descending;
        //            }
        //            else
        //            {
        //                sort_order = SortOrder.Ascending;
        //            }
        //        }
        //        else
        //        {
        //            // New column. Sort ascending.
        //            sort_order = SortOrder.Ascending;
        //        }

        //        // Remove the old sort indicator.
        //        SortingColumn.Text = SortingColumn.Text.Substring(2);
        //    }

        //    // Display the new sort order.
        //    SortingColumn = new_sorting_column;
        //    if (sort_order == SortOrder.Ascending)
        //    {
        //        SortingColumn.Text = "> " + SortingColumn.Text;
        //    }
        //    else
        //    {
        //        SortingColumn.Text = "< " + SortingColumn.Text;
        //    }

        //    // Create a comparer.
        //    lstTags.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);

        //    // Sort.
        //    lstTags.Sort();
        //}

        //private void lstMonitoring_ColumnClick(object sender, ColumnClickEventArgs e)
        //{
        //    // Get the new sorting column.
        //    ColumnHeader new_sorting_column = lstMonitoring.Columns[e.Column];

        //    // Figure out the new sorting order.
        //    System.Windows.Forms.SortOrder sort_order;
        //    if (SortingColumn == null)
        //    {
        //        // New column. Sort ascending.
        //        sort_order = SortOrder.Ascending;
        //    }
        //    else
        //    {
        //        // See if this is the same column.
        //        if (new_sorting_column == SortingColumn)
        //        {
        //            // Same column. Switch the sort order.
        //            if (SortingColumn.Text.StartsWith("> "))
        //            {
        //                sort_order = SortOrder.Descending;
        //            }
        //            else
        //            {
        //                sort_order = SortOrder.Ascending;
        //            }
        //        }
        //        else
        //        {
        //            // New column. Sort ascending.
        //            sort_order = SortOrder.Ascending;
        //        }

        //        // Remove the old sort indicator.
        //        SortingColumn.Text = SortingColumn.Text.Substring(2);
        //    }

        //    // Display the new sort order.
        //    SortingColumn = new_sorting_column;
        //    if (sort_order == SortOrder.Ascending)
        //    {
        //        SortingColumn.Text = "> " + SortingColumn.Text;
        //    }
        //    else
        //    {
        //        SortingColumn.Text = "< " + SortingColumn.Text;
        //    }

        //    // Create a comparer.
        //    lstMonitoring.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);

        //    // Sort.
        //    lstMonitoring.Sort();
        //}

        #endregion Sorting



        #endregion Tag

        private void tolTagChange_Click_1(object sender, EventArgs e)
        {

        }
    }
}
