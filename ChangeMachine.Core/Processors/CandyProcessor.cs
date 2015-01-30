using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Processors
{
    public class CandyProcessor : BaseProcessor
    {

        public override uint[] GetAcceptedValues()
        {
            return new uint[] { 1 };
        }

        public override string GetName()
        {
            return "Bala(s)";
        }

        //protected override IDictionary<uint, ulong> CalculateImplementation(ulong changeAmount)
        //{
        //    IDictionary<uint, ulong> candyCountDictionary = new Dictionary<uint, ulong>();

        //    ulong remainingAmount = changeAmount;
        //    uint[] acceptedValues = GetAcceptedValues();

        //    foreach (uint candy in acceptedValues)
        //    {
        //        if (remainingAmount == 0)
        //        {
        //            break;
        //        }

        //        ulong candyCount = remainingAmount / candy;

        //        if (candyCount >= 1)
        //        {
        //            remainingAmount = remainingAmount % candy;
        //            candyCountDictionary.Add(candy, candyCount);
        //        }

        //    }

        //    return candyCountDictionary;
        //}
    }
}
