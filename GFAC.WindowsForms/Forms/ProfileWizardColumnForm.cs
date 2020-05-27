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
        public string Name { get; set; }
        public string ColumnType { get; set; }
        public int Score { get; set; }
        public List<string> CorrectResponses { get; set; }
        public ProfileWizardColumnForm()
        {
            InitializeComponent();
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
                return (!string.IsNullOrEmpty(txtColumnName.Text) &&
                    cboColumnType.SelectedIndex > -1 &&
                    cboColumnType.Text.Equals("Score") ?
                      (!string.IsNullOrEmpty(txtScore.Text) &&
                      int.TryParse(txtScore.Text, out int checkScore)) :
                      true);
            }
        }
        public string ValidationMessage
        {
            get
            {
                StringBuilder message = new StringBuilder();

                if (string.IsNullOrEmpty(txtColumnName.Text)) message.AppendLine("Name should be provided!");
                if (cboColumnType.SelectedIndex == -1) message.AppendLine("Type should be provided!");
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
            Name = txtColumnName.Text;
            ColumnType = cboColumnType.Text;
            Score = !string.IsNullOrEmpty(txtScore.Text)? int.Parse(txtScore.Text): 0;
            CorrectResponses = lstCorrectResponses.Items.Cast<string>().ToList();
        }

        void IWizardPage.Load()
        {
        }
    }
}
