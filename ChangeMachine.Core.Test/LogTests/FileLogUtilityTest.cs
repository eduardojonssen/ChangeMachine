using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChangeMachine.Core.Utility;
using MockLibrary;
using ChangeMachine.Core.Model;
using Dlp.Framework;
using ChangeMachine.Core.Utility.Log;

namespace ChangeMachine.Core.Test.LogTests
{
    [TestClass]
    public class FileLogUtilityTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext){

            IocFactory.Register<IConfigurationUtility, ConfigurationUtilityMock>();
        }

        [TestMethod]
        public void WriteToLog_Test()
        {
            ChangeCalculator changeCalculator = new ChangeCalculator();

            CalculateRequest request = new CalculateRequest();

            request.ProductAmount = 100;
            request.PaidAmount = 150;

            CalculateResponse response = changeCalculator.Calculate(request);
        }
    }
}
