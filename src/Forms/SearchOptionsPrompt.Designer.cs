namespace Data_Package_Tool
{
    partial class SearchOptionsPrompt
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
            excludeGuildsCb = new System.Windows.Forms.CheckBox();
            excludeDmsCb = new System.Windows.Forms.CheckBox();
            excludeGroupDmsCb = new System.Windows.Forms.CheckBox();
            excludedIdsLb = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            saveBtn = new System.Windows.Forms.Button();
            addBtn = new System.Windows.Forms.Button();
            removeBtn = new System.Windows.Forms.Button();
            exactMatchRb = new System.Windows.Forms.RadioButton();
            wordsMatchRb = new System.Windows.Forms.RadioButton();
            regexMatchRb = new System.Windows.Forms.RadioButton();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            removeWhitelistBtn = new System.Windows.Forms.Button();
            addWhitelistBtn = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            whitelistIdsLb = new System.Windows.Forms.ListBox();
            beforeDateDtp = new System.Windows.Forms.DateTimePicker();
            beforeDateCb = new System.Windows.Forms.CheckBox();
            afterDateCb = new System.Windows.Forms.CheckBox();
            afterDateDtp = new System.Windows.Forms.DateTimePicker();
            caseSensitiveCb = new System.Windows.Forms.CheckBox();
            sortOrderCmb = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            hasFileCb = new System.Windows.Forms.CheckBox();
            hasImageCb = new System.Windows.Forms.CheckBox();
            hasVideoCb = new System.Windows.Forms.CheckBox();
            excludeDeletedCb = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // excludeGuildsCb
            // 
            excludeGuildsCb.AutoSize = true;
            excludeGuildsCb.Location = new System.Drawing.Point(137, 28);
            excludeGuildsCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            excludeGuildsCb.Name = "excludeGuildsCb";
            excludeGuildsCb.Size = new System.Drawing.Size(147, 19);
            excludeGuildsCb.TabIndex = 0;
            excludeGuildsCb.Text = "Exclude guild channels";
            excludeGuildsCb.UseVisualStyleBackColor = true;
            excludeGuildsCb.CheckedChanged += dummyValueChanged;
            // 
            // excludeDmsCb
            // 
            excludeDmsCb.AutoSize = true;
            excludeDmsCb.Location = new System.Drawing.Point(137, 51);
            excludeDmsCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            excludeDmsCb.Name = "excludeDmsCb";
            excludeDmsCb.Size = new System.Drawing.Size(138, 19);
            excludeDmsCb.TabIndex = 1;
            excludeDmsCb.Text = "Exclude dm channels";
            excludeDmsCb.UseVisualStyleBackColor = true;
            excludeDmsCb.CheckedChanged += dummyValueChanged;
            // 
            // excludeGroupDmsCb
            // 
            excludeGroupDmsCb.AutoSize = true;
            excludeGroupDmsCb.Location = new System.Drawing.Point(137, 74);
            excludeGroupDmsCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            excludeGroupDmsCb.Name = "excludeGroupDmsCb";
            excludeGroupDmsCb.Size = new System.Drawing.Size(173, 19);
            excludeGroupDmsCb.TabIndex = 2;
            excludeGroupDmsCb.Text = "Exclude group dm channels";
            excludeGroupDmsCb.UseVisualStyleBackColor = true;
            excludeGroupDmsCb.CheckedChanged += dummyValueChanged;
            // 
            // excludedIdsLb
            // 
            excludedIdsLb.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            excludedIdsLb.FormattingEnabled = true;
            excludedIdsLb.ItemHeight = 15;
            excludedIdsLb.Location = new System.Drawing.Point(12, 238);
            excludedIdsLb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            excludedIdsLb.Name = "excludedIdsLb";
            excludedIdsLb.Size = new System.Drawing.Size(182, 94);
            excludedIdsLb.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 222);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(199, 15);
            label1.TabIndex = 4;
            label1.Text = "Exclude specific channels/guilds ids:";
            // 
            // saveBtn
            // 
            saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            saveBtn.Location = new System.Drawing.Point(194, 352);
            saveBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new System.Drawing.Size(75, 23);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            addBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            addBtn.Location = new System.Drawing.Point(200, 238);
            addBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            addBtn.Name = "addBtn";
            addBtn.Size = new System.Drawing.Size(24, 21);
            addBtn.TabIndex = 6;
            addBtn.Text = "+";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // removeBtn
            // 
            removeBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            removeBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            removeBtn.Location = new System.Drawing.Point(200, 265);
            removeBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            removeBtn.Name = "removeBtn";
            removeBtn.Size = new System.Drawing.Size(24, 21);
            removeBtn.TabIndex = 7;
            removeBtn.Text = "-";
            removeBtn.UseVisualStyleBackColor = true;
            removeBtn.Click += removeBtn_Click;
            // 
            // exactMatchRb
            // 
            exactMatchRb.AutoSize = true;
            exactMatchRb.Location = new System.Drawing.Point(12, 27);
            exactMatchRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exactMatchRb.Name = "exactMatchRb";
            exactMatchRb.Size = new System.Drawing.Size(90, 19);
            exactMatchRb.TabIndex = 8;
            exactMatchRb.Text = "Exact match";
            exactMatchRb.UseVisualStyleBackColor = true;
            exactMatchRb.CheckedChanged += dummyValueChanged;
            // 
            // wordsMatchRb
            // 
            wordsMatchRb.AutoSize = true;
            wordsMatchRb.Location = new System.Drawing.Point(12, 50);
            wordsMatchRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            wordsMatchRb.Name = "wordsMatchRb";
            wordsMatchRb.Size = new System.Drawing.Size(96, 19);
            wordsMatchRb.TabIndex = 9;
            wordsMatchRb.Text = "Words match";
            wordsMatchRb.UseVisualStyleBackColor = true;
            wordsMatchRb.CheckedChanged += dummyValueChanged;
            // 
            // regexMatchRb
            // 
            regexMatchRb.AutoSize = true;
            regexMatchRb.Location = new System.Drawing.Point(12, 73);
            regexMatchRb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            regexMatchRb.Name = "regexMatchRb";
            regexMatchRb.Size = new System.Drawing.Size(94, 19);
            regexMatchRb.TabIndex = 10;
            regexMatchRb.Text = "Regex match";
            regexMatchRb.UseVisualStyleBackColor = true;
            regexMatchRb.CheckedChanged += dummyValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 10);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(71, 15);
            label2.TabIndex = 11;
            label2.Text = "Search type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(134, 10);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 15);
            label3.TabIndex = 12;
            label3.Text = "Exclusions:";
            // 
            // removeWhitelistBtn
            // 
            removeWhitelistBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            removeWhitelistBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            removeWhitelistBtn.Location = new System.Drawing.Point(429, 265);
            removeWhitelistBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            removeWhitelistBtn.Name = "removeWhitelistBtn";
            removeWhitelistBtn.Size = new System.Drawing.Size(24, 21);
            removeWhitelistBtn.TabIndex = 16;
            removeWhitelistBtn.Text = "-";
            removeWhitelistBtn.UseVisualStyleBackColor = true;
            removeWhitelistBtn.Click += removeWhitelistBtn_Click;
            // 
            // addWhitelistBtn
            // 
            addWhitelistBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            addWhitelistBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            addWhitelistBtn.Location = new System.Drawing.Point(429, 238);
            addWhitelistBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            addWhitelistBtn.Name = "addWhitelistBtn";
            addWhitelistBtn.Size = new System.Drawing.Size(24, 21);
            addWhitelistBtn.TabIndex = 15;
            addWhitelistBtn.Text = "+";
            addWhitelistBtn.UseVisualStyleBackColor = true;
            addWhitelistBtn.Click += addWhitelistBtn_Click;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(241, 222);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(232, 15);
            label4.TabIndex = 14;
            label4.Text = "Search only in specific channels/guilds ids:";
            // 
            // whitelistIdsLb
            // 
            whitelistIdsLb.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            whitelistIdsLb.FormattingEnabled = true;
            whitelistIdsLb.ItemHeight = 15;
            whitelistIdsLb.Location = new System.Drawing.Point(241, 238);
            whitelistIdsLb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            whitelistIdsLb.Name = "whitelistIdsLb";
            whitelistIdsLb.Size = new System.Drawing.Size(181, 94);
            whitelistIdsLb.TabIndex = 13;
            // 
            // beforeDateDtp
            // 
            beforeDateDtp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            beforeDateDtp.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            beforeDateDtp.Enabled = false;
            beforeDateDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            beforeDateDtp.Location = new System.Drawing.Point(12, 184);
            beforeDateDtp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            beforeDateDtp.Name = "beforeDateDtp";
            beforeDateDtp.Size = new System.Drawing.Size(200, 23);
            beforeDateDtp.TabIndex = 17;
            beforeDateDtp.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            beforeDateDtp.ValueChanged += dummyValueChanged;
            // 
            // beforeDateCb
            // 
            beforeDateCb.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            beforeDateCb.AutoSize = true;
            beforeDateCb.Location = new System.Drawing.Point(12, 161);
            beforeDateCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            beforeDateCb.Name = "beforeDateCb";
            beforeDateCb.Size = new System.Drawing.Size(111, 19);
            beforeDateCb.TabIndex = 18;
            beforeDateCb.Text = "Before this date:";
            beforeDateCb.UseVisualStyleBackColor = true;
            beforeDateCb.CheckedChanged += beforeDateCb_CheckedChanged;
            // 
            // afterDateCb
            // 
            afterDateCb.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            afterDateCb.AutoSize = true;
            afterDateCb.Location = new System.Drawing.Point(244, 161);
            afterDateCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            afterDateCb.Name = "afterDateCb";
            afterDateCb.Size = new System.Drawing.Size(103, 19);
            afterDateCb.TabIndex = 20;
            afterDateCb.Text = "After this date:";
            afterDateCb.UseVisualStyleBackColor = true;
            afterDateCb.CheckedChanged += afterDateCb_CheckedChanged;
            // 
            // afterDateDtp
            // 
            afterDateDtp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            afterDateDtp.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            afterDateDtp.Enabled = false;
            afterDateDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            afterDateDtp.Location = new System.Drawing.Point(244, 184);
            afterDateDtp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            afterDateDtp.Name = "afterDateDtp";
            afterDateDtp.Size = new System.Drawing.Size(200, 23);
            afterDateDtp.TabIndex = 19;
            afterDateDtp.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            afterDateDtp.ValueChanged += dummyValueChanged;
            // 
            // caseSensitiveCb
            // 
            caseSensitiveCb.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            caseSensitiveCb.AutoSize = true;
            caseSensitiveCb.Location = new System.Drawing.Point(12, 130);
            caseSensitiveCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            caseSensitiveCb.Name = "caseSensitiveCb";
            caseSensitiveCb.Size = new System.Drawing.Size(140, 19);
            caseSensitiveCb.TabIndex = 21;
            caseSensitiveCb.Text = "CaSe sEnSiTiVe search";
            caseSensitiveCb.UseVisualStyleBackColor = true;
            caseSensitiveCb.CheckedChanged += dummyValueChanged;
            // 
            // sortOrderCmb
            // 
            sortOrderCmb.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            sortOrderCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            sortOrderCmb.FormattingEnabled = true;
            sortOrderCmb.Items.AddRange(new object[] { "Newest to oldest", "Oldest to newest" });
            sortOrderCmb.Location = new System.Drawing.Point(304, 128);
            sortOrderCmb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            sortOrderCmb.Name = "sortOrderCmb";
            sortOrderCmb.Size = new System.Drawing.Size(139, 23);
            sortOrderCmb.TabIndex = 22;
            sortOrderCmb.SelectedIndexChanged += dummyValueChanged;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(241, 131);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(62, 15);
            label5.TabIndex = 23;
            label5.Text = "Sort order:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(314, 10);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 15);
            label6.TabIndex = 27;
            label6.Text = "Filters:";
            // 
            // hasFileCb
            // 
            hasFileCb.AutoSize = true;
            hasFileCb.Location = new System.Drawing.Point(317, 73);
            hasFileCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hasFileCb.Name = "hasFileCb";
            hasFileCb.Size = new System.Drawing.Size(96, 19);
            hasFileCb.TabIndex = 25;
            hasFileCb.Text = "Has other file";
            hasFileCb.UseVisualStyleBackColor = true;
            hasFileCb.CheckedChanged += dummyValueChanged;
            // 
            // hasImageCb
            // 
            hasImageCb.AutoSize = true;
            hasImageCb.Location = new System.Drawing.Point(317, 28);
            hasImageCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hasImageCb.Name = "hasImageCb";
            hasImageCb.Size = new System.Drawing.Size(82, 19);
            hasImageCb.TabIndex = 24;
            hasImageCb.Text = "Has image";
            hasImageCb.UseVisualStyleBackColor = true;
            hasImageCb.CheckedChanged += dummyValueChanged;
            // 
            // hasVideoCb
            // 
            hasVideoCb.AutoSize = true;
            hasVideoCb.Location = new System.Drawing.Point(317, 51);
            hasVideoCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hasVideoCb.Name = "hasVideoCb";
            hasVideoCb.Size = new System.Drawing.Size(78, 19);
            hasVideoCb.TabIndex = 28;
            hasVideoCb.Text = "Has video";
            hasVideoCb.UseVisualStyleBackColor = true;
            hasVideoCb.CheckedChanged += dummyValueChanged;
            // 
            // excludeDeletedCb
            // 
            excludeDeletedCb.AutoSize = true;
            excludeDeletedCb.Location = new System.Drawing.Point(137, 99);
            excludeDeletedCb.Name = "excludeDeletedCb";
            excludeDeletedCb.Size = new System.Drawing.Size(163, 19);
            excludeDeletedCb.TabIndex = 29;
            excludeDeletedCb.Text = "Exclude deleted messages";
            excludeDeletedCb.UseVisualStyleBackColor = true;
            excludeDeletedCb.CheckedChanged += dummyValueChanged;
            // 
            // SearchOptionsPrompt
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(477, 384);
            Controls.Add(excludeDeletedCb);
            Controls.Add(hasVideoCb);
            Controls.Add(label6);
            Controls.Add(hasFileCb);
            Controls.Add(hasImageCb);
            Controls.Add(label5);
            Controls.Add(sortOrderCmb);
            Controls.Add(caseSensitiveCb);
            Controls.Add(afterDateCb);
            Controls.Add(afterDateDtp);
            Controls.Add(beforeDateCb);
            Controls.Add(beforeDateDtp);
            Controls.Add(removeWhitelistBtn);
            Controls.Add(addWhitelistBtn);
            Controls.Add(label4);
            Controls.Add(whitelistIdsLb);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(regexMatchRb);
            Controls.Add(wordsMatchRb);
            Controls.Add(exactMatchRb);
            Controls.Add(removeBtn);
            Controls.Add(addBtn);
            Controls.Add(saveBtn);
            Controls.Add(label1);
            Controls.Add(excludedIdsLb);
            Controls.Add(excludeGroupDmsCb);
            Controls.Add(excludeDmsCb);
            Controls.Add(excludeGuildsCb);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SearchOptionsPrompt";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Search Options";
            FormClosing += SearchOptionsPrompt_FormClosing;
            Load += FiltersPrompt_Load;
            KeyDown += SearchOptionsPrompt_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox excludeGuildsCb;
        private System.Windows.Forms.CheckBox excludeDmsCb;
        private System.Windows.Forms.CheckBox excludeGroupDmsCb;
        private System.Windows.Forms.ListBox excludedIdsLb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.RadioButton exactMatchRb;
        private System.Windows.Forms.RadioButton wordsMatchRb;
        private System.Windows.Forms.RadioButton regexMatchRb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button removeWhitelistBtn;
        private System.Windows.Forms.Button addWhitelistBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox whitelistIdsLb;
        private System.Windows.Forms.DateTimePicker beforeDateDtp;
        private System.Windows.Forms.CheckBox beforeDateCb;
        private System.Windows.Forms.CheckBox afterDateCb;
        private System.Windows.Forms.DateTimePicker afterDateDtp;
        private System.Windows.Forms.CheckBox caseSensitiveCb;
        private System.Windows.Forms.ComboBox sortOrderCmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox hasFileCb;
        private System.Windows.Forms.CheckBox hasImageCb;
        private System.Windows.Forms.CheckBox hasVideoCb;
        private System.Windows.Forms.CheckBox excludeDeletedCb;
    }
}