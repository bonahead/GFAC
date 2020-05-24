using System.Collections.Generic;

namespace GFAC
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
