using Scada.Lang;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    /// <summary>
    /// The phrases used by the driver.
    /// <para>Фразы, используемые драйвером.</para>
    /// </summary>
    public static class DriverPhrases
    {


        public static string NoType { get; private set; }
        public static string NoProtocol {  get; private set; }

        public static string Request {  get; private set; }
        public static string Response { get; private set; }
        public static string ExecutedError { get; private set; }

        public static string SettingsName { get; private set; } = "Settings";
        public static string ChannelName { get; private set; } = "Channel";
        public static string DeviceName { get; private set; } = "Device";
        public static string GroupCommandName { get; private set; } = "Commands";
        public static string CommandName { get; private set; } = "Command";
        public static string GroupTagName { get; private set; } = "Tags";
        public static string TagName { get; private set; } = "Tag";
        



        public static string TitleLoadProject { get; private set; }
        public static string FilterProject { get; private set; }
        public static string TitleLoadCSV { get; private set; }
        public static string TitleSaveCSV { get; private set; }
        public static string FilterCSV { get; private set; }

        public static string QuestionNewProjectMsg { get; private set; }
        public static string QuestionNewProjectTitle { get; private set; }
        public static string QuestionAboutChanges { get; private set; }
        public static string QuestionLoadCSV { get; private set; }
        public static string Delete { get; private set; }
        public static string DeleteQuestion { get; private set; }


        public static string ChannelGatewayPortChecked { get; private set; }
        public static string NoComPort { get; private set; }

        public static string PortFree { get; private set; }
        public static string PortBusy {  get; private set; } 


        public static void Init()
        {
            InitConfig();
        }

        private static void InitConfig()
        {
            LocaleDict dict = Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.Config");

            NoType = dict[nameof(NoType)];
            NoProtocol = dict[nameof(NoProtocol)];

            Request = dict[nameof(Request)];
            Response = dict[nameof(Response)];
            ExecutedError = dict[nameof(ExecutedError)];

            ChannelName = dict[nameof(ChannelName)];
            DeviceName = dict[nameof(DeviceName)];
            GroupCommandName = dict[nameof(GroupCommandName)];
            CommandName = dict[nameof(CommandName)];
            GroupTagName = dict[nameof(GroupTagName)];
            TagName = dict[nameof(TagName)];

            TitleLoadProject = dict[nameof(TitleLoadProject)];
            FilterProject = dict[nameof(FilterProject)];

            TitleLoadCSV = dict[nameof(TitleLoadCSV)];
            TitleSaveCSV = dict[nameof(TitleSaveCSV)];
            FilterCSV = dict[nameof(FilterCSV)];

            QuestionNewProjectTitle = dict[nameof(QuestionNewProjectTitle)];
            QuestionNewProjectMsg = dict[nameof(QuestionNewProjectMsg)];
            QuestionAboutChanges = dict[nameof(QuestionAboutChanges)];
            QuestionLoadCSV = dict[nameof(QuestionLoadCSV)];
            Delete = dict[nameof(Delete)];
            DeleteQuestion = dict[nameof(DeleteQuestion)];

            ChannelGatewayPortChecked = dict[nameof(ChannelGatewayPortChecked)];
            NoComPort = dict[nameof(NoComPort)];

            PortFree = dict[nameof(PortFree)];
            PortBusy = dict[nameof(PortBusy)];
        }
    }
}
