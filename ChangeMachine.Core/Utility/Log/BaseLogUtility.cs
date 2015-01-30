using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility.Log
{
    public abstract class BaseLogUtility
    {
        public abstract void Write(LogEntry logEntry);
    }
}
