namespace GFAC.WindowsForms.Forms
{
    partial class ProfileWizardOverallForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDefaultColumnType = new System.Windows.Forms.Label();
            this.cboDefaultColumnType = new System.Windows.Forms.ComboBox();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDefaultColumnType
            // 
            this.lblDefaultColumnType.AutoSize = true;
            this.lblDefaultColumnType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDefaultColumnType.Location = new System.Drawing.Point(7, 39);
            this.lblDefaultColumnType.Name = "lblDefaultColumnType";
            this.lblDefaultColumnType.Size = new System.Drawing.Size(71, 13);
            this.lblDefaultColumnType.TabIndex = 24;
            this.lblDefaultColumnType.Text = "Default Type:";
            // 
            // cboDefaultColumnType
            // 
            this.cboDefaultColumnType.FormattingEnabled = true;
            this.cboDefaultColumnType.Items.AddRange(new object[] {
            "None",
            "Report",
            "Score"});
            this.cboDefaultColumnType.Location = new System.Drawing.Point(170, 36);
            this.cboDefaultColumnType.Name = "cboDefaultColumnType";
            this.cboDefaultColumnType.Size = new System.Drawing.Size(235, 21);
            this.cboDefaultColumnType.TabIndex = 23;
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProfileName.Location = new System.Drawing.Point(7, 9);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(67, 13);
            this.lblProfileName.TabIndex = 22;
            this.lblProfileName.Text = "ProfileName:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(170, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(235, 20);
            this.txtName.TabIndex = 21;
            // 
            // ProfileWizardOverallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDefaultColumnType);
            this.Controls.Add(this.cboDefaultColumnType);
            this.Controls.Add(this.lblProfileName);
            this.Controls.Add(this.txtName);
            this.Name = "ProfileWizardOverallForm";
            this.Size = new System.Drawing.Size(422, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDefaultColumnType;
        private System.Windows.Forms.ComboBox cboDefaultColumnType;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.TextBox txtName;
    }
}
