using ChangeMachine.Core.Processors;
using System;

namespace ChangeMachine.Core
{
    public sealed class ProcessorCompletedEventArgs : EventArgs
    {

        public ProcessorCompletedEventArgs() { }

        public ChangeData CurrentChange { get; set; }
    }
}
