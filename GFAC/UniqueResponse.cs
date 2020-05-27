using System.Collections.Generic;
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

        private static UniqueResponseCollection GetUniqueResponse(UniqueResponseCollection urc, Row row)
        {
            UniqueResponseCollection returnValue = urc;
            int colIndex = 0;
            int respIndex = 0;
            foreach (Column column in row.Columns)
            {
                ColumnType columnType = urc.Profile.Columns.Count + 1 > colIndex ?
                    urc.Profile.Columns[colIndex].Type :
                    urc.Profile.DefaultType;

                if (columnType.Equals(ColumnType.Score))
                {
                    if (!string.IsNullOrEmpty(column.ColumnValue))
                    {
                        if (!returnValue.UniqueRepsonses[respIndex].Any(ur => ur.Response.Equals(column.ColumnValue))) // new UniqueResponse() { Response = column.ColumnValue }))
                        {
                            returnValue.UniqueRepsonses[respIndex].Add(new UniqueResponse()
                            {
                                Response = column.ColumnValue,
                                Correct = urc.Profile.Columns[colIndex].CorrectResponses.Contains(column.ColumnValue)
                            });
                        }
                    }
                    respIndex++;
                }
                colIndex++;
            }
            return returnValue;
        }

        private static UniqueResponseCollection GetColumnHeaders(UniqueResponseCollection urc, Row row)
        {
            UniqueResponseCollection returnValue = urc;
            returnValue.UniqueRepsonses.Clear();
            int colIndex = 0;
            foreach (Column column in row.Columns)
            {
                ColumnType columnType = urc.Profile.Columns.Count + 1 > colIndex ?
                    urc.Profile.Columns[colIndex].Type :
                    urc.Profile.DefaultType;

                if (columnType.Equals(ColumnType.Score))
                {
                    returnValue.UniqueRepsonses.Add(new UniqueResponses());
                }
                colIndex++;
            }
            return returnValue;
        }
    }
}