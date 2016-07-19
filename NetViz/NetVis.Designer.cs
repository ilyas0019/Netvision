namespace NTTool
{
    partial class NetVis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetVis));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.chkOnline = new System.Windows.Forms.CheckBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lstDomain = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtFilter = new System.Windows.Forms.ToolStripTextBox();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanOnlineOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoteConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblScanning = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgInfo = new System.Windows.Forms.ToolStripProgressBar();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lstView = new System.Windows.Forms.ListView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showMachineDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.rdcMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lstSoftware = new System.Windows.Forms.ListView();
            this.lblStorage = new System.Windows.Forms.Label();
            this.lstStorage = new System.Windows.Forms.ListView();
            this.lblIPAddresses = new System.Windows.Forms.Label();
            this.lblNetworkDevices = new System.Windows.Forms.Label();
            this.lstIPAddress = new System.Windows.Forms.ListBox();
            this.lstNetworkDevices = new System.Windows.Forms.ListView();
            this.lblSoftware = new System.Windows.Forms.Label();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.contextSoftware = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuUninstall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.contextSoftware.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "OFF.jpg");
            this.imgList.Images.SetKeyName(1, "ON.jpg");
            this.imgList.Images.SetKeyName(2, "1467036508_knetworkconf.ico");
            // 
            // chkOnline
            // 
            this.chkOnline.AutoSize = true;
            this.chkOnline.Location = new System.Drawing.Point(383, 56);
            this.chkOnline.Name = "chkOnline";
            this.chkOnline.Size = new System.Drawing.Size(129, 17);
            this.chkOnline.TabIndex = 23;
            this.chkOnline.Text = "Online Machines Only";
            this.chkOnline.UseVisualStyleBackColor = true;
            this.chkOnline.Click += new System.EventHandler(this.chkOnline_CheckedChanged);
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(15, 37);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(25, 13);
            this.lblDomain.TabIndex = 29;
            this.lblDomain.Text = "Info";
            this.lblDomain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstDomain
            // 
            this.lstDomain.FormattingEnabled = true;
            this.lstDomain.Location = new System.Drawing.Point(14, 56);
            this.lstDomain.Name = "lstDomain";
            this.lstDomain.Size = new System.Drawing.Size(363, 30);
            this.lstDomain.TabIndex = 28;
            this.lstDomain.Click += new System.EventHandler(this.lstDomain_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.txtFilter,
            this.btnFilter,
            this.toolStripSeparator2,
            this.btnList,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1248, 25);
            this.toolStrip1.TabIndex = 32;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(91, 22);
            this.toolStripLabel1.Text = "Search Machine";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // txtFilter
            // 
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 25);
            this.txtFilter.ToolTipText = "Search Machine ";
            this.txtFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyUp);
            // 
            // btnFilter
            // 
            this.btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFilter.Image = global::NetVis.Properties.Resources.find;
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(23, 22);
            this.btnFilter.Text = "toolStripButton3";
            this.btnFilter.ToolTipText = "Search Machine ";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnList
            // 
            this.btnList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnList.Image = global::NetVis.Properties.Resources.Search_computer;
            this.btnList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(23, 22);
            this.btnList.Text = "Scan Network";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.fileToolStripMenuItem,
            this.remoteManagement});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1248, 24);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanNetworkToolStripMenuItem,
            this.scanOnlineOnly});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.fileToolStripMenuItem.Text = "Scan";
            // 
            // scanNetworkToolStripMenuItem
            // 
            this.scanNetworkToolStripMenuItem.Name = "scanNetworkToolStripMenuItem";
            this.scanNetworkToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.scanNetworkToolStripMenuItem.Text = "Scan Network";
            this.scanNetworkToolStripMenuItem.Click += new System.EventHandler(this.btnList_Click);
            // 
            // scanOnlineOnly
            // 
            this.scanOnlineOnly.Name = "scanOnlineOnly";
            this.scanOnlineOnly.Size = new System.Drawing.Size(165, 22);
            this.scanOnlineOnly.Text = "Scan Online Only";
            this.scanOnlineOnly.ToolTipText = "Scan Online Only";
            this.scanOnlineOnly.Click += new System.EventHandler(this.scanOnlineOnly_Click);
            // 
            // remoteManagement
            // 
            this.remoteManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemoteConnect});
            this.remoteManagement.Name = "remoteManagement";
            this.remoteManagement.Size = new System.Drawing.Size(134, 20);
            this.remoteManagement.Text = "Remote Management";
            // 
            // mnuRemoteConnect
            // 
            this.mnuRemoteConnect.Name = "mnuRemoteConnect";
            this.mnuRemoteConnect.Size = new System.Drawing.Size(163, 22);
            this.mnuRemoteConnect.Text = "Remote Connect";
            this.mnuRemoteConnect.Click += new System.EventHandler(this.mnuRemoteConnect_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblScanning,
            this.pgInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 711);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1248, 22);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblScanning
            // 
            this.lblScanning.Name = "lblScanning";
            this.lblScanning.Size = new System.Drawing.Size(65, 17);
            this.lblScanning.Text = "Scanning...";
            // 
            // pgInfo
            // 
            this.pgInfo.Name = "pgInfo";
            this.pgInfo.Size = new System.Drawing.Size(1000, 16);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "NetworkTool Files|*.bin";
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new System.Drawing.Point(12, 92);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lblInfo);
            this.splitContainer.Panel1.Controls.Add(this.lstView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lstSoftware);
            this.splitContainer.Panel2.Controls.Add(this.lblStorage);
            this.splitContainer.Panel2.Controls.Add(this.lstStorage);
            this.splitContainer.Panel2.Controls.Add(this.lblIPAddresses);
            this.splitContainer.Panel2.Controls.Add(this.lblNetworkDevices);
            this.splitContainer.Panel2.Controls.Add(this.lstIPAddress);
            this.splitContainer.Panel2.Controls.Add(this.lstNetworkDevices);
            this.splitContainer.Panel2.Controls.Add(this.lblSoftware);
            this.splitContainer.Size = new System.Drawing.Size(1236, 580);
            this.splitContainer.SplitterDistance = 680;
            this.splitContainer.TabIndex = 36;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(9, 1);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(25, 13);
            this.lblInfo.TabIndex = 29;
            this.lblInfo.Text = "Info";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.ContextMenuStrip = this.contextMenu;
            this.lstView.GridLines = true;
            this.lstView.Location = new System.Drawing.Point(6, 17);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(665, 559);
            this.lstView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstView.TabIndex = 28;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            this.lstView.DoubleClick += new System.EventHandler(this.lstView_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMachineDetails,
            this.rdcMenu});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(213, 48);
            // 
            // showMachineDetails
            // 
            this.showMachineDetails.Name = "showMachineDetails";
            this.showMachineDetails.Size = new System.Drawing.Size(212, 22);
            this.showMachineDetails.Text = "Show Machine Details";
            this.showMachineDetails.Click += new System.EventHandler(this.lstView_Click);
            // 
            // rdcMenu
            // 
            this.rdcMenu.Image = global::NetVis.Properties.Resources._1467036508_knetworkconf;
            this.rdcMenu.Name = "rdcMenu";
            this.rdcMenu.Size = new System.Drawing.Size(212, 22);
            this.rdcMenu.Text = "Connect Remote Machine";
            this.rdcMenu.Click += new System.EventHandler(this.rdcMenu_Click);
            // 
            // lstSoftware
            // 
            this.lstSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSoftware.ContextMenuStrip = this.contextSoftware;
            this.lstSoftware.FullRowSelect = true;
            this.lstSoftware.GridLines = true;
            this.lstSoftware.Location = new System.Drawing.Point(10, 19);
            this.lstSoftware.MultiSelect = false;
            this.lstSoftware.Name = "lstSoftware";
            this.lstSoftware.Size = new System.Drawing.Size(524, 218);
            this.lstSoftware.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstSoftware.TabIndex = 43;
            this.lstSoftware.UseCompatibleStateImageBehavior = false;
            this.lstSoftware.View = System.Windows.Forms.View.Details;
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Location = new System.Drawing.Point(9, 239);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(25, 13);
            this.lblStorage.TabIndex = 42;
            this.lblStorage.Text = "Info";
            this.lblStorage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstStorage
            // 
            this.lstStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStorage.Location = new System.Drawing.Point(10, 255);
            this.lstStorage.Name = "lstStorage";
            this.lstStorage.Size = new System.Drawing.Size(524, 86);
            this.lstStorage.TabIndex = 41;
            this.lstStorage.UseCompatibleStateImageBehavior = false;
            this.lstStorage.View = System.Windows.Forms.View.Details;
            // 
            // lblIPAddresses
            // 
            this.lblIPAddresses.AutoSize = true;
            this.lblIPAddresses.Location = new System.Drawing.Point(10, 480);
            this.lblIPAddresses.Name = "lblIPAddresses";
            this.lblIPAddresses.Size = new System.Drawing.Size(25, 13);
            this.lblIPAddresses.TabIndex = 40;
            this.lblIPAddresses.Text = "Info";
            this.lblIPAddresses.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNetworkDevices
            // 
            this.lblNetworkDevices.AutoSize = true;
            this.lblNetworkDevices.Location = new System.Drawing.Point(10, 344);
            this.lblNetworkDevices.Name = "lblNetworkDevices";
            this.lblNetworkDevices.Size = new System.Drawing.Size(25, 13);
            this.lblNetworkDevices.TabIndex = 39;
            this.lblNetworkDevices.Text = "Info";
            this.lblNetworkDevices.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstIPAddress
            // 
            this.lstIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstIPAddress.FormattingEnabled = true;
            this.lstIPAddress.Location = new System.Drawing.Point(11, 496);
            this.lstIPAddress.Name = "lstIPAddress";
            this.lstIPAddress.Size = new System.Drawing.Size(523, 82);
            this.lstIPAddress.TabIndex = 38;
            // 
            // lstNetworkDevices
            // 
            this.lstNetworkDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNetworkDevices.GridLines = true;
            this.lstNetworkDevices.Location = new System.Drawing.Point(10, 358);
            this.lstNetworkDevices.Name = "lstNetworkDevices";
            this.lstNetworkDevices.Size = new System.Drawing.Size(524, 119);
            this.lstNetworkDevices.TabIndex = 37;
            this.lstNetworkDevices.UseCompatibleStateImageBehavior = false;
            this.lstNetworkDevices.View = System.Windows.Forms.View.Details;
            this.lstNetworkDevices.Click += new System.EventHandler(this.lstNetworkDevices_Click);
            // 
            // lblSoftware
            // 
            this.lblSoftware.AutoSize = true;
            this.lblSoftware.Location = new System.Drawing.Point(10, 3);
            this.lblSoftware.Name = "lblSoftware";
            this.lblSoftware.Size = new System.Drawing.Size(25, 13);
            this.lblSoftware.TabIndex = 36;
            this.lblSoftware.Text = "Info";
            this.lblSoftware.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "*.bin";
            this.dlgSave.Filter = "Saved Files | *.bin";
            // 
            // contextSoftware
            // 
            this.contextSoftware.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUninstall});
            this.contextSoftware.Name = "contextMenu";
            this.contextSoftware.Size = new System.Drawing.Size(168, 26);
            // 
            // mnuUninstall
            // 
            this.mnuUninstall.Name = "mnuUninstall";
            this.mnuUninstall.Size = new System.Drawing.Size(167, 22);
            this.mnuUninstall.Text = "Uninstall Selected";
            this.mnuUninstall.Click += new System.EventHandler(this.toolUninstall_Click);
            // 
            // NetVis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1240, 750);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkOnline);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.lstDomain);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "NetVis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network Visualizer";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.contextSoftware.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.CheckBox chkOnline;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.ListBox lstDomain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox txtFilter;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanOnlineOnly;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblScanning;
        private System.Windows.Forms.ToolStripProgressBar pgInfo;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.ListView lstSoftware;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.ListView lstStorage;
        private System.Windows.Forms.Label lblIPAddresses;
        private System.Windows.Forms.Label lblNetworkDevices;
        private System.Windows.Forms.ListBox lstIPAddress;
        private System.Windows.Forms.ListView lstNetworkDevices;
        private System.Windows.Forms.Label lblSoftware;
        private System.Windows.Forms.ToolStripMenuItem remoteManagement;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoteConnect;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem rdcMenu;
        private System.Windows.Forms.ToolStripMenuItem showMachineDetails;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.ContextMenuStrip contextSoftware;
        private System.Windows.Forms.ToolStripMenuItem mnuUninstall;
    }
}

