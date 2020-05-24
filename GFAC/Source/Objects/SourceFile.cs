using GFAC.Common.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.Source.Objects
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
        public string FilePath_Name
        {
            get
            {
                if(string.IsNullOrEmpty(this.FileLocation) ||
                        string.IsNullOrEmpty(this.FileName))
                    return string.Empty;
                else
                    return $"{this.FileLocation}\\{this.FilePath_Name}";
            }
        }
    }
}
