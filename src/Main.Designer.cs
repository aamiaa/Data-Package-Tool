
namespace Data_Package_Tool
{
    partial class Main
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.loadTb = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.loadFileBtn = new System.Windows.Forms.Button();
            this.loadingLb = new System.Windows.Forms.Label();
            this.messagesTab = new System.Windows.Forms.TabPage();
            this.searchOptionsBtn = new System.Windows.Forms.Button();
            this.messagesNextBtn = new System.Windows.Forms.Button();
            this.messagesPrevBtn = new System.Windows.Forms.Button();
            this.massDeleteBtn = new System.Windows.Forms.Button();
            this.resultsCountLb = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchTb = new System.Windows.Forms.TextBox();
            this.imagesTab = new System.Windows.Forms.TabPage();
            this.imagesPanel = new System.Windows.Forms.Panel();
            this.imagesCountLb = new System.Windows.Forms.Label();
            this.imagesNextBtn = new System.Windows.Forms.Button();
            this.imagesPrevBtn = new System.Windows.Forms.Button();
            this.serversTab = new System.Windows.Forms.TabPage();
            this.serversStatusStrip = new System.Windows.Forms.StatusStrip();
            this.serversStatusLb = new System.Windows.Forms.ToolStripStatusLabel();
            this.serversPb = new System.Windows.Forms.ToolStripProgressBar();
            this.serversLv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serversContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyInvitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmsTab = new System.Windows.Forms.TabPage();
            this.dmsLv = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dmsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDmSELFBOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyUserIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyChannelIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webCanaryRb = new System.Windows.Forms.RadioButton();
            this.webPTBRb = new System.Windows.Forms.RadioButton();
            this.webStableRb = new System.Windows.Forms.RadioButton();
            this.defaultRb = new System.Windows.Forms.RadioButton();
            this.canaryRb = new System.Windows.Forms.RadioButton();
            this.ptbRb = new System.Windows.Forms.RadioButton();
            this.stableRb = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.massDeleteTimer = new System.Windows.Forms.Timer(this.components);
            this.searchBw = new System.ComponentModel.BackgroundWorker();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.loadTimer = new System.Windows.Forms.Timer(this.components);
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.listWPF1 = new Data_Package_Tool.MessageListWPF();
            this.tabControl1.SuspendLayout();
            this.loadTb.SuspendLayout();
            this.messagesTab.SuspendLayout();
            this.imagesTab.SuspendLayout();
            this.serversTab.SuspendLayout();
            this.serversStatusStrip.SuspendLayout();
            this.serversContextMenu.SuspendLayout();
            this.dmsTab.SuspendLayout();
            this.dmsContextMenu.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.loadTb);
            this.tabControl1.Controls.Add(this.messagesTab);
            this.tabControl1.Controls.Add(this.imagesTab);
            this.tabControl1.Controls.Add(this.serversTab);
            this.tabControl1.Controls.Add(this.dmsTab);
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 317);
            this.tabControl1.TabIndex = 0;
            // 
            // loadTb
            // 
            this.loadTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.loadTb.Controls.Add(this.progressBar1);
            this.loadTb.Controls.Add(this.loadFileBtn);
            this.loadTb.Controls.Add(this.loadingLb);
            this.loadTb.Location = new System.Drawing.Point(4, 22);
            this.loadTb.Name = "loadTb";
            this.loadTb.Padding = new System.Windows.Forms.Padding(3);
            this.loadTb.Size = new System.Drawing.Size(580, 291);
            this.loadTb.TabIndex = 2;
            this.loadTb.Text = "Load Data Package";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(8, 241);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(566, 23);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // loadFileBtn
            // 
            this.loadFileBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loadFileBtn.Location = new System.Drawing.Point(251, 167);
            this.loadFileBtn.Name = "loadFileBtn";
            this.loadFileBtn.Size = new System.Drawing.Size(75, 23);
            this.loadFileBtn.TabIndex = 0;
            this.loadFileBtn.Text = "Load File";
            this.loadFileBtn.UseVisualStyleBackColor = true;
            this.loadFileBtn.Click += new System.EventHandler(this.loadFileBtn_Click);
            // 
            // loadingLb
            // 
            this.loadingLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.loadingLb.ForeColor = System.Drawing.SystemColors.Control;
            this.loadingLb.Location = new System.Drawing.Point(6, 3);
            this.loadingLb.Name = "loadingLb";
            this.loadingLb.Size = new System.Drawing.Size(571, 227);
            this.loadingLb.TabIndex = 2;
            this.loadingLb.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // messagesTab
            // 
            this.messagesTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.messagesTab.Controls.Add(this.elementHost1);
            this.messagesTab.Controls.Add(this.searchOptionsBtn);
            this.messagesTab.Controls.Add(this.messagesNextBtn);
            this.messagesTab.Controls.Add(this.messagesPrevBtn);
            this.messagesTab.Controls.Add(this.massDeleteBtn);
            this.messagesTab.Controls.Add(this.resultsCountLb);
            this.messagesTab.Controls.Add(this.searchBtn);
            this.messagesTab.Controls.Add(this.searchTb);
            this.messagesTab.Location = new System.Drawing.Point(4, 22);
            this.messagesTab.Name = "messagesTab";
            this.messagesTab.Padding = new System.Windows.Forms.Padding(3);
            this.messagesTab.Size = new System.Drawing.Size(580, 291);
            this.messagesTab.TabIndex = 0;
            this.messagesTab.Text = "Messages";
            // 
            // searchOptionsBtn
            // 
            this.searchOptionsBtn.Location = new System.Drawing.Point(265, 6);
            this.searchOptionsBtn.Name = "searchOptionsBtn";
            this.searchOptionsBtn.Size = new System.Drawing.Size(55, 20);
            this.searchOptionsBtn.TabIndex = 7;
            this.searchOptionsBtn.Text = "Options";
            this.searchOptionsBtn.UseVisualStyleBackColor = true;
            this.searchOptionsBtn.Click += new System.EventHandler(this.searchOptionsBtn_Click);
            // 
            // messagesNextBtn
            // 
            this.messagesNextBtn.Location = new System.Drawing.Point(352, 5);
            this.messagesNextBtn.Name = "messagesNextBtn";
            this.messagesNextBtn.Size = new System.Drawing.Size(20, 20);
            this.messagesNextBtn.TabIndex = 6;
            this.messagesNextBtn.Text = ">";
            this.messagesNextBtn.UseVisualStyleBackColor = true;
            this.messagesNextBtn.Click += new System.EventHandler(this.messagesNextBtn_Click);
            // 
            // messagesPrevBtn
            // 
            this.messagesPrevBtn.Location = new System.Drawing.Point(326, 5);
            this.messagesPrevBtn.Name = "messagesPrevBtn";
            this.messagesPrevBtn.Size = new System.Drawing.Size(20, 20);
            this.messagesPrevBtn.TabIndex = 5;
            this.messagesPrevBtn.Text = "<";
            this.messagesPrevBtn.UseVisualStyleBackColor = true;
            this.messagesPrevBtn.Click += new System.EventHandler(this.messagesPrevBtn_Click);
            // 
            // massDeleteBtn
            // 
            this.massDeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.massDeleteBtn.Location = new System.Drawing.Point(497, 5);
            this.massDeleteBtn.Name = "massDeleteBtn";
            this.massDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.massDeleteBtn.TabIndex = 4;
            this.massDeleteBtn.Text = "Mass Delete";
            this.massDeleteBtn.UseVisualStyleBackColor = true;
            this.massDeleteBtn.Click += new System.EventHandler(this.massDeleteBtn_Click);
            // 
            // resultsCountLb
            // 
            this.resultsCountLb.AutoSize = true;
            this.resultsCountLb.ForeColor = System.Drawing.SystemColors.Control;
            this.resultsCountLb.Location = new System.Drawing.Point(378, 9);
            this.resultsCountLb.Name = "resultsCountLb";
            this.resultsCountLb.Size = new System.Drawing.Size(0, 13);
            this.resultsCountLb.TabIndex = 3;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(198, 6);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(55, 20);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchTb
            // 
            this.searchTb.Location = new System.Drawing.Point(6, 6);
            this.searchTb.Name = "searchTb";
            this.searchTb.Size = new System.Drawing.Size(186, 20);
            this.searchTb.TabIndex = 0;
            // 
            // imagesTab
            // 
            this.imagesTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.imagesTab.Controls.Add(this.imagesPanel);
            this.imagesTab.Controls.Add(this.imagesCountLb);
            this.imagesTab.Controls.Add(this.imagesNextBtn);
            this.imagesTab.Controls.Add(this.imagesPrevBtn);
            this.imagesTab.Location = new System.Drawing.Point(4, 22);
            this.imagesTab.Name = "imagesTab";
            this.imagesTab.Padding = new System.Windows.Forms.Padding(3);
            this.imagesTab.Size = new System.Drawing.Size(580, 291);
            this.imagesTab.TabIndex = 1;
            this.imagesTab.Text = "Images";
            // 
            // imagesPanel
            // 
            this.imagesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagesPanel.Location = new System.Drawing.Point(8, 35);
            this.imagesPanel.Name = "imagesPanel";
            this.imagesPanel.Size = new System.Drawing.Size(564, 248);
            this.imagesPanel.TabIndex = 3;
            // 
            // imagesCountLb
            // 
            this.imagesCountLb.AutoSize = true;
            this.imagesCountLb.ForeColor = System.Drawing.SystemColors.Control;
            this.imagesCountLb.Location = new System.Drawing.Point(69, 12);
            this.imagesCountLb.Name = "imagesCountLb";
            this.imagesCountLb.Size = new System.Drawing.Size(0, 13);
            this.imagesCountLb.TabIndex = 2;
            this.imagesCountLb.DoubleClick += new System.EventHandler(this.imagesCountLb_DoubleClick);
            // 
            // imagesNextBtn
            // 
            this.imagesNextBtn.Location = new System.Drawing.Point(38, 6);
            this.imagesNextBtn.Name = "imagesNextBtn";
            this.imagesNextBtn.Size = new System.Drawing.Size(24, 23);
            this.imagesNextBtn.TabIndex = 1;
            this.imagesNextBtn.Text = ">";
            this.imagesNextBtn.UseVisualStyleBackColor = true;
            this.imagesNextBtn.Click += new System.EventHandler(this.imagesNextBtn_Click);
            // 
            // imagesPrevBtn
            // 
            this.imagesPrevBtn.Location = new System.Drawing.Point(8, 6);
            this.imagesPrevBtn.Name = "imagesPrevBtn";
            this.imagesPrevBtn.Size = new System.Drawing.Size(24, 23);
            this.imagesPrevBtn.TabIndex = 0;
            this.imagesPrevBtn.Text = "<";
            this.imagesPrevBtn.UseVisualStyleBackColor = true;
            this.imagesPrevBtn.Click += new System.EventHandler(this.imagesPrevBtn_Click);
            // 
            // serversTab
            // 
            this.serversTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.serversTab.Controls.Add(this.serversStatusStrip);
            this.serversTab.Controls.Add(this.serversLv);
            this.serversTab.Location = new System.Drawing.Point(4, 22);
            this.serversTab.Name = "serversTab";
            this.serversTab.Padding = new System.Windows.Forms.Padding(3);
            this.serversTab.Size = new System.Drawing.Size(580, 291);
            this.serversTab.TabIndex = 4;
            this.serversTab.Text = "Servers";
            // 
            // serversStatusStrip
            // 
            this.serversStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serversStatusLb,
            this.serversPb});
            this.serversStatusStrip.Location = new System.Drawing.Point(3, 266);
            this.serversStatusStrip.Name = "serversStatusStrip";
            this.serversStatusStrip.Size = new System.Drawing.Size(574, 22);
            this.serversStatusStrip.TabIndex = 1;
            this.serversStatusStrip.Text = "statusStrip1";
            this.serversStatusStrip.Visible = false;
            // 
            // serversStatusLb
            // 
            this.serversStatusLb.BackColor = System.Drawing.SystemColors.Control;
            this.serversStatusLb.Name = "serversStatusLb";
            this.serversStatusLb.Size = new System.Drawing.Size(59, 17);
            this.serversStatusLb.Text = "Loading...";
            // 
            // serversPb
            // 
            this.serversPb.MarqueeAnimationSpeed = 0;
            this.serversPb.Name = "serversPb";
            this.serversPb.Size = new System.Drawing.Size(200, 16);
            // 
            // serversLv
            // 
            this.serversLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.serversLv.ContextMenuStrip = this.serversContextMenu;
            this.serversLv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serversLv.FullRowSelect = true;
            this.serversLv.HideSelection = false;
            this.serversLv.Location = new System.Drawing.Point(3, 3);
            this.serversLv.Name = "serversLv";
            this.serversLv.Size = new System.Drawing.Size(574, 285);
            this.serversLv.TabIndex = 0;
            this.serversLv.UseCompatibleStateImageBehavior = false;
            this.serversLv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 76;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Guild Id";
            this.columnHeader2.Width = 91;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Guild Name";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Join Method";
            this.columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Join Context";
            this.columnHeader4.Width = 81;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Invites";
            this.columnHeader5.Width = 120;
            // 
            // serversContextMenu
            // 
            this.serversContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyIdToolStripMenuItem,
            this.copyInvitesToolStripMenuItem});
            this.serversContextMenu.Name = "serversContextMenu";
            this.serversContextMenu.Size = new System.Drawing.Size(140, 48);
            // 
            // copyIdToolStripMenuItem
            // 
            this.copyIdToolStripMenuItem.Name = "copyIdToolStripMenuItem";
            this.copyIdToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.copyIdToolStripMenuItem.Text = "Copy id";
            this.copyIdToolStripMenuItem.Click += new System.EventHandler(this.copyIdToolStripMenuItem_Click);
            // 
            // copyInvitesToolStripMenuItem
            // 
            this.copyInvitesToolStripMenuItem.Name = "copyInvitesToolStripMenuItem";
            this.copyInvitesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.copyInvitesToolStripMenuItem.Text = "Copy invites";
            this.copyInvitesToolStripMenuItem.Click += new System.EventHandler(this.copyInvitesToolStripMenuItem_Click);
            // 
            // dmsTab
            // 
            this.dmsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.dmsTab.Controls.Add(this.dmsLv);
            this.dmsTab.Location = new System.Drawing.Point(4, 22);
            this.dmsTab.Name = "dmsTab";
            this.dmsTab.Padding = new System.Windows.Forms.Padding(3);
            this.dmsTab.Size = new System.Drawing.Size(580, 291);
            this.dmsTab.TabIndex = 5;
            this.dmsTab.Text = "Direct Messages";
            // 
            // dmsLv
            // 
            this.dmsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.dmsLv.ContextMenuStrip = this.dmsContextMenu;
            this.dmsLv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dmsLv.FullRowSelect = true;
            this.dmsLv.HideSelection = false;
            this.dmsLv.Location = new System.Drawing.Point(3, 3);
            this.dmsLv.Name = "dmsLv";
            this.dmsLv.Size = new System.Drawing.Size(574, 285);
            this.dmsLv.TabIndex = 0;
            this.dmsLv.UseCompatibleStateImageBehavior = false;
            this.dmsLv.View = System.Windows.Forms.View.Details;
            this.dmsLv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.dmsLv_ColumnClick);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Date";
            this.columnHeader7.Width = 83;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Channel Id";
            this.columnHeader8.Width = 110;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "User Id";
            this.columnHeader9.Width = 132;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Username";
            this.columnHeader10.Width = 147;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "# of your msgs";
            this.columnHeader11.Width = 81;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Note";
            this.columnHeader12.Width = 300;
            // 
            // dmsContextMenu
            // 
            this.dmsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewUserToolStripMenuItem,
            this.openDmSELFBOTToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyUserIdToolStripMenuItem,
            this.copyChannelIdToolStripMenuItem});
            this.dmsContextMenu.Name = "dmsContextMenu";
            this.dmsContextMenu.Size = new System.Drawing.Size(181, 98);
            // 
            // viewUserToolStripMenuItem
            // 
            this.viewUserToolStripMenuItem.Name = "viewUserToolStripMenuItem";
            this.viewUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewUserToolStripMenuItem.Text = "View user";
            this.viewUserToolStripMenuItem.Click += new System.EventHandler(this.viewUserToolStripMenuItem_Click);
            // 
            // openDmSELFBOTToolStripMenuItem
            // 
            this.openDmSELFBOTToolStripMenuItem.Name = "openDmSELFBOTToolStripMenuItem";
            this.openDmSELFBOTToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openDmSELFBOTToolStripMenuItem.Text = "Open dm (SELFBOT)";
            this.openDmSELFBOTToolStripMenuItem.Click += new System.EventHandler(this.openDmSELFBOTToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // copyUserIdToolStripMenuItem
            // 
            this.copyUserIdToolStripMenuItem.Name = "copyUserIdToolStripMenuItem";
            this.copyUserIdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyUserIdToolStripMenuItem.Text = "Copy user id";
            this.copyUserIdToolStripMenuItem.Click += new System.EventHandler(this.copyUserIdToolStripMenuItem_Click);
            // 
            // copyChannelIdToolStripMenuItem
            // 
            this.copyChannelIdToolStripMenuItem.Name = "copyChannelIdToolStripMenuItem";
            this.copyChannelIdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyChannelIdToolStripMenuItem.Text = "Copy channel id";
            this.copyChannelIdToolStripMenuItem.Click += new System.EventHandler(this.copyChannelIdToolStripMenuItem_Click);
            // 
            // settingsTab
            // 
            this.settingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.settingsTab.Controls.Add(this.groupBox1);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(580, 291);
            this.settingsTab.TabIndex = 3;
            this.settingsTab.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webCanaryRb);
            this.groupBox1.Controls.Add(this.webPTBRb);
            this.groupBox1.Controls.Add(this.webStableRb);
            this.groupBox1.Controls.Add(this.defaultRb);
            this.groupBox1.Controls.Add(this.canaryRb);
            this.groupBox1.Controls.Add(this.ptbRb);
            this.groupBox1.Controls.Add(this.stableRb);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 121);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Which Discord instance to launch";
            // 
            // webCanaryRb
            // 
            this.webCanaryRb.AutoSize = true;
            this.webCanaryRb.Location = new System.Drawing.Point(123, 88);
            this.webCanaryRb.Name = "webCanaryRb";
            this.webCanaryRb.Size = new System.Drawing.Size(99, 17);
            this.webCanaryRb.TabIndex = 6;
            this.webCanaryRb.TabStop = true;
            this.webCanaryRb.Text = "Browser Canary";
            this.webCanaryRb.UseVisualStyleBackColor = true;
            this.webCanaryRb.CheckedChanged += new System.EventHandler(this.discordInstanceSettingsChange);
            // 
            // webPTBRb
            // 
            this.webPTBRb.AutoSize = true;
            this.webPTBRb.Location = new System.Drawing.Point(123, 65);
            this.webPTBRb.Name = "webPTBRb";
            this.webPTBRb.Size = new System.Drawing.Size(87, 17);
            this.webPTBRb.TabIndex = 5;
            this.webPTBRb.TabStop = true;
            this.webPTBRb.Text = "Browser PTB";
            this.webPTBRb.UseVisualStyleBackColor = true;
            this.webPTBRb.CheckedChanged += new System.EventHandler(this.discordInstanceSettingsChange);
            // 
            // webStableRb
            // 
            this.webStableRb.AutoSize = true;
            this.webStableRb.Location = new System.Drawing.Point(123, 42);
            this.webStableRb.Name = "webStableRb";
            this.webStableRb.Size = new System.Drawing.Size(96, 17);
            this.webStableRb.TabIndex = 4;
            this.webStableRb.TabStop = true;
            this.webStableRb.Text = "Browser Stable";
            this.webStableRb.UseVisualStyleBackColor = true;
            this.webStableRb.CheckedChanged += new System.EventHandler(this.discordInstanceSettingsChange);
            // 
            // defaultRb
            // 
            this.defaultRb.AutoSize = true;
            this.defaultRb.ForeColor = System.Drawing.SystemColors.Control;
            this.defaultRb.Location = new System.Drawing.Point(6, 19);
            this.defaultRb.Name = "defaultRb";
            this.defaultRb.Size = new System.Drawing.Size(59, 17);
            this.defaultRb.TabIndex = 3;
            this.defaultRb.Text = "Default";
            this.defaultRb.UseVisualStyleBackColor = true;
            this.defaultRb.CheckedChanged += new System.EventHandler(this.discordInstanceSettingsChange);
            // 
            // canaryRb
            // 
            this.canaryRb.AutoSize = true;
            this.canaryRb.ForeColor = System.Drawing.SystemColors.Control;
            this.canaryRb.Location = new System.Drawing.Point(6, 88);
            this.canaryRb.Name = "canaryRb";
            this.canaryRb.Size = new System.Drawing.Size(58, 17);
            this.canaryRb.TabIndex = 2;
            this.canaryRb.Text = "Canary";
            this.canaryRb.UseVisualStyleBackColor = true;
            this.canaryRb.CheckedChanged += new System.EventHandler(this.discordInstanceSettingsChange);
            // 
            // ptbRb
            // 
            this.ptbRb.AutoSize = true;
            this.ptbRb.ForeColor = System.Drawing.SystemColors.Control;
            this.ptbRb.Location = new System.Drawing.Point(6, 65);
            this.ptbRb.Name = "ptbRb";
            this.ptbRb.Size = new System.Drawing.Size(46, 17);
            this.ptbRb.TabIndex = 1;
            this.ptbRb.Text = "PTB";
            this.ptbRb.UseVisualStyleBackColor = true;
            this.ptbRb.CheckedChanged += new System.EventHandler(this.discordInstanceSettingsChange);
            // 
            // stableRb
            // 
            this.stableRb.AutoSize = true;
            this.stableRb.ForeColor = System.Drawing.SystemColors.Control;
            this.stableRb.Location = new System.Drawing.Point(6, 42);
            this.stableRb.Name = "stableRb";
            this.stableRb.Size = new System.Drawing.Size(55, 17);
            this.stableRb.TabIndex = 0;
            this.stableRb.Text = "Stable";
            this.stableRb.UseVisualStyleBackColor = true;
            this.stableRb.CheckedChanged += new System.EventHandler(this.discordInstanceSettingsChange);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Discord Package files|*.zip";
            // 
            // massDeleteTimer
            // 
            this.massDeleteTimer.Tick += new System.EventHandler(this.massDeleteTimer_Tick);
            // 
            // searchBw
            // 
            this.searchBw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.searchBw_DoWork);
            this.searchBw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.searchBw_RunWorkerCompleted);
            // 
            // searchTimer
            // 
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // loadTimer
            // 
            this.loadTimer.Tick += new System.EventHandler(this.loadTimer_Tick);
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(3, 29);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(574, 259);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.listWPF1;
            // 
            // Main
            // 
            this.AcceptButton = this.searchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(588, 317);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Data Package Tool";
            this.tabControl1.ResumeLayout(false);
            this.loadTb.ResumeLayout(false);
            this.messagesTab.ResumeLayout(false);
            this.messagesTab.PerformLayout();
            this.imagesTab.ResumeLayout(false);
            this.imagesTab.PerformLayout();
            this.serversTab.ResumeLayout(false);
            this.serversTab.PerformLayout();
            this.serversStatusStrip.ResumeLayout(false);
            this.serversStatusStrip.PerformLayout();
            this.serversContextMenu.ResumeLayout(false);
            this.dmsTab.ResumeLayout(false);
            this.dmsContextMenu.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage messagesTab;
        private System.Windows.Forms.TabPage imagesTab;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage loadTb;
        private System.Windows.Forms.Button loadFileBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label loadingLb;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchTb;
        private System.Windows.Forms.Label resultsCountLb;
        private System.Windows.Forms.Button imagesNextBtn;
        private System.Windows.Forms.Button imagesPrevBtn;
        private System.Windows.Forms.Label imagesCountLb;
        private System.Windows.Forms.Panel imagesPanel;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton canaryRb;
        private System.Windows.Forms.RadioButton ptbRb;
        private System.Windows.Forms.RadioButton stableRb;
        private System.Windows.Forms.RadioButton defaultRb;
        private System.Windows.Forms.TabPage serversTab;
        private System.Windows.Forms.ListView serversLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private MessageListWPF listWPF1;
        private System.Windows.Forms.Button massDeleteBtn;
        private System.Windows.Forms.Timer massDeleteTimer;
        private System.Windows.Forms.Button messagesNextBtn;
        private System.Windows.Forms.Button messagesPrevBtn;
        private System.Windows.Forms.ContextMenuStrip serversContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyInvitesToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button searchOptionsBtn;
        private System.ComponentModel.BackgroundWorker searchBw;
        private System.Windows.Forms.Timer searchTimer;
        private System.Windows.Forms.Timer loadTimer;
        private System.Windows.Forms.TabPage dmsTab;
        private System.Windows.Forms.ListView dmsLv;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ContextMenuStrip dmsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyUserIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyChannelIdToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ToolStripMenuItem viewUserToolStripMenuItem;
        private System.Windows.Forms.RadioButton webCanaryRb;
        private System.Windows.Forms.RadioButton webPTBRb;
        private System.Windows.Forms.RadioButton webStableRb;
        private System.Windows.Forms.ToolStripMenuItem openDmSELFBOTToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.StatusStrip serversStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar serversPb;
        private System.Windows.Forms.ToolStripStatusLabel serversStatusLb;
    }
}

