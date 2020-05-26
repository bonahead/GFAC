namespace GFAC.WindowsForms.Forms
{
    partial class ProfileForm
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
            this.txtName = new System.Windows.Forms.TextBox();
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
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.btnColumnMoveUp = new System.Windows.Forms.Button();
            this.btnColumnMoveDown = new System.Windows.Forms.Button();
            this.btnColumnRemove = new System.Windows.Forms.Button();
            this.btnColumnAdd = new System.Windows.Forms.Button();
            this.lstCorrectResponses = new System.Windows.Forms.ListBox();
            this.btnCorrectResponseAdd = new System.Windows.Forms.Button();
            this.btnCorrectResponseRemove = new System.Windows.Forms.Button();
            this.grpWithSelected = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpWithSelected.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(482, 20);
            this.txtName.TabIndex = 17;
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProfileName.Location = new System.Drawing.Point(9, 16);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(67, 13);
            this.lblProfileName.TabIndex = 18;
            this.lblProfileName.Text = "ProfileName:";
            // 
            // cboDefaultColumnType
            // 
            this.cboDefaultColumnType.FormattingEnabled = true;
            this.cboDefaultColumnType.Items.AddRange(new object[] {
            "None",
            "Report",
            "Score"});
            this.cboDefaultColumnType.Location = new System.Drawing.Point(90, 38);
            this.cboDefaultColumnType.Name = "cboDefaultColumnType";
            this.cboDefaultColumnType.Size = new System.Drawing.Size(482, 21);
            this.cboDefaultColumnType.TabIndex = 19;
            // 
            // lblDefaultColumnType
            // 
            this.lblDefaultColumnType.AutoSize = true;
            this.lblDefaultColumnType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDefaultColumnType.Location = new System.Drawing.Point(9, 42);
            this.lblDefaultColumnType.Name = "lblDefaultColumnType";
            this.lblDefaultColumnType.Size = new System.Drawing.Size(71, 13);
            this.lblDefaultColumnType.TabIndex = 20;
            this.lblDefaultColumnType.Text = "Default Type:";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumns.Location = new System.Drawing.Point(9, 68);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(50, 13);
            this.lblColumns.TabIndex = 21;
            this.lblColumns.Text = "Columns:";
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumnName.Location = new System.Drawing.Point(8, 29);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(38, 13);
            this.lblColumnName.TabIndex = 24;
            this.lblColumnName.Text = "Name:";
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(171, 27);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(235, 20);
            this.txtColumnName.TabIndex = 23;
            // 
            // lblColumnScore
            // 
            this.lblColumnScore.AutoSize = true;
            this.lblColumnScore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumnScore.Location = new System.Drawing.Point(275, 59);
            this.lblColumnScore.Name = "lblColumnScore";
            this.lblColumnScore.Size = new System.Drawing.Size(38, 13);
            this.lblColumnScore.TabIndex = 26;
            this.lblColumnScore.Text = "Score:";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(356, 57);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(50, 20);
            this.txtScore.TabIndex = 25;
            // 
            // cboColumnType
            // 
            this.cboColumnType.FormattingEnabled = true;
            this.cboColumnType.Items.AddRange(new object[] {
            "None",
            "Report",
            "Score"});
            this.cboColumnType.Location = new System.Drawing.Point(171, 56);
            this.cboColumnType.Name = "cboColumnType";
            this.cboColumnType.Size = new System.Drawing.Size(98, 21);
            this.cboColumnType.TabIndex = 27;
            // 
            // lblColumnType
            // 
            this.lblColumnType.AutoSize = true;
            this.lblColumnType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblColumnType.Location = new System.Drawing.Point(8, 59);
            this.lblColumnType.Name = "lblColumnType";
            this.lblColumnType.Size = new System.Drawing.Size(34, 13);
            this.lblColumnType.TabIndex = 28;
            this.lblColumnType.Text = "Type:";
            // 
            // lblCorrectResponses
            // 
            this.lblCorrectResponses.AutoSize = true;
            this.lblCorrectResponses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCorrectResponses.Location = new System.Drawing.Point(8, 83);
            this.lblCorrectResponses.Name = "lblCorrectResponses";
            this.lblCorrectResponses.Size = new System.Drawing.Size(100, 13);
            this.lblCorrectResponses.TabIndex = 30;
            this.lblCorrectResponses.Text = "Correct Responses:";
            // 
            // lstColumns
            // 
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.Location = new System.Drawing.Point(90, 64);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(227, 212);
            this.lstColumns.TabIndex = 35;
            this.lstColumns.SelectedIndexChanged += new System.EventHandler(this.lstColumns_SelectedIndexChanged);
            // 
            // btnColumnMoveUp
            // 
            this.btnColumnMoveUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnMoveUp.Location = new System.Drawing.Point(6, 19);
            this.btnColumnMoveUp.Name = "btnColumnMoveUp";
            this.btnColumnMoveUp.Size = new System.Drawing.Size(237, 30);
            this.btnColumnMoveUp.TabIndex = 36;
            this.btnColumnMoveUp.Text = "Move Column Up";
            this.btnColumnMoveUp.UseVisualStyleBackColor = true;
            this.btnColumnMoveUp.Click += new System.EventHandler(this.btnColumnMoveUp_Click);
            // 
            // btnColumnMoveDown
            // 
            this.btnColumnMoveDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnMoveDown.Location = new System.Drawing.Point(6, 55);
            this.btnColumnMoveDown.Name = "btnColumnMoveDown";
            this.btnColumnMoveDown.Size = new System.Drawing.Size(237, 30);
            this.btnColumnMoveDown.TabIndex = 37;
            this.btnColumnMoveDown.Text = "Move Column Down";
            this.btnColumnMoveDown.UseVisualStyleBackColor = true;
            this.btnColumnMoveDown.Click += new System.EventHandler(this.btnColumnMoveDown_Click);
            // 
            // btnColumnRemove
            // 
            this.btnColumnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnRemove.Location = new System.Drawing.Point(6, 90);
            this.btnColumnRemove.Name = "btnColumnRemove";
            this.btnColumnRemove.Size = new System.Drawing.Size(237, 30);
            this.btnColumnRemove.TabIndex = 38;
            this.btnColumnRemove.Text = "Delete Column";
            this.btnColumnRemove.UseVisualStyleBackColor = true;
            this.btnColumnRemove.Click += new System.EventHandler(this.btnColumnRemove_Click);
            // 
            // btnColumnAdd
            // 
            this.btnColumnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnAdd.Location = new System.Drawing.Point(329, 116);
            this.btnColumnAdd.Name = "btnColumnAdd";
            this.btnColumnAdd.Size = new System.Drawing.Size(237, 30);
            this.btnColumnAdd.TabIndex = 39;
            this.btnColumnAdd.Text = "Add Column";
            this.btnColumnAdd.UseVisualStyleBackColor = true;
            this.btnColumnAdd.Click += new System.EventHandler(this.btnColumnAdd_Click);
            // 
            // lstCorrectResponses
            // 
            this.lstCorrectResponses.FormattingEnabled = true;
            this.lstCorrectResponses.Location = new System.Drawing.Point(171, 83);
            this.lstCorrectResponses.Name = "lstCorrectResponses";
            this.lstCorrectResponses.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCorrectResponses.Size = new System.Drawing.Size(235, 173);
            this.lstCorrectResponses.TabIndex = 40;
            // 
            // btnCorrectResponseAdd
            // 
            this.btnCorrectResponseAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCorrectResponseAdd.Location = new System.Drawing.Point(11, 200);
            this.btnCorrectResponseAdd.Name = "btnCorrectResponseAdd";
            this.btnCorrectResponseAdd.Size = new System.Drawing.Size(154, 25);
            this.btnCorrectResponseAdd.TabIndex = 44;
            this.btnCorrectResponseAdd.Text = "Add Response(s)";
            this.btnCorrectResponseAdd.UseVisualStyleBackColor = true;
            // 
            // btnCorrectResponseRemove
            // 
            this.btnCorrectResponseRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCorrectResponseRemove.Location = new System.Drawing.Point(11, 230);
            this.btnCorrectResponseRemove.Name = "btnCorrectResponseRemove";
            this.btnCorrectResponseRemove.Size = new System.Drawing.Size(154, 26);
            this.btnCorrectResponseRemove.TabIndex = 43;
            this.btnCorrectResponseRemove.Text = "Delete Response";
            this.btnCorrectResponseRemove.UseVisualStyleBackColor = true;
            // 
            // grpWithSelected
            // 
            this.grpWithSelected.Controls.Add(this.btnColumnMoveUp);
            this.grpWithSelected.Controls.Add(this.btnColumnMoveDown);
            this.grpWithSelected.Controls.Add(this.btnColumnRemove);
            this.grpWithSelected.Location = new System.Drawing.Point(323, 149);
            this.grpWithSelected.Name = "grpWithSelected";
            this.grpWithSelected.Size = new System.Drawing.Size(249, 126);
            this.grpWithSelected.TabIndex = 56;
            this.grpWithSelected.TabStop = false;
            this.grpWithSelected.Text = "With selected";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtColumnName);
            this.groupBox1.Controls.Add(this.lblColumnName);
            this.groupBox1.Controls.Add(this.btnCorrectResponseRemove);
            this.groupBox1.Controls.Add(this.cboColumnType);
            this.groupBox1.Controls.Add(this.btnCorrectResponseAdd);
            this.groupBox1.Controls.Add(this.lblColumnType);
            this.groupBox1.Controls.Add(this.txtScore);
            this.groupBox1.Controls.Add(this.lstCorrectResponses);
            this.groupBox1.Controls.Add(this.lblColumnScore);
            this.groupBox1.Controls.Add(this.lblCorrectResponses);
            this.groupBox1.Location = new System.Drawing.Point(578, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 264);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Columninfo";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 284);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpWithSelected);
            this.Controls.Add(this.btnColumnAdd);
            this.Controls.Add(this.lstColumns);
            this.Controls.Add(this.lblColumns);
            this.Controls.Add(this.lblDefaultColumnType);
            this.Controls.Add(this.cboDefaultColumnType);
            this.Controls.Add(this.lblProfileName);
            this.Controls.Add(this.txtName);
            this.Name = "ProfileForm";
            this.Text = "CalculationProfileForm";
            this.grpWithSelected.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
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
        private System.Windows.Forms.ListBox lstColumns;
        private System.Windows.Forms.Button btnColumnMoveUp;
        private System.Windows.Forms.Button btnColumnMoveDown;
        private System.Windows.Forms.Button btnColumnRemove;
        private System.Windows.Forms.Button btnColumnAdd;
        private System.Windows.Forms.ListBox lstCorrectResponses;
        private System.Windows.Forms.Button btnCorrectResponseAdd;
        private System.Windows.Forms.Button btnCorrectResponseRemove;
        private System.Windows.Forms.GroupBox grpWithSelected;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}