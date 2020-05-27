namespace GFAC.WindowsForms.Forms
{
    partial class ProfileWizardColumnForm
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
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.btnCorrectResponseRemove = new System.Windows.Forms.Button();
            this.cboColumnType = new System.Windows.Forms.ComboBox();
            this.btnCorrectResponseAdd = new System.Windows.Forms.Button();
            this.lblColumnType = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lstCorrectResponses = new System.Windows.Forms.ListBox();
            this.lblColumnScore = new System.Windows.Forms.Label();
            this.lblCorrectResponses = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(170, 7);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(235, 20);
            this.txtColumnName.TabIndex = 45;
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumnName.Location = new System.Drawing.Point(7, 9);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(38, 13);
            this.lblColumnName.TabIndex = 46;
            this.lblColumnName.Text = "Name:";
            // 
            // btnCorrectResponseRemove
            // 
            this.btnCorrectResponseRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCorrectResponseRemove.Location = new System.Drawing.Point(10, 210);
            this.btnCorrectResponseRemove.Name = "btnCorrectResponseRemove";
            this.btnCorrectResponseRemove.Size = new System.Drawing.Size(154, 26);
            this.btnCorrectResponseRemove.TabIndex = 53;
            this.btnCorrectResponseRemove.Text = "Delete Response";
            this.btnCorrectResponseRemove.UseVisualStyleBackColor = true;
            // 
            // cboColumnType
            // 
            this.cboColumnType.FormattingEnabled = true;
            this.cboColumnType.Items.AddRange(new object[] {
            "None",
            "Report",
            "Score"});
            this.cboColumnType.Location = new System.Drawing.Point(170, 36);
            this.cboColumnType.Name = "cboColumnType";
            this.cboColumnType.Size = new System.Drawing.Size(98, 21);
            this.cboColumnType.TabIndex = 49;
            // 
            // btnCorrectResponseAdd
            // 
            this.btnCorrectResponseAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCorrectResponseAdd.Location = new System.Drawing.Point(10, 180);
            this.btnCorrectResponseAdd.Name = "btnCorrectResponseAdd";
            this.btnCorrectResponseAdd.Size = new System.Drawing.Size(154, 25);
            this.btnCorrectResponseAdd.TabIndex = 54;
            this.btnCorrectResponseAdd.Text = "Add Response(s)";
            this.btnCorrectResponseAdd.UseVisualStyleBackColor = true;
            // 
            // lblColumnType
            // 
            this.lblColumnType.AutoSize = true;
            this.lblColumnType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumnType.Location = new System.Drawing.Point(7, 39);
            this.lblColumnType.Name = "lblColumnType";
            this.lblColumnType.Size = new System.Drawing.Size(34, 13);
            this.lblColumnType.TabIndex = 50;
            this.lblColumnType.Text = "Type:";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(355, 37);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(50, 20);
            this.txtScore.TabIndex = 47;
            // 
            // lstCorrectResponses
            // 
            this.lstCorrectResponses.FormattingEnabled = true;
            this.lstCorrectResponses.Location = new System.Drawing.Point(170, 63);
            this.lstCorrectResponses.Name = "lstCorrectResponses";
            this.lstCorrectResponses.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCorrectResponses.Size = new System.Drawing.Size(235, 173);
            this.lstCorrectResponses.TabIndex = 52;
            // 
            // lblColumnScore
            // 
            this.lblColumnScore.AutoSize = true;
            this.lblColumnScore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumnScore.Location = new System.Drawing.Point(274, 39);
            this.lblColumnScore.Name = "lblColumnScore";
            this.lblColumnScore.Size = new System.Drawing.Size(38, 13);
            this.lblColumnScore.TabIndex = 48;
            this.lblColumnScore.Text = "Score:";
            // 
            // lblCorrectResponses
            // 
            this.lblCorrectResponses.AutoSize = true;
            this.lblCorrectResponses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCorrectResponses.Location = new System.Drawing.Point(7, 63);
            this.lblCorrectResponses.Name = "lblCorrectResponses";
            this.lblCorrectResponses.Size = new System.Drawing.Size(100, 13);
            this.lblCorrectResponses.TabIndex = 51;
            this.lblCorrectResponses.Text = "Correct Responses:";
            // 
            // ProfileWizardColumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtColumnName);
            this.Controls.Add(this.lblColumnName);
            this.Controls.Add(this.btnCorrectResponseRemove);
            this.Controls.Add(this.cboColumnType);
            this.Controls.Add(this.btnCorrectResponseAdd);
            this.Controls.Add(this.lblColumnType);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.lstCorrectResponses);
            this.Controls.Add(this.lblColumnScore);
            this.Controls.Add(this.lblCorrectResponses);
            this.Name = "ProfileWizardColumnForm";
            this.Size = new System.Drawing.Size(422, 252);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.Button btnCorrectResponseRemove;
        private System.Windows.Forms.ComboBox cboColumnType;
        private System.Windows.Forms.Button btnCorrectResponseAdd;
        private System.Windows.Forms.Label lblColumnType;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.ListBox lstCorrectResponses;
        private System.Windows.Forms.Label lblColumnScore;
        private System.Windows.Forms.Label lblCorrectResponses;
    }
}
