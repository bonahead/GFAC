namespace GFAC
{
    partial class SessionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionForm));
            this.SelectFile = new System.Windows.Forms.Button();
            this.lblImportFile = new System.Windows.Forms.Label();
            this.ImportFile = new System.Windows.Forms.Button();
            this.SetDefaultProfile = new System.Windows.Forms.Button();
            this.lblProfile = new System.Windows.Forms.Label();
            this.GetProfiles = new System.Windows.Forms.Button();
            this.SaveProfile = new System.Windows.Forms.Button();
            this.lblCalculationProfile = new System.Windows.Forms.Label();
            this.btnSelectProfile = new System.Windows.Forms.Button();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.tabSource = new System.Windows.Forms.TabPage();
            this.DataGridSource = new System.Windows.Forms.DataGridView();
            this.tabResponses = new System.Windows.Forms.TabPage();
            this.dataGridResponses = new System.Windows.Forms.DataGridView();
            this.tabFinalScore = new System.Windows.Forms.TabPage();
            this.dataGridFinalScore = new System.Windows.Forms.DataGridView();
            this.tabsProcess = new System.Windows.Forms.TabControl();
            this.txtSessionName = new System.Windows.Forms.TextBox();
            this.lblSessionName = new System.Windows.Forms.Label();
            this.btnSaveSession = new System.Windows.Forms.Button();
            this.btnSaveASSession = new System.Windows.Forms.Button();
            this.btnLoadSession = new System.Windows.Forms.Button();
            this.btnProfileForm = new System.Windows.Forms.Button();
            this.txtProfile = new System.Windows.Forms.TextBox();
            this.tabSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSource)).BeginInit();
            this.tabResponses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResponses)).BeginInit();
            this.tabFinalScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFinalScore)).BeginInit();
            this.tabsProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectFile
            // 
            resources.ApplyResources(this.SelectFile, "SelectFile");
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.UseVisualStyleBackColor = true;
            // 
            // lblImportFile
            // 
            resources.ApplyResources(this.lblImportFile, "lblImportFile");
            this.lblImportFile.Name = "lblImportFile";
            // 
            // ImportFile
            // 
            resources.ApplyResources(this.ImportFile, "ImportFile");
            this.ImportFile.Name = "ImportFile";
            this.ImportFile.UseVisualStyleBackColor = true;
            this.ImportFile.Click += new System.EventHandler(this.ImportFile_Click);
            // 
            // SetDefaultProfile
            // 
            resources.ApplyResources(this.SetDefaultProfile, "SetDefaultProfile");
            this.SetDefaultProfile.Name = "SetDefaultProfile";
            this.SetDefaultProfile.UseVisualStyleBackColor = true;
            this.SetDefaultProfile.Click += new System.EventHandler(this.SetDefaultProfile_Click);
            // 
            // lblProfile
            // 
            resources.ApplyResources(this.lblProfile, "lblProfile");
            this.lblProfile.Name = "lblProfile";
            // 
            // GetProfiles
            // 
            resources.ApplyResources(this.GetProfiles, "GetProfiles");
            this.GetProfiles.Name = "GetProfiles";
            this.GetProfiles.UseVisualStyleBackColor = true;
            this.GetProfiles.Click += new System.EventHandler(this.GetProfiles_Click);
            // 
            // SaveProfile
            // 
            resources.ApplyResources(this.SaveProfile, "SaveProfile");
            this.SaveProfile.Name = "SaveProfile";
            this.SaveProfile.UseVisualStyleBackColor = true;
            this.SaveProfile.Click += new System.EventHandler(this.SaveProfile_Click);
            // 
            // lblCalculationProfile
            // 
            resources.ApplyResources(this.lblCalculationProfile, "lblCalculationProfile");
            this.lblCalculationProfile.Name = "lblCalculationProfile";
            // 
            // btnSelectProfile
            // 
            resources.ApplyResources(this.btnSelectProfile, "btnSelectProfile");
            this.btnSelectProfile.Name = "btnSelectProfile";
            this.btnSelectProfile.UseVisualStyleBackColor = true;
            this.btnSelectProfile.Click += new System.EventHandler(this.btnSelectProfile_Click);
            // 
            // lblInputFile
            // 
            resources.ApplyResources(this.lblInputFile, "lblInputFile");
            this.lblInputFile.Name = "lblInputFile";
            // 
            // btnSelectFile
            // 
            resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // txtInputFile
            // 
            resources.ApplyResources(this.txtInputFile, "txtInputFile");
            this.txtInputFile.Name = "txtInputFile";
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.DataGridSource);
            resources.ApplyResources(this.tabSource, "tabSource");
            this.tabSource.Name = "tabSource";
            this.tabSource.UseVisualStyleBackColor = true;
            // 
            // DataGridSource
            // 
            this.DataGridSource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.DataGridSource, "DataGridSource");
            this.DataGridSource.Name = "DataGridSource";
            this.DataGridSource.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSource_CellContentClick);
            this.DataGridSource.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridSource_ColumnHeaderMouseDoubleClick);
            // 
            // tabResponses
            // 
            this.tabResponses.Controls.Add(this.dataGridResponses);
            resources.ApplyResources(this.tabResponses, "tabResponses");
            this.tabResponses.Name = "tabResponses";
            this.tabResponses.UseVisualStyleBackColor = true;
            // 
            // dataGridResponses
            // 
            this.dataGridResponses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridResponses, "dataGridResponses");
            this.dataGridResponses.Name = "dataGridResponses";
            // 
            // tabFinalScore
            // 
            this.tabFinalScore.Controls.Add(this.dataGridFinalScore);
            resources.ApplyResources(this.tabFinalScore, "tabFinalScore");
            this.tabFinalScore.Name = "tabFinalScore";
            this.tabFinalScore.UseVisualStyleBackColor = true;
            // 
            // dataGridFinalScore
            // 
            this.dataGridFinalScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridFinalScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridFinalScore, "dataGridFinalScore");
            this.dataGridFinalScore.Name = "dataGridFinalScore";
            // 
            // tabsProcess
            // 
            this.tabsProcess.Controls.Add(this.tabFinalScore);
            this.tabsProcess.Controls.Add(this.tabResponses);
            this.tabsProcess.Controls.Add(this.tabSource);
            resources.ApplyResources(this.tabsProcess, "tabsProcess");
            this.tabsProcess.Name = "tabsProcess";
            this.tabsProcess.SelectedIndex = 0;
            // 
            // txtSessionName
            // 
            resources.ApplyResources(this.txtSessionName, "txtSessionName");
            this.txtSessionName.Name = "txtSessionName";
            // 
            // lblSessionName
            // 
            resources.ApplyResources(this.lblSessionName, "lblSessionName");
            this.lblSessionName.Name = "lblSessionName";
            // 
            // btnSaveSession
            // 
            resources.ApplyResources(this.btnSaveSession, "btnSaveSession");
            this.btnSaveSession.Name = "btnSaveSession";
            this.btnSaveSession.UseVisualStyleBackColor = true;
            this.btnSaveSession.Click += new System.EventHandler(this.btnSaveSession_Click);
            // 
            // btnSaveASSession
            // 
            resources.ApplyResources(this.btnSaveASSession, "btnSaveASSession");
            this.btnSaveASSession.Name = "btnSaveASSession";
            this.btnSaveASSession.UseVisualStyleBackColor = true;
            this.btnSaveASSession.Click += new System.EventHandler(this.btnSaveASSession_Click);
            // 
            // btnLoadSession
            // 
            resources.ApplyResources(this.btnLoadSession, "btnLoadSession");
            this.btnLoadSession.Name = "btnLoadSession";
            this.btnLoadSession.UseVisualStyleBackColor = true;
            this.btnLoadSession.Click += new System.EventHandler(this.btnLoadSession_Click);
            // 
            // btnProfileForm
            // 
            resources.ApplyResources(this.btnProfileForm, "btnProfileForm");
            this.btnProfileForm.Name = "btnProfileForm";
            this.btnProfileForm.UseVisualStyleBackColor = true;
            this.btnProfileForm.Click += new System.EventHandler(this.btnProfileForm_Click);
            // 
            // txtProfile
            // 
            resources.ApplyResources(this.txtProfile, "txtProfile");
            this.txtProfile.Name = "txtProfile";
            // 
            // SessionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtProfile);
            this.Controls.Add(this.btnProfileForm);
            this.Controls.Add(this.btnLoadSession);
            this.Controls.Add(this.btnSaveASSession);
            this.Controls.Add(this.btnSaveSession);
            this.Controls.Add(this.txtSessionName);
            this.Controls.Add(this.lblSessionName);
            this.Controls.Add(this.tabsProcess);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblInputFile);
            this.Controls.Add(this.btnSelectProfile);
            this.Controls.Add(this.lblCalculationProfile);
            this.Controls.Add(this.SaveProfile);
            this.Controls.Add(this.GetProfiles);
            this.Controls.Add(this.lblProfile);
            this.Controls.Add(this.SetDefaultProfile);
            this.Controls.Add(this.ImportFile);
            this.Controls.Add(this.lblImportFile);
            this.Controls.Add(this.SelectFile);
            this.Name = "SessionForm";
            this.tabSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSource)).EndInit();
            this.tabResponses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResponses)).EndInit();
            this.tabFinalScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFinalScore)).EndInit();
            this.tabsProcess.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFile;
        private System.Windows.Forms.Label lblImportFile;
        private System.Windows.Forms.Button ImportFile;
        private System.Windows.Forms.Button SetDefaultProfile;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.Button GetProfiles;
        private System.Windows.Forms.Button SaveProfile;
        private System.Windows.Forms.Label lblCalculationProfile;
        private System.Windows.Forms.Button btnSelectProfile;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.TabPage tabSource;
        private System.Windows.Forms.DataGridView DataGridSource;
        private System.Windows.Forms.TabPage tabResponses;
        private System.Windows.Forms.DataGridView dataGridResponses;
        private System.Windows.Forms.TabPage tabFinalScore;
        private System.Windows.Forms.DataGridView dataGridFinalScore;
        private System.Windows.Forms.TabControl tabsProcess;
        private System.Windows.Forms.TextBox txtSessionName;
        private System.Windows.Forms.Label lblSessionName;
        private System.Windows.Forms.Button btnSaveSession;
        private System.Windows.Forms.Button btnSaveASSession;
        private System.Windows.Forms.Button btnLoadSession;
        private System.Windows.Forms.Button btnProfileForm;
        private System.Windows.Forms.TextBox txtProfile;
    }
}