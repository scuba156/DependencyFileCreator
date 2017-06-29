using DependencyChecker.Dependencies;
using DependencyChecker.Dependencies.SupportedFiles;
using DependencyFileCreator.Dependencies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DependencyFileCreator {

    public partial class Main : Form {
        public Main() {
            InitializeComponent();
            SetTitle();
            SetButtonsEnabled(false);
            IsDirty = false;
            //TODO: Load last path from cache
        }

        public static bool IsDirty { get; private set; }
        public string PathName { get; private set; }
        public string SelectedRootDir { get; private set; }
        private void btnBrowse_Click(object sender, EventArgs e) {
            txtRootDir.Text = ShowBrowseRootDirDialog(txtRootDir.Text);

            if (Directory.Exists(Path.Combine(txtRootDir.Text, DependenciesFile.Dir))) {
                SelectedRootDir = txtRootDir.Text;

                if (File.Exists(Path.Combine(txtRootDir.Text, DependenciesFile.RelativePath))) {
                    ReloadFile();
                }
            } else {
                SetMessage("Selected directory does not contain an 'about' folder");
            }
            SetButtonsEnabled(true);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            ReloadFile();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveFile();
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

        private void grdViewDependencies_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            IsDirty = true;
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

        private void ReloadFile() {
            grdViewDependencies.Rows.Clear();
            List<DependencyMetaData> saveData = DependencyFileController.LoadFromFile(SelectedRootDir);

            foreach (DependencyMetaData dependency in saveData) {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(grdViewDependencies, dependency.Identifier, dependency.SteamID, dependency.RequiredVersion);
                grdViewDependencies.Rows.Add(row);
            }
            IsDirty = false;
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
                if (gridRow.Cells["RequiredVersionColumn"].Value != null) {
                    version = new Version(gridRow.Cells["RequiredVersionColumn"].Value.ToString());
                }
                saveData.Add(new DependencyMetaData(identifier.ToString(), steamID, version));
            }

            DependencyFileController.SaveToFile(SelectedRootDir, saveData);
            SetMessage("Saved");
        }

        private void SetButtonsEnabled(bool enabled) {
            this.btnSave.Enabled = enabled;
            this.btnReset.Enabled = enabled;
        }

        private void SetMessage(string message) {
            lblStatusMessage.Text = message;
            tmrMessageVisable.Start();
        }

        private void SetTitle() {
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            int count = 2;
            if (currentVersion.Build != 0) {
                count = 3;
            }
            this.Text = "Dependency File Creator v" + currentVersion.ToString(count);
        }

        private string ShowBrowseRootDirDialog(string rootDir) {
            FolderBrowserDialog fbd = new FolderBrowserDialog() {
                Description = "",
                SelectedPath = @"C:\Users\scuba156\Documents\Source\ColonySearch\ColonySearch\Output\ColonySearch",//rootDir,
                ShowNewFolderButton = false
            };
            if (fbd.ShowDialog() == DialogResult.OK) {
                return fbd.SelectedPath;
            }
            return rootDir;
        }

        private DialogResult ShowSaveBeforeClosingDialog() {
            string message = "Would you like to save your changes before closing?";
            string caption = "Save Changes?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            return MessageBox.Show(message, caption, buttons);
        }
        private void tmrMessageVisable_Tick(object sender, EventArgs e) {
            lblStatusMessage.Text = string.Empty;
        }
    }
}