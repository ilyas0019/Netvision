using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using NTTool.Core.Interfaces;
using System.Diagnostics;

namespace NTTool.Core.Classes
{
    public class UninstallProvider : IUninstallProvider
    {

        public bool InvokeUninstaller(string machineName, string unInstallFileName, string unInstallAurguments)
        {
            var path = @"D:\Projects\Netvision\Netvision\EmbdedTools\paexec.exe";

            Process p = new Process();
            p.StartInfo.FileName = path;
            p.StartInfo.Arguments = @"\\"+ machineName + " \"" + unInstallFileName + "\" /qn";
            p.Start();
            //" \"msiexec.exe /x {F98C2FAC-6DFB-43AB-8B99-8F6907589021} /qn\" ";
            return true;
        }
    }
}
