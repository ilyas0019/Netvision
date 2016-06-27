using NTTool.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTool.Core.Interfaces
{
    public interface INetworkProvider
    {

        List<MachineEntity> DomainNetworkComputers(string domainName, bool onLineMachinesOnly=false);
    }
}
