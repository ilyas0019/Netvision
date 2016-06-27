using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;

namespace NTTool.Core.Models
{
    [Serializable()]
    public class MachineEntity
    {

        public string LoggedInUser { get; set; }

        public string DomainName { get; set; }

        public string DNSHostName { get; set; }

        public string MachineName { get; set; }

        public string IPAddress { get; set; }

        public string[] IPAddresses { get; set; }

        public string MachineType { get; set; }

        public string OpratingSystem { get; set; }

        public string SystemDirectory { get; set; }

        public string OpratingSystemVersion { get; set; }

        public string OpratingSystemServicePack { get; set; }

        public string Manufacturer { get; set; }

        public string MachineMACAddress { get; set; }

        public MachineStatus MachineStatus { get; set; }

        public List<NetworkDevices> ListOfNetworkDevices { get; set; }

        public List<StorageDevices> ListOfStoragekDevices { get; set; }

    }
}