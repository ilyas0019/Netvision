using Microsoft.Win32;
using NTTool.Core.Models;
using NTTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NTTool.Core.Core;
using System.Text.RegularExpressions;


namespace NTTool.Core.Classes
{
    public class WindowsMachineProvider : IMachineProvider
    {

        private static IMachineProvider obj;
        //@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall". @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

        public List<SoftwareEntity> GetListOfInstalledSoftwares(string machineName)
        {
            
            var allProgram = ReadFromRegistryKeys(RegistryHive.LocalMachine, machineName, @"Software\Microsoft\Windows\CurrentVersion\Uninstall", RegistryView.Registry32);
            var allPrograms64 = ReadFromRegistryKeys(RegistryHive.LocalMachine, machineName, @"Software\Microsoft\Windows\CurrentVersion\Uninstall", RegistryView.Registry64);
            var allPrograms_32 = ReadFromRegistryKeys(RegistryHive.LocalMachine, machineName, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall", RegistryView.Registry32);
            var allPrograms_64 = ReadFromRegistryKeys(RegistryHive.LocalMachine , machineName, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall", RegistryView.Registry64);

            var allPrograms3 = ReadFromRegistryKeys(RegistryHive.CurrentUser, machineName, @"Software\Microsoft\Windows\CurrentVersion\Uninstall", RegistryView.Registry32);
            var allPrograms4 = ReadFromRegistryKeys(RegistryHive.CurrentUser, machineName, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall", RegistryView.Registry64);

            CollectResult(allPrograms64,allProgram);

            CollectResult(allPrograms_32, allProgram);

            CollectResult(allPrograms_64, allProgram);

            CollectResult(allPrograms3, allProgram);

            CollectResult(allPrograms4, allProgram);

            return allProgram;
        }

        private void CollectResult(List<SoftwareEntity> listOfPrograms,List<SoftwareEntity> allPrograms)
        {

            foreach (var item in listOfPrograms)
            {
                if (!allPrograms.Contains(item, new SoftwareComparer()))
                {
                    allPrograms.Add(item);
                }
            }
        }

        public List<SoftwareEntity> ReadFromRegistryKeys(RegistryHive registryHive, string machineName, string registryKey, RegistryView registryView)
        {
            List<SoftwareEntity> programs = null;
            string softwareRegLoc = registryKey;
            try
            {

                // Open Remote Machine Registry Key 
                RegistryKey remoteKey = RegistryKey.OpenRemoteBaseKey(registryHive, machineName, registryView);

                RegistryKey regKey = remoteKey.OpenSubKey(softwareRegLoc);

                // Open Registry Sub Key
                RegistryKey subKey;

                // Read Value from Registry Sub Key
                string softwareName;
                string displayVersion;
                string installDate;
                string publisher;
                string estimatedSize;
                int? systemComponent = null;
                string releaseType;
                string uninstallString;
                int? noRemove = null;
                string parentKeyName = null;

                programs = new List<SoftwareEntity>();
                if (regKey != null)
                {

                    foreach (string subKeyName in regKey.GetSubKeyNames())
                    {
                        // Open Registry Sub Key
                        subKey = regKey.OpenSubKey(subKeyName);

                        // Read Value from Registry Sub Key
                        softwareName = (string)subKey.GetValue("DisplayName");
                        displayVersion = (string)subKey.GetValue("DisplayVersion");
                        installDate = (string)subKey.GetValue("InstallDate");
                        publisher = (string)subKey.GetValue("Publisher");

                        systemComponent = (int?)subKey.GetValue("SystemComponent");
                        releaseType = (string)subKey.GetValue("ReleaseType");
                        parentKeyName = (string)subKey.GetValue("ParentKeyName");
                        uninstallString = (string)subKey.GetValue("UninstallString");

                        noRemove = (int?)subKey.GetValue("NoRemove");

                        estimatedSize = subKey.GetValue("EstimatedSize") == null ? "NA" : GetSize(subKey.GetValue("EstimatedSize").ToString());

                        DateTime? installationDate = new DateTime();

                        if (!string.IsNullOrEmpty(installDate))
                        {
                            DateTime dt = DateTime.ParseExact(installDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                            installDate = dt.ToString("dd/MM/yyyy");
                            installationDate = dt;
                        }
                        else
                        {
                            installationDate = null;
                        }

                        if (!string.IsNullOrEmpty(softwareName)
                            && systemComponent != 1
                            && string.IsNullOrEmpty(releaseType)
                            && string.IsNullOrEmpty(parentKeyName)
                            && (!string.IsNullOrEmpty(uninstallString) || noRemove != 1))
                        {

                            //RegQuery.lastWriteTime("HKEY_LOCAL_MACHINE\\"+softwareRegLoc + "\\" + subKeyName);
                            installationDate = installationDate == null ? GetLastModifiedDate(uninstallString) : installationDate;

                            programs.Add(new SoftwareEntity
                            {
                                DisplayName = softwareName,
                                Version = displayVersion,
                                Publisher = publisher,
                                InstallDate = installationDate,
                                EstimatedSize = estimatedSize,
                                UnInstallLocation = uninstallString
                            });
                        }
                    }
                }
            }

            catch (Exception)
            {
                throw;
            }
            return programs;
        }

        public DateTime? GetLastModifiedDate(string path)
        {

            var filePath = path.Replace("\"", string.Empty);

            if (filePath.IndexOf(".exe")>1)
            {
                filePath = filePath.Substring(0, filePath.IndexOf(".exe")+4);
            }

            var dt = File.GetLastWriteTime(filePath);

            return dt;
        }
    
        public MachineEntity GetStorageInfoOfMachine(string machine, string domain, MachineEntity objMachine)
        {

            ManagementScope scope = new ManagementScope();
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                scope = new ManagementScope(@"\\" + machine + "\\root\\CIMV2", options);
                scope.Connect();

                SelectQuery query = new SelectQuery("SELECT * FROM Win32_LogicalDisk");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                var storageDevices = new StorageDevices();
                objMachine.ListOfStoragekDevices = new List<StorageDevices>();
                using (ManagementObjectCollection queryCollection = searcher.Get())
                {
                    foreach (ManagementObject m in queryCollection)
                    {
                        storageDevices = new StorageDevices();

                        storageDevices.Name = m["Name"] == null ? "Unavailble" : m["Name"].ToString();
                        storageDevices.Caption = m["Caption"] == null ? "Unavailble" : m["Caption"].ToString();
                        storageDevices.FreeSpace = FreeSpaceInGB(m["FreeSpace"] == null ? "0" : m["FreeSpace"].ToString());
                        storageDevices.SerialNumber = m["VolumeSerialNumber"] == null ? "Unavailble" : m["VolumeSerialNumber"].ToString();

                        objMachine.ListOfStoragekDevices.Add(storageDevices);
                    }

                }



            }

            catch (Exception)
            {
                return objMachine;
            }

            return objMachine;
        }

        public MachineEntity GetMachineAdditionalInformation(string machine, string domain, MachineEntity objMachine)
        {

            ManagementScope scope = new ManagementScope();
            try
            {
                var options = new ConnectionOptions();
                options.Authentication = AuthenticationLevel.Default;
                options.Impersonation = ImpersonationLevel.Impersonate;
                options.EnablePrivileges = true;

                scope = new ManagementScope(@"\\" + machine + "\\root\\CIMV2", options);
                scope.Connect();

                var ipaddresses = GetIPAddresses(scope);

                var networkDevices = GetNetworkDevices(scope);

                if (ipaddresses.Length > 0)
                {
                    objMachine.IPAddress = ipaddresses[0];
                }

                objMachine.IPAddresses = ipaddresses;

                objMachine.MachineMACAddress = GetDefaultMACAddress(scope);

                objMachine.ListOfNetworkDevices = networkDevices;

            }

            catch (Exception)
            {
                return objMachine;
            }

            return objMachine;
        }

        private string GetSize(string estimatedSize)
        {
            if (!string.IsNullOrEmpty(estimatedSize))
            {
                return (double.Parse(estimatedSize) / 1024).ToString(".00");
            }
            else
            {
                return estimatedSize;
            }
        }

        private string[] GetIPAddresses(ManagementScope scope)
        {

            SelectQuery query = new SelectQuery("SELECT IPAddress FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");

            ManagementObjectSearcher NetworkSearcher = new ManagementObjectSearcher(scope, query);
            string[] arrIPAddress = null;
            foreach (ManagementObject NetworkObj in NetworkSearcher.Get())
            {
                arrIPAddress = (string[])(NetworkObj["IPAddress"]);
            }

            return arrIPAddress;
        }

        private string[] GetIPAddressByMacAddress(ManagementScope scope, string macAddress)
        {

            SelectQuery query = new SelectQuery("SELECT IPAddress FROM Win32_NetworkAdapterConfiguration WHERE MACAddress = '" + macAddress + "'");

            ManagementObjectSearcher NetworkSearcher = new ManagementObjectSearcher(scope, query);
            string[] arrIPAddress = null;
            foreach (ManagementObject NetworkObj in NetworkSearcher.Get())
            {
                arrIPAddress = (string[])(NetworkObj["IPAddress"]);
            }

            return arrIPAddress;
        }

        private List<NetworkDevices> GetNetworkDevices(ManagementScope scope)
        {
            ManagementObjectSearcher objSearcher;
            ManagementObjectCollection objColl;
            ObjectQuery objQuery;
            List<NetworkDevices> objListOfNetworkDevices = new List<NetworkDevices>(); ;

            objQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter WHERE AdapterTypeID <> NULL");
            scope.Connect();

            objSearcher = new ManagementObjectSearcher(scope, objQuery);
            objSearcher.Options.Timeout = new TimeSpan(0, 0, 0, 0, 7000);
            objColl = objSearcher.Get();
            NetworkDevices objNetworkDevice;
            string[] ip = null;
            foreach (ManagementObject mo in objColl)
            {
                objNetworkDevice = new NetworkDevices();

                objNetworkDevice.DeviceID = mo["DeviceID"] == null ? "Unavailble" : mo["DeviceID"].ToString();
                objNetworkDevice.Adaptertype = mo["AdapterType"] == null ? "Unavailble" : mo["AdapterType"].ToString();
                objNetworkDevice.Description = mo["Description"] == null ? "Unavailble" : mo["Description"].ToString();
                objNetworkDevice.MACaddress = mo["MACAddress"] == null ? "Unavailble" : mo["MACAddress"].ToString();
                objNetworkDevice.Manufacturer = mo["Manufacturer"] == null ? "Unavailble" : mo["Manufacturer"].ToString();

                ip = GetIPAddressByMacAddress(scope, objNetworkDevice.MACaddress);
                objNetworkDevice.IPAddresses = ip;

                objListOfNetworkDevices.Add(objNetworkDevice);

            }

            return objListOfNetworkDevices;

        }

        private string GetDefaultMACAddress(ManagementScope scope)
        {
            SelectQuery query = new SelectQuery("Select * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection objMOC = objMOS.Get();
            string macAddress = String.Empty;
            foreach (ManagementObject objMO in objMOC)
            {
                object tempMacAddrObj = objMO["MacAddress"];

                if (tempMacAddrObj == null)
                {
                    continue;
                }
                if (macAddress == String.Empty)
                {
                    macAddress = tempMacAddrObj.ToString();
                }
                objMO.Dispose();
            }

            return macAddress;
        }

        private string FreeSpaceInGB(string freeSpace)
        {

            return ((Convert.ToDouble(freeSpace) / 1024 / 1024) / 1024).ToString("0.00");

        }

        private DateTime? FormatDate(string installDate)
        {
            return DateTime.ParseExact(installDate, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        public static IMachineProvider GetInstance()
        {
            if (obj == null)
            {
                obj = new WindowsMachineProvider();
            }
            return obj;
        }

        //private string RunPSScript(string scriptText)
        //{
        //    // create Powershell runspace

        //    Runspace runspace = RunspaceFactory.CreateRunspace();

        //    // open it

        //    runspace.Open();

        //    // create a pipeline and feed it the script text

        //    Pipeline pipeline = runspace.CreatePipeline();
        //    pipeline.Commands.AddScript(scriptText);

        //    // add an extra command to transform the script
        //    // output objects into nicely formatted strings

        //    // remove this line to get the actual objects
        //    // that the script returns. For example, the script

        //    // "Get-Process" returns a collection
        //    // of System.Diagnostics.Process instances.

        //    pipeline.Commands.Add("Out-String");

        //    // execute the script

        //    System.Collections.ObjectModel.Collection<PSObject> results = pipeline.Invoke();

        //    // close the runspace

        //    runspace.Close();

        //    // convert the script result into a single string

        //    StringBuilder stringBuilder = new StringBuilder();
        //    foreach (PSObject obj in results)
        //    {
        //        stringBuilder.AppendLine(obj.ToString());
        //    }

        //    return stringBuilder.ToString();
        //}

        //private string PrepareScript()
        //{ 
        //    StringBuilder psscript= new StringBuilder("");
        //    psscript.Append(" if (!([Diagnostics.Process]::GetCurrentProcess().Path -match '\\\\syswow64\\\\')) " + Environment.NewLine);
        //    psscript.Append(" {" + Environment.NewLine);
        //    psscript.Append(" $unistallPath = \"\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\"" + Environment.NewLine);
        //    psscript.Append(" $unistallWow6432Path = \"\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\"" + Environment.NewLine);
        //    psscript.Append(" @(" + Environment.NewLine);
        //    psscript.Append(" if (Test-Path \"HKLM:$unistallWow6432Path\" ) { Get-ChildItem \"HKLM:$unistallWow6432Path\"}" + Environment.NewLine);
        //    psscript.Append(" if (Test-Path \"HKLM:$unistallPath\") {Get-ChildItem \"HKLM:$unistallPath\" }" + Environment.NewLine);
        //    psscript.Append(" if (Test-Path \"HKCU:$unistallWow6432Path\") { Get-ChildItem \"HKCU:$unistallWow6432Path\"}" + Environment.NewLine);
        //    psscript.Append(" if (Test-Path \"HKCU:$unistallPath\" ) { Get-ChildItem \"HKCU:$unistallPath\" } ) | " + Environment.NewLine);
        //    psscript.Append(" ForEach-Object { Get-ItemProperty $_.PSPath } |  Where-Object {  $_.DisplayName -and !$_.SystemComponent -and !$_.ReleaseType -and !$_.ParentKeyName -and ($_.UninstallString -or $_.NoRemove) } | " + Environment.NewLine);
        //    psscript.Append(" Sort-Object DisplayName | Select-Object DisplayName ,SystemComponent, ReleaseType, ParentKeyName, UninstallString, NoRemove" + Environment.NewLine);
        //    psscript.Append(" }" + Environment.NewLine);
        //    psscript.Append(" else" + Environment.NewLine);
        //    psscript.Append(" {" + Environment.NewLine);
        //    psscript.Append(" You are running 32-bit Powershell on 64-bit system. Please run 64-bit Powershell instead. | Write-Host -ForegroundColor Red" + Environment.NewLine);
        //    psscript.Append(" }" + Environment.NewLine);

        //    return psscript.ToString();

        //}
    }
}



