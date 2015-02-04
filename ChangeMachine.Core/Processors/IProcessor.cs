using System;
using System.Collections.Generic;

namespace ChangeMachine.Core.Processors
{
    public interface IProcessor
    {
        List<KeyValuePair<uint, ulong>> Calculate(ulong changeAmount);

        uint[] GetAcceptedValues();

        string GetName();
    }
}
