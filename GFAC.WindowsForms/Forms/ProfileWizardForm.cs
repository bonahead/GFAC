using MBG.SimpleWizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFAC.WindowsForms.Forms
{
    public partial class ProfileWizardForm : Form
    {
        private SourceFile SourceFile { get; set; }
        private WizardHost Wizard { get; set; }
        public Profile ReturnValue { get; set; }
        public ProfileWizardForm(SourceFile sourceFile)
        {
            InitializeComponent();
            SourceFile = sourceFile;
            CreateWizard();
        }
        public DialogResult ShowWizard()
        {
            Wizard.LoadWizard();
            DialogResult returnValue = Wizard.ShowDialog();

            if (returnValue == DialogResult.OK)
                ReturnValue = GenerateProfile();
            return returnValue;
        }
        private Profile GenerateProfile()
        {
            Profile returnValue = new Profile();

            int pageIndex = 0;
            foreach(IWizardPage page in Wizard.WizardPages.Values)
            {
                if (pageIndex == 0)
                {
                    ProfileWizardOverallForm overallForm = (ProfileWizardOverallForm)page;
                    returnValue.Name = overallForm.Name;
                    returnValue.DefaultType = GetColumnType(overallForm.DefaultColumnType);
                }
                else
                {
                    ProfileWizardColumnForm columnForm = (ProfileWizardColumnForm)page;
                    returnValue.Columns.Add(new ProfileColumn()
                    {
                        Name = columnForm.Name,
                        Type = GetColumnType(columnForm.ColumnType),
                        Score = columnForm.Score,
                        CorrectResponses = columnForm.CorrectResponses
                    });
                }
                pageIndex++;
            }

            return returnValue;
        }
        private ColumnType GetColumnType(string selectedItem="")
        {
            
            switch (selectedItem)
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
        private void CreateWizard()
        {
            Wizard = new WizardHost();
            Wizard.WizardCompleted += new WizardHost.WizardCompletedEventHandler(host_WizardCompleted);
            int pageIndex = 2;
            //Overall Profile Properties

            Wizard.WizardPages.Add(1, new ProfileWizardOverallForm());

            foreach(Column column in SourceFile.Rows[0].Columns)
            {
                Wizard.WizardPages.Add(pageIndex, new ProfileWizardColumnForm());
                pageIndex++;
            }
        }
        void host_WizardCompleted()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
          
        }
    }
}
