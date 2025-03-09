using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscEmpty : UserControl
    {
        public uscEmpty()
        {
            InitializeComponent();
        }

        #region Form
        public FrmConfigForm frmParentGloabal;          // global general form
        public bool boolParent = false;                 // сhild startup flag
        public bool modified;                           // the configuration was modified
        #endregion Form
    }
}
