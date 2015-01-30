using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChangeMachine.Core.Utility;
using MockLibrary;
using ChangeMachine.Core.Model;

namespace ChangeMachine.Core.Test.LogTests
{
    [TestClass]
    public class FileLogUtilityTest
    {
        [TestMethod]
        public void WriteToLog_Test()
        {
            IConfigurationUtility configurationUtility = new ConfigurationUtilityMock();

            ChangeCalculator changeCalculator = new ChangeCalculator(configurationUtility);

            CalculateRequest request = new CalculateRequest();

            request.ProductAmount = 100;
            request.PaidAmount = 150;

            CalculateResponse response = changeCalculator.Calculate(request);
        }
    }
}
