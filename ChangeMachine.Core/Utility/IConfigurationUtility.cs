using ChangeMachine.Core.Model;
using System;
namespace ChangeMachine.Core.Utility
{
    public interface IConfigurationUtility
    {
        IMoney[] AvailableMoney { get;}

        string LogFileName { get; }

        string LogFilePath { get; }
    }
}
