using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTTool.Core.Models
{
    [Serializable()]
    public class StorageDevices
    {
        public string Caption { get; set; }
        public string Name { get; set; }
        public string FreeSpace { get; set; }
        public string SerialNumber { get; set; }
    }
}
