using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.Objects
{
    public class Row
    {
        public Columns Columns { get; set; }
        public Row()
        {
            Columns = new Columns();
        }
    }
    public class Rows : List<Row> { }
}
