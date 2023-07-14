
namespace Data_Package_Images
{
    partial class Attachment
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
            this.imagePb = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jumpToMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyChannelIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyUserIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyGuildIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imagePb)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePb
            // 
            this.imagePb.ContextMenuStrip = this.contextMenuStrip1;
            this.imagePb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePb.Location = new System.Drawing.Point(0, 0);
            this.imagePb.Name = "imagePb";
            this.imagePb.Size = new System.Drawing.Size(150, 150);
            this.imagePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePb.TabIndex = 0;
            this.imagePb.TabStop = false;
            this.imagePb.Click += new System.EventHandler(this.imagePb_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jumpToMessageToolStripMenuItem,
            this.viewUserToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyChannelIdToolStripMenuItem,
            this.copyGuildIdToolStripMenuItem,
            this.copyUserIdToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 142);
            // 
            // jumpToMessageToolStripMenuItem
            // 
            this.jumpToMessageToolStripMenuItem.Name = "jumpToMessageToolStripMenuItem";
            this.jumpToMessageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.jumpToMessageToolStripMenuItem.Text = "Jump to message";
            this.jumpToMessageToolStripMenuItem.Click += new System.EventHandler(this.jumpToMessageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // copyChannelIdToolStripMenuItem
            // 
            this.copyChannelIdToolStripMenuItem.Name = "copyChannelIdToolStripMenuItem";
            this.copyChannelIdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyChannelIdToolStripMenuItem.Text = "Copy channel id";
            this.copyChannelIdToolStripMenuItem.Click += new System.EventHandler(this.copyChannelIdToolStripMenuItem_Click);
            // 
            // copyUserIdToolStripMenuItem
            // 
            this.copyUserIdToolStripMenuItem.Enabled = false;
            this.copyUserIdToolStripMenuItem.Name = "copyUserIdToolStripMenuItem";
            this.copyUserIdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyUserIdToolStripMenuItem.Text = "Copy user id";
            this.copyUserIdToolStripMenuItem.Click += new System.EventHandler(this.copyUserIdToolStripMenuItem_Click);
            // 
            // copyGuildIdToolStripMenuItem
            // 
            this.copyGuildIdToolStripMenuItem.Enabled = false;
            this.copyGuildIdToolStripMenuItem.Name = "copyGuildIdToolStripMenuItem";
            this.copyGuildIdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyGuildIdToolStripMenuItem.Text = "Copy guild id";
            this.copyGuildIdToolStripMenuItem.Click += new System.EventHandler(this.copyGuildIdToolStripMenuItem_Click);
            // 
            // viewUserToolStripMenuItem
            // 
            this.viewUserToolStripMenuItem.Enabled = false;
            this.viewUserToolStripMenuItem.Name = "viewUserToolStripMenuItem";
            this.viewUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewUserToolStripMenuItem.Text = "View user";
            this.viewUserToolStripMenuItem.Click += new System.EventHandler(this.viewUserToolStripMenuItem_Click);
            // 
            // Attachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imagePb);
            this.Name = "Attachment";
            ((System.ComponentModel.ISupportInitialize)(this.imagePb)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePb;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jumpToMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copyChannelIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyUserIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyGuildIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUserToolStripMenuItem;
    }
}
