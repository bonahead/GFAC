using GFAC.Common;
using System;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC.WindowsForms.Forms
{
    public partial class GFACMain : Form
    {
        private int childFormNumber = 0;

        public GFACMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            New_GFACSession();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            Open_GFACSession();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GFACForm activeChild = (GFACForm)this.ActiveMdiChild;

            if (activeChild != null)
                activeChild.SaveAs();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void New_GFACSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_GFACSession();
        }

        private void New_GFACSession()
        {
            OverallSessionForm overallSessionForm = new OverallSessionForm();
            overallSessionForm.MdiParent = this;
            overallSessionForm.Text = "GFAC Session";
            childFormNumber++;
            overallSessionForm.Show();
        }
        private void responseSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionForm sessionForm = new SessionForm();
            sessionForm.MdiParent = this;
            sessionForm.Text = "Response Session";
            childFormNumber++;
            sessionForm.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm();
            profileForm.MdiParent = this;
            profileForm.Text = "Profile";
            childFormNumber++;
            profileForm.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GFACForm activeChild = (GFACForm)this.ActiveMdiChild;

            if (activeChild != null)
                activeChild.Save();
        }

        private void Open_GFACSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_GFACSession();
        }
        private void Open_GFACSession()
        {
            string filepath = Functions.SelectFile(FileType.OverallSession, false);
            if (string.IsNullOrEmpty(filepath))
                return;

            OverallSessionForm overallSessionForm = new OverallSessionForm(filepath);
            overallSessionForm.MdiParent = this;
            overallSessionForm.Text = "GFAC Session";
            childFormNumber++;
            overallSessionForm.Show();
        }

        private void Open_ResponseSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = Functions.SelectFile(FileType.Session, false);
            if (string.IsNullOrEmpty(filepath))
                return;

            SessionForm sessionForm = new SessionForm(filepath);
            sessionForm.MdiParent = this;
            sessionForm.Text = "Response Session";
            childFormNumber++;
            sessionForm.Show();
        }

        private void Open_ProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = Functions.SelectFile(FileType.Profile, false);
            if (string.IsNullOrEmpty(filepath))
                return;

            ProfileForm profileForm = new ProfileForm(filepath);
            profileForm.MdiParent = this;
            profileForm.Text = "Profile";
            childFormNumber++;
            profileForm.Show();
        }
    }
}
