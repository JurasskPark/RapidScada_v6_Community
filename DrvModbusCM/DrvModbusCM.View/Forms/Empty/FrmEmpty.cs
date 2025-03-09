namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmEmpty : Form
    {
        #region Form

        public FrmEmpty()
        {
            InitializeComponent();
            FormatWindow(true);
        }

        public FrmEmpty(ProjectNodeData device)
        {         
            InitializeComponent();
            FormatWindow(true);
        }

        public FrmEmpty(ref ProjectNodeData device, bool hasParent = true)
        {
            boolParent = hasParent;
            InitializeComponent();
            FormatWindow(boolParent);
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Dock = DockStyle.Left | DockStyle.Top;
                this.TopLevel = false;
            }
        }

        #endregion Form

        #region Variables
        public FrmConfig frmParentGloabal;              // global general form
        public bool boolParent = false;                 // сhild startup flag
        public bool modified;                           // the configuration was modified
        #endregion Variables
    }
}
