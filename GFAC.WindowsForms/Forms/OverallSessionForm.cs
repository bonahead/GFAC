using GFAC.Common;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC.WindowsForms.Forms
{
    public partial class OverallSessionForm : GFACForm
    {
        public OverallSession _overallSession = new OverallSession();

        public OverallSessionForm()
        {
            InitializeComponent();
            _overallSession = new OverallSession();
        }
        public OverallSessionForm(string filepath)
        {
            InitializeComponent();
            OverallSession overallSession = OverallSession.ImportOverallSession(filepath);

            if (overallSession != null)
            {
                _overallSession = overallSession;
                PopulateForm();
            }
            else
            {
                MessageBox.Show(Messages.OverallSession_UnableToLoad, Captions.OverallSession_Load, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        #region Buttons
        private void btnSessionAdd_Click(object sender, EventArgs e)
        {
            int currentSelectedIndex = lstSessions.SelectedIndex;
            string sessionFile = Functions.SelectFile(FileType.Session);
            if (!string.IsNullOrEmpty(sessionFile))
            {
                Session session = Session.ImportSession(sessionFile);
                if (session != null)
                {
                    AddSession(session);
                }
                else
                    MessageBox.Show(Messages.Session_UnableToLoad, Captions.Session_Load, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddSession(Session session)
        {
            if (lstSessions.Items.Contains(session.Name))
            {
                MessageBox.Show(Messages.Session_UniqueName, Captions.Session_Load, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _overallSession.Sessions.Add(session);
                PopulateSessionsList();
                lstSessions.SelectedIndex = lstSessions.Items.Count - 1;
            }
        }
        private void btnSessionMoveUp_Click(object sender, EventArgs e)
        {
            int index = lstSessions.SelectedIndex;
            MoveSession(index);

            PopulateSessionsList();
            lstSessions.SelectedIndex = index - 1;
        }
        private void btnSessionMoveDown_Click(object sender, EventArgs e)
        {
            int index = lstSessions.SelectedIndex;
            MoveSession(index, false);

            PopulateSessionsList();
            lstSessions.SelectedIndex = index + 1;
        }
        private void btnSessionRemove_Click(object sender, EventArgs e)
        {
            int index = lstSessions.SelectedIndex;
            RemoveSession();

            PopulateSessionsList();
            lstSessions.SelectedIndex = -1;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Sessions newSessions = new Sessions();
            foreach (Session sess in _overallSession.Sessions)
            {
                Session newSession = sess;

                if (sess == null)
                    return;

                if (sess.Profile == null)
                    return;

                sess.SourceFile = GetSourceFile(sess.SourceFile.FileName);

                UniqueResponseCollection urc = new UniqueResponseCollection();
                if (sess.SourceFile != null)
                    urc = GetUniqueResponses(sess);

                if (sess.SourceFile != null &&
                    sess.UniqueResponses != null)
                    sess.Responders = GetResponders(sess, urc);
                newSessions.Add(newSession);
            }
            _overallSession.Sessions = newSessions;

            Rows r = _overallSession.TotalScore();
            PopulateFinalScore();
        }

        #endregion
        #region Private Methods
        private void MoveSession(int index, bool moveUp = true)
        {
            int newIndex = moveUp ?
                index - 1 :
                index + 1;

            if (_overallSession.Sessions.Count() < newIndex && newIndex > -1)
                return;

            Session oldProfileColumn = GetSession(index);
            Session newProfileColumn = GetSession(newIndex);


            _overallSession.Sessions[index] = newProfileColumn;
            _overallSession.Sessions[newIndex] = oldProfileColumn;
        }
        private Session GetSession(int index)
        {
            Session returnValue = null;
            if (_overallSession == null)
                return returnValue;

            if (_overallSession.Sessions.Count <= index)
                return returnValue;

            returnValue = _overallSession.Sessions[index];
            return returnValue;
        }
        private void RemoveSession()
        {
            foreach (int index in lstSessions.SelectedIndices.Cast<int>().AsEnumerable().Reverse())
            {
                Session session = GetSession(index);

                if (session != null)
                    _overallSession.Sessions.RemoveAt(index);
            }
        }
        private void lstSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lstSessions.SelectedIndex;
            btnSessionMoveDown.Enabled = (selectedIndex < _overallSession.Sessions.Count - 1 && selectedIndex > -1);
            btnSessionMoveUp.Enabled = selectedIndex > 0;
            btnSessionRemove.Enabled = (selectedIndex < _overallSession.Sessions.Count && selectedIndex > -1);
        }
        #endregion
        #region Overridden Methods
        public override void Save()
        {
            UpdateOverallSession();
            SaveOverallSession();
        }
        public override void SaveAs()
        {
            UpdateOverallSession(true);
            SaveOverallSession();
        }
        #endregion
        #region File methods
        private void UpdateOverallSession(bool removeFileInfo = false)
        {
            if (_overallSession == null)
                _overallSession = new OverallSession();

            _overallSession.Name = txtName.Text;

            if (removeFileInfo)
            {
                _overallSession.FileName = string.Empty;
                _overallSession.FilePath = string.Empty;
            }
        }
        private void SaveOverallSession()
        {
            string filepath = string.IsNullOrEmpty(_overallSession.FilePath_Name) ?
                Functions.SelectFile(FileType.OverallSession, true) :
                _overallSession.FilePath_Name;

            _overallSession = OverallSession.ExportOverallSession(filepath, _overallSession);
        }
        #endregion
        #region Form methods
        private void PopulateForm()
        {
            if (_overallSession == null)
                return;

            this.txtName.Text = _overallSession.Name;
            PopulateSessionsList();
        }
        private void PopulateSessionsList()
        {
            lstSessions.DataSource = _overallSession.Sessions.Select(c => c.Name).ToList();
            lstSessions.Refresh();
        }
        private void PopulateFinalScore()
        {
            dataGridFinalScore.DataSource = _overallSession.DataTableFinalScore();
            dataGridFinalScore.AutoResizeColumns();
            dataGridFinalScore.Refresh();
        }
        #endregion


        private SourceFile GetSourceFile(string sourceFileName)
        {
            SourceFile returnValue = new SourceFile();
            try
            {
                SourceFile sourceFile = new SourceFile(sourceFileName);
                returnValue = sourceFile.Import();
            }
            catch { }
            return returnValue;
        }
        private Responders GetResponders(Session sess, UniqueResponseCollection urc)
        {
            Responders returnValue = new Responders();
            try
            {
                Responders responders = new Responders();
                returnValue = responders.ProcessResponders(sess, urc);
            }
            catch { }

            return returnValue;
        }
        private UniqueResponseCollection GetUniqueResponses(Session sess)
        {
            UniqueResponseCollection returnValue = new UniqueResponseCollection();
            try
            {
                UniqueResponseCollection uniqueResponseCollection = new UniqueResponseCollection();
                returnValue = uniqueResponseCollection.CollectUniqueResponses(sess);
            }
            catch { }

            return returnValue;
        }
    }
}
