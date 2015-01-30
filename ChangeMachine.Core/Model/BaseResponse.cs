using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Model
{
    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            this.ErrorReportCollection = new List<ErrorReport>();
        }

        public bool Success { get; set; }

        public List<ErrorReport> ErrorReportCollection { get; set; }
    }
}
