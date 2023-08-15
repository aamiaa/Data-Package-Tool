
namespace Data_Package_Images
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Loading...");
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.loadTb = new System.Windows.Forms.TabPage();
            this.loadingLb = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.loadFileBtn = new System.Windows.Forms.Button();
            this.messagesTab = new System.Windows.Forms.TabPage();
            this.searchOptionsBtn = new System.Windows.Forms.Button();
            this.messagesNextBtn = new System.Windows.Forms.Button();
            this.messagesPrevBtn = new System.Windows.Forms.Button();
            this.massDeleteBtn = new System.Windows.Forms.Button();
            this.resultsCountLb = new System.Windows.Forms.Label();
            this.messagesPanel = new System.Windows.Forms.Panel();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchTb = new System.Windows.Forms.TextBox();
            this.imagesTab = new System.Windows.Forms.TabPage();
            this.imagesPanel = new System.Windows.Forms.Panel();
            this.imagesCountLb = new System.Windows.Forms.Label();
            this.imagesNextBtn = new System.Windows.Forms.Button();
            this.imagesPrevBtn = new System.Windows.Forms.Button();
            this.serversTab = new System.Windows.Forms.TabPage();
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
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.defaultRb = new System.Windows.Forms.RadioButton();
            this.canaryRb = new System.Windows.Forms.RadioButton();
            this.ptbRb = new System.Windows.Forms.RadioButton();
            this.stableRb = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guildsBw = new System.ComponentModel.BackgroundWorker();
            this.massDeleteTimer = new System.Windows.Forms.Timer(this.components);
            this.searchBw = new System.ComponentModel.BackgroundWorker();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.listWPF1 = new Data_Package_Images.MessageListWPF();
            this.loadBw = new System.ComponentModel.BackgroundWorker();
            this.loadTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.loadTb.SuspendLayout();
            this.messagesTab.SuspendLayout();
            this.messagesPanel.SuspendLayout();
            this.imagesTab.SuspendLayout();
            this.serversTab.SuspendLayout();
            this.serversContextMenu.SuspendLayout();
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
            this.loadTb.Controls.Add(this.loadingLb);
            this.loadTb.Controls.Add(this.progressBar1);
            this.loadTb.Controls.Add(this.loadFileBtn);
            this.loadTb.Location = new System.Drawing.Point(4, 22);
            this.loadTb.Name = "loadTb";
            this.loadTb.Padding = new System.Windows.Forms.Padding(3);
            this.loadTb.Size = new System.Drawing.Size(580, 291);
            this.loadTb.TabIndex = 2;
            this.loadTb.Text = "Load Data Package";
            // 
            // loadingLb
            // 
            this.loadingLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.loadingLb.ForeColor = System.Drawing.SystemColors.Control;
            this.loadingLb.Location = new System.Drawing.Point(6, 193);
            this.loadingLb.Name = "loadingLb";
            this.loadingLb.Size = new System.Drawing.Size(600, 45);
            this.loadingLb.TabIndex = 2;
            this.loadingLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.loadFileBtn.Location = new System.Drawing.Point(267, 167);
            this.loadFileBtn.Name = "loadFileBtn";
            this.loadFileBtn.Size = new System.Drawing.Size(75, 23);
            this.loadFileBtn.TabIndex = 0;
            this.loadFileBtn.Text = "Load File";
            this.loadFileBtn.UseVisualStyleBackColor = true;
            this.loadFileBtn.Click += new System.EventHandler(this.loadFileBtn_Click);
            // 
            // messagesTab
            // 
            this.messagesTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.messagesTab.Controls.Add(this.searchOptionsBtn);
            this.messagesTab.Controls.Add(this.messagesNextBtn);
            this.messagesTab.Controls.Add(this.messagesPrevBtn);
            this.messagesTab.Controls.Add(this.massDeleteBtn);
            this.messagesTab.Controls.Add(this.resultsCountLb);
            this.messagesTab.Controls.Add(this.messagesPanel);
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
            // messagesPanel
            // 
            this.messagesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messagesPanel.AutoScroll = true;
            this.messagesPanel.Controls.Add(this.elementHost1);
            this.messagesPanel.Location = new System.Drawing.Point(6, 32);
            this.messagesPanel.Name = "messagesPanel";
            this.messagesPanel.Size = new System.Drawing.Size(568, 251);
            this.messagesPanel.TabIndex = 2;
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
            this.serversTab.Controls.Add(this.serversLv);
            this.serversTab.Location = new System.Drawing.Point(4, 22);
            this.serversTab.Name = "serversTab";
            this.serversTab.Padding = new System.Windows.Forms.Padding(3);
            this.serversTab.Size = new System.Drawing.Size(580, 291);
            this.serversTab.TabIndex = 4;
            this.serversTab.Text = "Servers";
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
            this.serversLv.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
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
            this.groupBox1.Controls.Add(this.defaultRb);
            this.groupBox1.Controls.Add(this.canaryRb);
            this.groupBox1.Controls.Add(this.ptbRb);
            this.groupBox1.Controls.Add(this.stableRb);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 121);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Which Discord instance to launch";
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
            // guildsBw
            // 
            this.guildsBw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.guildsBw_DoWork);
            this.guildsBw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.guildsBw_RunWorkerCompleted);
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
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(568, 251);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.listWPF1;
            // 
            // loadBw
            // 
            this.loadBw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadBw_DoWork);
            this.loadBw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.loadBw_RunWorkerCompleted);
            // 
            // loadTimer
            // 
            this.loadTimer.Tick += new System.EventHandler(this.loadTimer_Tick);
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
            this.Text = "Data Package Images";
            this.tabControl1.ResumeLayout(false);
            this.loadTb.ResumeLayout(false);
            this.messagesTab.ResumeLayout(false);
            this.messagesTab.PerformLayout();
            this.messagesPanel.ResumeLayout(false);
            this.imagesTab.ResumeLayout(false);
            this.imagesTab.PerformLayout();
            this.serversTab.ResumeLayout(false);
            this.serversContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Panel messagesPanel;
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
        private System.ComponentModel.BackgroundWorker guildsBw;
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
        private System.ComponentModel.BackgroundWorker loadBw;
        private System.Windows.Forms.Timer loadTimer;
    }
}

