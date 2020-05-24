using System.Collections.Generic;
using System.Data;

namespace GFAC
{
    public class ProfileColumn : BaseGFAC
    {
        public string Name { get; set; }
        public ColumnType Type { get; set; }
        public int Order { get; set; }
        public int Score { get; set; }
        public List<string> CorrectResponses { get; set; }
        public ProfileColumn()
        {
            CorrectResponses = new List<string>();
        }
    }
    public class ProfileColumns : List<ProfileColumn>
    {
        public DataTable DataTable
        {
            get
            {
                return BaseGFAC.RowsToDataTable(this);
            }
        }
    }
    public enum ColumnType
    {
        Report,
        Score,
        None
    }

}
