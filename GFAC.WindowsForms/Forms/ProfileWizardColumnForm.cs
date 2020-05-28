using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MBG.SimpleWizard;

namespace GFAC.WindowsForms.Forms
{
    public partial class ProfileWizardColumnForm : UserControl, IWizardPage
    {
        private Column Column { get; set; }
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
        public int Score { get; set; }
        public List<string> CorrectResponses { get; set; }
        public List<string> CurrentResponses { get; set; }
        public ProfileWizardColumnForm(Column column, UniqueResponses urc)
        {
            InitializeComponent();
            Column = column;
            CurrentResponses = urc.Select(r => r.Response).ToList();
        }
        public UserControl Content
        {
            get { return this; }
        }
        public bool IsBusy => throw new NotImplementedException();
        public bool PageValid
        {
            //TODO: ReturnValue is not correct
            get {
                bool ColumnNameFilled = !string.IsNullOrEmpty(txtColumnName.Text);
                bool ScoreFilled = cboColumnType.Text.Equals("Score") ?
                    (!string.IsNullOrEmpty(txtScore.Text) &&
                      int.TryParse(txtScore.Text, out int checkScore)) :
                      true;
                return (ColumnNameFilled &&
                    ScoreFilled);
            }
        }
        public string ValidationMessage
        {
            get
            {
                StringBuilder message = new StringBuilder();

                if (string.IsNullOrEmpty(txtColumnName.Text)) message.AppendLine("Name should be provided!");
                if (cboColumnType.Text.Equals("Score") && 
                    string.IsNullOrEmpty(txtScore.Text) ) message.AppendLine("Score should be provided!");
                if (cboColumnType.Text.Equals("Score") &&
                    !int.TryParse(txtScore.Text, out int checkScore)) message.AppendLine("Score should be a number!");

                return message.ToString();
            }
        }
        public void Cancel()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            ColumnName = txtColumnName.Text;
            ColumnType = cboColumnType.Text;
            Score = !string.IsNullOrEmpty(txtScore.Text)? int.Parse(txtScore.Text): 0;
            CorrectResponses = lstCorrectResponses.Items.Cast<string>().ToList();
        }
        void IWizardPage.Load()
        {
            txtColumnName.Text = Column.ColumnValue;
            lstCurrentResponses.Items.AddRange(CurrentResponses.ToArray());
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
                            if (!lstCorrectResponses.Items.Contains(cr))
                                lstCorrectResponses.Items.Add(cr);
                    }
                }
            }
            PopulateCorrectResponses(lstCorrectResponses.Items.Cast<String>().ToList());
        }

        private void btnCorrectResponseRemove_Click(object sender, EventArgs e)
        {
            foreach (int index in lstCorrectResponses.SelectedIndices.Cast<int>().AsEnumerable().Reverse())
            {
                lstCorrectResponses.Items.RemoveAt(index);
            }
            PopulateCorrectResponses(lstCorrectResponses.Items.Cast<String>().ToList());
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

        private void lstCurrentResponses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCurrentToCorrectResponses.Enabled = lstCurrentResponses.SelectedIndices.Count != 0;
        }

        private void btnCurrentToCorrectResponses_Click(object sender, EventArgs e)
        {
            foreach (string cr in lstCurrentResponses.SelectedItems.Cast<string>().ToList())
            {
                if (!string.IsNullOrEmpty(cr))
                    if (!lstCorrectResponses.Items.Contains(cr))
                        lstCorrectResponses.Items.Add(cr);
            }
            PopulateCorrectResponses(lstCorrectResponses.Items.Cast<String>().ToList());
        }

        private void lstCorrectResponses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCorrectResponseRemove.Enabled = lstCorrectResponses.SelectedIndices.Count != 0;
        }
    }
}
