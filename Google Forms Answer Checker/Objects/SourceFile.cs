using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFAC.Objects
{
    public class SourceFile : BaseGFAC
    {
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public Rows Rows { get; set; }
        public SourceFile()
        {
            Rows = new Rows();
        }
        public DataTable DataTable
        {
            get
            {
                return RowsToDataTable(this.Rows);
            }
        }
    }
}
