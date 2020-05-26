using GFAC.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC.WindowsForms.Forms
{
    public partial class ProfileForm : GFACForm
    {
        public Profile _profile;
        private int _PreviousSelectedColumnIndex = -1;
        public ProfileForm()
        {
            InitializeComponent();
            _profile = new Profile();
        }
        public ProfileForm(string filepath)
        {
            InitializeComponent();
            Profile profile = Profile.ImportProfile(filepath);

            if (profile != null)
            {
                _profile = profile;
                PopulateForm();
            }
            else
            {
                MessageBox.Show(Messages.Profile_UnableToLoad, Captions.Profile_Load, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        #region Buttons
        private void btnColumnAdd_Click(object sender, EventArgs e)
        {
            AddColumn();
            ClearColumnInfo();
            PopulateColumnsList();
            lstColumns.SelectedIndex = _profile.Columns.Count - 1;
        }
        private void btnColumnMoveDown_Click(object sender, EventArgs e)
        {
            int index = lstColumns.SelectedIndex;
            MoveColumnInfo(index, false);

            PopulateColumnsList();
            lstColumns.SelectedIndex = index + 1;
        }
        private void btnColumnMoveUp_Click(object sender, EventArgs e)
        {
            int index = lstColumns.SelectedIndex;
            MoveColumnInfo(index);

            PopulateColumnsList();
            lstColumns.SelectedIndex = index - 1;
        }
        private void btnColumnRemove_Click(object sender, EventArgs e)
        {
            int index = lstColumns.SelectedIndex;
            RemoveColumnInfo();

            PopulateColumnsList();
            lstColumns.SelectedIndex = -1;
        }
        private void btnCorrectResponseAdd_Click(object sender, EventArgs e)
        {
            using (CorrectResponsesForm crf = new CorrectResponsesForm())
            {
                DialogResult result = crf.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string[] correctResponses = crf.ReturnValue
                                                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (string cr in correctResponses)
                    {
                        if (!string.IsNullOrEmpty(cr))
                            if (!_profile.Columns[_PreviousSelectedColumnIndex].CorrectResponses.Contains(cr))
                                _profile.Columns[_PreviousSelectedColumnIndex].CorrectResponses.Add(cr);
                    }
                }
            }
            PopulateCorrectResponses(_profile.Columns[_PreviousSelectedColumnIndex].CorrectResponses);
        }
        private void btnCorrectResponseRemove_Click(object sender, EventArgs e)
        {
            foreach (int index in lstCorrectResponses.SelectedIndices.Cast<int>().AsEnumerable().Reverse())
            {
                _profile.Columns[_PreviousSelectedColumnIndex].CorrectResponses.RemoveAt(index);
            }
            PopulateCorrectResponses(_profile.Columns[_PreviousSelectedColumnIndex].CorrectResponses);
        }
        #endregion
        #region Private Methods
        #endregion
        #region Overridden Methods
        public override void Save()
        {
            UpdateProfile();
            SaveProfile();
        }
        public override void SaveAs()
        {
            UpdateProfile(true);
            SaveProfile();
        }
        #endregion
        #region File Methods
        private void UpdateProfile(bool removeFileInfo = false)
        {
            if (_profile == null)
                _profile = new Profile();

            _profile.Name = txtName.Text;
            _profile.DefaultType = GetColumnType(cboDefaultColumnType.Text);

            SaveColumnInfo(lstColumns.SelectedIndex);

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
        #endregion
        #region Form Methods
        private void PopulateForm()
        {
            this.txtName.Text = _profile.Name;
            this.cboDefaultColumnType.Text = _profile.DefaultType.ToString();
            PopulateColumnsList();
        }
        private void PopulateColumnsList()
        {
            lstColumns.Items.Clear();
            foreach(string columnName in _profile.Columns.Select(c => c.Name))
            {
                lstColumns.Items.Add(columnName);
            }
            lstColumns.Refresh();
        }
        private void SaveColumnInfo(int index)
        {
            if (index == -1)
                return;

            _profile.Columns[index].Name = txtColumnName.Text;
            _profile.Columns[index].Type = GetColumnType(cboColumnType.Text);
            _profile.Columns[index].Score = int.TryParse(txtScore.Text, out int score) ?
                                                                score :
                                                                0;
            _profile.Columns[index].CorrectResponses = lstCorrectResponses.Items.Cast<String>().ToList();
        }
        private void lstColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lstColumns.SelectedIndex;
            btnColumnMoveDown.Enabled = (selectedIndex < _profile.Columns.Count - 1 && selectedIndex > -1);
            btnColumnMoveUp.Enabled = selectedIndex > 0;
            btnColumnRemove.Enabled = (selectedIndex < _profile.Columns.Count && selectedIndex > -1);

            if (selectedIndex != _PreviousSelectedColumnIndex && _PreviousSelectedColumnIndex > -1)
            {
                SaveColumnInfo(_PreviousSelectedColumnIndex);
                PopulateColumnsList();
            }

            if (selectedIndex > -1)
            {
                PopulateColumnInfo(selectedIndex);
            }

            _PreviousSelectedColumnIndex = selectedIndex;
            lstColumns.SelectedIndex = selectedIndex;
        }
        private ProfileColumn GetProfileColumn(int index)
        {
            ProfileColumn returnValue = null;
            if (_profile == null)
                return returnValue;

            if (_profile.Columns.Count <= index)
                return returnValue;

            returnValue = _profile.Columns[index];
            return returnValue;
        }
        private void RemoveColumnInfo()
        {
            foreach (int index in lstColumns.SelectedIndices.Cast<int>().AsEnumerable().Reverse())
            {
                ProfileColumn profileColumn = GetProfileColumn(index);

                if (profileColumn != null)
                    _profile.Columns.RemoveAt(index);
            }
        }
        private void ClearColumnInfo()
        {
            txtColumnName.Text = string.Empty;
            cboColumnType.SelectedIndex = 0;
            txtScore.Text = "1";
            PopulateCorrectResponses(new List<string>());

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
        private void PopulateColumnInfo(int index)
        {
            if (index == -1)
                return;

            ProfileColumn profileColumn = GetProfileColumn(index);

            if (profileColumn == null)
                return;

            txtColumnName.Text = profileColumn.Name;
            txtScore.Text = profileColumn.Score.ToString();
            cboColumnType.SelectedIndex = cboColumnType.FindString(profileColumn.Type.ToString());
            PopulateCorrectResponses(profileColumn.CorrectResponses);
        }
        private void PopulateCorrectResponses(List<string> correctResponses)
        {
            lstCorrectResponses.Items.Clear();
            foreach (string value in correctResponses.OrderBy(cr => cr).ToList())
            {
                lstCorrectResponses.Items.Add(value);
            }
            lstCorrectResponses.Refresh();
        }
        private void AddColumn()
        {
            _profile.Columns.Add(new ProfileColumn() { Name = "New Column" });
        }
        #endregion
    }
}
