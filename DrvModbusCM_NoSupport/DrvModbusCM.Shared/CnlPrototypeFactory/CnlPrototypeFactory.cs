using System;
using System.Collections.Generic;
using System.Text;
using Scada.Comm.Devices;
using Scada.Comm.Drivers.DrvModbusCM;
using Scada.Data;
using Scada.Data.Const;
using Scada.Data.Entities;
using Scada.Lang;
using static Scada.Comm.Drivers.DrvModbusCM.ProjectDeviceTag;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    /// <summary>
    /// Creates channel prototypes for a simulator device.
    /// <para>Создает прототипы каналов для симулятора устройства.</para>
    /// </summary>
    internal static class CnlPrototypeFactory
    {
        /// <summary>
        /// Devices
        /// <para>Устройства</para>
        /// </summary>
        public static List<ProjectDevice> devices;
        /// <summary>
        /// Tags Group
        /// <para>Группа тегов</para>
        /// </summary>
        private static List<ProjectDeviceGroupTag> deviceGroupTags;
        /// <summary>
        /// Tag
        /// <para>Тег</para>
        /// </summary>
        private static List<ProjectDeviceTag> deviceTags;

        /// <summary>
        /// Gets the grouped channel prototypes.
        /// </summary>
        public static List<CnlPrototypeGroup> GetCnlPrototypeGroups(Project project, bool deviceName = false)
        {
            devices = project.Settings.ProjectDevice;
            deviceGroupTags = project.Settings.ProjectDeviceGroupTag;
            deviceTags = project.Settings.ProjectDeviceTag;


            List<CnlPrototypeGroup> groups = new List<CnlPrototypeGroup>();
            CnlPrototypeGroup group = new CnlPrototypeGroup();

            string nameGroup = string.Empty;
            string nameTag = string.Empty;

            for (int d = 0; d < devices.Count; d++)
            {
                nameGroup = devices[d].DeviceName;
                Guid deviceID = devices[d].DeviceID;
                group = new CnlPrototypeGroup(nameGroup);

                List<ProjectDeviceTag> lstDeviceTags = deviceTags.Where(r => r.DeviceID == deviceID).ToList();

                for (int t = 0; t < lstDeviceTags.Count; t++)
                {
                    if(deviceName)
                    {
                        group.AddCnlPrototype("" + nameGroup + "." + lstDeviceTags[t].DeviceTagCode + "", lstDeviceTags[t].DeviceTagname).SetFormat(FormatCode.G);
                    }
                    else
                    {
                        group.AddCnlPrototype("" + lstDeviceTags[t].DeviceTagCode + "", lstDeviceTags[t].DeviceTagname).SetFormat(FormatCode.G);
                    }                 
                }

                groups.Add(group);
            }

            return groups;
        }

        /// <summary>
        /// Gets the device tag format depending on the Modbus element type.
        /// </summary>
        private static TagFormat GetTagFormat(ProjectDeviceTag tag)
        {
            DeviceTagFormatData format = (DeviceTagFormatData)Enum.Parse(typeof(DeviceTagFormatData), tag.DeviceTagType.ToString());

            switch (format)
            {
                case ProjectDeviceTag.DeviceTagFormatData.BIT:

                    break;
                case ProjectDeviceTag.DeviceTagFormatData.BIT32:

                    break;
                case ProjectDeviceTag.DeviceTagFormatData.BIT64:

                    break;
                case ProjectDeviceTag.DeviceTagFormatData.DOUBLE:
                    
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.FLOAT:
                    
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.HEX:
                   
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.INT:
                   
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.LONG:
                    
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.SHORT:
                   
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.UINT:
                    
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.ULONG:
                    
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.USHORT:
                   
                    break;
            }


            //if (tag.DeviceTagType == ElemType.Bool)
            //    return TagFormat.OffOn;
            //else if (elemConfig.ElemType == ElemType.Float || elemConfig.ElemType == ElemType.Double)
            //    return TagFormat.FloatNumber;
            //else if (elemConfig.IsBitMask)
            //    return TagFormat.HexNumber;
            //else
            //    return TagFormat.IntNumber;
            return TagFormat.FloatNumber;
        }


    }
}
