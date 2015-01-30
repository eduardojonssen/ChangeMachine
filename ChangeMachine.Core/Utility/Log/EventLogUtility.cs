using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility.Log
{
    public class EventLogUtility : BaseLogUtility
    {
        const string APPLICATION_NAME = "ChangeMan Chine";

        public override void Write(LogEntry logEntry)
        {


            if (EventLog.SourceExists(APPLICATION_NAME) == false)
            {

                EventLog.CreateEventSource(APPLICATION_NAME, "Application");
            }

            EventLog.WriteEntry(APPLICATION_NAME, logEntry.Message, GetLogEntryType(logEntry.Category));

        }


        private static EventLogEntryType GetLogEntryType(LogCategory logCategory)
        {

            switch (logCategory)
            {
                case LogCategory.Information:
                    return EventLogEntryType.Information;
                case LogCategory.Warning:
                    return EventLogEntryType.Warning;
                case LogCategory.Error:
                default:
                    return EventLogEntryType.Error;

            }

        }

        private static string BuildLogMessage(LogEntry logEntry)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendFormat("Date:{0} |", logEntry.CreateDate);
            logMessage.AppendFormat("Category:{0} |", logEntry.Category);
            logMessage.AppendFormat("Message:{0} |", logEntry.Message.Replace('\n', ' '));
            logMessage.AppendLine();

            return logMessage.ToString();
        }
    }
}

