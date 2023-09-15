
namespace Data_Package_Tool
{
    partial class MassDeletePrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MassDeletePrompt));
            this.delayTb = new System.Windows.Forms.TrackBar();
            this.delayLb = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.delayTb)).BeginInit();
            this.SuspendLayout();
            // 
            // delayTb
            // 
            this.delayTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delayTb.Location = new System.Drawing.Point(12, 131);
            this.delayTb.Maximum = 100;
            this.delayTb.Minimum = 1;
            this.delayTb.Name = "delayTb";
            this.delayTb.Size = new System.Drawing.Size(104, 45);
            this.delayTb.TabIndex = 2;
            this.delayTb.Value = 15;
            this.delayTb.Scroll += new System.EventHandler(this.delayTb_Scroll);
            // 
            // delayLb
            // 
            this.delayLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delayLb.AutoSize = true;
            this.delayLb.Location = new System.Drawing.Point(12, 115);
            this.delayLb.Name = "delayLb";
            this.delayLb.Size = new System.Drawing.Size(109, 13);
            this.delayLb.TabIndex = 3;
            this.delayLb.Text = "Delete delay: 1500ms";
            // 
            // startBtn
            // 
            this.startBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startBtn.Location = new System.Drawing.Point(178, 196);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 66);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // MassDeletePrompt
            // 
            this.AcceptButton = this.startBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 231);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.delayLb);
            this.Controls.Add(this.delayTb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MassDeletePrompt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mass Delete Prompt";
            ((System.ComponentModel.ISupportInitialize)(this.delayTb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar delayTb;
        private System.Windows.Forms.Label delayLb;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label label2;
    }
}