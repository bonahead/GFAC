using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GFAC
{
    public class Responder
    {
        public List<string> ReportColumns { get; set; }
        public List<string> ScoreColumns { get; set; }
        public List<int> ResponseScore { get; set; }
        public int TotalScore
        {
            get { return ResponseScore.Sum(); }
        }
        public Responder()
        {
            ReportColumns = new List<string>();
            ScoreColumns = new List<string>();
            ResponseScore = new List<int>();
        }
    }
    public class Responders : List<Responder>
    {
        private SourceFile SourceFile { get; set; }
        private Profile Profile { get; set; }
        private UniqueResponseCollection UniqueResponseCollection { get; set; }
        public Responders ProcessResponders(SourceFile sourceFile, Profile profile, UniqueResponseCollection uniqueResponseCollection)
        {
            if (sourceFile == null ||
                    profile == null ||
                    uniqueResponseCollection == null)
                return null;

            SourceFile = sourceFile;
            Profile = profile;
            UniqueResponseCollection = uniqueResponseCollection;
            Responders returnValue = new Responders();

            bool firstRow = true;
            foreach (Row row in SourceFile.Rows)
            {
                if (firstRow)
                    firstRow = false;
                else
                {
                    Responder newResponder = new Responder();
                    int colindex = 0;
                    int respIndex = 0;
                    ColumnType columnType;
                    foreach (Column column in row.Columns)
                    {
                        columnType = Profile.Columns.Count + 1 > colindex ?
                            Profile.Columns[colindex].Type :
                            Profile.DefaultType;

                        switch (columnType)
                        {
                            case ColumnType.Report:
                                newResponder.ReportColumns.Add(column.ColumnValue);
                                break;
                            case ColumnType.Score:
                                newResponder.ScoreColumns.Add(column.ColumnValue);
                                int responseScore = uniqueResponseCollection.UniqueRepsonses[respIndex].Any(ur => ur.Response.Equals(column.ColumnValue) && ur.Correct) ?
                                    Profile.Columns[colindex].Score :
                                    0;
                                newResponder.ResponseScore.Add(responseScore);
                                respIndex++;
                                break;
                            default:
                                break;
                        }
                        colindex++;
                    }
                    returnValue.Add(newResponder);
                }
            }
            return returnValue;
        }
        public DataTable DataTableResponses
        {
            get
            {
                Rows rows = new Rows();
                int colIndex = 1;
                bool firstRow = true;
                foreach (Responder responder in this)
                {
                    if (firstRow)
                    {
                        rows.Add(GetColumnHeaders(responder, true));
                        firstRow = false;
                    }
                    Columns newColumns = new Columns();
                    //ReportColumms
                    responder.ReportColumns
                       .ForEach(rc => newColumns.Add(new Column() { ColumnValue = rc }));

                    //ScoreColumns
                    responder.ScoreColumns
                       .ForEach(rc => newColumns.Add(new Column() { ColumnValue = rc }));

                    rows.Add(new Row() { Columns = newColumns });
                    colIndex++;
                }
                return BaseGFAC.RowsToDataTable(rows);
            }
        }
        public DataTable DataTableFinalScore
        {
            get
            {
                Rows rows = new Rows();
                int colIndex = 1;
                bool firstRow = true;
                foreach (Responder responder in this)
                {
                    if (firstRow)
                    {
                        rows.Add(GetColumnHeaders(responder));
                        firstRow = false;
                    }
                    Columns newColumns = new Columns();
                    //Rank
                    newColumns.Add(new Column() { ColumnValue = colIndex.ToString() });

                    //ReportColumms
                    responder.ReportColumns
                       .ForEach(rc => newColumns.Add(new Column() { ColumnValue = rc }));

                    //TotalScore
                    newColumns.Add(new Column() { ColumnValue = responder.TotalScore.ToString() });

                    rows.Add(new Row() { Columns = newColumns });
                    colIndex++;
                }

                //TODO: Sort Ranking
                Rows rankedRows = new Rows();
                firstRow = true;
                int rank = 0;
                int scorePrevious = 0;
                rankedRows.Add(rows.FirstOrDefault());
                rows.Remove(rows.FirstOrDefault());
                foreach (Row row in rows.OrderByDescending(r => int.Parse(r.Columns[r.Columns.Count - 1].ColumnValue)))
                {
                    if (int.Parse(row.Columns[row.Columns.Count - 1].ColumnValue) != scorePrevious)
                    {
                        scorePrevious = int.Parse(row.Columns[row.Columns.Count - 1].ColumnValue);
                        rank++;
                    }
                    Columns newColumns = new Columns();
                    //Rank
                    newColumns.Add(new Column() { ColumnValue = rank.ToString() });

                    row.Columns.Skip(1).ToList()
                       .ForEach(r => newColumns.Add(new Column() { ColumnValue = r.ColumnValue }));

                    rankedRows.Add(new Row() { Columns = newColumns });
                }
                return BaseGFAC.RowsToDataTable(rankedRows);
            }
        }
        //TODO: Get Columnheaders from Profile
        private Row GetColumnHeaders(Responder responder, bool responses = false)
        {
            Row returnValue = new Row();
            Columns newColumns = new Columns();

            //Rank
            if (!responses)
                newColumns.Add(new Column() { ColumnValue = @"#" });
            //ReportColumns
            responder.ReportColumns
                       .ForEach(rc => newColumns.Add(new Column() { ColumnValue = string.Empty }));

            if (responses)
            {
                //ReportColumns
                responder.ScoreColumns
                       .ForEach(rc => newColumns.Add(new Column() { ColumnValue = string.Empty }));
            }
            else
            {
                //TotalScore
                newColumns.Add(new Column() { ColumnValue = @"Score" });
            }

            returnValue = new Row() { Columns = newColumns };
            return returnValue;
        }

    }
}