using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GFAC
{
    public class UniqueResponse
    {
        public string Response { get; set; }
        public bool Correct { get; set; }
    }
    public class UniqueResponses : List<UniqueResponse> { }
    public class UniqueResponseCollection //: BaseGFAC
    {
        private SourceFile SourceFile { get; set; }
        private Profile Profile { get; set; }
        public List<UniqueResponses> UniqueRepsonses { get; set; }
        public UniqueResponseCollection()
        {
            UniqueRepsonses = new List<UniqueResponses>();
        }
        public static UniqueResponseCollection CollectUniqueResponses(Session session)
        {
            if (session.SourceFile == null ||
                    session.Profile == null)
                return null;

            UniqueResponseCollection returnValue = new UniqueResponseCollection();
            returnValue.SourceFile = session.SourceFile;
            returnValue.Profile = session.Profile;
            
            bool firstRow = true;
            foreach (Row row in returnValue.SourceFile.Rows)
            {
                if (firstRow)
                {
                    returnValue = GetColumnHeaders(returnValue, row);
                    firstRow = false;
                }
                else
                {
                    returnValue = GetUniqueResponse(returnValue, row);
                }
            }
            return returnValue;
        }
        public static UniqueResponseCollection CollectUniqueResponses(SourceFile sourceFile)
        {
            if (sourceFile == null)
                return null;

            UniqueResponseCollection returnValue = new UniqueResponseCollection();
            returnValue.SourceFile = sourceFile;

            bool firstRow = true;
            foreach (Row row in returnValue.SourceFile.Rows)
            {
                if (firstRow)
                {
                    returnValue = GetColumnHeaders(returnValue, row, true);
                    firstRow = false;
                }
                else
                {
                    returnValue = GetUniqueResponse(returnValue, row, true);
                }
            }
            return returnValue;
        }
        private static UniqueResponseCollection GetUniqueResponse(UniqueResponseCollection urc, Row row, bool allColumns = false)
        {
            UniqueResponseCollection returnValue = urc;
            int colIndex = 0;
            int respIndex = 0;
            foreach (Column column in row.Columns)
            {
                ColumnType columnType = allColumns ? 
                    ColumnType.None :
                    urc.Profile.Columns.Count + 1 > colIndex ?
                        urc.Profile.Columns[colIndex].Type :
                        urc.Profile.DefaultType;

                if (columnType.Equals(ColumnType.Score) || allColumns)
                {
                    if (!string.IsNullOrEmpty(column.ColumnValue))
                    {
                        if (!returnValue.UniqueRepsonses[respIndex].Any(ur => ur.Response.Equals(column.ColumnValue))) // new UniqueResponse() { Response = column.ColumnValue }))
                        {
                            returnValue.UniqueRepsonses[respIndex].Add(new UniqueResponse()
                            {
                                Response = column.ColumnValue,
                                Correct = allColumns ? false : urc.Profile.Columns[colIndex].CorrectResponses.Contains(column.ColumnValue)
                            });
                        }
                    }
                    respIndex++;
                }
                colIndex++;
            }
            return returnValue;
        }

        private static UniqueResponseCollection GetColumnHeaders(UniqueResponseCollection urc, Row row, bool allColumns = false)
        {
            UniqueResponseCollection returnValue = urc;
            returnValue.UniqueRepsonses.Clear();
            int colIndex = 0;
            foreach (Column column in row.Columns)
            {

                ColumnType columnType = allColumns ?
                    ColumnType.None :
                    urc.Profile.Columns.Count + 1 > colIndex ?
                        urc.Profile.Columns[colIndex].Type :
                        urc.Profile.DefaultType;

                if (columnType.Equals(ColumnType.Score) || allColumns)
                {
                    returnValue.UniqueRepsonses.Add(new UniqueResponses());
                }
                colIndex++;
            }
            return returnValue;
        }
    }
}