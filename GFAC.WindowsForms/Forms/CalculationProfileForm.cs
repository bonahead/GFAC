using GFAC.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC.WindowsForms.Forms
{
    public partial class CalculationProfileForm : Form
    {
        public static ResourceManager rm = new ResourceManager("GFAC.WindowsForms.Resources.Labels", typeof(SessionForm).Assembly);
        public Profile _profile;
        private int _columnsSelectedIndex =-1;
        public CalculationProfileForm()
        {
            InitializeComponent();
            SetFormLabels();
        }
        private void SetFormLabels()
        {
            lblProfileName.Text = $"{rm.GetString("lblProfileName")}:";
            lblDefaultColumnType.Text = $"{rm.GetString("lblDefaultColumnType")}:";
            lblColumns.Text = $"{rm.GetString("lblColumns")}:";
            lblColumnName.Text = $"{rm.GetString("lblColumnName")}:";
            lblColumnType.Text = $"{rm.GetString("lblColumnType")}:";
            lblColumnScore.Text = $"{rm.GetString("lblColumnScore")}:";
            lblCorrectResponses.Text = $"{rm.GetString("lblCorrectResponses")}:";
        }
        private void PopulateForm()
        {
            this.txtProfileName.Text = _profile.Name;
            this.cboDefaultColumnType.Text = _profile.DefaultType.ToString();
            PopulateColumnsList();
        }
        private void PopulateColumnsList()
        {
            _columnsSelectedIndex = -1;
            lstColumns.DataSource = _profile.Columns.Select(c => c.Name).ToList();
            lstColumns.Refresh();
        }
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            UpdateProfile();
            SaveProfile();
        }
        private void UpdateProfile (bool removeFileInfo = false)
        {
            if (_profile == null)
                _profile = new Profile();

            _profile.Name = txtProfileName.Text;
            _profile.DefaultType = GetColumnType(cboDefaultColumnType.Text);

            if (removeFileInfo)
            {
                _profile.FileName = string.Empty;
                _profile.FilePath = string.Empty;
            }
        }
        private void SaveProfile()
        {
            string filepath = string.IsNullOrEmpty(_profile.FilePath_Name) ?
                Functions.SelectFile(FileType.Profile, true) :
                _profile.FilePath_Name;

            _profile = Profile.ExportProfile(filepath, _profile);
        }

        private void btnSaveASProfile_Click(object sender, EventArgs e)
        {
            UpdateProfile(true);
            SaveProfile();
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            string filepath = Functions.SelectFile(FileType.Profile, false);

            Profile profile = Profile.ImportProfile(filepath);

            if (profile != null)
            {
                _profile = profile;
                PopulateForm();
            }
            else
                MessageBox.Show("unable to load Session");
        }
        private void lstColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lstColumns.SelectedIndex;
            if (_columnsSelectedIndex > -1)
            {
                SaveColumnInfo();
                PopulateColumnsList();
            }

            if (selectedIndex > -1)
            {
                PopulateColumnInfo();
            }
        }
        private ProfileColumn GetProfileColumn(int index)
        {
            ProfileColumn returnValue = null;
            if (_profile == null)
                return returnValue;

            if (_profile.Columns.Count <= index )
                return returnValue;

            returnValue = _profile.Columns[index];
            return returnValue;
        }
        private void SaveColumnInfo()
        {
            bool newColumn = true;
            ProfileColumn profileColumn = GetProfileColumn(_columnsSelectedIndex);

            if (profileColumn == null)
                profileColumn = new ProfileColumn();
            else
                newColumn = false;

            profileColumn.Name = txtColumnName.Text;
            profileColumn.Type = GetColumnType(cboColumnType.SelectedItem);
            profileColumn.Score = int.Parse(txtScore.Text);
            profileColumn.CorrectResponses = GetCorrectResponses();

            if (newColumn)
                _profile.Columns.Add(profileColumn);
            else
                _profile.Columns[_columnsSelectedIndex] = profileColumn;
            
        }
        private void RemoveColumnInfo()
        {
            foreach (int index in lstColumns.SelectedIndices.Cast<int>().AsEnumerable().Reverse())
            {
                ProfileColumn profileColumn = GetProfileColumn(index);

                if (profileColumn != null)
                    _profile.Columns.RemoveAt(index);

                _columnsSelectedIndex = -1;
            }
        }
        private void ClearColumnInfo()
        {
            _columnsSelectedIndex = -1;
            txtColumnName.Text = string.Empty;
            cboColumnType.SelectedIndex = 0;
            txtScore.Text = "1";
           // lstCorrectResponses.Items.Clear();
        }
        private void MoveColumnInfo(int index, bool moveUp = true)
        {
            int newIndex = moveUp ?
                index - 1 :
                index + 1;

            if (_profile.Columns.Count() < newIndex && newIndex > -1)
                return;
            
            ProfileColumn oldProfileColumn = GetProfileColumn(index);
            ProfileColumn newProfileColumn = GetProfileColumn(newIndex);
                

            _profile.Columns[index] = newProfileColumn;
            _profile.Columns[newIndex] = oldProfileColumn;          
        }
        private List<string> GetCorrectResponses()
        {
            List<string> returnValue = new List<string>();
            List<string> initialList = new List<string>();
            foreach (string value in lstCorrectResponses.Items)
            {
                initialList.Add(value.ToUpper());
            }
            returnValue = initialList.Distinct().ToList();
            return returnValue;
        }
        private ColumnType GetColumnType(object selectedItem)
        {
            switch (selectedItem.ToString())
            {
                case "None":
                    return ColumnType.None;
                case "Report":
                    return ColumnType.Report;
                case "Score":
                    return ColumnType.Score;
                default:
                    return ColumnType.None;
            }
        }
        private void PopulateColumnInfo()
        {
            ProfileColumn profileColumn = GetProfileColumn(lstColumns.SelectedIndex);

            if (profileColumn == null)
                return;

            txtColumnName.Text = profileColumn.Name;
            txtScore.Text = profileColumn.Score.ToString();
            cboColumnType.SelectedIndex = cboColumnType.FindString(profileColumn.Type.ToString());
            PopulateCorrectResponses(profileColumn.CorrectResponses);
        }
        private void PopulateCorrectResponses(List<string> correctResponses)
        {
            lstCorrectResponses.DataSource = correctResponses;
            lstCorrectResponses.Invalidate();
        }

        private void btnColumnMoveDown_Click(object sender, EventArgs e)
        {
            int index = lstColumns.SelectedIndex;
            if (index > -1)
                MoveColumnInfo(index, false);
 
            PopulateColumnsList();
            lstColumns.SelectedIndex = index + 1;
        }

        private void btnColumnMoveUp_Click(object sender, EventArgs e)
        {
            int index = lstColumns.SelectedIndex;
            if (index > -1)
                MoveColumnInfo(index);

            PopulateColumnsList();
            lstColumns.SelectedIndex = index - 1;
        }

        private void btnColumnRemove_Click(object sender, EventArgs e)
        {
            int index = lstColumns.SelectedIndex;
            if (index > -1)
                RemoveColumnInfo();
            PopulateColumnsList();
            lstColumns.SelectedIndex =  - 1;
        }

        private void btnColumnAdd_Click(object sender, EventArgs e)
        {
            ClearColumnInfo();
            _columnsSelectedIndex = _profile.Columns.Count;
            SaveColumnInfo();
            PopulateColumnsList();
            lstColumns.SelectedIndex = _profile.Columns.Count - 1;
            _columnsSelectedIndex = lstColumns.SelectedIndex;
        }

        private void btnCorrectResponseAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddCorrectResponses.Text))
                return;

            ProfileColumn column = GetProfileColumn(lstColumns.SelectedIndex);
            List<string> newCorrectResponses =
                txtAddCorrectResponses.Text
                .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach(string newCR in newCorrectResponses)
            {
                if (!column.CorrectResponses.Contains(newCR.Trim().ToUpper()))
                    column.CorrectResponses.Add(newCR.Trim().ToUpper());
            }

            PopulateCorrectResponses(column.CorrectResponses);
        }
    }
}
