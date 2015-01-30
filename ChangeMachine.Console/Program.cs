using ChangeMachine.Core.Model;
using ChangeMachine.Core.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o valor do produto: ");
            ulong productAmount = ulong.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o valor pago: ");
            ulong paidAmount = ulong.Parse(Console.ReadLine());

            ChangeMachine.Core.ChangeCalculator changeCalculator = new Core.ChangeCalculator();

            CalculateRequest request = new CalculateRequest();
            request.ProductAmount = productAmount;
            request.PaidAmount = paidAmount;

            CalculateResponse response = changeCalculator.Calculate(request);

            if (response.Success == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocorreram um ou mais erros:");
                foreach (ErrorReport error in response.ErrorReportCollection)
                {
                    Console.WriteLine("{0}: {1}", error.FieldName, error.Message);
                }
            }
            else
            {

                Console.WriteLine("Troco:");
                foreach (ChangeData changeData in response.Change)
                {
                    foreach (KeyValuePair<uint, ulong> changeItem in changeData.ChangeDictionary)
                    {
                        Console.WriteLine("{0} {1} de {2}", changeItem.Value, changeData.MoneyDescription, changeItem.Key);
                    }

                }
            }

            Console.ReadKey();
        }
    }
}
