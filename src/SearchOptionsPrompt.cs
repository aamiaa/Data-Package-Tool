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

namespace Data_Package_Images
{
    public partial class SearchOptionsPrompt : Form
    {
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

            if (Properties.Settings.Default.SearchExcludeIDs != null)
            {
                foreach (var id in Properties.Settings.Default.SearchExcludeIDs)
                {
                    excludedIdsLb.Items.Add(id);
                }
            }
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

            var ids = new StringCollection();
            foreach(string item in excludedIdsLb.Items)
            {
                ids.Add(item);
            }
            Properties.Settings.Default.SearchExcludeIDs = ids;

            Properties.Settings.Default.Save();
            Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter the id", "Prompt");
            if(!excludedIdsLb.Items.Contains(id))
            {
                excludedIdsLb.Items.Add(id);
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
            }
        }
    }
}
