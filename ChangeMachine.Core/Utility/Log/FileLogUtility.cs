using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility.Log
{
    public class FileLogUtility:BaseLogUtility
    {
        private string fileName;
        private string filePath;
        public FileLogUtility(string filePath,string fileName)
        {
            this.fileName = fileName;
            this.filePath = filePath;
        }
        public override void Write(LogEntry logEntry)
        {
            if (Directory.Exists(this.filePath) == false)
            {
                Directory.CreateDirectory(this.filePath);
            }

            string fullName = Path.Combine(this.filePath, this.fileName);

            string logMessage = BuildLogMessage(logEntry);
            File.AppendAllText(fullName, logMessage);
        }

        private static string BuildLogMessage(LogEntry logEntry)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendFormat("Date:{0} |", logEntry.CreateDate);
            logMessage.AppendFormat("Category:{0} |", logEntry.Category);
            logMessage.AppendFormat("Message:{0} |", logEntry.Message.Replace('\n',' '));
            logMessage.AppendLine();

            return logMessage.ToString();
        }
    }
}
