
namespace Data_Package_Images
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
            this.tokenTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.delayTb = new System.Windows.Forms.TrackBar();
            this.delayLb = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.delayTb)).BeginInit();
            this.SuspendLayout();
            // 
            // tokenTb
            // 
            this.tokenTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tokenTb.Location = new System.Drawing.Point(12, 63);
            this.tokenTb.Name = "tokenTb";
            this.tokenTb.Size = new System.Drawing.Size(392, 20);
            this.tokenTb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter your token:";
            // 
            // delayTb
            // 
            this.delayTb.Location = new System.Drawing.Point(12, 132);
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
            this.delayLb.AutoSize = true;
            this.delayLb.Location = new System.Drawing.Point(12, 116);
            this.delayLb.Name = "delayLb";
            this.delayLb.Size = new System.Drawing.Size(77, 13);
            this.delayLb.TabIndex = 3;
            this.delayLb.Text = "Delay: 1500ms";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(180, 197);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // MassDeletePrompt
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 232);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.delayLb);
            this.Controls.Add(this.delayTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tokenTb);
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

        private System.Windows.Forms.TextBox tokenTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar delayTb;
        private System.Windows.Forms.Label delayLb;
        private System.Windows.Forms.Button saveBtn;
    }
}