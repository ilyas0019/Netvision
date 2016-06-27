using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTTool.Core.Models
{
    public class SoftwareEntity
    {

        public DateTime? InstallDate { get; set; }

        public string UnInstallLocation { get; set; }

        public string Publisher { get; set; }

        public string EstimatedSize { get; set; }
        
        public string Version { get; set; }

        public string DisplayName { get; set; }

        public string ReleaseType { get; set; }

    }
}