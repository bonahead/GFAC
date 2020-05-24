using GFAC.CalculationProfile.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.Common.Objects
{
    public class BaseGFAC
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime? LastSaved { get; set; }
        internal static DataTable RowsToDataTable(ProfileColumns columns)
        {
            DataTable returnValue = new DataTable();

            Rows newRows = new Rows();
            foreach (ProfileColumn pc in columns)
            {
                Row newRow = new Row();
                newRow.Columns.Add(new Column()
                {
                    ColumnValue = pc.Name
                });
                newRow.Columns.Add(new Column()
                {
                    ColumnValue = pc.Type.ToString()
                });
                newRow.Columns.Add(new Column()
                {
                    ColumnValue = pc.Score.ToString()
                });
                newRows.Add(newRow);
            }
            try
            {
                returnValue = RowsToDataTable(newRows);
            }
            catch
            {
                returnValue = new DataTable();
            }
            return returnValue;
        }

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
