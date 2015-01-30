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

            ConfigurationUtilityMock config = new ConfigurationUtilityMock();

            List<IMoney> availableMoney = new List<IMoney>();
            availableMoney.AddRange(this.GetCoinCollection(new uint[] { 100, 50, 25, 10, 5, 1 }));
            availableMoney.AddRange(this.GetBillCollection(new uint[] { 10000, 5000, 2000, 1000, 500, 200 }));

            config.AvailableMoney = availableMoney.ToArray();

            this.ConfigurationUtility = config;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeCalculator_ArgumentNull_Test(){

            ChangeCalculator changeCalculator = new ChangeCalculator(null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeCalculator_EmptyCoins_Test()
        {
            MockLibrary.ConfigurationUtilityMock config = new MockLibrary.ConfigurationUtilityMock();

            config.AvailableMoney = new IMoney[] { };

            ChangeCalculator changeCalculator = new ChangeCalculator(config);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeCalculator_RepeatedMoney_Test()
        {
            ConfigurationUtilityMock config = new ConfigurationUtilityMock();

            List<IMoney> availableMoney = new List<IMoney>();
            availableMoney.AddRange(this.GetCoinCollection(new uint[] { 1, 1 }));

            config.AvailableMoney = availableMoney.ToArray();

            ChangeCalculator changeCalculator = new ChangeCalculator(config);
        }

        [TestMethod]
        public void Calculate_InsuficientAmount_Test()
        {
            ChangeCalculator changeCalculator = new ChangeCalculator(this.ConfigurationUtility);

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
            ChangeCalculator changeCalculator = new ChangeCalculator(this.ConfigurationUtility);

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
            ChangeCalculator changeCalculator = new ChangeCalculator(this.ConfigurationUtility);

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
