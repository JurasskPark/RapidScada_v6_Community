using System;
using System.Collections.Generic;
using System.Text;
using Scada.Comm.Devices;
using Scada.Comm.Drivers.DrvModbusCM;
using Scada.Data;
using Scada.Data.Const;
using Scada.Data.Entities;
using Scada.Lang;
using static Scada.Comm.Drivers.DrvModbusCM.ProjectTag;

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
        private static List<ProjectGroupTag> groupTags;
        /// <summary>
        /// Tag
        /// <para>Тег</para>
        /// </summary>
        private static List<ProjectTag> tags;

        /// <summary>
        /// Gets the grouped channel prototypes.
        /// </summary>
        public static List<CnlPrototypeGroup> GetCnlPrototypeGroups(Project project, bool deviceNameAdd = false)
        {
            //devices = project.Settings.ProjectDevice;
            //groupTags = project.Settings.ProjectGroupTag;
            //tags = project.Settings.ProjectTag;

            List<CnlPrototypeGroup> groups = new List<CnlPrototypeGroup>();
            CnlPrototypeGroup group = new CnlPrototypeGroup();

            string nameDevice = string.Empty;
            string nameGroup = string.Empty;
            string nameTag = string.Empty;

            for (int d = 0; d < devices.Count; d++)
            {
                nameDevice = devices[d].Name;
                Guid deviceID = devices[d].ID;

                List<ProjectGroupTag> lstDeviceGroupTagsSearch = new List<ProjectGroupTag>();
                if (groupTags != null && groupTags.Count > 0)
                {
                    lstDeviceGroupTagsSearch = groupTags.Where(r => r.ParentID == deviceID).ToList();
                }

                for (int g = 0; g < lstDeviceGroupTagsSearch.Count; g++)
                {
                    if (lstDeviceGroupTagsSearch[g].Enabled == true)
                    {
                        nameGroup = lstDeviceGroupTagsSearch[g].Name;
                        Guid groupTagID = lstDeviceGroupTagsSearch[g].ID;

                        group = new CnlPrototypeGroup("[" + nameDevice + "][" + nameGroup + "]");

                        List<ProjectTag> lstDeviceTagsSearch = new List<ProjectTag>();
                        if (tags != null && tags.Count > 0)
                        {
                            //lstDeviceTagsSearch = tags.Where(r => r.ID == deviceID && r.GroupTagID == groupTagID && r.Enabled == true).ToList();
                        }

                        for (int t = 0; t < lstDeviceTagsSearch.Count; t++)
                        {
                            if (deviceNameAdd)
                            {
                                group.AddCnlPrototype("" + nameGroup + "." + lstDeviceTagsSearch[t].Code + "", lstDeviceTagsSearch[t].Name).SetFormat(FormatCode.G);
                            }
                            else
                            {
                                group.AddCnlPrototype("" + lstDeviceTagsSearch[t].Code + "", lstDeviceTagsSearch[t].Name).SetFormat(FormatCode.G);
                            }
                        }

                        groups.Add(group);
                    }
                }
            }
            return groups;
        }

        /// <summary>
        /// Gets the device tag format depending on the Modbus element type.
        /// </summary>
        private static TagFormat GetTagFormat(ProjectTag tag)
        {
            FormatData format = (FormatData)Enum.Parse(typeof(FormatData), tag.TagType.ToString());

            switch (format)
            {
                case ProjectTag.FormatData.BIT:

                    break;
                case ProjectTag.FormatData.BIT32:

                    break;
                case ProjectTag.FormatData.BIT64:

                    break;
                case ProjectTag.FormatData.DOUBLE:
                    
                    break;
                case ProjectTag.FormatData.FLOAT:
                    
                    break;
                case ProjectTag.FormatData.HEX:
                   
                    break;
                case ProjectTag.FormatData.INT:
                   
                    break;
                case ProjectTag.FormatData.LONG:
                    
                    break;
                case ProjectTag.FormatData.SHORT:
                   
                    break;
                case ProjectTag.FormatData.UINT:
                    
                    break;
                case ProjectTag.FormatData.ULONG:
                    
                    break;
                case ProjectTag.FormatData.USHORT:
                   
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
