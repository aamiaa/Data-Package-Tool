
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            tabControl1 = new System.Windows.Forms.TabControl();
            loadTb = new System.Windows.Forms.TabPage();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            loadFileBtn = new System.Windows.Forms.Button();
            loadingLb = new System.Windows.Forms.Label();
            messagesTab = new System.Windows.Forms.TabPage();
            elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            searchOptionsBtn = new System.Windows.Forms.Button();
            messagesNextBtn = new System.Windows.Forms.Button();
            messagesPrevBtn = new System.Windows.Forms.Button();
            massDeleteBtn = new System.Windows.Forms.Button();
            resultsCountLb = new System.Windows.Forms.Label();
            searchBtn = new System.Windows.Forms.Button();
            searchTb = new System.Windows.Forms.TextBox();
            imagesTab = new System.Windows.Forms.TabPage();
            imagesPanel = new System.Windows.Forms.Panel();
            imagesCountLb = new System.Windows.Forms.Label();
            imagesNextBtn = new System.Windows.Forms.Button();
            imagesPrevBtn = new System.Windows.Forms.Button();
            serversTab = new System.Windows.Forms.TabPage();
            serversStatusStrip = new System.Windows.Forms.StatusStrip();
            serversStatusLb = new System.Windows.Forms.ToolStripStatusLabel();
            serversPb = new System.Windows.Forms.ToolStripProgressBar();
            serversLv = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            serversContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            copyIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyInvitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dmsTab = new System.Windows.Forms.TabPage();
            elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            vcTab = new System.Windows.Forms.TabPage();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            topChannelsLb = new System.Windows.Forms.Label();
            topVC = new System.Windows.Forms.ListView();
            columnHeader11 = new System.Windows.Forms.ColumnHeader();
            columnHeader12 = new System.Windows.Forms.ColumnHeader();
            columnHeader8 = new System.Windows.Forms.ColumnHeader();
            topVCContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            copyVCChannelIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyVCGuildIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            topServersLb = new System.Windows.Forms.Label();
            topVCGuilds = new System.Windows.Forms.ListView();
            columnHeader13 = new System.Windows.Forms.ColumnHeader();
            columnHeader10 = new System.Windows.Forms.ColumnHeader();
            topVCGuildsContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            copyVCIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            settingsTab = new System.Windows.Forms.TabPage();
            repoLb = new System.Windows.Forms.LinkLabel();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            botTokenTb = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            userTokenTb = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            webCanaryRb = new System.Windows.Forms.RadioButton();
            webPTBRb = new System.Windows.Forms.RadioButton();
            webStableRb = new System.Windows.Forms.RadioButton();
            defaultRb = new System.Windows.Forms.RadioButton();
            canaryRb = new System.Windows.Forms.RadioButton();
            ptbRb = new System.Windows.Forms.RadioButton();
            stableRb = new System.Windows.Forms.RadioButton();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            massDeleteTimer = new System.Windows.Forms.Timer(components);
            searchBw = new System.ComponentModel.BackgroundWorker();
            searchTimer = new System.Windows.Forms.Timer(components);
            loadTimer = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            loadTb.SuspendLayout();
            messagesTab.SuspendLayout();
            imagesTab.SuspendLayout();
            serversTab.SuspendLayout();
            serversStatusStrip.SuspendLayout();
            serversContextMenu.SuspendLayout();
            dmsTab.SuspendLayout();
            vcTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            topVCContextMenu.SuspendLayout();
            topVCGuildsContextMenu.SuspendLayout();
            settingsTab.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(loadTb);
            tabControl1.Controls.Add(messagesTab);
            tabControl1.Controls.Add(imagesTab);
            tabControl1.Controls.Add(serversTab);
            tabControl1.Controls.Add(dmsTab);
            tabControl1.Controls.Add(vcTab);
            tabControl1.Controls.Add(settingsTab);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(588, 317);
            tabControl1.TabIndex = 0;
            // 
            // loadTb
            // 
            loadTb.BackColor = System.Drawing.Color.FromArgb(49, 51, 56);
            loadTb.Controls.Add(progressBar1);
            loadTb.Controls.Add(loadFileBtn);
            loadTb.Controls.Add(loadingLb);
            loadTb.Location = new System.Drawing.Point(4, 24);
            loadTb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadTb.Name = "loadTb";
            loadTb.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadTb.Size = new System.Drawing.Size(580, 289);
            loadTb.TabIndex = 2;
            loadTb.Text = "Load Data Package";
            // 
            // progressBar1
            // 
            progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar1.Location = new System.Drawing.Point(8, 241);
            progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(566, 23);
            progressBar1.TabIndex = 1;
            progressBar1.Visible = false;
            // 
            // loadFileBtn
            // 
            loadFileBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            loadFileBtn.Location = new System.Drawing.Point(251, 167);
            loadFileBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadFileBtn.Name = "loadFileBtn";
            loadFileBtn.Size = new System.Drawing.Size(75, 23);
            loadFileBtn.TabIndex = 0;
            loadFileBtn.Text = "Load File";
            loadFileBtn.UseVisualStyleBackColor = true;
            loadFileBtn.Click += loadFileBtn_Click;
            // 
            // loadingLb
            // 
            loadingLb.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            loadingLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            loadingLb.ForeColor = System.Drawing.SystemColors.Control;
            loadingLb.Location = new System.Drawing.Point(6, 3);
            loadingLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            loadingLb.Name = "loadingLb";
            loadingLb.Size = new System.Drawing.Size(571, 227);
            loadingLb.TabIndex = 2;
            loadingLb.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // messagesTab
            // 
            messagesTab.BackColor = System.Drawing.Color.FromArgb(49, 51, 56);
            messagesTab.Controls.Add(elementHost1);
            messagesTab.Controls.Add(searchOptionsBtn);
            messagesTab.Controls.Add(messagesNextBtn);
            messagesTab.Controls.Add(messagesPrevBtn);
            messagesTab.Controls.Add(massDeleteBtn);
            messagesTab.Controls.Add(resultsCountLb);
            messagesTab.Controls.Add(searchBtn);
            messagesTab.Controls.Add(searchTb);
            messagesTab.Location = new System.Drawing.Point(4, 24);
            messagesTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            messagesTab.Name = "messagesTab";
            messagesTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            messagesTab.Size = new System.Drawing.Size(580, 289);
            messagesTab.TabIndex = 0;
            messagesTab.Text = "Messages";
            // 
            // elementHost1
            // 
            elementHost1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            elementHost1.Location = new System.Drawing.Point(3, 29);
            elementHost1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            elementHost1.Name = "elementHost1";
            elementHost1.Size = new System.Drawing.Size(574, 259);
            elementHost1.TabIndex = 0;
            elementHost1.Text = "elementHost1";
            // 
            // searchOptionsBtn
            // 
            searchOptionsBtn.Location = new System.Drawing.Point(261, 6);
            searchOptionsBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchOptionsBtn.Name = "searchOptionsBtn";
            searchOptionsBtn.Size = new System.Drawing.Size(59, 23);
            searchOptionsBtn.TabIndex = 7;
            searchOptionsBtn.Text = "Options";
            searchOptionsBtn.UseVisualStyleBackColor = true;
            searchOptionsBtn.Click += searchOptionsBtn_Click;
            // 
            // messagesNextBtn
            // 
            messagesNextBtn.Enabled = false;
            messagesNextBtn.Location = new System.Drawing.Point(355, 6);
            messagesNextBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            messagesNextBtn.Name = "messagesNextBtn";
            messagesNextBtn.Size = new System.Drawing.Size(23, 23);
            messagesNextBtn.TabIndex = 6;
            messagesNextBtn.Text = ">";
            messagesNextBtn.UseVisualStyleBackColor = true;
            messagesNextBtn.Click += messagesNextBtn_Click;
            // 
            // messagesPrevBtn
            // 
            messagesPrevBtn.Enabled = false;
            messagesPrevBtn.Location = new System.Drawing.Point(326, 6);
            messagesPrevBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            messagesPrevBtn.Name = "messagesPrevBtn";
            messagesPrevBtn.Size = new System.Drawing.Size(23, 23);
            messagesPrevBtn.TabIndex = 5;
            messagesPrevBtn.Text = "<";
            messagesPrevBtn.UseVisualStyleBackColor = true;
            messagesPrevBtn.Click += messagesPrevBtn_Click;
            // 
            // massDeleteBtn
            // 
            massDeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            massDeleteBtn.Location = new System.Drawing.Point(492, 6);
            massDeleteBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            massDeleteBtn.Name = "massDeleteBtn";
            massDeleteBtn.Size = new System.Drawing.Size(80, 23);
            massDeleteBtn.TabIndex = 4;
            massDeleteBtn.Text = "Mass Delete";
            massDeleteBtn.UseVisualStyleBackColor = true;
            massDeleteBtn.Click += massDeleteBtn_Click;
            // 
            // resultsCountLb
            // 
            resultsCountLb.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            resultsCountLb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            resultsCountLb.ForeColor = System.Drawing.SystemColors.Control;
            resultsCountLb.Location = new System.Drawing.Point(379, 10);
            resultsCountLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultsCountLb.Name = "resultsCountLb";
            resultsCountLb.Size = new System.Drawing.Size(112, 15);
            resultsCountLb.TabIndex = 3;
            // 
            // searchBtn
            // 
            searchBtn.Enabled = false;
            searchBtn.Location = new System.Drawing.Point(198, 6);
            searchBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new System.Drawing.Size(55, 23);
            searchBtn.TabIndex = 1;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // searchTb
            // 
            searchTb.Location = new System.Drawing.Point(6, 6);
            searchTb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchTb.Name = "searchTb";
            searchTb.Size = new System.Drawing.Size(186, 23);
            searchTb.TabIndex = 0;
            // 
            // imagesTab
            // 
            imagesTab.BackColor = System.Drawing.Color.FromArgb(49, 51, 56);
            imagesTab.Controls.Add(imagesPanel);
            imagesTab.Controls.Add(imagesCountLb);
            imagesTab.Controls.Add(imagesNextBtn);
            imagesTab.Controls.Add(imagesPrevBtn);
            imagesTab.Location = new System.Drawing.Point(4, 24);
            imagesTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imagesTab.Name = "imagesTab";
            imagesTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imagesTab.Size = new System.Drawing.Size(580, 289);
            imagesTab.TabIndex = 1;
            imagesTab.Text = "Images";
            // 
            // imagesPanel
            // 
            imagesPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            imagesPanel.Location = new System.Drawing.Point(8, 37);
            imagesPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imagesPanel.Name = "imagesPanel";
            imagesPanel.Size = new System.Drawing.Size(564, 245);
            imagesPanel.TabIndex = 3;
            // 
            // imagesCountLb
            // 
            imagesCountLb.AutoSize = true;
            imagesCountLb.ForeColor = System.Drawing.SystemColors.Control;
            imagesCountLb.Location = new System.Drawing.Point(71, 11);
            imagesCountLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            imagesCountLb.Name = "imagesCountLb";
            imagesCountLb.Size = new System.Drawing.Size(0, 15);
            imagesCountLb.TabIndex = 2;
            imagesCountLb.DoubleClick += imagesCountLb_DoubleClick;
            // 
            // imagesNextBtn
            // 
            imagesNextBtn.Location = new System.Drawing.Point(40, 7);
            imagesNextBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imagesNextBtn.Name = "imagesNextBtn";
            imagesNextBtn.Size = new System.Drawing.Size(23, 23);
            imagesNextBtn.TabIndex = 1;
            imagesNextBtn.Text = ">";
            imagesNextBtn.UseVisualStyleBackColor = true;
            imagesNextBtn.Click += imagesNextBtn_Click;
            // 
            // imagesPrevBtn
            // 
            imagesPrevBtn.Location = new System.Drawing.Point(9, 7);
            imagesPrevBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imagesPrevBtn.Name = "imagesPrevBtn";
            imagesPrevBtn.Size = new System.Drawing.Size(23, 23);
            imagesPrevBtn.TabIndex = 0;
            imagesPrevBtn.Text = "<";
            imagesPrevBtn.UseVisualStyleBackColor = true;
            imagesPrevBtn.Click += imagesPrevBtn_Click;
            // 
            // serversTab
            // 
            serversTab.BackColor = System.Drawing.Color.FromArgb(49, 51, 56);
            serversTab.Controls.Add(serversStatusStrip);
            serversTab.Controls.Add(serversLv);
            serversTab.Location = new System.Drawing.Point(4, 24);
            serversTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            serversTab.Name = "serversTab";
            serversTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            serversTab.Size = new System.Drawing.Size(580, 289);
            serversTab.TabIndex = 4;
            serversTab.Text = "Servers";
            // 
            // serversStatusStrip
            // 
            serversStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { serversStatusLb, serversPb });
            serversStatusStrip.Location = new System.Drawing.Point(4, 307);
            serversStatusStrip.Name = "serversStatusStrip";
            serversStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            serversStatusStrip.Size = new System.Drawing.Size(670, 25);
            serversStatusStrip.TabIndex = 1;
            serversStatusStrip.Text = "statusStrip1";
            serversStatusStrip.Visible = false;
            // 
            // serversStatusLb
            // 
            serversStatusLb.BackColor = System.Drawing.SystemColors.Control;
            serversStatusLb.Name = "serversStatusLb";
            serversStatusLb.Size = new System.Drawing.Size(59, 20);
            serversStatusLb.Text = "Loading...";
            // 
            // serversPb
            // 
            serversPb.MarqueeAnimationSpeed = 0;
            serversPb.Name = "serversPb";
            serversPb.Size = new System.Drawing.Size(233, 19);
            // 
            // serversLv
            // 
            serversLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader6, columnHeader3, columnHeader4, columnHeader5 });
            serversLv.ContextMenuStrip = serversContextMenu;
            serversLv.Dock = System.Windows.Forms.DockStyle.Fill;
            serversLv.FullRowSelect = true;
            serversLv.Location = new System.Drawing.Point(4, 3);
            serversLv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            serversLv.Name = "serversLv";
            serversLv.Size = new System.Drawing.Size(572, 283);
            serversLv.TabIndex = 0;
            serversLv.UseCompatibleStateImageBehavior = false;
            serversLv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Date";
            columnHeader1.Width = 76;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Guild Id";
            columnHeader2.Width = 91;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Guild Name";
            columnHeader6.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Join Method";
            columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Join Context";
            columnHeader4.Width = 81;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Invites";
            columnHeader5.Width = 120;
            // 
            // serversContextMenu
            // 
            serversContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { copyIdToolStripMenuItem, copyInvitesToolStripMenuItem });
            serversContextMenu.Name = "serversContextMenu";
            serversContextMenu.Size = new System.Drawing.Size(140, 48);
            // 
            // copyIdToolStripMenuItem
            // 
            copyIdToolStripMenuItem.Name = "copyIdToolStripMenuItem";
            copyIdToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            copyIdToolStripMenuItem.Text = "Copy id";
            copyIdToolStripMenuItem.Click += copyIdToolStripMenuItem_Click;
            // 
            // copyInvitesToolStripMenuItem
            // 
            copyInvitesToolStripMenuItem.Name = "copyInvitesToolStripMenuItem";
            copyInvitesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            copyInvitesToolStripMenuItem.Text = "Copy invites";
            copyInvitesToolStripMenuItem.Click += copyInvitesToolStripMenuItem_Click;
            // 
            // dmsTab
            // 
            dmsTab.BackColor = System.Drawing.Color.FromArgb(49, 51, 56);
            dmsTab.Controls.Add(elementHost2);
            dmsTab.Location = new System.Drawing.Point(4, 24);
            dmsTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dmsTab.Name = "dmsTab";
            dmsTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dmsTab.Size = new System.Drawing.Size(580, 289);
            dmsTab.TabIndex = 5;
            dmsTab.Text = "Direct Messages";
            // 
            // elementHost2
            // 
            elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            elementHost2.Location = new System.Drawing.Point(4, 3);
            elementHost2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            elementHost2.Name = "elementHost2";
            elementHost2.Size = new System.Drawing.Size(572, 283);
            elementHost2.TabIndex = 0;
            elementHost2.Text = "elementHost2";
            // 
            // vcTab
            // 
            vcTab.BackColor = System.Drawing.Color.FromArgb(49, 51, 56);
            vcTab.Controls.Add(splitContainer1);
            vcTab.Location = new System.Drawing.Point(4, 24);
            vcTab.Name = "vcTab";
            vcTab.Size = new System.Drawing.Size(580, 289);
            vcTab.TabIndex = 6;
            vcTab.Text = "Voice Stats";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(topChannelsLb);
            splitContainer1.Panel1.Controls.Add(topVC);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(topServersLb);
            splitContainer1.Panel2.Controls.Add(topVCGuilds);
            splitContainer1.Size = new System.Drawing.Size(580, 289);
            splitContainer1.SplitterDistance = 308;
            splitContainer1.TabIndex = 2;
            // 
            // topChannelsLb
            // 
            topChannelsLb.Dock = System.Windows.Forms.DockStyle.Top;
            topChannelsLb.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            topChannelsLb.ForeColor = System.Drawing.Color.White;
            topChannelsLb.Location = new System.Drawing.Point(0, 0);
            topChannelsLb.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            topChannelsLb.Name = "topChannelsLb";
            topChannelsLb.Size = new System.Drawing.Size(308, 31);
            topChannelsLb.TabIndex = 1;
            topChannelsLb.Text = "Top Channels";
            topChannelsLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // topVC
            // 
            topVC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            topVC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader11, columnHeader12, columnHeader8 });
            topVC.ContextMenuStrip = topVCContextMenu;
            topVC.FullRowSelect = true;
            topVC.Location = new System.Drawing.Point(4, 30);
            topVC.Name = "topVC";
            topVC.Size = new System.Drawing.Size(304, 255);
            topVC.TabIndex = 0;
            topVC.UseCompatibleStateImageBehavior = false;
            topVC.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Name";
            columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Location";
            columnHeader12.Width = 100;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Duration";
            columnHeader8.Width = 100;
            // 
            // topVCContextMenu
            // 
            topVCContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { copyVCChannelIdToolStripMenuItem, copyVCGuildIdToolStripMenuItem });
            topVCContextMenu.Name = "serversContextMenu";
            topVCContextMenu.Size = new System.Drawing.Size(161, 48);
            // 
            // copyVCChannelIdToolStripMenuItem
            // 
            copyVCChannelIdToolStripMenuItem.Name = "copyVCChannelIdToolStripMenuItem";
            copyVCChannelIdToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            copyVCChannelIdToolStripMenuItem.Text = "Copy channel id";
            copyVCChannelIdToolStripMenuItem.Click += copyVCChannelIdToolStripMenuItem_Click;
            // 
            // copyVCGuildIdToolStripMenuItem
            // 
            copyVCGuildIdToolStripMenuItem.Name = "copyVCGuildIdToolStripMenuItem";
            copyVCGuildIdToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            copyVCGuildIdToolStripMenuItem.Text = "Copy guild id";
            copyVCGuildIdToolStripMenuItem.Click += copyVCGuildIdToolStripMenuItem_Click;
            // 
            // topServersLb
            // 
            topServersLb.Dock = System.Windows.Forms.DockStyle.Top;
            topServersLb.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            topServersLb.ForeColor = System.Drawing.Color.White;
            topServersLb.Location = new System.Drawing.Point(0, 0);
            topServersLb.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            topServersLb.Name = "topServersLb";
            topServersLb.Size = new System.Drawing.Size(268, 31);
            topServersLb.TabIndex = 2;
            topServersLb.Text = "Top Servers";
            topServersLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // topVCGuilds
            // 
            topVCGuilds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            topVCGuilds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader13, columnHeader10 });
            topVCGuilds.ContextMenuStrip = topVCGuildsContextMenu;
            topVCGuilds.FullRowSelect = true;
            topVCGuilds.Location = new System.Drawing.Point(0, 30);
            topVCGuilds.Name = "topVCGuilds";
            topVCGuilds.Size = new System.Drawing.Size(264, 255);
            topVCGuilds.TabIndex = 1;
            topVCGuilds.UseCompatibleStateImageBehavior = false;
            topVCGuilds.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Name";
            columnHeader13.Width = 160;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Duration";
            columnHeader10.Width = 100;
            // 
            // topVCGuildsContextMenu
            // 
            topVCGuildsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { copyVCIdToolStripMenuItem });
            topVCGuildsContextMenu.Name = "serversContextMenu";
            topVCGuildsContextMenu.Size = new System.Drawing.Size(146, 26);
            // 
            // copyVCIdToolStripMenuItem
            // 
            copyVCIdToolStripMenuItem.Name = "copyVCIdToolStripMenuItem";
            copyVCIdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            copyVCIdToolStripMenuItem.Text = "Copy guild id";
            copyVCIdToolStripMenuItem.Click += copyVCIdToolStripMenuItem_Click;
            // 
            // settingsTab
            // 
            settingsTab.BackColor = System.Drawing.Color.FromArgb(49, 51, 56);
            settingsTab.Controls.Add(repoLb);
            settingsTab.Controls.Add(groupBox2);
            settingsTab.Controls.Add(groupBox1);
            settingsTab.Location = new System.Drawing.Point(4, 24);
            settingsTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            settingsTab.Name = "settingsTab";
            settingsTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            settingsTab.Size = new System.Drawing.Size(580, 289);
            settingsTab.TabIndex = 3;
            settingsTab.Text = "Settings";
            // 
            // repoLb
            // 
            repoLb.ActiveLinkColor = System.Drawing.Color.MediumSlateBlue;
            repoLb.Dock = System.Windows.Forms.DockStyle.Bottom;
            repoLb.ForeColor = System.Drawing.SystemColors.Control;
            repoLb.LinkColor = System.Drawing.Color.CornflowerBlue;
            repoLb.Location = new System.Drawing.Point(4, 269);
            repoLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            repoLb.Name = "repoLb";
            repoLb.Size = new System.Drawing.Size(572, 17);
            repoLb.TabIndex = 3;
            repoLb.TabStop = true;
            repoLb.Text = "Github Repo";
            repoLb.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            repoLb.LinkClicked += repoLb_LinkClicked;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(botTokenTb);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(userTokenTb);
            groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            groupBox2.Location = new System.Drawing.Point(301, 6);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(271, 121);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tokens required to use some functions";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 69);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Bot token:";
            // 
            // botTokenTb
            // 
            botTokenTb.Location = new System.Drawing.Point(6, 85);
            botTokenTb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            botTokenTb.Name = "botTokenTb";
            botTokenTb.Size = new System.Drawing.Size(259, 23);
            botTokenTb.TabIndex = 2;
            botTokenTb.TextChanged += botTokenTb_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 23);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "User token:";
            // 
            // userTokenTb
            // 
            userTokenTb.Location = new System.Drawing.Point(6, 39);
            userTokenTb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            userTokenTb.Name = "userTokenTb";
            userTokenTb.Size = new System.Drawing.Size(259, 23);
            userTokenTb.TabIndex = 0;
            userTokenTb.TextChanged += userTokenTb_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(webCanaryRb);
            groupBox1.Controls.Add(webPTBRb);
            groupBox1.Controls.Add(webStableRb);
            groupBox1.Controls.Add(defaultRb);
            groupBox1.Controls.Add(canaryRb);
            groupBox1.Controls.Add(ptbRb);
            groupBox1.Controls.Add(stableRb);
            groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            groupBox1.Location = new System.Drawing.Point(6, 6);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(232, 121);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Which Discord instance to launch";
            // 
            // webCanaryRb
            // 
            webCanaryRb.AutoSize = true;
            webCanaryRb.Location = new System.Drawing.Point(123, 88);
            webCanaryRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            webCanaryRb.Name = "webCanaryRb";
            webCanaryRb.Size = new System.Drawing.Size(107, 19);
            webCanaryRb.TabIndex = 6;
            webCanaryRb.TabStop = true;
            webCanaryRb.Text = "Browser Canary";
            webCanaryRb.UseVisualStyleBackColor = true;
            webCanaryRb.CheckedChanged += discordInstanceSettingsChange;
            // 
            // webPTBRb
            // 
            webPTBRb.AutoSize = true;
            webPTBRb.Location = new System.Drawing.Point(123, 65);
            webPTBRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            webPTBRb.Name = "webPTBRb";
            webPTBRb.Size = new System.Drawing.Size(90, 19);
            webPTBRb.TabIndex = 5;
            webPTBRb.TabStop = true;
            webPTBRb.Text = "Browser PTB";
            webPTBRb.UseVisualStyleBackColor = true;
            webPTBRb.CheckedChanged += discordInstanceSettingsChange;
            // 
            // webStableRb
            // 
            webStableRb.AutoSize = true;
            webStableRb.Location = new System.Drawing.Point(123, 42);
            webStableRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            webStableRb.Name = "webStableRb";
            webStableRb.Size = new System.Drawing.Size(102, 19);
            webStableRb.TabIndex = 4;
            webStableRb.TabStop = true;
            webStableRb.Text = "Browser Stable";
            webStableRb.UseVisualStyleBackColor = true;
            webStableRb.CheckedChanged += discordInstanceSettingsChange;
            // 
            // defaultRb
            // 
            defaultRb.AutoSize = true;
            defaultRb.ForeColor = System.Drawing.SystemColors.Control;
            defaultRb.Location = new System.Drawing.Point(6, 19);
            defaultRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            defaultRb.Name = "defaultRb";
            defaultRb.Size = new System.Drawing.Size(63, 19);
            defaultRb.TabIndex = 3;
            defaultRb.Text = "Default";
            defaultRb.UseVisualStyleBackColor = true;
            defaultRb.CheckedChanged += discordInstanceSettingsChange;
            // 
            // canaryRb
            // 
            canaryRb.AutoSize = true;
            canaryRb.ForeColor = System.Drawing.SystemColors.Control;
            canaryRb.Location = new System.Drawing.Point(6, 88);
            canaryRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            canaryRb.Name = "canaryRb";
            canaryRb.Size = new System.Drawing.Size(62, 19);
            canaryRb.TabIndex = 2;
            canaryRb.Text = "Canary";
            canaryRb.UseVisualStyleBackColor = true;
            canaryRb.CheckedChanged += discordInstanceSettingsChange;
            // 
            // ptbRb
            // 
            ptbRb.AutoSize = true;
            ptbRb.ForeColor = System.Drawing.SystemColors.Control;
            ptbRb.Location = new System.Drawing.Point(6, 65);
            ptbRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ptbRb.Name = "ptbRb";
            ptbRb.Size = new System.Drawing.Size(45, 19);
            ptbRb.TabIndex = 1;
            ptbRb.Text = "PTB";
            ptbRb.UseVisualStyleBackColor = true;
            ptbRb.CheckedChanged += discordInstanceSettingsChange;
            // 
            // stableRb
            // 
            stableRb.AutoSize = true;
            stableRb.ForeColor = System.Drawing.SystemColors.Control;
            stableRb.Location = new System.Drawing.Point(6, 42);
            stableRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            stableRb.Name = "stableRb";
            stableRb.Size = new System.Drawing.Size(57, 19);
            stableRb.TabIndex = 0;
            stableRb.Text = "Stable";
            stableRb.UseVisualStyleBackColor = true;
            stableRb.CheckedChanged += discordInstanceSettingsChange;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Discord Package files|*.zip";
            // 
            // massDeleteTimer
            // 
            massDeleteTimer.Tick += massDeleteTimer_Tick;
            // 
            // searchBw
            // 
            searchBw.DoWork += searchBw_DoWork;
            searchBw.RunWorkerCompleted += searchBw_RunWorkerCompleted;
            // 
            // searchTimer
            // 
            searchTimer.Tick += searchTimer_Tick;
            // 
            // loadTimer
            // 
            loadTimer.Tick += loadTimer_Tick;
            // 
            // Main
            // 
            AcceptButton = searchBtn;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(588, 317);
            Controls.Add(tabControl1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Main";
            Text = "Data Package Tool";
            tabControl1.ResumeLayout(false);
            loadTb.ResumeLayout(false);
            messagesTab.ResumeLayout(false);
            messagesTab.PerformLayout();
            imagesTab.ResumeLayout(false);
            imagesTab.PerformLayout();
            serversTab.ResumeLayout(false);
            serversTab.PerformLayout();
            serversStatusStrip.ResumeLayout(false);
            serversStatusStrip.PerformLayout();
            serversContextMenu.ResumeLayout(false);
            dmsTab.ResumeLayout(false);
            vcTab.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            topVCContextMenu.ResumeLayout(false);
            topVCGuildsContextMenu.ResumeLayout(false);
            settingsTab.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton webCanaryRb;
        private System.Windows.Forms.RadioButton webPTBRb;
        private System.Windows.Forms.RadioButton webStableRb;
        private System.Windows.Forms.StatusStrip serversStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar serversPb;
        private System.Windows.Forms.ToolStripStatusLabel serversStatusLb;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox botTokenTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userTokenTb;
        private System.Windows.Forms.LinkLabel repoLb;
        private System.Windows.Forms.TabPage vcTab;
        private System.Windows.Forms.ListView topVC;
        private System.Windows.Forms.ListView topVCGuilds;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ContextMenuStrip topVCContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyVCGuildIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyVCChannelIdToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip topVCGuildsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyVCIdToolStripMenuItem;
        private System.Windows.Forms.Label topChannelsLb;
        private System.Windows.Forms.Label topServersLb;
    }
}

