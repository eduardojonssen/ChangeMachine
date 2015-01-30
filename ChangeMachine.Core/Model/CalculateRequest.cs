using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Model
{
    public class CalculateRequest : BaseRequest
    {
        public ulong ProductAmount { get; set; }

        public ulong PaidAmount { get; set; }

        protected override void Validate()
        {
            // Verifica se o valor pago é menor que o valor do produto.
            if (this.PaidAmount < this.ProductAmount)
            {
                base.AddError("PaidAmount", "Insuficient paid amount.");
            }
        }
    }
}
