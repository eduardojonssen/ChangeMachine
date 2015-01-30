using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Model
{
    public class Coin : IMoney
    {
        public Coin()
        {}
        public Coin(uint value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Obtém ou define o valor da moeda.
        /// </summary>
        public uint Value { get; set; }
    }
}
