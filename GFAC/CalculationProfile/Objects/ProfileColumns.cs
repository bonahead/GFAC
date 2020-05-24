using GFAC.Common.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.CalculationProfile.Objects
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
    public class ProfileColumns : List<ProfileColumn>  {
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
