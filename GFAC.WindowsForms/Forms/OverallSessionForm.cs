﻿using GFAC.Common;
using System;
using System.Data;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC.WindowsForms.Forms
{
    public partial class OverallSessionForm : Form
    {
        public static ResourceManager rm = new ResourceManager("GFAC.WindowsForms.Resources.Labels", typeof(SessionForm).Assembly);
        public OverallSession _overallSession = new OverallSession();
        private int _columnsSelectedIndex = -1;

        public OverallSessionForm()
        {
            InitializeComponent();
            SetFormLabels();
            _overallSession = new OverallSession();
        }

        private void SetFormLabels()
        {
            lblOverallSessionName.Text = $"{rm.GetString("lblOverallSessionName")}:";
            lblSessionFile.Text = $"{rm.GetString("lblSessionFile")}:";
        }
        private void btnColumnMoveUp_Click(object sender, EventArgs e)
        {
            int index = lstSessions.SelectedIndex;
            if (index > -1)
                MoveSession(index);

            PopulateSessionsList();
            lstSessions.SelectedIndex = index - 1;
        }

        private void btnColumnMoveDown_Click(object sender, EventArgs e)
        {
            int index = lstSessions.SelectedIndex;
            if (index > -1)
                MoveSession(index, false);

            PopulateSessionsList();
            lstSessions.SelectedIndex = index + 1;
        }
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
        private void PopulateSessionsList()
        {
            _columnsSelectedIndex = -1;
            lstSessions.DataSource = _overallSession.Sessions.Select(c => c.Name).ToList();
            lstSessions.Refresh();
        }
        private void RemoveSession()
        {
            foreach (int index in lstSessions.SelectedIndices.Cast<int>().AsEnumerable().Reverse())
            {
                Session session = GetSession(index);

                if (session != null)
                    _overallSession.Sessions.RemoveAt(index);

                _columnsSelectedIndex = -1;
            }
        }

        private void btnColumnRemove_Click(object sender, EventArgs e)
        {
            int index = lstSessions.SelectedIndex;
            if (index > -1)
                RemoveSession();
            PopulateSessionsList();
            lstSessions.SelectedIndex = -1;
        }

        private void btnColumnAdd_Click(object sender, EventArgs e)
        {
            ClearSession();
            _columnsSelectedIndex =  _overallSession.Sessions.Count;
            SaveSession();
            PopulateSessionsList();
            lstSessions.SelectedIndex = _overallSession.Sessions.Count - 1;
            _columnsSelectedIndex = lstSessions.SelectedIndex;
        }
        private void ClearSession()
        {
            _columnsSelectedIndex = -1;
            txtName.Text = string.Empty;
        }
        private void SaveSession()
        {
            if (_overallSession == null)
                _overallSession = new OverallSession();

            bool newColumn = true;
            Session session = GetSession(_columnsSelectedIndex);

            if (session == null)
                session = new Session();
            else
                newColumn = false;

            session.Name = txtName.Text;
            //TODO

            if (newColumn)
                _overallSession.Sessions.Add(session);
            else
                _overallSession.Sessions[_columnsSelectedIndex] = session;

        }
        private void btnSaveOverallSession_Click(object sender, EventArgs e)
        {
            UpdateOverallSession();
            SaveOverallSession();
        }

        private void btnSaveASOverallSession_Click(object sender, EventArgs e)
        {
            UpdateOverallSession(true);
            SaveOverallSession();
        }

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
        private void btnLoadOverallSession_Click(object sender, EventArgs e)
        {
            string filepath = Functions.SelectFile(FileType.OverallSession, false);
            OverallSession overallSession = OverallSession.ImportOverallSession(filepath);

            if (overallSession != null)
            {
                _overallSession = overallSession;
                PopulateForm();
            }
            else
                MessageBox.Show("unable to load Overall Session");
        }
        private void PopulateForm()
        {
            this.txtName.Text = _overallSession.Name;
            PopulateSessionsList();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            txtSessionFile.Text = Functions.SelectFile(FileType.Session);
            if (!string.IsNullOrEmpty(txtSessionFile.Text))
            {
                Session session = Session.ImportSession(txtSessionFile.Text);
                _overallSession.Sessions.Add(session);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Sessions newSessions = new Sessions();
            foreach(Session sess in _overallSession.Sessions)
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
        private void PopulateFinalScore()
        {
            dataGridFinalScore.DataSource = _overallSession.DataTableFinalScore();
            dataGridFinalScore.AutoResizeColumns();
            dataGridFinalScore.Refresh();
        }
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
