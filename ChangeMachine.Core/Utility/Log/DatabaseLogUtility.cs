using ChangeMachine.Core.Repository;
using ChangeMachine.Core.Repository.Entities;
using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility.Log
{
    public class DatabaseLogUtility : BaseLogUtility
    {
        public override void Write(LogEntry logEntry)
        {
            ILogEntryRepository logEntryRepository = IocFactory.Resolve<ILogEntryRepository>(this.ConfigurationUtility.ConnectionString);
            
            LogEntryEntity logEntryEntity = MapToDatabase(logEntry);

            try
            {
                logEntryRepository.SaveLog(logEntryEntity);
            }
            catch (Exception ex)
            {
                RaiseLogError(ex);
            }
        }

        private LogEntryEntity MapToDatabase(LogEntry logEntry)
        {
            LogEntryEntity logEntryEntity = new LogEntryEntity();
            logEntryEntity.CreateDate = DateTime.Now;
            logEntryEntity.LogCategoryId = (int)logEntry.Category;
            logEntryEntity.LogMessage = logEntry.Message;

            return logEntryEntity;
        }
    }
}
