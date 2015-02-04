using Dlp.Framework;
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
        public static BaseLogUtility CreateLogUtility()
        {
            // Obtém uma instancia do utilitário de acesso ao arquivo de configuração.
            IConfigurationUtility configurationUtility = IocFactory.Resolve<IConfigurationUtility>();

            switch (configurationUtility.LogType)
            {
                case LogUtilityType.File:
                    return new FileLogUtility(configurationUtility.LogFilePath, configurationUtility.LogFileName);

                case LogUtilityType.Database:
                    return new DatabaseLogUtility();

                case LogUtilityType.EventLog:
                default:
                    return new EventLogUtility();
            }
        }
    }
}
