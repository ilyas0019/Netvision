using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTTool.Core.Interfaces;
using NTTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTool.Tests
{
    [TestClass]
    public class AppTest
    {

        [TestMethod]
        public void GetListOfInstalledSoftwares()
        {
            var obj = new MockMachineProivder();
            var list = obj.GetListOfInstalledSoftwares("machine");
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void GetDomains()
        {
            var network = new MockNetworkProivder();
            Assert.IsTrue(network.EnumerateDomains().Count > 0);
        }

        [TestMethod]
        public void GetDomainNetworkComputers()
        {
            var network = new MockNetworkProivder();
            Assert.IsTrue(network.DomainNetworkComputers("Domain").Count > 0);
        }

        [TestMethod]
        public void ActiveNetworkComputers()
        {
            var network = new MockNetworkProivder();
            var machineInfo = network.NetworkComputers();
            Assert.IsTrue(machineInfo.Count>0);
        }
    }

    public class MockMachineProivder : IMachineProvider
    {

        public List<NTTool.Core.Models.SoftwareEntity> GetListOfInstalledSoftwares(string machineName)
        {
            var objList = new List<NTTool.Core.Models.SoftwareEntity>();
            objList.Add(new NTTool.Core.Models.SoftwareEntity { DisplayName = "Test" });
            return objList;
        }


        public MachineEntity GetMachineAdditionalInformation(string machine, string domain, MachineEntity objMachine)
        {
            throw new NotImplementedException();
        }

        public MachineEntity GetStorageInfoOfMachine(string machine, string domain, MachineEntity objMachine)
        {
            throw new NotImplementedException();
        }
    }

    public class MockNetworkProivder : INetworkProvider
    {
        

        public List<string> EnumerateDomains()
        {
            var obj = new List<string>();
            obj.Add("Domain");
            return obj;
        }

        public List<NTTool.Core.Models.MachineEntity> DomainNetworkComputers(string domainName)
        {
            var objList = new List<NTTool.Core.Models.MachineEntity>();
            objList.Add(new NTTool.Core.Models.MachineEntity { DomainName = "Domain", OpratingSystem = "Windows" });
            return objList;
        }

        public NTTool.Core.Models.MachineEntity GetMachineAdditionalInformation(string machine, string domain, NTTool.Core.Models.MachineEntity objMachine)
        {
            objMachine.DomainName = "Domain";
            objMachine.OpratingSystem = "Windows";

            return objMachine;
        }


        public List<MachineEntity> NetworkComputers()
        {

            var objList = new List<NTTool.Core.Models.MachineEntity>();
            objList.Add(new NTTool.Core.Models.MachineEntity { DomainName = "Domain", OpratingSystem = "Windows" });
            return objList;
        }

        public bool IsDomainAdministrator
        {
            get;
            set;
        }

        public List<MachineEntity> DomainNetworkComputers(string domainName, bool onLineMachinesOnly = false)
        {
            throw new NotImplementedException();
        }
    }

}
