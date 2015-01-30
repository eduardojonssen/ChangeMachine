using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Processors
{
    public class DilmaProcessor : BaseProcessor
    {
        public override uint[] GetAcceptedValues()
        {
            return new uint[] { 125, 120, 115, 110, 105, 100, 95, 90, 85, 80, 75 };
        }

        public override string GetName()
        {
            return "Dilma(s)";
        }
    }
}
