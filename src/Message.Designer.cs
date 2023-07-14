
namespace Data_Package_Images
{
    partial class Message
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.avatarPb = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyChannelIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMetadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usernameLb = new System.Windows.Forms.Label();
            this.contentLb = new System.Windows.Forms.Label();
            this.dateLb = new System.Windows.Forms.Label();
            this.metadataLb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPb)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // avatarPb
            // 
            this.avatarPb.BackColor = System.Drawing.Color.Transparent;
            this.avatarPb.ContextMenuStrip = this.contextMenuStrip1;
            this.avatarPb.Image = global::Data_Package_Images.Properties.Resources._0;
            this.avatarPb.Location = new System.Drawing.Point(8, 21);
            this.avatarPb.Name = "avatarPb";
            this.avatarPb.Size = new System.Drawing.Size(40, 40);
            this.avatarPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatarPb.TabIndex = 0;
            this.avatarPb.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToMessageToolStripMenuItem,
            this.viewUserToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyMessageToolStripMenuItem,
            this.copyChannelIdToolStripMenuItem,
            this.copyMetadataToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 120);
            // 
            // goToMessageToolStripMenuItem
            // 
            this.goToMessageToolStripMenuItem.Name = "goToMessageToolStripMenuItem";
            this.goToMessageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.goToMessageToolStripMenuItem.Text = "Go to message";
            this.goToMessageToolStripMenuItem.Click += new System.EventHandler(this.goToMessageToolStripMenuItem_Click);
            // 
            // viewUserToolStripMenuItem
            // 
            this.viewUserToolStripMenuItem.Enabled = false;
            this.viewUserToolStripMenuItem.Name = "viewUserToolStripMenuItem";
            this.viewUserToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.viewUserToolStripMenuItem.Text = "View user";
            this.viewUserToolStripMenuItem.Click += new System.EventHandler(this.viewUserToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // copyMessageToolStripMenuItem
            // 
            this.copyMessageToolStripMenuItem.Name = "copyMessageToolStripMenuItem";
            this.copyMessageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyMessageToolStripMenuItem.Text = "Copy message";
            this.copyMessageToolStripMenuItem.Click += new System.EventHandler(this.copyMessageToolStripMenuItem_Click);
            // 
            // copyChannelIdToolStripMenuItem
            // 
            this.copyChannelIdToolStripMenuItem.Name = "copyChannelIdToolStripMenuItem";
            this.copyChannelIdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyChannelIdToolStripMenuItem.Text = "Copy channel id";
            this.copyChannelIdToolStripMenuItem.Click += new System.EventHandler(this.copyChannelIdToolStripMenuItem_Click);
            // 
            // copyMetadataToolStripMenuItem
            // 
            this.copyMetadataToolStripMenuItem.Name = "copyMetadataToolStripMenuItem";
            this.copyMetadataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyMetadataToolStripMenuItem.Text = "Copy metadata";
            this.copyMetadataToolStripMenuItem.Click += new System.EventHandler(this.copyMetadataToolStripMenuItem_Click);
            // 
            // usernameLb
            // 
            this.usernameLb.AutoSize = true;
            this.usernameLb.BackColor = System.Drawing.Color.Transparent;
            this.usernameLb.ContextMenuStrip = this.contextMenuStrip1;
            this.usernameLb.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usernameLb.ForeColor = System.Drawing.SystemColors.Control;
            this.usernameLb.Location = new System.Drawing.Point(60, 19);
            this.usernameLb.Name = "usernameLb";
            this.usernameLb.Size = new System.Drawing.Size(98, 20);
            this.usernameLb.TabIndex = 1;
            this.usernameLb.Text = "Lorem ipsum";
            // 
            // contentLb
            // 
            this.contentLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentLb.AutoSize = true;
            this.contentLb.BackColor = System.Drawing.Color.Transparent;
            this.contentLb.ContextMenuStrip = this.contextMenuStrip1;
            this.contentLb.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.contentLb.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.contentLb.Location = new System.Drawing.Point(60, 41);
            this.contentLb.MaximumSize = new System.Drawing.Size(500, 0);
            this.contentLb.Name = "contentLb";
            this.contentLb.Size = new System.Drawing.Size(194, 20);
            this.contentLb.TabIndex = 2;
            this.contentLb.Text = "Lorem ipsum dolor sit amet";
            // 
            // dateLb
            // 
            this.dateLb.AutoSize = true;
            this.dateLb.ContextMenuStrip = this.contextMenuStrip1;
            this.dateLb.Font = new System.Drawing.Font("Source Sans Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateLb.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dateLb.Location = new System.Drawing.Point(175, 21);
            this.dateLb.Name = "dateLb";
            this.dateLb.Size = new System.Drawing.Size(79, 15);
            this.dateLb.TabIndex = 3;
            this.dateLb.Text = "Today at 12:34";
            // 
            // metadataLb
            // 
            this.metadataLb.AutoSize = true;
            this.metadataLb.Font = new System.Drawing.Font("Source Sans Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.metadataLb.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.metadataLb.Location = new System.Drawing.Point(0, 0);
            this.metadataLb.Name = "metadataLb";
            this.metadataLb.Size = new System.Drawing.Size(0, 15);
            this.metadataLb.TabIndex = 4;
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.metadataLb);
            this.Controls.Add(this.dateLb);
            this.Controls.Add(this.contentLb);
            this.Controls.Add(this.usernameLb);
            this.Controls.Add(this.avatarPb);
            this.Name = "Message";
            this.Size = new System.Drawing.Size(568, 67);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPb)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox avatarPb;
        private System.Windows.Forms.Label usernameLb;
        private System.Windows.Forms.Label contentLb;
        private System.Windows.Forms.Label dateLb;
        private System.Windows.Forms.Label metadataLb;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem goToMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copyMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyChannelIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMetadataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUserToolStripMenuItem;
    }
}
