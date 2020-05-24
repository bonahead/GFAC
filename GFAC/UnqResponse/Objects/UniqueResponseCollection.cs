using GFAC.Common.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.UnqResponse.Objects
{
    public class UniqueResponseCollection : BaseGFAC
    {
        internal List<UniqueResponses> UniqueRepsonses { get; set; }
        public UniqueResponseCollection()
        {
            UniqueRepsonses = new List<UniqueResponses>();
        }
        //public DataTable DataTable
        //{
        //    get
        //    {
        //        return RowsToDataTable(this.Rows);
        //    }
        //}
    }
}
