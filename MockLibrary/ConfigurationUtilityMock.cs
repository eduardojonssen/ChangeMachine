using ChangeMachine.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockLibrary
{
    public class ConfigurationUtilityMock : IConfigurationUtility
    {
        public string LogFileName
        {
            get { return "LogTest.log"; }
        }

        public string LogFilePath
        {
            get { return @"C:\Logs\Test"; }
        }
    }
}
