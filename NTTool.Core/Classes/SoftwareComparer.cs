using NTTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTool.Core.Classes
{
    class SoftwareComparer : IEqualityComparer<SoftwareEntity>
    {
        public bool Equals(SoftwareEntity s1, SoftwareEntity s2)
        {
            return s1.DisplayName == s2.DisplayName;
        }

        public int GetHashCode(SoftwareEntity p)
        {
            return p.DisplayName.GetHashCode();
        }
        
    }
}
