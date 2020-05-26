namespace GFAC.WindowsForms.Forms
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
            this.lblImportFile = new System.Windows.Forms.Label();
            this.lblProfile = new System.Windows.Forms.Label();
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtProfile = new System.Windows.Forms.TextBox();
            this.lblOverallSessionName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSource)).BeginInit();
            this.tabResponses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResponses)).BeginInit();
            this.tabFinalScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFinalScore)).BeginInit();
            this.tabsProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblImportFile
            // 
            resources.ApplyResources(this.lblImportFile, "lblImportFile");
            this.lblImportFile.Name = "lblImportFile";
            // 
            // lblProfile
            // 
            resources.ApplyResources(this.lblProfile, "lblProfile");
            this.lblProfile.Name = "lblProfile";
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
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // txtProfile
            // 
            resources.ApplyResources(this.txtProfile, "txtProfile");
            this.txtProfile.Name = "txtProfile";
            // 
            // lblOverallSessionName
            // 
            resources.ApplyResources(this.lblOverallSessionName, "lblOverallSessionName");
            this.lblOverallSessionName.Name = "lblOverallSessionName";
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // SessionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblOverallSessionName);
            this.Controls.Add(this.txtProfile);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.tabsProcess);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblInputFile);
            this.Controls.Add(this.btnSelectProfile);
            this.Controls.Add(this.lblCalculationProfile);
            this.Controls.Add(this.lblProfile);
            this.Controls.Add(this.lblImportFile);
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
        private System.Windows.Forms.Label lblImportFile;
        private System.Windows.Forms.Label lblProfile;
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
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtProfile;
        private System.Windows.Forms.Label lblOverallSessionName;
        private System.Windows.Forms.Button btnRefresh;
    }
}