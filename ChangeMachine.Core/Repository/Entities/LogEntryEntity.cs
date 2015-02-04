using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Repository.Entities
{
    public class LogEntryEntity
    {
        public int LogEntryId { get; set; }
        public int LogCategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public string LogMessage { get; set; }
    }
}
