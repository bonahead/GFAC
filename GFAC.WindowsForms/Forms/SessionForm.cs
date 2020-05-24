using GFAC.CalculationProfile.Handlers;
using GFAC.CalculationProfile.Objects;
using GFAC.CalulationSession.Handlers;
using GFAC.CalulationSession.Objects;
using GFAC.Common;
using GFAC.Response.Handlers;
using GFAC.Response.Objects;
using GFAC.Source.Handlers;
using GFAC.Source.Objects;
using GFAC.UnqResponse.Handlers;
using GFAC.UnqResponse.Objects;
using GFAC.WindowsForms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC
{
    public partial class SessionForm : Form
    {
        public static ResourceManager rm = new ResourceManager("GFAC.WindowsForms.Resources.Labels", typeof(SessionForm).Assembly);
        private SourceFile _sourceFile;
        private UniqueResponseCollection _uniqueResponseCollection;
        private Responders _responders;
        public Profiles _calculationProfiles;
        private Session _session;
        private Profile _calculationProfile;

        public SessionForm()
        {
            InitializeComponent();
            SetCalculationProfile();
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
        private void SetCalculationProfile()
        {
            if (string.IsNullOrEmpty(txtProfile.Text))
            {
                _calculationProfile = Profile.GetDefault();
            }
            else
            {
                ProfileHandler ph = new ProfileHandler(txtProfile.Text);
                _calculationProfile = ph.ImportProfile();
            }
         }
        private void SelectFile_Click(object sender, EventArgs e)
        {
            txtInputFile.Text = Functions.SelectFile(FileType.CSV);
        }
        private void btnSelectProfile_Click(object sender, EventArgs e)
        {
            txtProfile.Text = Functions.SelectFile(FileType.Profile);
        }

        private void ImportFile_Click(object sender, EventArgs e)
        {
            _sourceFile = GetSourceFile();
            if (_sourceFile != null) 
                _uniqueResponseCollection = GetUniqueResponses();
            
            if (_sourceFile != null && 
                _uniqueResponseCollection != null) 
                _responders = GetResponders();

            if (_sourceFile != null) PopulateTabSource();
            if (_responders != null) PopulateTabFinalScore();
            if (_responders != null) PopulateTabResponses();
            //if (_uniqueResponseCollection != null) PopulateTabResponses();

        }
        private Responders GetResponders()
        {
            Responders returnValue = new Responders();
            try
            {
                ProfileHandler ph = new ProfileHandler(txtProfile.Text);
                Profile calculationProfile = ph.ImportProfile();
                ResponderHandler rh = new ResponderHandler(_sourceFile, calculationProfile, _uniqueResponseCollection);
                returnValue = rh.ExecuteProfileOnSourceFile();
            }
            catch { }

            return returnValue;
        }

        private UniqueResponseCollection GetUniqueResponses()
        {
            UniqueResponseCollection returnValue = new UniqueResponseCollection();
            try
            {
                SetCalculationProfile();
                UniqueResponseCollectionHandler urh = new UniqueResponseCollectionHandler(_sourceFile, _calculationProfile);
                returnValue = urh.CollectUniqueResponses();
            }
            catch { }

            return returnValue;
        }

        private SourceFile GetSourceFile()
        {
            SourceFile returnValue = new SourceFile();
            try
            {
                SourceFileHandler sfh = new SourceFileHandler(txtInputFile.Text);
                returnValue = sfh.ImportFile();
            }
            catch { }
            return returnValue;
        }

        private void PopulateTabSource()
        {
            DataGridSource.DataSource = _sourceFile.DataTable;
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
        private void SetDefaultProfile_Click(object sender, EventArgs e)
        {
            string ProfileName = "Default";

            ProfileHandler ph = new ProfileHandler();
            ph.SetProfile(ProfileName);

            lblProfile.Text = ProfileName;
        }
        private void SetProfileOnSourceFile_Click(object sender, EventArgs e)
        {
            string ProfileName = lblProfile.Text;

            ProfileHandler ph = new ProfileHandler();
            //ph.SetProfileOnSourceFile(ProfileName);
        }
        private void GetProfiles_Click(object sender, EventArgs e)
        {
            ProfileHandler ph = new ProfileHandler();
            _calculationProfiles = ph.ImportProfiles();
        }
        private void SaveProfile_Click(object sender, EventArgs e)
        {
            _calculationProfiles = Profiles.GetDefault();

            ProfileHandler ph = new ProfileHandler(_calculationProfiles);
            ph.ExportProfiles();
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
        private void DataGridSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void SaveSession()
        {
            string filepath = string.IsNullOrEmpty(_session.FilePath_Name) ?
                Functions.SelectFile(FileType.Session, true) :
                _session.FilePath_Name;

            SessionHandler sh = new SessionHandler(filepath, _session);
            _session = sh.ExportSession();
        }
        private void UpdateSession(bool removeFileInfo = false)
        {
            if (_session == null)
                _session = new Session();
            
            //_session.CalculationProfile = _calculationProfiles[cboCalculationProfiles.SelectedIndex];
            _session.SourceFile = _sourceFile;
            _session.SessionName = txtSessionName.Text;

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

            SessionHandler sh = new SessionHandler(filepath);
            Session session = sh.ImportSession();

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
            this.txtSessionName.Text = _session.SessionName;
            this.txtInputFile.Text = _session.SourceFile != null ? 
                _session.SourceFile.FileName :
                string.Empty;
        }
        private void btnProfileForm_Click(object sender, EventArgs e)
        {
            CalculationProfileForm f = new CalculationProfileForm();
            f.Show();
        }

        
    }
}
