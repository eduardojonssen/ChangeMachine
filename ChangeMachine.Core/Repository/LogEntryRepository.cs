using ChangeMachine.Core.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dlp.Connectors;

namespace ChangeMachine.Core.Repository
{
    public class LogEntryRepository : BaseRepository, ILogEntryRepository
    {
        private const string SAVE_LOG_QUERY = 
        @"INSERT INTO LogEntry (LogCategoryId, CreateDate, LogMessage) 
        VALUES (@LogCategoryId, @CreateDate, @LogMessage)";

        public LogEntryRepository(string connectionString)
            : base(connectionString)
        {

        }

        public void SaveLog(LogEntryEntity logEntry)
        {
            throw new Exception("Voce ta tentando inserir macaco no banco. O banco nao suporta macaco.");

            using(DatabaseConnector databaseConnector = new DatabaseConnector(base.connectionString))
            {
                databaseConnector.ExecuteNonQuery(SAVE_LOG_QUERY, logEntry);
            }
        }
    }
}
