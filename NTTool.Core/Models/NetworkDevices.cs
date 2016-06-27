using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTTool.Core.Models
{
     [Serializable()] 
    public class NetworkDevices
    {
        public string DeviceID { get; set; }
        public string Adaptertype { get; set; }
        public string Description { get; set; }
        public string MACaddress { get; set; }
        public string Manufacturer { get; set; }
        public string[] IPAddresses  { get; set; }
    }
}
