using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GFAC.Common.Enumerations;

namespace GFAC.Common
{
    public class Functions
    {
        internal static string SelectFile(FileType fileType, bool save = false)
        {
            string returnValue = string.Empty;

            try
            {
                FileDialog fileDialog;
                if (save)
                    fileDialog = new SaveFileDialog();
                else
                    fileDialog = new OpenFileDialog();

                fileDialog.InitialDirectory = "";
                fileDialog.Filter = fileType.Value;
                fileDialog.RestoreDirectory = true;

                if(fileDialog.ShowDialog() == DialogResult.OK)
                {
                    returnValue = fileDialog.FileName;
                }
                fileDialog = null;
            }
            catch { 
            //TODO
            }
            return returnValue;
        }
    }
}
