using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Processors
{
    public class BillProcessor : BaseProcessor
    {
        public override uint[] GetAcceptedValues()
        {
            return new uint[] { 10000, 5000, 2000, 1000, 500, 200 };
        }

        public override string GetName()
        {
            return "Cédula(s)";
        }
      
    }
}
