using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.Objects
{
    public class ProfileColumn
    {
        public string ColumnName { get; set; }
        public ProfileColumnType ProfileColumnType { get; set; }
        public int ColumnOrder { get; set; }
        public int ScoreCorrect { get; set; }
    }

    public class ProfileColumns : List<ProfileColumn> { }
    public enum ProfileColumnType
    {                 
        Report,//Blue = Report
        Score,//Green = Score
        None //Grey = None
    }

}
