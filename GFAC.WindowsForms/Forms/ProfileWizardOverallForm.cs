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
using System.Runtime.Remoting.Messaging;

namespace GFAC.WindowsForms.Forms
{
    public partial class ProfileWizardOverallForm : UserControl, IWizardPage
    {
        public string ProfileName { get; set; }
        public string DefaultColumnType { get; set; }
        public ProfileWizardOverallForm()
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
            get { 
                return (!string.IsNullOrEmpty(txtName.Text) &&
                    cboDefaultColumnType.SelectedIndex > -1);
            }
        }
        public string ValidationMessage
        {
            get
            {
                StringBuilder message = new StringBuilder();

                if (string.IsNullOrEmpty(txtName.Text)) message.AppendLine("Name should be provided!");
                if (cboDefaultColumnType.SelectedIndex == -1) message.AppendLine("Default Type should be provided!");

                return message.ToString();
            }
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            ProfileName = txtName.Text;
            DefaultColumnType = cboDefaultColumnType.Text;
        }
        void IWizardPage.Load()
        {
            
        }
    }
}
