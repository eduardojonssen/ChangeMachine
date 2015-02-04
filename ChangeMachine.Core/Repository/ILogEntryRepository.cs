using ChangeMachine.Core.Repository.Entities;
using System;
namespace ChangeMachine.Core.Repository
{
    interface ILogEntryRepository
    {
        void SaveLog(LogEntryEntity logEntry);
    }
}
