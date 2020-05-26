namespace GFAC.WindowsForms.Forms
{
    partial class OverallSessionForm
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
            this.lstSessions = new System.Windows.Forms.ListBox();
            this.btnSessionAdd = new System.Windows.Forms.Button();
            this.btnSessionRemove = new System.Windows.Forms.Button();
            this.btnSessionMoveDown = new System.Windows.Forms.Button();
            this.btnSessionMoveUp = new System.Windows.Forms.Button();
            this.dataGridFinalScore = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblOverallSessionName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblSessions = new System.Windows.Forms.Label();
            this.grpWithSelected = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFinalScore)).BeginInit();
            this.grpWithSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSessions
            // 
            this.lstSessions.FormattingEnabled = true;
            this.lstSessions.Location = new System.Drawing.Point(90, 38);
            this.lstSessions.Name = "lstSessions";
            this.lstSessions.Size = new System.Drawing.Size(227, 212);
            this.lstSessions.TabIndex = 0;
            this.lstSessions.SelectedIndexChanged += new System.EventHandler(this.lstSessions_SelectedIndexChanged);
            // 
            // btnSessionAdd
            // 
            this.btnSessionAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSessionAdd.Location = new System.Drawing.Point(329, 88);
            this.btnSessionAdd.Name = "btnSessionAdd";
            this.btnSessionAdd.Size = new System.Drawing.Size(237, 30);
            this.btnSessionAdd.TabIndex = 43;
            this.btnSessionAdd.Text = "Add Session";
            this.btnSessionAdd.UseVisualStyleBackColor = true;
            this.btnSessionAdd.Click += new System.EventHandler(this.btnSessionAdd_Click);
            // 
            // btnSessionRemove
            // 
            this.btnSessionRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSessionRemove.Location = new System.Drawing.Point(6, 88);
            this.btnSessionRemove.Name = "btnSessionRemove";
            this.btnSessionRemove.Size = new System.Drawing.Size(237, 30);
            this.btnSessionRemove.TabIndex = 42;
            this.btnSessionRemove.Text = "Delete Session";
            this.btnSessionRemove.UseVisualStyleBackColor = true;
            this.btnSessionRemove.Click += new System.EventHandler(this.btnSessionRemove_Click);
            // 
            // btnSessionMoveDown
            // 
            this.btnSessionMoveDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSessionMoveDown.Location = new System.Drawing.Point(6, 55);
            this.btnSessionMoveDown.Name = "btnSessionMoveDown";
            this.btnSessionMoveDown.Size = new System.Drawing.Size(237, 27);
            this.btnSessionMoveDown.TabIndex = 41;
            this.btnSessionMoveDown.Text = "Move Session Down";
            this.btnSessionMoveDown.UseVisualStyleBackColor = true;
            this.btnSessionMoveDown.Click += new System.EventHandler(this.btnSessionMoveDown_Click);
            // 
            // btnSessionMoveUp
            // 
            this.btnSessionMoveUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSessionMoveUp.Location = new System.Drawing.Point(6, 19);
            this.btnSessionMoveUp.Name = "btnSessionMoveUp";
            this.btnSessionMoveUp.Size = new System.Drawing.Size(237, 30);
            this.btnSessionMoveUp.TabIndex = 40;
            this.btnSessionMoveUp.Text = "Move Session Up";
            this.btnSessionMoveUp.UseVisualStyleBackColor = true;
            this.btnSessionMoveUp.Click += new System.EventHandler(this.btnSessionMoveUp_Click);
            // 
            // dataGridFinalScore
            // 
            this.dataGridFinalScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridFinalScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFinalScore.Location = new System.Drawing.Point(578, 38);
            this.dataGridFinalScore.Name = "dataGridFinalScore";
            this.dataGridFinalScore.Size = new System.Drawing.Size(795, 212);
            this.dataGridFinalScore.TabIndex = 47;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(482, 20);
            this.txtName.TabIndex = 52;
            // 
            // lblOverallSessionName
            // 
            this.lblOverallSessionName.AutoSize = true;
            this.lblOverallSessionName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOverallSessionName.Location = new System.Drawing.Point(9, 16);
            this.lblOverallSessionName.Name = "lblOverallSessionName";
            this.lblOverallSessionName.Size = new System.Drawing.Size(75, 13);
            this.lblOverallSessionName.TabIndex = 51;
            this.lblOverallSessionName.Text = "SessionName:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(1233, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 23);
            this.btnRefresh.TabIndex = 53;
            this.btnRefresh.Text = "refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblSessions
            // 
            this.lblSessions.AutoSize = true;
            this.lblSessions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSessions.Location = new System.Drawing.Point(9, 38);
            this.lblSessions.Name = "lblSessions";
            this.lblSessions.Size = new System.Drawing.Size(52, 13);
            this.lblSessions.TabIndex = 54;
            this.lblSessions.Text = "Sessions:";
            // 
            // grpWithSelected
            // 
            this.grpWithSelected.Controls.Add(this.btnSessionMoveUp);
            this.grpWithSelected.Controls.Add(this.btnSessionMoveDown);
            this.grpWithSelected.Controls.Add(this.btnSessionRemove);
            this.grpWithSelected.Location = new System.Drawing.Point(323, 124);
            this.grpWithSelected.Name = "grpWithSelected";
            this.grpWithSelected.Size = new System.Drawing.Size(249, 126);
            this.grpWithSelected.TabIndex = 55;
            this.grpWithSelected.TabStop = false;
            this.grpWithSelected.Text = "With selected";
            // 
            // OverallSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 262);
            this.Controls.Add(this.grpWithSelected);
            this.Controls.Add(this.lblSessions);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSessionAdd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblOverallSessionName);
            this.Controls.Add(this.dataGridFinalScore);
            this.Controls.Add(this.lstSessions);
            this.Name = "OverallSessionForm";
            this.Text = "GFAC Session";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFinalScore)).EndInit();
            this.grpWithSelected.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSessions;
        private System.Windows.Forms.Button btnSessionAdd;
        private System.Windows.Forms.Button btnSessionRemove;
        private System.Windows.Forms.Button btnSessionMoveDown;
        private System.Windows.Forms.Button btnSessionMoveUp;
        private System.Windows.Forms.DataGridView dataGridFinalScore;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblOverallSessionName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblSessions;
        private System.Windows.Forms.GroupBox grpWithSelected;
    }
}