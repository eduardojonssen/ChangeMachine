using ChangeMachine.Core.Model;
using ChangeMachine.Core.Processors;
using ChangeMachine.Core.Utility;
using ChangeMachine.Core.Utility.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ChangeMachine.Core
{
    public class ChangeCalculator
    {
        private BaseLogUtility logUtility;
        public ChangeCalculator(IConfigurationUtility configurationUtility = null)
        {
            IConfigurationUtility configuration = configurationUtility;

            // Caso nenhum valor tenha sido informado, instancia a classe padrão.
            if (configuration == null)
            {
                configuration = new ConfigurationUtility();
            }

            this.logUtility = LogUtilityFactory.CreateLogUtility(configuration);
        }
        public CalculateResponse Calculate(CalculateRequest request)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            LogEntry requestLogEntry = new LogEntry();
            requestLogEntry.Category = LogCategory.Information;
            requestLogEntry.Message = serializer.Serialize(request);

            logUtility.Write(requestLogEntry);

            CalculateResponse response = new CalculateResponse();

            // Verifica se o request recebido é valido.
            if (request.IsValid == false)
            {
                response.ErrorReportCollection = request.ErrorReportCollection;
                return response;
            }

            // Armazena o troco a ser retornado.
            ulong changeAmount = request.PaidAmount - request.ProductAmount;

            // Armazena o troco ainda não processado.
            ulong remainingAmount = changeAmount;

            List<ChangeData> changeDataCollection = new List<ChangeData>();

            while (remainingAmount > 0)
            {
                // Selecionar o processador adequado para o troco restante.
                BaseProcessor processor = ProcessorFactory.Create(remainingAmount);

                // Verifica se foi encontrado um processador para realizar o cálculo.
                if (processor == null)
                {
                    ErrorReport errorReport = new ErrorReport();
                    errorReport.FieldName = "ChangeAmount";
                    errorReport.Message = "Unable to calculate the change amount.";

                    response.ErrorReportCollection.Add(errorReport);

                    break;
                }

                // Calcula o troco para o valor especificado.
                List<KeyValuePair<uint, ulong>> changeCollection = processor.Calculate(remainingAmount);

                ChangeData changeData = new ChangeData();
                changeData.MoneyDescription = processor.GetName();
                changeData.ChangeCollection = changeCollection;
                changeDataCollection.Add(changeData);

                IEnumerable<ulong> processedAmountCollection = changeCollection.Select(p => p.Key * p.Value);
                ulong processedAmount = 0;
                foreach (ulong amount in processedAmountCollection)
                {
                    processedAmount += amount;
                }

                remainingAmount -= processedAmount;


            }

            // Caso nenhum erro tenha sido encontrado, define success como true e informa o troco
            if (response.ErrorReportCollection.Any() == false)
            {
                response.Success = true;
                response.Change = changeDataCollection;
            }


            LogEntry responseLogEntry = new LogEntry();
            responseLogEntry.Category = LogCategory.Information;
            responseLogEntry.Message = serializer.Serialize(response);

            logUtility.Write(responseLogEntry);
            return response;
        }

    }
}
