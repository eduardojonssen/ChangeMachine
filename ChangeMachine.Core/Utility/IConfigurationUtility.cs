using ChangeMachine.Core.Model;
using ChangeMachine.Core.Utility.Log;
using System;
namespace ChangeMachine.Core.Utility
{
    public interface IConfigurationUtility
    {
        string LogFileName { get; }

        string LogFilePath { get; }

        LogUtilityType LogType { get; }
    }
}
