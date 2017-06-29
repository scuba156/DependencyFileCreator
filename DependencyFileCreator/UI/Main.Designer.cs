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
            this.txtRootDir = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdViewDependencies = new System.Windows.Forms.DataGridView();
            this.IdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SteamIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredVersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tmrMessageVisable = new System.Windows.Forms.Timer(this.components);
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDependencies)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to your mods \'about\' folder:";
            // 
            // txtRootDir
            // 
            this.txtRootDir.Enabled = false;
            this.txtRootDir.Location = new System.Drawing.Point(16, 28);
            this.txtRootDir.Name = "txtRootDir";
            this.txtRootDir.Size = new System.Drawing.Size(292, 20);
            this.txtRootDir.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(314, 26);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(23, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdViewDependencies);
            this.groupBox1.Location = new System.Drawing.Point(10, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 218);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dependencies";
            // 
            // grdViewDependencies
            // 
            this.grdViewDependencies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdViewDependencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewDependencies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdentifierColumn,
            this.SteamIDColumn,
            this.RequiredVersionColumn});
            this.grdViewDependencies.Location = new System.Drawing.Point(6, 19);
            this.grdViewDependencies.Name = "grdViewDependencies";
            this.grdViewDependencies.RowHeadersVisible = false;
            this.grdViewDependencies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdViewDependencies.Size = new System.Drawing.Size(315, 188);
            this.grdViewDependencies.TabIndex = 4;
            this.grdViewDependencies.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdViewDependencies_CellValidating);
            this.grdViewDependencies.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdViewDependencies_CellValueChanged);
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(256, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(16, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tmrMessageVisable
            // 
            this.tmrMessageVisable.Interval = 3000;
            this.tmrMessageVisable.Tick += new System.EventHandler(this.tmrMessageVisable_Tick);
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.Location = new System.Drawing.Point(10, 273);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(327, 18);
            this.lblStatusMessage.TabIndex = 6;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(140, 344);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Main
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(346, 379);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtRootDir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDependencies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRootDir;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView grdViewDependencies;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentifierColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SteamIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredVersionColumn;
        private System.Windows.Forms.Timer tmrMessageVisable;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Button btnReset;
    }
}

