using ChangeMachine.Core.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility
{
    /// <summary>
    /// Loads configuration for Change Machine
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConfigurationUtility : IConfigurationUtility
    {
        private uint[] GetAvailableMoney(string settingKey, char separator)
        {
            string availableMoneySettings = ConfigurationManager.AppSettings[settingKey];
            string[] splittedMoney = availableMoneySettings.Split(separator);

            if (splittedMoney.Any() == false)
            {
                return new uint[] { };
            }

            return splittedMoney.Select(p => uint.Parse(p)).ToArray();
        }

        public IMoney[] AvailableMoney
        {
            get
            {
                Coin[] availableCoins = this.GetAvailableMoney("availableCoins", ';')
                    .Select(coin => new Coin(coin)).ToArray();

                Bill[] availableBills = this.GetAvailableMoney("availableBills", ';')
                    .Select(bill => new Bill(bill)).ToArray();;

                List<IMoney> availableMoney = new List<IMoney>(availableCoins);
                availableMoney.AddRange(availableBills);

                if (availableMoney.Any() == false)
                {
                    throw new ConfigurationException("there is no money configuration");
                }

                return availableMoney.ToArray();
            }
        }

        public string LogFilePath { get { return ConfigurationManager.AppSettings["LogFilePath"];} }

        public string LogFileName { get { return ConfigurationManager.AppSettings["LogFileName"]; } }
                
    }
}
