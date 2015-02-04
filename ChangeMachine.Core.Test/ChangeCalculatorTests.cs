using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChangeMachine.Core.Model;
using System.Linq;
using ChangeMachine.Core.Utility;
using System.Collections.Generic;
using MockLibrary;
using System.Diagnostics.CodeAnalysis;

namespace ChangeMachine.Core.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ChangeCalculatorTests
    {
        public IConfigurationUtility ConfigurationUtility { get; set; }

        [TestInitialize]
        public void Initialize() {

            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeCalculator_ArgumentNull_Test(){

            ChangeCalculator changeCalculator = new ChangeCalculator();

        }

        [TestMethod]
        public void Calculate_InsuficientAmount_Test()
        {
            ChangeCalculator changeCalculator = new ChangeCalculator();

            CalculateRequest request = new CalculateRequest();
            request.ProductAmount = 1000;
            request.PaidAmount = 900;

            CalculateResponse response = changeCalculator.Calculate(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Success);
            Assert.IsNotNull(response.ErrorReportCollection);
            Assert.IsTrue(response.ErrorReportCollection.Any());
        }

        [TestMethod]
        public void Calculate_ChangeAmountZero_Test()
        {
            ChangeCalculator changeCalculator = new ChangeCalculator();
            CalculateRequest request = new CalculateRequest();
            request.ProductAmount = 1000;
            request.PaidAmount = 1000;

            CalculateResponse response = changeCalculator.Calculate(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsFalse(response.ErrorReportCollection.Any());
        }

        [TestMethod]
        public void Calculate_ValidChange_Test()
        {
            ChangeCalculator changeCalculator = new ChangeCalculator();

            CalculateRequest request = new CalculateRequest();
            request.ProductAmount = 1000;
            request.PaidAmount = 2576;

            //uint expected100Bills = 0;
            //uint expected50Bills = 0;
            //uint expected20Bills = 0;
            uint expected10Bills = 1;
            uint expected5Bills = 1;
            //uint expected2Bills = 0;

            //uint expected100Coins = 15;
            uint expected50Coins = 1;
            uint expected25Coins = 1;
            uint expected1Coins = 1;

            CalculateResponse response = changeCalculator.Calculate(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsFalse(response.ErrorReportCollection.Any());


            Assert.AreEqual(5, response.Change.Count());
            Assert.AreEqual(expected10Bills, response.Change[1000]);
            Assert.AreEqual(expected5Bills, response.Change[500]);
            Assert.AreEqual(expected50Coins, response.Change[50]);
            Assert.AreEqual(expected25Coins, response.Change[25]);
            Assert.AreEqual(expected1Coins, response.Change[1]);
        }


        private IMoney[] GetCoinCollection(uint[] coins)
        {
            List<IMoney> coinCollection = new List<IMoney>();

            foreach (uint coin in coins)
            {
                coinCollection.Add(new Coin(coin));
            }

            return coinCollection.ToArray();
        }
        private IMoney[] GetBillCollection(uint[] bills)
        {
            List<IMoney> billCollection = new List<IMoney>();

            foreach (uint bill in bills)
            {
                billCollection.Add(new Bill(bill));
            }

            return billCollection.ToArray();
        }
    }
}
