using DrvModbusCM.Shared.Communication;
using Master;
using Scada.Data.Entities;
using Scada.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static Scada.Comm.Drivers.DrvModbusCM.ProjectTag;

namespace Scada.Comm.Drivers.DrvModbusCM
{

    #region Project
    /// <summary>
    /// Represents the configuration of a device driver.
    /// <para>Представляет конфигурацию драйвера устройства.</para>
    /// </summary>
    [Serializable]
    public class Project
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Project()
        {
            Driver = new ProjectDriver();
        }

        private void SetToDefault()
        {
            Driver = new ProjectDriver();
        }

        #region Variables
        // driver
        // драйвер
        private ProjectDriver driver;
        public ProjectDriver Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        #endregion Variables

        #region Load
        /// <summary>
        /// Loads the configuration from the specified file.
        /// <para>Загружает конфигурацию из указанного файла.</para>
        /// </summary>
        public bool Load(string fileName, out string errMsg)
        {
            SetToDefault();

            try
            {
                if (!File.Exists(fileName))
                {
                    try
                    {
                        Save(fileName, out errMsg);
                    }
                    catch
                    {
                        throw new FileNotFoundException(string.Format(CommonPhrases.NamedFileNotFound, fileName));
                    }
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlElement rootElem = xmlDoc.DocumentElement;

                try { Driver.LoadFromXml(rootElem.SelectSingleNode("Driver")); } catch { Driver = new ProjectDriver(); }

                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        #endregion Load

        #region Save
        /// <summary>
        /// Saves the configuration to the specified file.
        /// <para>Сохраняет конфигурацию в указанный файл.</para>
        /// </summary>
        public bool Save(string fileName, out string errMsg)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.AppendChild(xmlDecl);

                XmlElement rootElem = xmlDoc.CreateElement("Config");
                xmlDoc.AppendChild(rootElem);

                try { Driver.SaveToXml(rootElem.AppendElem("Driver")); } catch { }

                xmlDoc.Save(fileName);
                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        #endregion Save

    }
    #endregion Project

    #region ProjectNodeData
    public struct ProjectNodeData
    {
        public ProjectNodeType NodeType;
        public ProjectDriver Driver;
        public ProjectSettings Settings;
        public ProjectGroupChannel GroupChannel;
        public ProjectChannel Channel;
        public ProjectDevice Device;
        public ProjectGroupCommand GroupCommand;
        public ProjectCommand Command;
        public ProjectGroupTag GroupTag;
        public ProjectTag Tag;
    }

    #endregion ProjectNodeData

    #region ProjectNodeType
    public enum ProjectNodeType
    {
        Driver,
        Settings,
        GroupChannel,
        Channel,
        Device,
        GroupCommand,
        Command,
        GroupTag,
        Tag,
    };

    #endregion ProjectNodeType














}