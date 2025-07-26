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

   
        public static string Port = Locale.IsRussian ? "Порт" : "Port";
        public static string Path = Locale.IsRussian ? "Путь" : "Path";

        public static string Enabled = Locale.IsRussian ? "Включена" : "Enabled";
        public static string Successfully = Locale.IsRussian ? "Успешно" : "Successfully";
        public static string Unsuccessful = Locale.IsRussian ? "Неуспешно" : "Unsuccessful";



        public static string DriverClientInitialization = Locale.IsRussian ? "Инициализация клиента драйвера" : "Initializing the driver client";
        public static string DriverClientAddList = Locale.IsRussian ? "Добавление клиента драйвера" : "Adding the driver client";

       
        public static string DriverClientTagsTransmittingParameters = Locale.IsRussian ? "Передача тегов" : "Transmitting tags";
        public static string OPCImportTags = Locale.IsRussian ? "Импорт тегов" : "Importing tags";

        
        public static string QuestionAboutChanges = Locale.IsRussian ? "Изменения не сохранены. Сохранить изменения?" : "The changes are not saved. Save changes?";
        public static string QuestionEmptyName = Locale.IsRussian ? "Поле Наименование не может быть пустым!" : "The Name field cannot be empty!";
        public static string QuestionDelete = Locale.IsRussian ? "Вы действительно хотите удалить " : "Do you really want to delete ";

    
        public static string Connection = Locale.IsRussian ? "Соединение" : "Connection";
        public static string ConnectionError = Locale.IsRussian ? "Подключение не произошло" : "Connection failed";

        public static string TagsIsNull = Locale.IsRussian ? "Список тегов пустой" : "The tag list is empty";
        public static string TagsCount = Locale.IsRussian ? "Количество тегов" : "Number of tags";
        public static string Error = Locale.IsRussian ? "Ошибка" : "Error";

        public static string Status = Locale.IsRussian ? "Статус" : "Status";

        public static string FileNoFound = Locale.IsRussian ? "Файл проекта не был найден!" : "The project file was not found!";
        public static string FileLenghtZero = Locale.IsRussian ? "Файл проекта пустой!" : "The project file is empty!";
    }
}
