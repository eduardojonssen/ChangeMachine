using ChangeMachine.Core.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Model
{
    public class CalculateResponse : BaseResponse
    {

        public CalculateResponse()
        {
            this.Change = new List<ChangeData>();
        }

        public List<ChangeData> Change { get; set; }


    }
}
