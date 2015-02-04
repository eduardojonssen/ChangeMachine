using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utility.Log
{
    public delegate void LogErrorEventHandler(object sender, LogErrorEventArgs e);

    public abstract class BaseLogUtility
    {
        public abstract void Write(LogEntry logEntry);

        public event LogErrorEventHandler OnLogError;

        private IConfigurationUtility _configurationUtility;

        public IConfigurationUtility ConfigurationUtility {
            get {
                if (this._configurationUtility == null) { this._configurationUtility = IocFactory.Resolve<IConfigurationUtility>(); }
                return this._configurationUtility;
            }
        }

        /// <summary>
        /// Raise log error.
        /// </summary>
        /// <param name="ex"></param>
        protected void RaiseLogError(Exception ex)
        {
            if (OnLogError != null)
            {
                OnLogError(this, new LogErrorEventArgs(ex));
            }
        }

    }
}
