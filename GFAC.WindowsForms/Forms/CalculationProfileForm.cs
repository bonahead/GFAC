using GFAC.CalculationProfile.Handlers;
using GFAC.CalculationProfile.Objects;
using GFAC.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC.WindowsForms.Forms
{
    public partial class CalculationProfileForm : Form
    {
        public static ResourceManager rm = new ResourceManager("GFAC.WindowsForms.Resources.Labels", typeof(SessionForm).Assembly);
        public Profile _calculationProfile;
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
        private void SetDefaultProfile_Click(object sender, EventArgs e)
        {
            _calculationProfile = Profile.GetDefault();
            PopulateForm();
        }
        private void PopulateForm()
        {
            this.txtProfileName.Text = _calculationProfile.ProfileName;
            this.cboDefaultColumnType.Text = _calculationProfile.DefaultType.ToString();
            PopulateColumnsList();
        }
        private void PopulateColumnsList()
        {
            _columnsSelectedIndex = -1;
            lstColumns.DataSource = _calculationProfile.Columns.Select(c => c.Name).ToList();
            lstColumns.Refresh();
        }
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            UpdateProfile();
            SaveProfile();
        }
        private void UpdateProfile (bool removeFileInfo = false)
        {
            if (_calculationProfile == null)
                _calculationProfile = new Profile();

            _calculationProfile.ProfileName = txtProfileName.Text;
            _calculationProfile.DefaultType = GetColumnType(cboDefaultColumnType.Text);

            if (removeFileInfo)
            {
                _calculationProfile.FileName = string.Empty;
                _calculationProfile.FilePath = string.Empty;
            }
        }
        private void SaveProfile()
        {
            string filepath = string.IsNullOrEmpty(_calculationProfile.FilePath_Name) ?
                Functions.SelectFile(FileType.Profile, true) :
                _calculationProfile.FilePath_Name;

            ProfileHandler ph = new ProfileHandler(filepath, _calculationProfile);
            _calculationProfile = ph.ExportProfile();
        }

        private void btnSaveASProfile_Click(object sender, EventArgs e)
        {
            UpdateProfile(true);
            SaveProfile();
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            string filepath = Functions.SelectFile(FileType.Profile, false);

            ProfileHandler ph = new ProfileHandler(filepath);
            Profile profile = ph.ImportProfile();

            if (profile != null)
            {
                _calculationProfile = profile;
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
            if (_calculationProfile == null)
                return returnValue;

            if (_calculationProfile.Columns.Count <= index )
                return returnValue;

            returnValue = _calculationProfile.Columns[index];
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
                _calculationProfile.Columns.Add(profileColumn);
            else
                _calculationProfile.Columns[_columnsSelectedIndex] = profileColumn;
            
        }
        private void RemoveColumnInfo()
        {
            foreach (int index in lstColumns.SelectedIndices.Cast<int>().AsEnumerable().Reverse())
            {
                ProfileColumn profileColumn = GetProfileColumn(index);

                if (profileColumn != null)
                    _calculationProfile.Columns.RemoveAt(index);

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

            if (_calculationProfile.Columns.Count() < newIndex && newIndex > -1)
                return;
            
            ProfileColumn oldProfileColumn = GetProfileColumn(index);
            ProfileColumn newProfileColumn = GetProfileColumn(newIndex);
                

            _calculationProfile.Columns[index] = newProfileColumn;
            _calculationProfile.Columns[newIndex] = oldProfileColumn;          
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
            _columnsSelectedIndex = _calculationProfile.Columns.Count;
            SaveColumnInfo();
            PopulateColumnsList();
            lstColumns.SelectedIndex = _calculationProfile.Columns.Count - 1;
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

        private void CalculationProfileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
