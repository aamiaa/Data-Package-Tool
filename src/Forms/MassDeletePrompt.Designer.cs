
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
            delayTb = new System.Windows.Forms.TrackBar();
            delayLb = new System.Windows.Forms.Label();
            startBtn = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)delayTb).BeginInit();
            SuspendLayout();
            // 
            // delayTb
            // 
            delayTb.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            delayTb.Location = new System.Drawing.Point(12, 131);
            delayTb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            delayTb.Maximum = 100;
            delayTb.Minimum = 1;
            delayTb.Name = "delayTb";
            delayTb.Size = new System.Drawing.Size(121, 45);
            delayTb.TabIndex = 2;
            delayTb.Value = 15;
            delayTb.Scroll += delayTb_Scroll;
            // 
            // delayLb
            // 
            delayLb.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            delayLb.AutoSize = true;
            delayLb.Location = new System.Drawing.Point(12, 115);
            delayLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            delayLb.Name = "delayLb";
            delayLb.Size = new System.Drawing.Size(117, 15);
            delayLb.TabIndex = 3;
            delayLb.Text = "Delete delay: 1500ms";
            // 
            // startBtn
            // 
            startBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            startBtn.Location = new System.Drawing.Point(178, 196);
            startBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            startBtn.Name = "startBtn";
            startBtn.Size = new System.Drawing.Size(75, 23);
            startBtn.TabIndex = 4;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(14, 29);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(386, 76);
            label2.TabIndex = 5;
            label2.Text = resources.GetString("label2.Text");
            // 
            // MassDeletePrompt
            // 
            AcceptButton = startBtn;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(414, 229);
            Controls.Add(label2);
            Controls.Add(startBtn);
            Controls.Add(delayLb);
            Controls.Add(delayTb);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MassDeletePrompt";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Mass Delete Prompt";
            ((System.ComponentModel.ISupportInitialize)delayTb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TrackBar delayTb;
        private System.Windows.Forms.Label delayLb;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label label2;
    }
}