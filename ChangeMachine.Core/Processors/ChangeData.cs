using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Processors
{
    public class ChangeData
    {
        public ChangeData() {
            this.ChangeCollection = new List<KeyValuePair<uint, ulong>>();
        }

        /// <summary>
        /// Obtém ou define a descrição da unidade monetária
        /// </summary>
        public string MoneyDescription { get; set; }
        
        /// <summary>
        /// Obtém ou define o dicionário de valor-quantidade do troco.
        /// </summary>
        public List<KeyValuePair<uint, ulong>> ChangeCollection { get; set; }
    }
}
