using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Model
{
    public abstract class BaseRequest
    {
        public BaseRequest()
        {
            this._errorReportCollection = new List<ErrorReport>();
        }

        /// <summary>
        /// Obtém o resultado da validação.
        /// </summary>
        internal bool IsValid {
            get {
                this._errorReportCollection.Clear();
                this.Validate();
                // Caso não existam erros na lista, será retornado true, indicando que o request é valido.
                return (this._errorReportCollection.Any() == false);
            }
        }

        /// <summary>
        /// Obtém ou define a lista de erros encontrados na validação.
        /// </summary>
        private List<ErrorReport> _errorReportCollection;

        /// <summary>
        /// Obtém a lista de erros ocorridos durante a validação.
        /// </summary>
        internal List<ErrorReport> ErrorReportCollection { get { return this._errorReportCollection.ToList(); } }

        protected abstract void Validate();

        /// <summary>
        /// Adiciona um registro de erro de validação.
        /// </summary>
        /// <param name="fieldName">Propriedade que causou o erro.</param>
        /// <param name="message">Memsagem descritiva do erro.</param>
        protected void AddError(string fieldName, string message) {
        
            ErrorReport errorReport = new ErrorReport();

            // Armazena o nome da classe concreta.
            string className = this.GetType().Name;

            // Verifica se o nome da classe já foi especificado.
            if (fieldName.IndexOf(className) == -1) {

                fieldName = string.Format("{0}.{1}", className, fieldName);
            }

            errorReport.FieldName = fieldName;
            errorReport.Message = message;

            this._errorReportCollection.Add(errorReport);
        }
    }
}
