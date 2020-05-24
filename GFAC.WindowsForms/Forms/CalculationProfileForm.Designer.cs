namespace GFAC.WindowsForms.Forms
{
    partial class CalculationProfileForm
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
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.cboDefaultColumnType = new System.Windows.Forms.ComboBox();
            this.lblDefaultColumnType = new System.Windows.Forms.Label();
            this.lblColumns = new System.Windows.Forms.Label();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.lblColumnScore = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.cboColumnType = new System.Windows.Forms.ComboBox();
            this.lblColumnType = new System.Windows.Forms.Label();
            this.lblCorrectResponses = new System.Windows.Forms.Label();
            this.btnLoadProfile = new System.Windows.Forms.Button();
            this.btnSaveASProfile = new System.Windows.Forms.Button();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.btnColumnMoveUp = new System.Windows.Forms.Button();
            this.btnColumnMoveDown = new System.Windows.Forms.Button();
            this.btnColumnRemove = new System.Windows.Forms.Button();
            this.btnColumnAdd = new System.Windows.Forms.Button();
            this.lstCorrectResponses = new System.Windows.Forms.ListBox();
            this.btnCorrectResponseAdd = new System.Windows.Forms.Button();
            this.btnCorrectResponseRemove = new System.Windows.Forms.Button();
            this.txtAddCorrectResponses = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtProfileName
            // 
            this.txtProfileName.Location = new System.Drawing.Point(147, 12);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(496, 20);
            this.txtProfileName.TabIndex = 17;
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProfileName.Location = new System.Drawing.Point(12, 15);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(35, 13);
            this.lblProfileName.TabIndex = 18;
            this.lblProfileName.Text = "label1";
            // 
            // cboDefaultColumnType
            // 
            this.cboDefaultColumnType.FormattingEnabled = true;
            this.cboDefaultColumnType.Items.AddRange(new object[] {
            "None",
            "Report",
            "Score"});
            this.cboDefaultColumnType.Location = new System.Drawing.Point(147, 51);
            this.cboDefaultColumnType.Name = "cboDefaultColumnType";
            this.cboDefaultColumnType.Size = new System.Drawing.Size(496, 21);
            this.cboDefaultColumnType.TabIndex = 19;
            // 
            // lblDefaultColumnType
            // 
            this.lblDefaultColumnType.AutoSize = true;
            this.lblDefaultColumnType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDefaultColumnType.Location = new System.Drawing.Point(12, 54);
            this.lblDefaultColumnType.Name = "lblDefaultColumnType";
            this.lblDefaultColumnType.Size = new System.Drawing.Size(35, 13);
            this.lblDefaultColumnType.TabIndex = 20;
            this.lblDefaultColumnType.Text = "label1";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumns.Location = new System.Drawing.Point(12, 98);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(35, 13);
            this.lblColumns.TabIndex = 21;
            this.lblColumns.Text = "label1";
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumnName.Location = new System.Drawing.Point(266, 101);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(35, 13);
            this.lblColumnName.TabIndex = 24;
            this.lblColumnName.Text = "label1";
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(408, 95);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(235, 20);
            this.txtColumnName.TabIndex = 23;
            // 
            // lblColumnScore
            // 
            this.lblColumnScore.AutoSize = true;
            this.lblColumnScore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumnScore.Location = new System.Drawing.Point(266, 152);
            this.lblColumnScore.Name = "lblColumnScore";
            this.lblColumnScore.Size = new System.Drawing.Size(35, 13);
            this.lblColumnScore.TabIndex = 26;
            this.lblColumnScore.Text = "label1";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(575, 149);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(68, 20);
            this.txtScore.TabIndex = 25;
            // 
            // cboColumnType
            // 
            this.cboColumnType.FormattingEnabled = true;
            this.cboColumnType.Items.AddRange(new object[] {
            "None",
            "Report",
            "Score"});
            this.cboColumnType.Location = new System.Drawing.Point(543, 122);
            this.cboColumnType.Name = "cboColumnType";
            this.cboColumnType.Size = new System.Drawing.Size(100, 21);
            this.cboColumnType.TabIndex = 27;
            // 
            // lblColumnType
            // 
            this.lblColumnType.AutoSize = true;
            this.lblColumnType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumnType.Location = new System.Drawing.Point(266, 125);
            this.lblColumnType.Name = "lblColumnType";
            this.lblColumnType.Size = new System.Drawing.Size(35, 13);
            this.lblColumnType.TabIndex = 28;
            this.lblColumnType.Text = "label1";
            // 
            // lblCorrectResponses
            // 
            this.lblCorrectResponses.AutoSize = true;
            this.lblCorrectResponses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCorrectResponses.Location = new System.Drawing.Point(266, 175);
            this.lblCorrectResponses.Name = "lblCorrectResponses";
            this.lblCorrectResponses.Size = new System.Drawing.Size(35, 13);
            this.lblCorrectResponses.TabIndex = 30;
            this.lblCorrectResponses.Text = "label1";
            // 
            // btnLoadProfile
            // 
            this.btnLoadProfile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoadProfile.Location = new System.Drawing.Point(678, 70);
            this.btnLoadProfile.Name = "btnLoadProfile";
            this.btnLoadProfile.Size = new System.Drawing.Size(123, 23);
            this.btnLoadProfile.TabIndex = 34;
            this.btnLoadProfile.Text = "LoadProfile";
            this.btnLoadProfile.UseVisualStyleBackColor = true;
            this.btnLoadProfile.Click += new System.EventHandler(this.btnLoadProfile_Click);
            // 
            // btnSaveASProfile
            // 
            this.btnSaveASProfile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveASProfile.Location = new System.Drawing.Point(678, 41);
            this.btnSaveASProfile.Name = "btnSaveASProfile";
            this.btnSaveASProfile.Size = new System.Drawing.Size(123, 23);
            this.btnSaveASProfile.TabIndex = 33;
            this.btnSaveASProfile.Text = "SaveASProfile";
            this.btnSaveASProfile.UseVisualStyleBackColor = true;
            this.btnSaveASProfile.Click += new System.EventHandler(this.btnSaveASProfile_Click);
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveProfile.Location = new System.Drawing.Point(678, 12);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(123, 23);
            this.btnSaveProfile.TabIndex = 32;
            this.btnSaveProfile.Text = "SaveProfile";
            this.btnSaveProfile.UseVisualStyleBackColor = true;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // lstColumns
            // 
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.Location = new System.Drawing.Point(147, 101);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(113, 303);
            this.lstColumns.TabIndex = 35;
            this.lstColumns.SelectedIndexChanged += new System.EventHandler(this.lstColumns_SelectedIndexChanged);
            // 
            // btnColumnMoveUp
            // 
            this.btnColumnMoveUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnMoveUp.Location = new System.Drawing.Point(269, 239);
            this.btnColumnMoveUp.Name = "btnColumnMoveUp";
            this.btnColumnMoveUp.Size = new System.Drawing.Size(54, 37);
            this.btnColumnMoveUp.TabIndex = 36;
            this.btnColumnMoveUp.Text = "Up";
            this.btnColumnMoveUp.UseVisualStyleBackColor = true;
            this.btnColumnMoveUp.Click += new System.EventHandler(this.btnColumnMoveUp_Click);
            // 
            // btnColumnMoveDown
            // 
            this.btnColumnMoveDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnMoveDown.Location = new System.Drawing.Point(269, 367);
            this.btnColumnMoveDown.Name = "btnColumnMoveDown";
            this.btnColumnMoveDown.Size = new System.Drawing.Size(54, 37);
            this.btnColumnMoveDown.TabIndex = 37;
            this.btnColumnMoveDown.Text = "Down";
            this.btnColumnMoveDown.UseVisualStyleBackColor = true;
            this.btnColumnMoveDown.Click += new System.EventHandler(this.btnColumnMoveDown_Click);
            // 
            // btnColumnRemove
            // 
            this.btnColumnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnRemove.Location = new System.Drawing.Point(269, 282);
            this.btnColumnRemove.Name = "btnColumnRemove";
            this.btnColumnRemove.Size = new System.Drawing.Size(54, 37);
            this.btnColumnRemove.TabIndex = 38;
            this.btnColumnRemove.Text = "Delete";
            this.btnColumnRemove.UseVisualStyleBackColor = true;
            this.btnColumnRemove.Click += new System.EventHandler(this.btnColumnRemove_Click);
            // 
            // btnColumnAdd
            // 
            this.btnColumnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnAdd.Location = new System.Drawing.Point(269, 324);
            this.btnColumnAdd.Name = "btnColumnAdd";
            this.btnColumnAdd.Size = new System.Drawing.Size(54, 37);
            this.btnColumnAdd.TabIndex = 39;
            this.btnColumnAdd.Text = "Add";
            this.btnColumnAdd.UseVisualStyleBackColor = true;
            this.btnColumnAdd.Click += new System.EventHandler(this.btnColumnAdd_Click);
            // 
            // lstCorrectResponses
            // 
            this.lstCorrectResponses.FormattingEnabled = true;
            this.lstCorrectResponses.Location = new System.Drawing.Point(375, 175);
            this.lstCorrectResponses.Name = "lstCorrectResponses";
            this.lstCorrectResponses.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCorrectResponses.Size = new System.Drawing.Size(208, 225);
            this.lstCorrectResponses.TabIndex = 40;
            // 
            // btnCorrectResponseAdd
            // 
            this.btnCorrectResponseAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCorrectResponseAdd.Location = new System.Drawing.Point(734, 363);
            this.btnCorrectResponseAdd.Name = "btnCorrectResponseAdd";
            this.btnCorrectResponseAdd.Size = new System.Drawing.Size(54, 37);
            this.btnCorrectResponseAdd.TabIndex = 44;
            this.btnCorrectResponseAdd.Text = "Add";
            this.btnCorrectResponseAdd.UseVisualStyleBackColor = true;
            this.btnCorrectResponseAdd.Click += new System.EventHandler(this.btnCorrectResponseAdd_Click);
            // 
            // btnCorrectResponseRemove
            // 
            this.btnCorrectResponseRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCorrectResponseRemove.Location = new System.Drawing.Point(589, 363);
            this.btnCorrectResponseRemove.Name = "btnCorrectResponseRemove";
            this.btnCorrectResponseRemove.Size = new System.Drawing.Size(54, 37);
            this.btnCorrectResponseRemove.TabIndex = 43;
            this.btnCorrectResponseRemove.Text = "Delete";
            this.btnCorrectResponseRemove.UseVisualStyleBackColor = true;
            // 
            // txtAddCorrectResponses
            // 
            this.txtAddCorrectResponses.Location = new System.Drawing.Point(589, 175);
            this.txtAddCorrectResponses.Multiline = true;
            this.txtAddCorrectResponses.Name = "txtAddCorrectResponses";
            this.txtAddCorrectResponses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddCorrectResponses.Size = new System.Drawing.Size(199, 143);
            this.txtAddCorrectResponses.TabIndex = 45;
            // 
            // CalculationProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.txtAddCorrectResponses);
            this.Controls.Add(this.btnCorrectResponseAdd);
            this.Controls.Add(this.btnCorrectResponseRemove);
            this.Controls.Add(this.lstCorrectResponses);
            this.Controls.Add(this.btnColumnAdd);
            this.Controls.Add(this.btnColumnRemove);
            this.Controls.Add(this.btnColumnMoveDown);
            this.Controls.Add(this.btnColumnMoveUp);
            this.Controls.Add(this.lstColumns);
            this.Controls.Add(this.btnLoadProfile);
            this.Controls.Add(this.btnSaveASProfile);
            this.Controls.Add(this.btnSaveProfile);
            this.Controls.Add(this.lblCorrectResponses);
            this.Controls.Add(this.lblColumnType);
            this.Controls.Add(this.cboColumnType);
            this.Controls.Add(this.lblColumnScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.lblColumnName);
            this.Controls.Add(this.txtColumnName);
            this.Controls.Add(this.lblColumns);
            this.Controls.Add(this.lblDefaultColumnType);
            this.Controls.Add(this.cboDefaultColumnType);
            this.Controls.Add(this.lblProfileName);
            this.Controls.Add(this.txtProfileName);
            this.Name = "CalculationProfileForm";
            this.Text = "CalculationProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.ComboBox cboDefaultColumnType;
        private System.Windows.Forms.Label lblDefaultColumnType;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Label lblColumnScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.ComboBox cboColumnType;
        private System.Windows.Forms.Label lblColumnType;
        private System.Windows.Forms.Label lblCorrectResponses;
        private System.Windows.Forms.Button btnLoadProfile;
        private System.Windows.Forms.Button btnSaveASProfile;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.ListBox lstColumns;
        private System.Windows.Forms.Button btnColumnMoveUp;
        private System.Windows.Forms.Button btnColumnMoveDown;
        private System.Windows.Forms.Button btnColumnRemove;
        private System.Windows.Forms.Button btnColumnAdd;
        private System.Windows.Forms.ListBox lstCorrectResponses;
        private System.Windows.Forms.Button btnCorrectResponseAdd;
        private System.Windows.Forms.Button btnCorrectResponseRemove;
        private System.Windows.Forms.TextBox txtAddCorrectResponses;
    }
}