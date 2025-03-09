// Copyright (c) Rapid Software LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Scada.Comm.Config;
using Scada.Comm.Devices;
using Scada.Comm.Drivers.DrvModbusCM.View.Forms;
using Scada.Comm.Drivers.DrvModbusCM;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    /// <summary>
    /// Implements the data source user interface.
    /// <para>Реализует пользовательский интерфейс источника данных.</para>
    /// </summary>
    internal class DevDeviceVTDView : DeviceView
    {

        private Project project = new Project();

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DevDeviceVTDView(DriverView parentView, LineConfig lineConfig, DeviceConfig deviceConfig)
            : base(parentView, lineConfig, deviceConfig)
        {
            CanShowProperties = true;
        }

        /// <summary>
        /// Shows a modal dialog box for editing data source properties.
        /// </summary>
        public override bool ShowProperties()
        {

            if (new FrmConfigForm(AppDirs, DeviceNum).ShowDialog() == DialogResult.OK)
            {
                LineConfigModified = true;
                DeviceConfigModified = true;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
