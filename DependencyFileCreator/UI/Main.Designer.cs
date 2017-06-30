namespace DependencyFileCreator {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAboutDir = new System.Windows.Forms.TextBox();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GrdViewDependencies = new System.Windows.Forms.DataGridView();
            this.IdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SteamIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredVersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TimerClearStatusMessage = new System.Windows.Forms.Timer(this.components);
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdViewDependencies)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to your mods \'about\' directory:";
            // 
            // txtAboutDir
            // 
            this.txtAboutDir.Enabled = false;
            this.txtAboutDir.Location = new System.Drawing.Point(16, 28);
            this.txtAboutDir.Name = "txtAboutDir";
            this.txtAboutDir.Size = new System.Drawing.Size(292, 20);
            this.txtAboutDir.TabIndex = 1;
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(314, 26);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(23, 23);
            this.BtnBrowse.TabIndex = 2;
            this.BtnBrowse.Text = "...";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GrdViewDependencies);
            this.groupBox1.Location = new System.Drawing.Point(10, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 256);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dependencies";
            // 
            // GrdViewDependencies
            // 
            this.GrdViewDependencies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrdViewDependencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdViewDependencies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdentifierColumn,
            this.SteamIDColumn,
            this.RequiredVersionColumn});
            this.GrdViewDependencies.Location = new System.Drawing.Point(6, 19);
            this.GrdViewDependencies.Name = "GrdViewDependencies";
            this.GrdViewDependencies.RowHeadersVisible = false;
            this.GrdViewDependencies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdViewDependencies.Size = new System.Drawing.Size(315, 231);
            this.GrdViewDependencies.TabIndex = 4;
            this.GrdViewDependencies.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.GrdViewDependencies_CellValidating);
            this.GrdViewDependencies.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdViewDependencies_CellValueChanged);
            // 
            // IdentifierColumn
            // 
            this.IdentifierColumn.HeaderText = "Identifier";
            this.IdentifierColumn.Name = "IdentifierColumn";
            // 
            // SteamIDColumn
            // 
            this.SteamIDColumn.HeaderText = "SteamID";
            this.SteamIDColumn.Name = "SteamIDColumn";
            // 
            // RequiredVersionColumn
            // 
            this.RequiredVersionColumn.HeaderText = "Required Version";
            this.RequiredVersionColumn.Name = "RequiredVersionColumn";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(262, 341);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TimerClearStatusMessage
            // 
            this.TimerClearStatusMessage.Interval = 3000;
            this.TimerClearStatusMessage.Tick += new System.EventHandler(this.TimerClearStatusMessage_Tick);
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.Location = new System.Drawing.Point(10, 320);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(327, 18);
            this.lblStatusMessage.TabIndex = 6;
            this.lblStatusMessage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(10, 341);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 7;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // Main
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 373);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.txtAboutDir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdViewDependencies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAboutDir;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridView GrdViewDependencies;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentifierColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SteamIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredVersionColumn;
        private System.Windows.Forms.Timer TimerClearStatusMessage;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Button BtnReset;
    }
}

