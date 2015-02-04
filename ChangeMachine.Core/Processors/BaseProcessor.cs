using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Processors
{
    public abstract class BaseProcessor : IProcessor
    {
        public List<KeyValuePair<uint, ulong>> Calculate(ulong changeAmount)
        {
            // Executa a validação do valor recebido.
            if (this.Validate(changeAmount) == false)
            {
                return new List<KeyValuePair<uint, ulong>>();
            }

            // Executa o cálculo do troco.
            return this.CalculateImplementation(changeAmount);
        }

        public abstract uint[] GetAcceptedValues();

        public abstract string GetName();

        protected List<KeyValuePair<uint, ulong>> CalculateImplementation(ulong changeAmount)
        {
            List<KeyValuePair<uint, ulong>> moneyCountDictionary = new List<KeyValuePair<uint, ulong>>();

            uint[] acceptedValues = GetAcceptedValues();

            uint maxAcceptedValue = GetAcceptedValues().Where(v => v <= changeAmount).Max();

            ulong moneyCount = changeAmount / maxAcceptedValue;

            moneyCountDictionary.Add(new KeyValuePair<uint, ulong>(maxAcceptedValue, moneyCount));

            return moneyCountDictionary;
        }

        protected bool Validate(ulong changeAmount)
        {
            return (changeAmount >= GetAcceptedValues().Min());
        }
    }
}
