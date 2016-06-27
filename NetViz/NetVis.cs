﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTTool.Core;
using NTTool.Core.Models;
using System.Net;
using System.Security.Principal;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using NTTool.Core.Interfaces;
using NTTool.Core.Classes;
using System.Diagnostics;


namespace NTTool
{

    public delegate List<MachineEntity> FillNetoworkMachineList(string domain, bool onLineMachine);

    public partial class NetVis : Form
    {

        public List<MachineEntity> ListOfMachines { get; set; }
        public List<NetworkDevices> ListOfNetworkDevices { get; set; }
        public string SelectedDomain { get; set; }
        public string SelectedMachineName { get; set; }
        public int Online { get; set; }

        public NetVis()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ScanNetwork();
        }

        private void ScanNetwork()
        {
            Application.DoEvents();
            ResetPager(0);
            try
            {
                FillListOfMachines();
            }
            catch (Exception ex)
            {
                ResetPager(0);
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearForm()
        {
            lblInfo.Text = "";
            lblIPAddresses.Text = "";
            lblNetworkDevices.Text = "";
            lblStorage.Text = "";
            lblSoftware.Text = "";

            lstView.Items.Clear();
            lstNetworkDevices.Items.Clear();
            lstStorage.Items.Clear();
            lstIPAddress.DataSource = null;
            lstSoftware.Items.Clear();

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterFill();

        }

        private void FilterFill()
        {
            ResetPager(0);

            if (ListOfMachines != null)
            {
                FillListOfMachines(SearchMachine(txtFilter.Text.ToUpper()));
            }
            else
            {
                MessageBox.Show("Please scan your network first");
            }
        }

        private void lstView_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            try
            {

                lstNetworkDevices.Items.Clear();
                lstIPAddress.DataSource = null;
                lstStorage.Items.Clear();
                lstSoftware.Items.Clear();
                SelectedMachineName = lstView.SelectedItems[0].SubItems[1].Text;
                
                if (DomainProvider.GetInstance().IsDomainAdministrator || Dns.GetHostName() == SelectedMachineName)
                {
                    InitCursor();
                    GetListofSofwares();
                    PopulateNetworkDevices();
                    FillStorage();
                    ResetCursor();
                }
                else
                {
                    MessageBox.Show("Please login as domain admin to see other system details");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void lstNetworkDevices_Click(object sender, EventArgs e)
        {
            GetListofIPAddresses();

        }

        private void FillStorage()
        {
            var objMachine = ListOfMachines.Where(x => x.MachineName == SelectedMachineName).ToList().FirstOrDefault();
            objMachine = WindowsMachineProvider.GetInstance().GetStorageInfoOfMachine(SelectedMachineName, SelectedDomain, objMachine);
            lstStorage.Items.Clear();
            lstStorage.FullRowSelect = true;
            ListViewItem lvi;
            foreach (var item in objMachine.ListOfStoragekDevices)
            {
                lvi = new ListViewItem(item.Name);
                lvi.SubItems.Add(item.SerialNumber);
                lvi.SubItems.Add(item.FreeSpace);

                lstStorage.Items.Add(lvi);
            }



            lblStorage.Text = string.Format("{0} Storage Devices found on machine {1} ", objMachine.ListOfStoragekDevices == null ? 0 : objMachine.ListOfStoragekDevices.Count, SelectedMachineName);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {

                ClearForm();

                lstView.Items.Clear();
                lstView.FullRowSelect = true;
                lstView.SmallImageList = imgList;

                // Attach Subitems to the ListView
                lstView.Columns.Clear();
                lstView.Columns.Add("Machine Status", 100, HorizontalAlignment.Left);
                lstView.Columns.Add("Machine Name", 100, HorizontalAlignment.Left);
                lstView.Columns.Add("Machine IP", 80, HorizontalAlignment.Left);
                lstView.Columns.Add("Machine MAC", 100, HorizontalAlignment.Left);
                lstView.Columns.Add("Machine OS", 130, HorizontalAlignment.Left);
                lstView.Columns.Add("OS Version", 70, HorizontalAlignment.Left);
                lstView.Columns.Add("System Service Pack", 150, HorizontalAlignment.Left);

                lstNetworkDevices.Items.Clear();
                lstNetworkDevices.FullRowSelect = true;

                lstSoftware.Columns.Clear();
                lstSoftware.Columns.Add("Title", 150, HorizontalAlignment.Left);
                lstSoftware.Columns.Add("Version", 50, HorizontalAlignment.Left);
                lstSoftware.Columns.Add("Installation Date", 80, HorizontalAlignment.Left);
                lstSoftware.Columns.Add("Publisher", 100, HorizontalAlignment.Left);
                lstSoftware.Columns.Add("Uninstall Location", 0, HorizontalAlignment.Left);

                // Attach Subitems to the ListView
                lstNetworkDevices.Columns.Clear();
                lstNetworkDevices.Columns.Add("Device ID", 60, HorizontalAlignment.Left);
                lstNetworkDevices.Columns.Add("Adapter Type", 100, HorizontalAlignment.Left);
                lstNetworkDevices.Columns.Add("Description", 200, HorizontalAlignment.Left);
                lstNetworkDevices.Columns.Add("MACAddress", 150, HorizontalAlignment.Left);
                lstNetworkDevices.Columns.Add("Manufacturer", 100, HorizontalAlignment.Left);

                lstStorage.Columns.Clear();
                lstStorage.Columns.Add("Name", 50, HorizontalAlignment.Left);
                lstStorage.Columns.Add("Serial Number", 100, HorizontalAlignment.Left);
                lstStorage.Columns.Add("Free Space(GB)", 150, HorizontalAlignment.Right);

                FillDomain();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void buttonAction_Click(object sender, EventArgs e)
        {
            
        }

       

        private void FillDomain()
        {

            var loggedinUser = WindowsIdentity.GetCurrent().Name.Split('\\')[1];
            var domains = DomainProvider.GetInstance().EnumerateDomains(loggedinUser);
            lblDomain.Text = string.Format("Domain({0})", domains.Count);
            lstDomain.DataSource = domains;

            SelectedDomain = domains.FirstOrDefault();

        }

        private void FillListOfMachines(string searchString = null)
        {
            
            ClearForm();

            InitCursor();
            
            ListOfMachines = GetNetworkMachineData(searchString);

            FillListOfMachines(ListOfMachines);

            ResetCursor();

            lblScanning.Text = string.Format(lblScanning.Text + "- Ended at {0}", DateTime.Now);
        }

        private List<MachineEntity> GetNetworkMachineData(string searchString = null)
        {
            var listOfMachines = NetworkProvider.GetInstance().DomainNetworkComputers(SelectedDomain, chkOnline.Checked);

            if (!string.IsNullOrEmpty(searchString))
            {
                listOfMachines = listOfMachines.Where(x => x.MachineName.Contains(searchString)).ToList();
            }

            return listOfMachines;
        }

        private List<MachineEntity> SearchMachine(string searchString = null)
        {
            var listOfMachines = new List<MachineEntity>();
            if (!string.IsNullOrEmpty(searchString))
            {
                listOfMachines = ListOfMachines.Where(x => x.MachineName.Contains(searchString)).ToList();
            }
            else
            {
                listOfMachines = ListOfMachines;
            }

            return listOfMachines;
        }

        public void FillListOfMachines(List<MachineEntity> listOfMachines)
        {
            lblSoftware.Text = "";
            lblInfo.Text = "";
            lblScanning.Text = string.Format("Scanning stared at {0}", DateTime.Now);

            lstView.Items.Clear();
            lstView.FullRowSelect = true;
            lstSoftware.Items.Clear();
                      
            MachineEntity objMachine = new MachineEntity();

            ResetPager(listOfMachines.Count);
            Online = 0;
            foreach (var item in listOfMachines)
            {
                FillMachineDetail(item);
            }

           
            lblInfo.Text = string.Format("Total no of machines is '{0}' currently online '{1}'", listOfMachines.Count, Online);
        }

        private void FillMachineDetail(MachineEntity item)
        {
         
            if (Dns.GetHostName() == item.MachineName)
            {
                WindowsMachineProvider.GetInstance().GetMachineAdditionalInformation(item.MachineName, SelectedDomain, item);
                item.MachineStatus = MachineStatus.Online;
            }

            ListViewItem lvi = new ListViewItem(Enum.GetName(typeof(MachineStatus), item.MachineStatus));
            lvi.SubItems.Add(item.MachineName);
            lvi.SubItems.Add(item.IPAddress);
            lvi.SubItems.Add(item.MachineMACAddress);
            lvi.SubItems.Add(item.OpratingSystem);
            lvi.SubItems.Add(item.OpratingSystemVersion);
            lvi.SubItems.Add(item.OpratingSystemServicePack);
            if (item.MachineStatus == MachineStatus.Online)
            {
                lvi.ImageIndex = 1;
                Online++;
            }
            else
            {
                lvi.ImageIndex = 0;
            }

            lvi.ToolTipText = "Double click to see detail of selected machine";
            lstView.Items.Add(lvi);
            pgInfo.Value++;


            //Button buttonAction = new Button();
            //buttonAction.Text = "Click me";
            //buttonAction.BackColor = SystemColors.ButtonFace;
            //buttonAction.Click += buttonAction_Click;
            //Point p = this.lstView.Items[1].Position;
            //p.X -= 21;
            //buttonAction.Location = p;
            //buttonAction.Size = this.lstView.Items[1].Bounds.Size;
            //this.lstView.Controls.Add(buttonAction);



        }

        private void ResetPager(int maxValue)
        {
            pgInfo.Minimum = 0;
            pgInfo.Value = 0;
            pgInfo.Maximum = maxValue;
        }

        private void GetListofSofwares()
        {

            SelectedMachineName = lstView.SelectedItems[0].SubItems[1].Text;

            var listOfSoftwares = WindowsMachineProvider.GetInstance().GetListOfInstalledSoftwares(SelectedMachineName);
            
            string installationDate = string.Empty;
            foreach (var item in listOfSoftwares)
            {
                installationDate= item.InstallDate==null? "" : item.InstallDate.ToString();
                ListViewItem lvi = new ListViewItem(item.DisplayName);
                lvi.SubItems.Add(item.Version);
                lvi.SubItems.Add(installationDate);
                lvi.SubItems.Add(item.Publisher);
                lvi.SubItems.Add(item.UnInstallLocation);
                lstSoftware.Items.Add(lvi);
            }
            
            lblSoftware.Text = string.Format("{0} Software Installed on machine {1}", listOfSoftwares == null ? 0 : listOfSoftwares.Count, SelectedMachineName);

        }

        private void GetListofIPAddresses()
        {
            var macAddress = lstNetworkDevices.SelectedItems[0].SubItems[3].Text;
            var listOfIPAddresses = ListOfNetworkDevices.Where(x => x.MACaddress == macAddress).ToList().FirstOrDefault();

            lstIPAddress.DataSource = listOfIPAddresses.IPAddresses;

            lblIPAddresses.Text = string.Format("{0} IPAddresses found on machine {1} with MACAddress {2} ", listOfIPAddresses.IPAddresses == null ? 0 : listOfIPAddresses.IPAddresses.Length, lstView.SelectedItems[0].SubItems[1].Text, macAddress);
        }

        private void PopulateNetworkDevices()
        {
            var machineName = lstView.SelectedItems[0].SubItems[1].Text;

            var machineDetails = ListOfMachines.Where(x => x.MachineName == machineName).ToList().FirstOrDefault();


            machineDetails = WindowsMachineProvider.GetInstance().GetMachineAdditionalInformation(machineName, SelectedDomain, machineDetails);

            ListOfNetworkDevices = machineDetails.ListOfNetworkDevices;

            foreach (var item in machineDetails.ListOfNetworkDevices)
            {
                ListViewItem lvi = new ListViewItem(item.DeviceID);
                lvi.SubItems.Add(item.Adaptertype);
                lvi.SubItems.Add(item.Description);
                lvi.SubItems.Add(item.MACaddress);
                lvi.SubItems.Add(item.Manufacturer);
                lstNetworkDevices.Items.Add(lvi);
            }

            lblNetworkDevices.Text = string.Format("{0} NetworkDevices Installed on machine :{1}", machineDetails.ListOfNetworkDevices == null ? 0 : machineDetails.ListOfNetworkDevices.Count, lstView.SelectedItems[0].SubItems[1].Text);
        }

        private void scanOnlineOnly_Click(object sender, EventArgs e)
        {
            chkOnline.Checked = true;
            ScanNetwork();
        }

        private void chkOnline_CheckedChanged(object sender, EventArgs e)
        {

            if (ListOfMachines == null)
            {
                MessageBox.Show("Please scan network first");
                chkOnline.Checked = false;
                return;
            }
            
            if (chkOnline.Checked)
            {
                var list = ListOfMachines.Where(x => x.MachineStatus == MachineStatus.Online).ToList();
                FillListOfMachines(list);
            }
            else
            {
                FillListOfMachines(ListOfMachines);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveResults()
        {
            if (ListOfMachines != null)
            {
                var dataFilePath = Application.StartupPath + "\\";
                var fileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.Ticks.ToString() + ".bin";
                
                using (Stream stream = File.Open(dataFilePath + fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, ListOfMachines);
                }
            }
            else
            {
                MessageBox.Show("No machine are listed.");
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveResults();
        }

        private void ReadResult(string fileName)
        {

            using (Stream stream = File.Open(fileName, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();

                ListOfMachines = (List<MachineEntity>)bin.Deserialize(stream);
                ClearForm();
                FillListOfMachines(ListOfMachines);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dlgOpen.InitialDirectory = Application.StartupPath;
            dlgOpen.ShowDialog();
            var fileName = dlgOpen.FileName;
            if (!string.IsNullOrEmpty(fileName))
            {
                ReadResult(fileName);
            }
        }

        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterFill();
            }
        }

        private void lstDomain_Click(object sender, EventArgs e)
        {
            SelectedDomain = lstDomain.SelectedItem.ToString();
        }

        private void wakeUpSelectedMachine_Click(object sender, EventArgs e)
        {
            var objWakeU = new WakeUp();
            var objMachine = ListOfMachines.Where(x => x.MachineName == SelectedMachineName).FirstOrDefault();
            objWakeU.WakeFunction(objMachine.MachineMACAddress,objMachine.IPAddress);
        }

        private void InitCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        public override void ResetCursor()
        {
            Cursor.Current = Cursors.Default;
        }

        private void mnuRemoteConnect_Click(object sender, EventArgs e)
        {
            RemoteConnect(SelectedMachineName);
        }
        protected void RemoteConnect(string machine)
        {
            Process rdcProcess = new Process();
            rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            rdcProcess.StartInfo.Arguments = "/v " + machine;
            rdcProcess.Start();
        }

        private void lstView_DoubleClick(object sender, EventArgs e)
        {
            RemoteConnect(SelectedMachineName);
        }

        public EventHandler btn_Click { get; set; }

        private void rdcMenu_Click(object sender, EventArgs e)
        {
            RemoteConnect(SelectedMachineName);
        }
    }
}
