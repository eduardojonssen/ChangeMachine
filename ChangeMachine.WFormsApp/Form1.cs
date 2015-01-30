using ChangeMachine.Core.Model;
using ChangeMachine.Core.Processors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeMachine.WFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UxBtnCalculate_Click(object sender, EventArgs e)
        {

            ulong productAmount = ulong.Parse(UxTxtProductAmount.Text);


            ulong paidAmount = ulong.Parse(UxTxtPaidAmount.Text);

            ChangeMachine.Core.ChangeCalculator changeCalculator = new Core.ChangeCalculator();

            CalculateRequest request = new CalculateRequest();
            request.ProductAmount = productAmount;
            request.PaidAmount = paidAmount;

            CalculateResponse response = changeCalculator.Calculate(request);
            
            if (response.Success == false)
            {
                StringBuilder errorMessage = new StringBuilder();

                foreach (ErrorReport error in response.ErrorReportCollection)
                {
                    errorMessage.AppendFormat("{0}: {1}", error.FieldName, error.Message).AppendLine();
                }

                MessageBox.Show(errorMessage.ToString(), "Deu Ruim, Brother!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StringBuilder result = new StringBuilder();
                foreach (ChangeData changeData in response.Change)
                {
                    foreach (KeyValuePair<uint, ulong> changeItem in changeData.ChangeCollection)
                    {
                        result.AppendFormat("{0} {1} de {2}", changeItem.Value, changeData.MoneyDescription, changeItem.Key).AppendLine();
                    }

                }
                UxTxtChangeResult.Text = result.ToString();
            }
        }

        
    }
}
