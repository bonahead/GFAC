using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.Objects
{
    public class BaseGFAC
    {
        internal static DataTable RowsToDataTable(Rows rows)
        {
            DataTable returnValue = new DataTable();
            bool firstRow = true;
            foreach (Row row in rows)
            {
                if (firstRow)
                {
                    foreach (Column column in row.Columns)
                    {
                        returnValue.Columns.Add(new DataColumn()
                        {
                            ColumnName = column.ColumnValue,
                            DataType = typeof(string)
                        });
                    }
                    firstRow = false;
                }
                else
                {
                    object[] newRow = row.Columns.Select(r => r.ColumnValue).ToArray();
                    returnValue.Rows.Add(newRow);
                }
            }
            return returnValue;
        }
    }
}
