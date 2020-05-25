using GFAC.Common;
using GFAC.WindowsForms.Forms;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC
{
    public partial class SessionForm : Form
    {
        public static ResourceManager rm = new ResourceManager("GFAC.WindowsForms.Resources.Labels", typeof(SessionForm).Assembly);
        private UniqueResponseCollection _uniqueResponseCollection;
        private Responders _responders;
        private Session _session;

        public SessionForm()
        {
            InitializeComponent();
            SetFormLabels();
        }
        private void SetFormLabels()
        {
            lblSessionName.Text = $"{rm.GetString("lblSessionName")}:";
            lblCalculationProfile.Text = $"{rm.GetString("lblCalculationProfile")}:";
            lblInputFile.Text = $"{rm.GetString("lblInputFile")}:";
            btnSelectProfile.Text = rm.GetString("btnSelectProfile");
            btnSelectFile.Text = rm.GetString("btnSelectFile");
            tabFinalScore.Text = rm.GetString("tabFinalScore");
            tabResponses.Text = rm.GetString("tabResponses");
            tabSource.Text = rm.GetString("tabSource");
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
        private void btnImportFile_Click(object sender, EventArgs e)
        {
            ImportFile();            
        }
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
            SourceFile returnValue = new SourceFile();
            try
            {
                SourceFile sourceFile  = new SourceFile(txtInputFile.Text);
                returnValue = sourceFile.Import();
            }
            catch { }
            return returnValue;
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

        private void DataGridSource_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {//TODO Make DataGridHandler
            //ProfileColumnType
            //Grey = None
            //Blue = Report
            //Green = Score
            DataGridSource.EnableHeadersVisualStyles = false;
            DataGridViewColumn column = DataGridSource.Columns[e.ColumnIndex];

            if(column.HeaderCell.Style.BackColor==Color.Gray)
                column.HeaderCell.Style.BackColor = Color.Blue;
            else if (column.HeaderCell.Style.BackColor == Color.Blue)
                column.HeaderCell.Style.BackColor = Color.Green;
            else if (column.HeaderCell.Style.BackColor == Color.Green)
                column.HeaderCell.Style.BackColor = Color.Gray;
            else
                column.HeaderCell.Style.BackColor = Color.Blue;
        }

        private void SaveSession()
        {
            string filepath = string.IsNullOrEmpty(_session.FilePath_Name) ?
                Functions.SelectFile(FileType.Session, true) :
                _session.FilePath_Name;

            _session = Session.ExportSession(filepath, _session);
        }
        private void UpdateSession(bool removeFileInfo = false)
        {
            if (_session == null)
                _session = new Session();
            
            _session.Name = txtSessionName.Text;

            if(removeFileInfo)
            {
                _session.FileName = string.Empty;
                _session.FilePath = string.Empty;
            }
        }
        private void btnSaveSession_Click(object sender, EventArgs e)
        {
            UpdateSession();
            SaveSession();
        }
        private void btnSaveASSession_Click(object sender, EventArgs e)
        {
            UpdateSession(true);
            SaveSession();
        }
        private void btnLoadSession_Click(object sender, EventArgs e)
        {
            string filepath = Functions.SelectFile(FileType.Session, false);

            Session session = Session.ImportSession(filepath);

            if (session != null)
            {
                _session = session;
                PopulateForm();
            }
            else
                MessageBox.Show("unable to load Session");
        }
        private void PopulateForm()
        {
            //Todo Not all form is populated
            this.txtSessionName.Text = _session.Name;
            this.txtInputFile.Text = _session.SourceFile != null ? 
                _session.SourceFile.FileName :
                string.Empty;
            this.txtProfile.Text = _session.Profile != null ?
                _session.Profile.FileName : 
                string.Empty;
        }
        private void btnProfileForm_Click(object sender, EventArgs e)
        {
            CalculationProfileForm f = new CalculationProfileForm();
            f.Show();
        }

        private void btnOverallSessionForm_Click(object sender, EventArgs e)
        {
            OverallSessionForm f = new OverallSessionForm();
            f.Show();
        }

        private void SessionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
