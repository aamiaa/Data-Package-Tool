using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Package_Tool
{
    public partial class SearchOptionsPrompt : Form
    {
        private bool ChangesMade = false;
        public SearchOptionsPrompt()
        {
            InitializeComponent();
        }

        private void FiltersPrompt_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SearchMode == "exact")
            {
                exactMatchRb.Checked = true;
            }
            else if (Properties.Settings.Default.SearchMode == "words")
            {
                wordsMatchRb.Checked = true;
            }
            else if (Properties.Settings.Default.SearchMode == "regex")
            {
                regexMatchRb.Checked = true;
            }

            excludeGuildsCb.Checked = Properties.Settings.Default.SearchExcludeGuilds;
            excludeDmsCb.Checked = Properties.Settings.Default.SearchExcludeDMs;
            excludeGroupDmsCb.Checked = Properties.Settings.Default.SearchExcludeGDMs;
            beforeDateCb.Checked = Properties.Settings.Default.SearchBeforeEnabled;
            afterDateCb.Checked = Properties.Settings.Default.SearchAfterEnabled;

            if (Properties.Settings.Default.SearchExcludeIDs != null)
            {
                foreach (var id in Properties.Settings.Default.SearchExcludeIDs)
                {
                    excludedIdsLb.Items.Add(id);
                }
            }

            if (Properties.Settings.Default.SearchWhitelistIDs != null)
            {
                foreach (var id in Properties.Settings.Default.SearchWhitelistIDs)
                {
                    whitelistIdsLb.Items.Add(id);
                }
            }

            if(Properties.Settings.Default.SearchBeforeDate != null)
            {
                beforeDateDtp.Value = Properties.Settings.Default.SearchBeforeDate;
            }

            if(Properties.Settings.Default.SearchAfterDate != null)
            {
                afterDateDtp.Value = Properties.Settings.Default.SearchAfterDate;
            }

            ChangesMade = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(exactMatchRb.Checked)
            {
                Properties.Settings.Default.SearchMode = "exact";
            } else if(wordsMatchRb.Checked)
            {
                Properties.Settings.Default.SearchMode = "words";
            } else if(regexMatchRb.Checked)
            {
                Properties.Settings.Default.SearchMode = "regex";
            }

            Properties.Settings.Default.SearchExcludeGuilds = excludeGuildsCb.Checked;
            Properties.Settings.Default.SearchExcludeDMs = excludeDmsCb.Checked;
            Properties.Settings.Default.SearchExcludeGDMs = excludeGroupDmsCb.Checked;
            Properties.Settings.Default.SearchBeforeEnabled = beforeDateCb.Checked;
            Properties.Settings.Default.SearchAfterEnabled = afterDateCb.Checked;

            var excludeIds = new StringCollection();
            foreach(string item in excludedIdsLb.Items)
            {
                excludeIds.Add(item);
            }
            Properties.Settings.Default.SearchExcludeIDs = excludeIds;

            var whitelistIds = new StringCollection();
            foreach (string item in whitelistIdsLb.Items)
            {
                whitelistIds.Add(item);
            }
            Properties.Settings.Default.SearchWhitelistIDs = whitelistIds;

            Properties.Settings.Default.SearchBeforeDate = beforeDateDtp.Value;
            Properties.Settings.Default.SearchAfterDate = afterDateDtp.Value;

            Properties.Settings.Default.Save();
            ChangesMade = false;
            Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter the id", "Prompt");
            if (id == "") return;
            if (!excludedIdsLb.Items.Contains(id))
            {
                excludedIdsLb.Items.Add(id);
                ChangesMade = true;
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (excludedIdsLb.SelectedIndex > -1)
            {
                int oldIdx = excludedIdsLb.SelectedIndex;
                excludedIdsLb.Items.RemoveAt(excludedIdsLb.SelectedIndex);
                if (excludedIdsLb.Items.Count > 0)
                {
                    excludedIdsLb.SelectedIndex = Math.Min(oldIdx, excludedIdsLb.Items.Count - 1);
                }
                ChangesMade = true;
            }
        }

        private void addWhitelistBtn_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter the id", "Prompt");
            if (id == "") return;
            if (!whitelistIdsLb.Items.Contains(id))
            {
                whitelistIdsLb.Items.Add(id);
                ChangesMade = true;
            }
        }

        private void removeWhitelistBtn_Click(object sender, EventArgs e)
        {
            if (whitelistIdsLb.SelectedIndex > -1)
            {
                int oldIdx = whitelistIdsLb.SelectedIndex;
                whitelistIdsLb.Items.RemoveAt(whitelistIdsLb.SelectedIndex);
                if (whitelistIdsLb.Items.Count > 0)
                {
                    whitelistIdsLb.SelectedIndex = Math.Min(oldIdx, whitelistIdsLb.Items.Count - 1);
                }
                ChangesMade = true;
            }
        }

        private void beforeDateCb_CheckedChanged(object sender, EventArgs e)
        {
            beforeDateDtp.Enabled = beforeDateCb.Checked;
            ChangesMade = true;
        }

        private void afterDateCb_CheckedChanged(object sender, EventArgs e)
        {
            afterDateDtp.Enabled = afterDateCb.Checked;
            ChangesMade = true;
        }

        private void SearchOptionsPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void SearchOptionsPrompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ChangesMade)
            {
                var result = MessageBox.Show("Your changes will be lost. Are you sure you want to close?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dummyValueChanged(object sender, EventArgs e)
        {
            ChangesMade = true;
        }
    }
}
