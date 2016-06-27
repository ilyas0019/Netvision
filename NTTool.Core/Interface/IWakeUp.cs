using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTTool.Core.Interfaces

{
    interface IWakeUp
    {
        void WakeFunction(string MAC_ADDRESS, string ipAddress, string subNetMask = null);
    }
}
