using ChangeMachine.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Model;

namespace MockLibrary
{
    public class ConfigurationUtilityMock : IConfigurationUtility
    {

        public IMoney[] AvailableMoney { get; set; }
    }
}
