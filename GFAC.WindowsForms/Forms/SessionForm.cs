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
            {
                _session.Profile = Profile.ImportProfile(txtProfile.Text);
            }
            if (!string.IsNullOrEmpty(txtProfile.Text) &&
                    !string.IsNullOrEmpty(txtInputFile.Text))
            {
                ImportFile();
            }
        }
        private void SelectFile_Click(object sender, EventArgs e)
        {
            txtInputFile.Text = Functions.SelectFile(FileType.CSV);
            if (!string.IsNullOrEmpty(txtProfile.Text) &&
                !string.IsNullOrEmpty(txtInputFile.Text))
            {
                ImportFile();
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

            if (_session.SourceFile != null)
                _uniqueResponseCollection = GetUniqueResponses();

            if (_session.SourceFile != null &&
                _uniqueResponseCollection != null)
                _responders = GetResponders();

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
            dataGridFinalScore.DataSource = _responders.DataTableFinalScore;
            dataGridFinalScore.AutoResizeColumns();
            dataGridFinalScore.Refresh();
        }
        private void PopulateTabResponses()
        {
            dataGridResponses.DataSource = _responders.DataTableResponses;
            dataGridResponses.AutoResizeColumns();
            dataGridResponses.Refresh();
        }
        #endregion

        private void ImportFile()
        {
            if (_session == null)
                return;
            if (_session.Profile == null)
                return;

            _session.SourceFile = GetSourceFile();
            if (_session.SourceFile != null)
                _uniqueResponseCollection = GetUniqueResponses();

            if (_session.SourceFile != null &&
                _uniqueResponseCollection != null)
                _responders = GetResponders();

            if (_session.SourceFile != null) PopulateTabSource();
            if (_responders != null) PopulateTabFinalScore();
            if (_responders != null) PopulateTabResponses();
            //if (_uniqueResponseCollection != null) PopulateTabResponses();
        }
        private Responders GetResponders()
        {
            //TODO: To Be Moved
            Responders returnValue = new Responders();
            try
            {
                Responders responders = new Responders();
                returnValue = responders.ProcessResponders(_session, _uniqueResponseCollection);
            }
            catch { }

            return returnValue;
        }
        private UniqueResponseCollection GetUniqueResponses()
        {
            //TODO: To Be Moved
            UniqueResponseCollection returnValue = new UniqueResponseCollection();
            try
            {
                UniqueResponseCollection uniqueResponseCollection = new UniqueResponseCollection();
                returnValue = uniqueResponseCollection.CollectUniqueResponses(_session);
            }
            catch { }

            return returnValue;
        }
        private SourceFile GetSourceFile()
        {
            //TODO: To Be Moved
            SourceFile returnValue = new SourceFile();
            try
            {
                SourceFile sourceFile = new SourceFile(txtInputFile.Text);
                returnValue = sourceFile.Import();
            }
            catch { }
            return returnValue;
        }
        
        private void DataGridSource_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {//TODO Make DataGridHandler
            //ProfileColumnType
            //Grey = None
            //Blue = Report
            //Green = Score
            DataGridSource.EnableHeadersVisualStyles = false;
            DataGridViewColumn column = DataGridSource.Columns[e.ColumnIndex];

            if (column.HeaderCell.Style.BackColor == Color.Gray)
                column.HeaderCell.Style.BackColor = Color.Blue;
            else if (column.HeaderCell.Style.BackColor == Color.Blue)
                column.HeaderCell.Style.BackColor = Color.Green;
            else if (column.HeaderCell.Style.BackColor == Color.Green)
                column.HeaderCell.Style.BackColor = Color.Gray;
            else
                column.HeaderCell.Style.BackColor = Color.Blue;
        }

    }
}
