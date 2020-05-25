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
        public UniqueResponseCollection CollectUniqueResponses(Session session)
        {
            if (session.SourceFile == null ||
                    session.Profile == null)
                return null;

            SourceFile = session.SourceFile;
            Profile = session.Profile;
            UniqueResponseCollection returnValue = new UniqueResponseCollection();
            bool firstRow = true;
            foreach (Row row in SourceFile.Rows)
            {
                if (firstRow)
                {
                    returnValue = GetColumnHeaders(row);
                    firstRow = false;
                }
                else
                {
                    returnValue = GetUniqueResponse(returnValue, row);
                }
            }
            return returnValue;
        }

        private UniqueResponseCollection GetUniqueResponse(UniqueResponseCollection urc, Row row)
        {
            UniqueResponseCollection returnValue = urc;
            int colIndex = 0;
            int respIndex = 0;
            foreach (Column column in row.Columns)
            {
                ColumnType columnType = Profile.Columns.Count + 1 > colIndex ?
                    Profile.Columns[colIndex].Type :
                    Profile.DefaultType;

                if (columnType.Equals(ColumnType.Score))
                {
                    if (!string.IsNullOrEmpty(column.ColumnValue))
                    {
                        if (!returnValue.UniqueRepsonses[respIndex].Any(ur => ur.Response.Equals(column.ColumnValue))) // new UniqueResponse() { Response = column.ColumnValue }))
                        {
                            returnValue.UniqueRepsonses[respIndex].Add(new UniqueResponse()
                            {
                                Response = column.ColumnValue,
                                Correct = true
                            });
                        }
                    }
                    respIndex++;
                }
                colIndex++;
            }
            return returnValue;
        }

        private UniqueResponseCollection GetColumnHeaders(Row row)
        {
            UniqueResponseCollection returnValue = new UniqueResponseCollection();
            int colIndex = 0;
            foreach (Column column in row.Columns)
            {
                ColumnType columnType = Profile.Columns.Count + 1 > colIndex ?
                    Profile.Columns[colIndex].Type :
                    Profile.DefaultType;

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