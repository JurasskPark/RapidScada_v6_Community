using Scada.Lang;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public static class DriverDictonary
    {


        public static string Empty = Locale.IsRussian ? "" : "";
        public static string EmptyWord = Locale.IsRussian ? "Пусто" : "Empty";
        public static string WarningEmpty = Locale.IsRussian ? "Поле Наименование не может быть пустым!" : "The Name field cannot be empty!";

        public static string ClientTCP = Locale.IsRussian ? "TCP клиент" : "TCP client";
        public static string ClientUDP = Locale.IsRussian ? "UDP клиент" : "UDP client";

        public static string CommandExecutedError = Locale.IsRussian ? "[Ошибка][Команда была выполнена с ошибкой!]" : "[Error][The command was executed with an error!]";

        public static string StartDriver = Locale.IsRussian? "Запуск приложения" : "Launching the application";
        public static string Timeout = Locale.IsRussian ? "Таймаут" : "Timeout";
        public static string Delay = Locale.IsRussian ? "Пауза" : "Delay";
        public static string Period = Locale.IsRussian? "Период" : "Period";

        public static string ProjectName = Locale.IsRussian ? "Проект" : "Project";
        public static string ProjectNo = Locale.IsRussian ?
            "Количество тегов не было получено т.к. конфигурационный файл не был загружен" :
            "The number of tags was not received because the configuration file was not loaded";

        public static string Devices = Locale.IsRussian? "Устройства" : "Devices";
        public static string DeviceGroupTags = Locale.IsRussian ? "Группы тегов" : "Tag groups";
        public static string DeviceTags = Locale.IsRussian ? "Теги" : "Tags";
        public static string GroupCommands = Locale.IsRussian? "Группы команд" : "Command groups";
        public static string Commands = Locale.IsRussian? "Команды" : "Commands";

        public static string Name = Locale.IsRussian ? "Канал связи" : "Communication channel";
        public static string DeviceName = Locale.IsRussian ? "Устройство" : "Device";
        public static string GroupTagName = Locale.IsRussian ? "Группа тегов" : "Tag group";
        public static string GroupCommandName = Locale.IsRussian ? "Команды" : "Commands";
        public static string OpcConnectDataName = Locale.IsRussian ? "Данные подключения" : "Connection data";

        //public static string Name = Locale.IsRussian ? "Название" : "Name";
        public static string OPCUrl = Locale.IsRussian ? "OPC Url" : "OPC Url";
        public static string SpecificationName = Locale.IsRussian ? "Спецификация" : "Specification";
        public static string Port = Locale.IsRussian ? "Порт" : "Port";
        public static string Path = Locale.IsRussian ? "Путь" : "Path";

        public static string Enabled = Locale.IsRussian ? "Включена" : "Enabled";
        public static string Successfully = Locale.IsRussian ? "Успешно" : "Successfully";
        public static string Unsuccessful = Locale.IsRussian ? "Неуспешно" : "Unsuccessful";

        public static string Credentials = Locale.IsRussian ? "Учетные данные" : "Credentials";
        public static string WindowsAuthorization = Locale.IsRussian ? "Windows авторизация" : "Windows authorization";
        public static string UserLogin = Locale.IsRussian ? "Имя пользователя" : "Username";
        public static string UserPassword = Locale.IsRussian ? "Пароль" : "Password";
        public static string Domain = Locale.IsRussian ? "Домен" : "Domain";
        public static string WebProxy = Locale.IsRussian ? "Веб-прокси сервер" : "WebProxy";
        public static string UseDefaultCredentials = Locale.IsRussian ? "Учетные данные по умолчанию" : "Use Default Credentials";
        public static string AddressHost = Locale.IsRussian ? "Адрес хоста" : "Address Host";
        public static string HostNameType = Locale.IsRussian ? "Тип хоста" : "Host Type";
        public static string HostLocalPath = Locale.IsRussian ? "Локальный путь" : "Local Path";

        public static string DriverClientInitialization = Locale.IsRussian ? "Инициализация клиента драйвера" : "Initializing the driver client";
        public static string DriverClientAddList = Locale.IsRussian ? "Добавление клиента драйвера" : "Adding the driver client";

        public static string DriverClientDeviceTransmittingParameters = Locale.IsRussian ? "Передача параметров OPC-сервера" : "Transmitting OPC server parameters";
        public static string DriverClientGroupTagTransmittingParameters = Locale.IsRussian ? "Передача параметров группы тегов" : "Transmitting tag group parameters";
        public static string DriverClientTagsTransmittingParameters = Locale.IsRussian ? "Передача тегов" : "Transmitting tags";

        public static string OPCSearch = Locale.IsRussian ? "Поиск OPC серверов" : "Search for OPC servers";
        public static string OPCInitialization = Locale.IsRussian ? "Инициализация OPC" : "OPC Initialization";
        public static string OPCImportTags = Locale.IsRussian ? "Импорт тегов" : "Importing tags";

        
        public static string QuestionAboutChanges = Locale.IsRussian ? "Изменения не сохранены. Сохранить изменения?" : "The changes are not saved. Save changes?";
        public static string QuestionEmptyName = Locale.IsRussian ? "Поле Наименование не может быть пустым!" : "The Name field cannot be empty!";
        public static string QuestionDelete = Locale.IsRussian ? "Вы действительно хотите удалить " : "Do you really want to delete ";

        public static string ResultPing = Locale.IsRussian ? "Результат пинга устройства " : "The result of the device ping ";

        public static string Connection = Locale.IsRussian ? "Соединение" : "Connection";
        public static string ConnectionError = Locale.IsRussian ? "Подключение не произошло" : "Connection failed";
        public static string ServerStatusName = Locale.IsRussian ? "Статус сервера: " : "Status of Server: ";  
      
        public static string StateSubscription = Locale.IsRussian ? "Cостояние подписки" : "State of a subscription";
        public static string Subscription = Locale.IsRussian ? "Подписка" : "Subscription";

        public static string ClientHandle = Locale.IsRussian ? "Управление клиентом" : "Client Handle";
        public static string ServerHandle = Locale.IsRussian ? "Управление сервером" : "Server Handle";
        public static string Active = Locale.IsRussian ? "Активный" : "Active";
        public static string Filters = Locale.IsRussian ? "Фильтры" : "Filters";
        public static string LocaleName = Locale.IsRussian ? "Языковой стандарт" : "Locale";
        public static string UpdateRate = Locale.IsRussian ? "Частота обновления" : "Update Rate";
        public static string KeepAlive = Locale.IsRussian ? "Aктивность соединения " : "Keep Alive";
        public static string Deadband = Locale.IsRussian ? "Зона нечувствительности" : "Deadband";

        public static string ErrorAddTagsSubscription = Locale.IsRussian ? "Ошибка при добавлении тега в подписку " : "Error adding tag to subscription ";
        public static string GoodAddTagsSubscription = Locale.IsRussian ? "Успешно добавлено тегов в подписку " : "Successfully added tags to subscription ";

        public static string TagsIsNull = Locale.IsRussian ? "Список тегов пустой" : "The tag list is empty";
        public static string TagsCount = Locale.IsRussian ? "Количество тегов" : "Number of tags";
        public static string Error = Locale.IsRussian ? "Ошибка" : "Error";

        public static string Status = Locale.IsRussian ? "Статус" : "Status";

        public static string FileNoFound = Locale.IsRussian ? "Файл проекта не был найден!" : "The project file was not found!";
        public static string FileLenghtZero = Locale.IsRussian ? "Файл проекта пустой!" : "The project file is empty!";
    }
}
