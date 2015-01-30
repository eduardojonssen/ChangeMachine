using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Model
{
    public sealed class ErrorReport
    {
        public ErrorReport() { }

        /// <summary>
        /// Obtém ou define o nome da propriedade que disparou o erro.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Obtém ou define a mensagem descritiva do erro ocorrido.
        /// </summary>
        public string Message { get; set; }
    }
}
