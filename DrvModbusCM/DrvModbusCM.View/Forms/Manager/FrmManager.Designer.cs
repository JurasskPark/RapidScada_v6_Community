namespace DrvModbusCM.View.Forms.Manager
{
    partial class FrmManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            olvRegistersWrite = new BrightIdeasSoftware.ObjectListView();
            ((System.ComponentModel.ISupportInitialize)olvRegistersWrite).BeginInit();
            SuspendLayout();
            // 
            // olvRegistersWrite
            // 
            olvRegistersWrite.AlternateRowBackColor = Color.FromArgb(137, 180, 213);
            olvRegistersWrite.AutoArrange = false;
            olvRegistersWrite.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            olvRegistersWrite.CellEditEnterChangesRows = true;
            olvRegistersWrite.CellEditTabChangesRows = true;
            olvRegistersWrite.CellEditUseWholeCell = false;
            olvRegistersWrite.CheckedAspectName = "";
            olvRegistersWrite.Dock = DockStyle.Fill;
            olvRegistersWrite.EmptyListMsg = "";
            olvRegistersWrite.ForeColor = SystemColors.WindowText;
            olvRegistersWrite.FullRowSelect = true;
            olvRegistersWrite.GridLines = true;
            olvRegistersWrite.GroupWithItemCountFormat = "{0} ({1} people)";
            olvRegistersWrite.GroupWithItemCountSingularFormat = "{0} ({1} person)";
            olvRegistersWrite.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            olvRegistersWrite.HeaderUsesThemes = true;
            olvRegistersWrite.HeaderWordWrap = true;
            olvRegistersWrite.HideSelection = true;
            olvRegistersWrite.LabelEdit = true;
            olvRegistersWrite.Location = new Point(0, 0);
            olvRegistersWrite.Margin = new Padding(7, 3, 4, 3);
            olvRegistersWrite.MultiSelect = false;
            olvRegistersWrite.Name = "olvRegistersWrite";
            olvRegistersWrite.OverlayText.Alignment = ContentAlignment.BottomLeft;
            olvRegistersWrite.OverlayText.Text = "";
            olvRegistersWrite.SelectedBackColor = Color.FromArgb(70, 138, 189);
            olvRegistersWrite.SelectedColumnTint = Color.FromArgb(254, 70, 138, 189);
            olvRegistersWrite.SelectedForeColor = Color.White;
            olvRegistersWrite.ShowGroups = false;
            olvRegistersWrite.ShowHeaderInAllViews = false;
            olvRegistersWrite.Size = new Size(800, 450);
            olvRegistersWrite.SortGroupItemsByPrimaryColumn = false;
            olvRegistersWrite.TabIndex = 26;
            olvRegistersWrite.UnfocusedSelectedBackColor = Color.FromArgb(70, 138, 189);
            olvRegistersWrite.UnfocusedSelectedForeColor = Color.FromArgb(70, 138, 189);
            olvRegistersWrite.UseAlternatingBackColors = true;
            olvRegistersWrite.UseCompatibleStateImageBehavior = false;
            olvRegistersWrite.View = System.Windows.Forms.View.Details;
            // 
            // FrmManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(olvRegistersWrite);
            Name = "FrmManager";
            Text = "Manager";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)olvRegistersWrite).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olvRegistersWrite;
    }
}