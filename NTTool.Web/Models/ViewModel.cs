using NTTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTTool.Models
{
    public class ViewModel
    {
        public MachineEntity MachineInfo { get; set; }
        public List<SoftwareEntity> SoftwareList    { get; set; }
    }
    


}