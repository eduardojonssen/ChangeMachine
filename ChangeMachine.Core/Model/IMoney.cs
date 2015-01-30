using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Model
{
    public interface IMoney
    {

        /// <summary>
        /// Obtém ou define o valor da importancia.
        /// </summary>
        uint Value { get; set; }
    }
}
