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
    public partial class CorrectResponsesForm : Form
    {
        public string ReturnValue { get; set; }
        public CorrectResponsesForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.ReturnValue = txtCorrectResponses.Text;
            this.Close();
        }
    }
}
