using GFAC.Common;
using System;
using System.Drawing;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC.WindowsForms.Forms
{
    public partial class SessionForm : GFACForm
    {
        private UniqueResponseCollection _uniqueResponseCollection;
        private Responders _responders;
        private Session _session;

        public SessionForm()
        {
            InitializeComponent();
            _session = new Session();
        }
        public SessionForm(string filepath)
        {
            InitializeComponent();
            Session session = Session.ImportSession(filepath);

            if (session != null)
            {
                _session = session;
                PopulateForm();
            }
            else
            {
                MessageBox.Show(Messages.Session_UnableToLoad, Captions.Session_Load, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        #region Buttons
        private void btnSelectProfile_Click(object sender, EventArgs e)
        {
            txtProfile.Text = Functions.SelectFile(FileType.Profile);
            if (!string.IsNullOrEmpty(txtProfile.Text))
                _session.Profile = Profile.ImportProfile(txtProfile.Text);
            
            if (_session.Profile != null &&
                    !string.IsNullOrEmpty(txtInputFile.Text))
            {
                ImportFile();
            }
        }
        private void SelectFile_Click(object sender, EventArgs e)
        {
            txtInputFile.Text = Functions.SelectFile(FileType.CSV);

            if (!string.IsNullOrEmpty(txtProfile.Text) &&
                    _session.Profile == null)
                _session.Profile = Profile.ImportProfile(txtProfile.Text);

            if(_session.Profile == null)
            {
                DialogResult result =MessageBox.Show(Messages.Session_NoProfile, Captions.Session_Load, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                    ProcessNoProfile(txtInputFile.Text);

                if (result == DialogResult.Cancel)
                    return;
            }

            if (!string.IsNullOrEmpty(txtInputFile.Text))
                ImportFile();
        }

        private void ProcessNoProfile(string sourceFilePath_Name)
        {
            SourceFile sf = new SourceFile(sourceFilePath_Name);
            SourceFile sourceFile = sf.Import();
            _uniqueResponseCollection = sourceFile != null ?
                UniqueResponseCollection.CollectUniqueResponses(sourceFile) :
                null;

            ProfileWizardForm pwf = new ProfileWizardForm(sourceFile, _uniqueResponseCollection);
            DialogResult result = pwf.ShowWizard();
            if (result == DialogResult.OK)
            {
                _session.Profile = pwf.ReturnValue;
                string filepath = string.IsNullOrEmpty(_session.Profile.FilePath_Name) ?
                    Functions.SelectFile(FileType.Profile, true) :
                    _session.Profile.FilePath_Name;

                _session.Profile = Profile.ExportProfile(filepath, _session.Profile);
                txtProfile.Text = _session.Profile_Filepath;
            }            
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ImportFile();
        }
        #endregion
        #region Private Methods
        #endregion
        #region Overridden Methods
        public override void Save()
        {
            UpdateSession();
            SaveSession();
        }
        public override void SaveAs()
        {
            UpdateSession(true);
            SaveSession();
        }
        #endregion
        #region File Methods
        private void UpdateSession(bool removeFileInfo = false)
        {
            if (_session == null)
                _session = new Session();

            _session.Name = txtName.Text;

            if (removeFileInfo)
            {
                _session.FileName = string.Empty;
                _session.FilePath = string.Empty;
            }
        }
        private void SaveSession()
        {
            string filepath = string.IsNullOrEmpty(_session.FilePath_Name) ?
                Functions.SelectFile(FileType.Session, true) :
                _session.FilePath_Name;

            _session = Session.ExportSession(filepath, _session);
        }
        #endregion
        #region Form Methods
        private void PopulateForm()
        {
            this.txtName.Text = _session.Name;
            this.txtInputFile.Text = _session.SourceFile != null ?
                _session.SourceFile.FileName :
                string.Empty;
            this.txtProfile.Text = _session.Profile != null ?
                _session.Profile.FileName :
                string.Empty;

            if (_session.SourceFile != null) PopulateTabSource();
            if (_responders != null) PopulateTabFinalScore();
            if (_responders != null) PopulateTabResponses();
        }
        private void PopulateTabSource()
        {
            DataGridSource.DataSource = _session.SourceFile.DataTable;
            DataGridSource.AutoResizeColumns();
            DataGridSource.Refresh();
        }
        private void PopulateTabFinalScore()
        {
            dataGridFinalScore.DataSource = _session.Responders.DataTableFinalScore;
            dataGridFinalScore.AutoResizeColumns();
            dataGridFinalScore.Refresh();
        }
        private void PopulateTabResponses()
        {
            dataGridResponses.DataSource = _session.Responders.DataTableResponses;
            dataGridResponses.AutoResizeColumns();
            dataGridResponses.Refresh();
        }
        #endregion

        private void ImportFile()
        {
            if (_session == null)
                return;

            _session.SourceFile_Filepath = txtInputFile.Text;
            _session.Profile_Filepath = txtProfile.Text;

            _session.ProcessSourceFile();

            if (_session.SourceFile != null) PopulateTabSource();
            if (_session.Responders != null)
            {
                PopulateTabFinalScore();
                PopulateTabResponses();
            }
        }
      
        //private void DataGridSource_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{//TODO Make DataGridHandler
        //    //ProfileColumnType
        //    //Grey = None
        //    //Blue = Report
        //    //Green = Score
        //    DataGridSource.EnableHeadersVisualStyles = false;
        //    DataGridViewColumn column = DataGridSource.Columns[e.ColumnIndex];

        //    if (column.HeaderCell.Style.BackColor == Color.Gray)
        //        column.HeaderCell.Style.BackColor = Color.Blue;
        //    else if (column.HeaderCell.Style.BackColor == Color.Blue)
        //        column.HeaderCell.Style.BackColor = Color.Green;
        //    else if (column.HeaderCell.Style.BackColor == Color.Green)
        //        column.HeaderCell.Style.BackColor = Color.Gray;
        //    else
        //        column.HeaderCell.Style.BackColor = Color.Blue;
        //}
    }
}
