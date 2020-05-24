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
            this.btnColumnAdd = new System.Windows.Forms.Button();
            this.btnColumnRemove = new System.Windows.Forms.Button();
            this.btnColumnMoveDown = new System.Windows.Forms.Button();
            this.btnColumnMoveUp = new System.Windows.Forms.Button();
            this.txtSessionFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblSessionFile = new System.Windows.Forms.Label();
            this.dataGridFinalScore = new System.Windows.Forms.DataGridView();
            this.btnLoadOverallSession = new System.Windows.Forms.Button();
            this.btnSaveASOverallSession = new System.Windows.Forms.Button();
            this.btnSaveOverallSession = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblOverallSessionName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFinalScore)).BeginInit();
            this.SuspendLayout();
            // 
            // lstSessions
            // 
            this.lstSessions.FormattingEnabled = true;
            this.lstSessions.Location = new System.Drawing.Point(12, 70);
            this.lstSessions.Name = "lstSessions";
            this.lstSessions.Size = new System.Drawing.Size(165, 368);
            this.lstSessions.TabIndex = 0;
            // 
            // btnColumnAdd
            // 
            this.btnColumnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnAdd.Location = new System.Drawing.Point(183, 358);
            this.btnColumnAdd.Name = "btnColumnAdd";
            this.btnColumnAdd.Size = new System.Drawing.Size(54, 37);
            this.btnColumnAdd.TabIndex = 43;
            this.btnColumnAdd.Text = "Add";
            this.btnColumnAdd.UseVisualStyleBackColor = true;
            this.btnColumnAdd.Click += new System.EventHandler(this.btnColumnAdd_Click);
            // 
            // btnColumnRemove
            // 
            this.btnColumnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnRemove.Location = new System.Drawing.Point(183, 316);
            this.btnColumnRemove.Name = "btnColumnRemove";
            this.btnColumnRemove.Size = new System.Drawing.Size(54, 37);
            this.btnColumnRemove.TabIndex = 42;
            this.btnColumnRemove.Text = "Delete";
            this.btnColumnRemove.UseVisualStyleBackColor = true;
            this.btnColumnRemove.Click += new System.EventHandler(this.btnColumnRemove_Click);
            // 
            // btnColumnMoveDown
            // 
            this.btnColumnMoveDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnMoveDown.Location = new System.Drawing.Point(183, 401);
            this.btnColumnMoveDown.Name = "btnColumnMoveDown";
            this.btnColumnMoveDown.Size = new System.Drawing.Size(54, 37);
            this.btnColumnMoveDown.TabIndex = 41;
            this.btnColumnMoveDown.Text = "Down";
            this.btnColumnMoveDown.UseVisualStyleBackColor = true;
            this.btnColumnMoveDown.Click += new System.EventHandler(this.btnColumnMoveDown_Click);
            // 
            // btnColumnMoveUp
            // 
            this.btnColumnMoveUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnMoveUp.Location = new System.Drawing.Point(183, 273);
            this.btnColumnMoveUp.Name = "btnColumnMoveUp";
            this.btnColumnMoveUp.Size = new System.Drawing.Size(54, 37);
            this.btnColumnMoveUp.TabIndex = 40;
            this.btnColumnMoveUp.Text = "Up";
            this.btnColumnMoveUp.UseVisualStyleBackColor = true;
            this.btnColumnMoveUp.Click += new System.EventHandler(this.btnColumnMoveUp_Click);
            // 
            // txtSessionFile
            // 
            this.txtSessionFile.Location = new System.Drawing.Point(302, 69);
            this.txtSessionFile.Name = "txtSessionFile";
            this.txtSessionFile.Size = new System.Drawing.Size(435, 20);
            this.txtSessionFile.TabIndex = 46;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectFile.Location = new System.Drawing.Point(754, 67);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(209, 24);
            this.btnSelectFile.TabIndex = 45;
            this.btnSelectFile.Text = "Select Session";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // lblSessionFile
            // 
            this.lblSessionFile.AutoSize = true;
            this.lblSessionFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSessionFile.Location = new System.Drawing.Point(191, 73);
            this.lblSessionFile.Name = "lblSessionFile";
            this.lblSessionFile.Size = new System.Drawing.Size(35, 13);
            this.lblSessionFile.TabIndex = 44;
            this.lblSessionFile.Text = "label1";
            // 
            // dataGridFinalScore
            // 
            this.dataGridFinalScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridFinalScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFinalScore.Location = new System.Drawing.Point(302, 145);
            this.dataGridFinalScore.Name = "dataGridFinalScore";
            this.dataGridFinalScore.Size = new System.Drawing.Size(596, 293);
            this.dataGridFinalScore.TabIndex = 47;
            // 
            // btnLoadOverallSession
            // 
            this.btnLoadOverallSession.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoadOverallSession.Location = new System.Drawing.Point(1097, 77);
            this.btnLoadOverallSession.Name = "btnLoadOverallSession";
            this.btnLoadOverallSession.Size = new System.Drawing.Size(140, 23);
            this.btnLoadOverallSession.TabIndex = 50;
            this.btnLoadOverallSession.Text = "Load Overall Session";
            this.btnLoadOverallSession.UseVisualStyleBackColor = true;
            this.btnLoadOverallSession.Click += new System.EventHandler(this.btnLoadOverallSession_Click);
            // 
            // btnSaveASOverallSession
            // 
            this.btnSaveASOverallSession.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveASOverallSession.Location = new System.Drawing.Point(1097, 48);
            this.btnSaveASOverallSession.Name = "btnSaveASOverallSession";
            this.btnSaveASOverallSession.Size = new System.Drawing.Size(140, 23);
            this.btnSaveASOverallSession.TabIndex = 49;
            this.btnSaveASOverallSession.Text = "SaveAS Overall Session";
            this.btnSaveASOverallSession.UseVisualStyleBackColor = true;
            this.btnSaveASOverallSession.Click += new System.EventHandler(this.btnSaveASOverallSession_Click);
            // 
            // btnSaveOverallSession
            // 
            this.btnSaveOverallSession.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveOverallSession.Location = new System.Drawing.Point(1097, 19);
            this.btnSaveOverallSession.Name = "btnSaveOverallSession";
            this.btnSaveOverallSession.Size = new System.Drawing.Size(140, 23);
            this.btnSaveOverallSession.TabIndex = 48;
            this.btnSaveOverallSession.Text = "Save Overall Session";
            this.btnSaveOverallSession.UseVisualStyleBackColor = true;
            this.btnSaveOverallSession.Click += new System.EventHandler(this.btnSaveOverallSession_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(128, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(496, 20);
            this.txtName.TabIndex = 52;
            // 
            // lblOverallSessionName
            // 
            this.lblOverallSessionName.AutoSize = true;
            this.lblOverallSessionName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOverallSessionName.Location = new System.Drawing.Point(15, 19);
            this.lblOverallSessionName.Name = "lblOverallSessionName";
            this.lblOverallSessionName.Size = new System.Drawing.Size(35, 13);
            this.lblOverallSessionName.TabIndex = 51;
            this.lblOverallSessionName.Text = "label1";
            // 
            // OverallSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 450);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblOverallSessionName);
            this.Controls.Add(this.btnLoadOverallSession);
            this.Controls.Add(this.btnSaveASOverallSession);
            this.Controls.Add(this.btnSaveOverallSession);
            this.Controls.Add(this.dataGridFinalScore);
            this.Controls.Add(this.txtSessionFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblSessionFile);
            this.Controls.Add(this.btnColumnAdd);
            this.Controls.Add(this.btnColumnRemove);
            this.Controls.Add(this.btnColumnMoveDown);
            this.Controls.Add(this.btnColumnMoveUp);
            this.Controls.Add(this.lstSessions);
            this.Name = "OverallSessionForm";
            this.Text = "OverallSessionForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFinalScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSessions;
        private System.Windows.Forms.Button btnColumnAdd;
        private System.Windows.Forms.Button btnColumnRemove;
        private System.Windows.Forms.Button btnColumnMoveDown;
        private System.Windows.Forms.Button btnColumnMoveUp;
        private System.Windows.Forms.TextBox txtSessionFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblSessionFile;
        private System.Windows.Forms.DataGridView dataGridFinalScore;
        private System.Windows.Forms.Button btnLoadOverallSession;
        private System.Windows.Forms.Button btnSaveASOverallSession;
        private System.Windows.Forms.Button btnSaveOverallSession;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblOverallSessionName;
    }
}