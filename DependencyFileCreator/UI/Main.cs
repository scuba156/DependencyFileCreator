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
        public string SelectedRootDir { get; private set; }
        private const int ClearStatusMessageTimerCount = 3000;

        private void BtnBrowse_Click(object sender, EventArgs e) {
            txtAboutDir.Text = ShowBrowseAboutDirDialog(txtAboutDir.Text);

            SelectedRootDir = Directory.GetParent(txtAboutDir.Text).FullName;

            if (File.Exists(Path.Combine(txtAboutDir.Text, DependenciesFile.FileName))) {
                ReloadFile();
            }

            SetButtonsEnabled(true);
        }

        private void BtnReset_Click(object sender, EventArgs e) {
            if (IsDirty) {

            }
            ReloadFile();
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            SaveFile();
        }

        private void GrdViewDependencies_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            if (e.ColumnIndex == GrdViewDependencies.Columns["RequiredVersionColumn"].Index && e.FormattedValue.ToString() != string.Empty) { //Required Version Column
                BtnSave.Enabled = false;
                string[] values = e.FormattedValue.ToString().Split('.');
                int count = 0;
                foreach (var value in values) {
                    count++;
                    if (!int.TryParse(value, out int num)) {
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
            BtnSave.Enabled = true;
        }

        private void GrdViewDependencies_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
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
            GrdViewDependencies.Rows.Clear();

            try {
                List<DependencyMetaData> saveData = DependencyFileController.LoadFromFile(SelectedRootDir);

                foreach (DependencyMetaData dependency in saveData) {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(GrdViewDependencies, dependency.Identifier, dependency.SteamID, dependency.RequiredVersion);
                    GrdViewDependencies.Rows.Add(row);
                }
                IsDirty = false;
            } catch (Exception e) {
                SetMessage("failed to open: " + e.Message);
            }

        }

        private void SaveFile() {
            List<DependencyMetaData> saveData = new List<DependencyMetaData>();

            foreach (DataGridViewRow gridRow in GrdViewDependencies.Rows) {
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

            DependencyFileController.SaveToFile(Path.Combine(SelectedRootDir, DependenciesFile.Directory), saveData);
            SetMessage("Saved");
        }

        private void SetButtonsEnabled(bool enabled) {
            this.BtnSave.Enabled = enabled;
            this.BtnReset.Enabled = enabled;
        }

        private void SetMessage(string message) {
            lblStatusMessage.Text = message;
            TimerClearStatusMessage.Stop();
            TimerClearStatusMessage.Start();
        }

        private void SetTitle() {
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            int count = 2;
            if (currentVersion.Build != 0) {
                count = 3;
            }
            this.Text = "Dependency File Creator v" + currentVersion.ToString(count);
#if DEBUG
            this.Text += " [DEBUG]";
#endif
        }

        private string ShowBrowseAboutDirDialog(string aboutDir) {
            FolderBrowserDialog fbd = new FolderBrowserDialog() {
                Description = "Select your mods 'about' folder",
                SelectedPath = aboutDir,
                ShowNewFolderButton = false
            };
            if (fbd.ShowDialog() == DialogResult.OK) {
                return fbd.SelectedPath;
            }
            return aboutDir;
        }

        private DialogResult ShowSaveBeforeClosingDialog() {
            string message = "Would you like to save your changes before closing?";
            string caption = "Save Changes?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            return MessageBox.Show(message, caption, buttons);
        }

        private void TimerClearStatusMessage_Tick(object sender, EventArgs e) {
            lblStatusMessage.Text = string.Empty;
        }
    }
}