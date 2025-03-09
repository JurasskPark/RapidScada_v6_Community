using Scada.Comm.Drivers.DrvIEC61107.View;
using Scada.Comm.Drivers.DrvModbusCM.View.Forms;

namespace Scada.Comm.Drivers.DrvIEC61107.View
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
            FrmConfigForm frmConfig = new FrmConfigForm();
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
            public const string ChannelEmpty = "channel_empty_16.png";
            public const string ChannelSerialPort = "channel_serialport_16.png";
            public const string ChannelEthernet = "channel_ethernet_16.png";
            public const string Device = "device_16.png";
            public const string DeviceOff = "device_off_16.png";
            public const string GroupCmd = "cmd_group_16.png";
            public const string GroupCmdOff = "cmd_group_off_16.png";
            public const string Cmd = "cmd_16.png";
            public const string CmdOff = "cmd_off_16.png";
            public const string GroupTag = "tag_group_16.png";
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
            FrmConfigForm frmConfig = new FrmConfigForm();
            return new Dictionary<string, Image>
            {
                { ImageKey.ChannelEmpty, frmConfig.imgList.Images[ImageKey.ChannelEmpty] },
                { ImageKey.ChannelEthernet, frmConfig.imgList.Images[ImageKey.ChannelEthernet] },
                { ImageKey.ChannelSerialPort, frmConfig.imgList.Images[ImageKey.ChannelSerialPort] },
                { ImageKey.Device, frmConfig.imgList.Images[ImageKey.Device] },
                { ImageKey.DeviceOff, frmConfig.imgList.Images[ImageKey.DeviceOff] },
                { ImageKey.GroupCmd, frmConfig.imgList.Images[ImageKey.GroupCmd] },
                { ImageKey.GroupCmdOff, frmConfig.imgList.Images[ImageKey.GroupCmdOff] },
                { ImageKey.Cmd, frmConfig.imgList.Images[ImageKey.Cmd] },

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
