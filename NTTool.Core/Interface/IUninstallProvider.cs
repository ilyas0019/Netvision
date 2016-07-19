using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTTool.Core.Interfaces
{
    public interface IUninstallProvider
    {
        bool InvokeUninstaller(string machineName, string unInstallFileName, string unInstallAurguments);
    }
}
