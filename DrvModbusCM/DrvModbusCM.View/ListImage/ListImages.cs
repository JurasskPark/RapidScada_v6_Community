namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public static class ListImages
    {
        #region Images Form
        /// <summary>
        /// Gets images used by the configuration form.
        /// </summary>
        public static class ImageKeyForm
        {
            public const string New = "new.png";
            public const string Open = "open.png";
            public const string Save = "save.png";
            public const string SaveAs = "saveas.png";

            public const string Start = "start.png";
            public const string Stop = "stop.png";
            public const string ActionLog = "action_log.png";


        }

        /// <summary>
        /// Specifies the image keys for the configuration form.
        /// </summary>
        public static Dictionary<string, Image> GetFormImages()
        {
            FrmConfig frmConfig = new FrmConfig();
            return new Dictionary<string, Image>
            {
                { ImageKeyForm.New, frmConfig.imgListForm.Images[ImageKeyForm.New] },
                { ImageKeyForm.Open, frmConfig.imgListForm.Images[ImageKeyForm.Open] },
                { ImageKeyForm.Save, frmConfig.imgListForm.Images[ImageKeyForm.Save] },
                { ImageKeyForm.SaveAs, frmConfig.imgListForm.Images[ImageKeyForm.SaveAs] },
                { ImageKeyForm.Start, frmConfig.imgListForm.Images[ImageKeyForm.Start] },
                { ImageKeyForm.Stop, frmConfig.imgListForm.Images[ImageKeyForm.Stop] },
                { ImageKeyForm.ActionLog, frmConfig.imgListForm.Images[ImageKeyForm.ActionLog] },
            };
        }


        #endregion Images Form

        #region Images TreeView
        /// <summary>
        /// Gets images used by the configuration tree.
        /// </summary>
        public static class ImageKey
        {
            public const string Settings = "setting_tools_16.png";

            public const string ChannelEmpty = "channel_empty_16.png";
            public const string ChannelSerialPort = "channel_serialport_16.png";
            public const string ChannelEthernet = "channel_ethernet_16.png";
            
            public const string Device = "device_16.png";
            public const string DeviceOff = "device_off_16.png";
           
            public const string GroupCmd = "cmd_group_16.png";
            public const string GroupCmdOff = "cmd_group_off_16.png";
            public const string Cmd = "cmd_16.png";
            public const string CmdOff = "cmd_off_16.png";
            public const string Cmd00 = "cmd_00_16.png";
            public const string Cmd00Off = "cmd_00_off_16.png";
            public const string Cmd01 = "cmd_01_16.png";
            public const string Cmd01Off = "cmd_01_off_16.png";
            public const string Cmd02 = "cmd_02_16.png";
            public const string Cmd02Off = "cmd_02_off_16.png";
            public const string Cmd03 = "cmd_03_16.png";
            public const string Cmd03Off = "cmd_03_off_16.png";
            public const string Cmd04 = "cmd_04_16.png";
            public const string Cmd04Off = "cmd_04_off_16.png";

            public const string GroupTag = "tag_group_16.png";
            public const string GroupTagOff = "tag_group_off_16.png";


            public const string Tag = "tag_16.png";
            public const string TagAdd = "tag_add_16.png";
            public const string TagEdit = "tag_edit_16.png";
            public const string TagDelete = "tag_delete_16.png";


            ////////////////////////////////////


            public const string Elem = "elem.png";
            public const string FolderClosed = "folder_closed.png";
            public const string FolderClosedInactive = "folder_closed_inactive.png";
            public const string FolderOpen = "folder_open.png";
            public const string FolderOpenInactive = "folder_open_inactive.png";
            public const string Options = "options.png";


            
            public const string CmdRequest = "cmd_request.png";

            public const string GroupSndRequest = "snd_group_request.png";
            public const string SndRequest = "snd_request.png";


  

            public const string Up = "move_up.png";
            public const string Down = "move_down.png";
            public const string Delete = "delete.png";
        }

        /// <summary>
        /// Specifies the image keys for the configuration tree.
        /// </summary>
        public static Dictionary<string, Image> GetTreeViewImages()
        {
            FrmConfig frmConfig = new FrmConfig();
            return new Dictionary<string, Image>
            {
                {ImageKey.Settings, frmConfig.imgList.Images[ImageKey.Settings] },

                { ImageKey.ChannelEmpty, frmConfig.imgList.Images[ImageKey.ChannelEmpty] },
                { ImageKey.ChannelEthernet, frmConfig.imgList.Images[ImageKey.ChannelEthernet] },
                { ImageKey.ChannelSerialPort, frmConfig.imgList.Images[ImageKey.ChannelSerialPort] },
                { ImageKey.Device, frmConfig.imgList.Images[ImageKey.Device] },
                { ImageKey.DeviceOff, frmConfig.imgList.Images[ImageKey.DeviceOff] },

                { ImageKey.GroupCmd, frmConfig.imgList.Images[ImageKey.GroupCmd] },
                { ImageKey.GroupCmdOff, frmConfig.imgList.Images[ImageKey.GroupCmdOff] },
                { ImageKey.Cmd, frmConfig.imgList.Images[ImageKey.Cmd] },
                { ImageKey.CmdOff, frmConfig.imgList.Images[ImageKey.CmdOff] },
                { ImageKey.Cmd00, frmConfig.imgList.Images[ImageKey.Cmd00] },
                { ImageKey.Cmd00Off, frmConfig.imgList.Images[ImageKey.Cmd00Off] },
                { ImageKey.Cmd01, frmConfig.imgList.Images[ImageKey.Cmd01] },
                { ImageKey.Cmd01Off, frmConfig.imgList.Images[ImageKey.Cmd01Off] },
                { ImageKey.Cmd02, frmConfig.imgList.Images[ImageKey.Cmd02] },
                { ImageKey.Cmd02Off, frmConfig.imgList.Images[ImageKey.Cmd02Off] },
                { ImageKey.Cmd03, frmConfig.imgList.Images[ImageKey.Cmd03] },
                { ImageKey.Cmd03Off, frmConfig.imgList.Images[ImageKey.Cmd03Off] },
                { ImageKey.Cmd04, frmConfig.imgList.Images[ImageKey.Cmd04] },
                { ImageKey.Cmd04Off, frmConfig.imgList.Images[ImageKey.Cmd04Off] },




                { ImageKey.GroupTag, frmConfig.imgList.Images[ImageKey.GroupTag] },
                { ImageKey.Tag, frmConfig.imgList.Images[ImageKey.Tag] },
                { ImageKey.TagAdd, frmConfig.imgList.Images[ImageKey.TagAdd] },
                { ImageKey.TagEdit, frmConfig.imgList.Images[ImageKey.TagEdit] },
                { ImageKey.TagDelete, frmConfig.imgList.Images[ImageKey.TagDelete] },


                { ImageKey.Elem, frmConfig.imgList.Images[ImageKey.Elem] },
                { ImageKey.FolderClosed, frmConfig.imgList.Images[ImageKey.FolderClosed] },
                { ImageKey.FolderClosedInactive, frmConfig.imgList.Images[ImageKey.FolderClosedInactive] },
                { ImageKey.FolderOpen, frmConfig.imgList.Images[ImageKey.FolderOpen] },
                { ImageKey.FolderOpenInactive, frmConfig.imgList.Images[ImageKey.FolderOpenInactive] },
                { ImageKey.Options, frmConfig.imgList.Images[ImageKey.Options] },


                { ImageKey.CmdRequest, frmConfig.imgList.Images[ImageKey.CmdRequest] },
                { ImageKey.GroupSndRequest, frmConfig.imgList.Images[ImageKey.GroupSndRequest] },
                { ImageKey.SndRequest, frmConfig.imgList.Images[ImageKey.SndRequest] },
                { ImageKey.GroupCmd, frmConfig.imgList.Images[ImageKey.GroupCmd] },

                { ImageKey.Up, frmConfig.imgList.Images[ImageKey.Up] },
                { ImageKey.Down, frmConfig.imgList.Images[ImageKey.Down] },
                { ImageKey.Delete, frmConfig.imgList.Images[ImageKey.Delete] }
            };
        }


        #endregion Images TreeView

    }
}
