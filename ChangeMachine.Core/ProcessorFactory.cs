using ChangeMachine.Core.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core
{
    public static class ProcessorFactory
    {
        /// <summary>
        /// Obtém o processador adequado para o valor do troco a ser retornado.
        /// </summary>
        /// <param name="changeAmount">Valor do troco a ser processado.</param>
        /// <returns>Retorna o processador a ser utilizado para o cálculo do troco.</returns>
        public static BaseProcessor Create(ulong changeAmount)
        {
            // Lista dos tipos de processadores disponíveis.
            BaseProcessor[] processorCollection = new BaseProcessor[] {
                new CoinProcessor(),
                new BillProcessor(),
                new CandyProcessor(),
                new DilmaProcessor()
            };

            // Adicione novos processadores acima desta linha.

            Nullable<uint> closestValue = null;
            BaseProcessor selectedProcessor = null;

            // Analisa cada processador e localiza aquele que possui um valor mais próximo possível do troco a ser retornado.
            foreach (BaseProcessor processor in processorCollection)
            {
                // Obtém o valor mais próximo do troco, deste processador.
                IEnumerable<uint> currentClosestValue = processor.GetAcceptedValues().Where(v => v <= changeAmount);

                if (currentClosestValue.Any() == false) { continue; }

                // Se o valor encontrado estiver mais próximo do valor do troco anteriormente encontrado, substitui o valor.
                if (closestValue.HasValue == false || currentClosestValue.Max() > closestValue)
                {
                    closestValue = currentClosestValue.Max();
                    selectedProcessor = processor;
                }
            }

            return selectedProcessor;
        }

    }
}
