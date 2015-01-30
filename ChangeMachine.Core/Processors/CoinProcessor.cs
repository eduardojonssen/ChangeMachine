using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Processors
{
    public class CoinProcessor : BaseProcessor
    {
        public override uint[] GetAcceptedValues()
        {
            return new uint[] { 100, 50, 25, 10, 5 };
        }

        public override string GetName()
        {
            return "Moeda(s)";
        }
    }
}
