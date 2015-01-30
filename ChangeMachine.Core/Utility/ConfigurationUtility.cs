using ChangeMachine.Core.Model;
using ChangeMachine.Core.Utility.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility
{
    /// <summary>
    /// Loads configuration for Change Machine
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConfigurationUtility : IConfigurationUtility
    {
        public string LogFilePath { get { return ConfigurationManager.AppSettings["LogFilePath"];} }

        public string LogFileName { get { return ConfigurationManager.AppSettings["LogFileName"]; } }

        public LogUtilityType LogType
        {
            get
            {
                return (LogUtilityType)Enum.Parse(typeof(LogUtilityType), ConfigurationManager.AppSettings["LogType"]);
            } 
        }
    }
}
