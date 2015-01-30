using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Model
{
    public class Bill : IMoney
    {
        public Bill()
        {

        }
        public Bill(uint value)
        {
            this.Value = value;
        }
        
        /// <summary>
        /// Obtém ou define o valor da cédula.
        /// </summary>
        public uint Value { get; set; }
    }
}
