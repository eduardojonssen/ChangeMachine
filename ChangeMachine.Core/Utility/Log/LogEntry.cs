using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility.Log
{
    public class LogEntry
    {
        public LogEntry()
        {
            this.CreateDate = DateTime.UtcNow;
        }

        public string Message { get; set; }

        public LogCategory Category { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
