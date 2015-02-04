using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility.Log
{
    public class LogErrorEventArgs: EventArgs
    {
        public LogErrorEventArgs()
        {

        }

        public LogErrorEventArgs(Exception ex)
        {
            this.LogErrorException = ex;
        }

        public Exception LogErrorException { get; set; }
    }
}
