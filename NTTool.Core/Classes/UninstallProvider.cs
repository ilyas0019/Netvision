using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using NTTool.Core.Interfaces;

namespace NTTool.Core.Classes
{
    public class UninstallProvider : IUninstallProvider
    {

        public bool InvokeUninstaller(string machineName, string uninstallString)
        {
            throw new NotImplementedException();
        }
    }
}
