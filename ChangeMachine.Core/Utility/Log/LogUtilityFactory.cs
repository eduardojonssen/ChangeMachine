using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility.Log
{
    public static class LogUtilityFactory
    {
        public static BaseLogUtility CreateLogUtility(IConfigurationUtility configuration)
        {
            switch (configuration.LogType)
            {
                case LogUtilityType.File:
                    return new FileLogUtility(configuration.LogFilePath,configuration.LogFileName);
                case LogUtilityType.EventLog:
                default:
                    return new EventLogUtility();
            }
        }
    }
}
