using DependencyChecker.Dependencies;
using DependencyFileCreator.Dependencies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DependencyFileCreator {
    public partial class Main : Form {
        public string PathName { get; private set; }
        public static bool IsDirty { get; private set; }
        public string DependencyFilePath { get; private set; }

        public Main() {
            InitializeComponent();
            SetTitle();
            SetButtonsEnabled(false);
            //TODO: Load last path from cache
        }

        private void SetTitle() {
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            int count = 2;
            if (currentVersion.Build != 0) {
                count = 3;
            }
            this.Text = "Dependency File Creator v" + currentVersion.ToString(count);
        }

        private string ShowBrowseRootDirDialog(string aboutDirectory) {
            FolderBrowserDialog fbd = new FolderBrowserDialog() {
                Description = "",
                SelectedPath = aboutDirectory,
                ShowNewFolderButton = false
            };
            if (fbd.ShowDialog() == DialogResult.OK) {
                return fbd.SelectedPath;
            }
            return aboutDirectory;
        }

        private DialogResult ShowSaveBeforeClosingDialog() {
            string message = "Would you like to save your changes before closing?";
            string caption = "Save Changes?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            return MessageBox.Show(message, caption, buttons);
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            txtRootDir.Text = ShowBrowseRootDirDialog(txtRootDir.Text);

            DependencyFilePath = Path.Combine(txtRootDir.Text, DependencyChecker.Dependencies.SupportedFiles.DependenciesFile.RelativePath);

            if (File.Exists(DependencyFilePath)) {
                ReloadFile();
            }

            SetButtonsEnabled(true);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveFile();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void SetMessage(string message) {
            lblStatusMessage.Text = message;
            tmrMessageVisable.Start();
        }

        private void SetButtonsEnabled(bool enabled) {
            this.btnSave.Enabled = enabled;
            this.btnReset.Enabled = enabled;
        }

        private void grdViewDependencies_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            if (e.ColumnIndex == grdViewDependencies.Columns["RequiredVersionColumn"].Index && e.FormattedValue.ToString() != string.Empty) { //Required Version Column
                btnSave.Enabled = false;
                string[] values = e.FormattedValue.ToString().Split('.');
                int count = 0;
                foreach (var value in values) {
                    count++;
                    int num;
                    if (!int.TryParse(value, out num)) {
                        e.Cancel = true;
                        SetMessage(value + " is not a valid number");
                        return;
                    } else if (num < 0) {
                        e.Cancel = true;
                        SetMessage(value + " cannot be less than zero");
                        return;
                    } else if (count > 4) {
                        e.Cancel = true;
                        SetMessage(e.FormattedValue + " is not a valid version format");
                        return;
                    }
                }
            }
            btnSave.Enabled = true;
        }

        private void tmrMessageVisable_Tick(object sender, EventArgs e) {
            lblStatusMessage.Text = string.Empty;
        }

        private void ReloadFile() {
            grdViewDependencies.Rows.Clear();
            List<DependencyMetaData> saveData = DependencyFileController.LoadFromFile(DependencyFilePath);

            foreach (DependencyMetaData dependency in saveData) {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(grdViewDependencies);
                row.Cells["IdentifierColumn"].Value = dependency.Identifier;
                row.Cells["SteamIDColumn"].Value = dependency.SteamID;
                row.Cells["RequiredVersionColumn"].Value = dependency.RequiredVersion;

                grdViewDependencies.Rows.Add(row);
            }
        }

        private void SaveFile() {
            List<DependencyMetaData> saveData = new List<DependencyMetaData>();

            foreach (DataGridViewRow gridRow in grdViewDependencies.Rows) {
                var identifier = gridRow.Cells["IdentifierColumn"].Value;
                if (identifier == null) {
                    continue;
                }
                string steamID = string.Empty;
                if (gridRow.Cells["SteamIDColumn"].Value != null) {
                    steamID = gridRow.Cells["SteamIDColumn"].Value.ToString();
                }
                Version version = new Version();
                if (gridRow.Cells["RequiredVersionColumn"].Value !=null) {
                    version = new Version(gridRow.Cells["RequiredVersionColumn"].Value.ToString());
                }
                saveData.Add(new DependencyMetaData(identifier.ToString(), steamID, version));
            }

            DependencyFileController.SaveToFile(DependencyFilePath, saveData);
            SetMessage("Saved");
        }

        private void btnReset_Click(object sender, EventArgs e) {
            ReloadFile();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            if (IsDirty) {
                DialogResult result = ShowSaveBeforeClosingDialog();

                switch (result) {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        SaveFile();
                        break;
                }
            }
        }
    }
}
