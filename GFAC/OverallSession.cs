using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;

namespace GFAC
{
    public class OverallSession : BaseGFAC
    {
        public string Name { get; set; }
        public Sessions Sessions { get; set; }
        public Responders Responders { get; set; }
        public OverallSession()
        {
            Sessions = new Sessions();
        }
        public static OverallSession ExportOverallSession(string filePath_Name, OverallSession overallSession)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            string FilePath = Path.GetDirectoryName(filePath_Name);
            string FileName = Path.GetFileNameWithoutExtension(filePath_Name);

            if (string.IsNullOrEmpty(overallSession.Name))
                overallSession.Name = FileName;

            overallSession = ExportData(overallSession, FilePath, FileName);
            
            return overallSession;
        }
        public static OverallSession ImportOverallSession(string filePath_Name)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            string FilePath = Path.GetDirectoryName(filePath_Name);
            string FileName = Path.GetFileNameWithoutExtension(filePath_Name);

            try
            {
                return ImportData<OverallSession>(FilePath, FileName);
            }
            catch
            {
                return null;
            }
        }
        public DataTable DataTableFinalScore()
        {
            return RowsToDataTable(TotalScore());
        }

        public Rows TotalScore()
        {
            //TODO:Refactor
            Rows returnValue = new Rows();

            Row headerRow = new Row();
            int headerCount = this.Sessions.Count + 3;
            //Generate HeaderRow
            for (int i = 0; i < headerCount; i++ )
            {
                Column newColumn = new Column();
                if (i == 0) newColumn.ColumnValue = "Rank";
                else if (i == 1) newColumn.ColumnValue = "Responder";
                else if (i == headerCount- 1) newColumn.ColumnValue = "Total";
                else newColumn.ColumnValue = this.Sessions[i-2].Name;

                headerRow.Columns.Add(newColumn);
            }
            
            //Collect Unique Responders
            List<string> uniqueResponders = new List<string>();
            foreach (Session sess in this.Sessions)
            {
                foreach(Responder resp in sess.Responders)
                {
                    if (!uniqueResponders.Contains(string.Join(",",resp.ReportColumns.ToArray())))
                    {
                        uniqueResponders.Add(string.Join(",", resp.ReportColumns.ToArray()));
                    }   
                    
                }
            }

            //Generate ResponderRows
            Rows responderRows = new Rows();
            foreach (string uniqueResponder in uniqueResponders)
            {
                Row newRow = new Row();
                for (int i = 0; i < headerRow.Columns.Count; i++)
                {
                    Column newColumn = new Column();
                    if (i == 1) newColumn.ColumnValue = uniqueResponder;
                    newRow.Columns.Add(newColumn);
                }
                responderRows.Add(newRow);
            }

            //Add Score to ResponderRows
            int colindex = 2;
            foreach (Session sess in this.Sessions)
            {
                foreach (Responder resp in sess.Responders)
                {
                    int rowIndex = responderRows.Select((value, index) => new { value, index })
                        .Where(r => r.value.Columns[1].ColumnValue.Equals(string.Join(",", resp.ReportColumns.ToArray())))
                        .Select(r => r.index).FirstOrDefault(); ;

                    responderRows[rowIndex].Columns[colindex].ColumnValue = resp.TotalScore.ToString();
                }
                colindex++;
            }

            //Add Total Score To ResponderRows
            foreach(Row resp in responderRows)
            {
                int TotalScore = 0;
                foreach(Column score in resp.Columns.Skip(2))
                {
                    if (!string.IsNullOrEmpty(score.ColumnValue))
                        TotalScore = TotalScore + int.Parse(score.ColumnValue);
                }
                resp.Columns[resp.Columns.Count - 1].ColumnValue = TotalScore.ToString();
            }

            //Make RankedRows
            Rows rankedRows = new Rows();
            int rank = 0;
            int scorePrevious = 0;
            foreach(Row row in responderRows.OrderByDescending(r => int.Parse(r.Columns[r.Columns.Count -1].ColumnValue)))
            {
                if (int.Parse(row.Columns[row.Columns.Count - 1].ColumnValue) != scorePrevious)
                {
                    scorePrevious = int.Parse(row.Columns[row.Columns.Count - 1].ColumnValue);
                    rank++;
                }
                row.Columns[0].ColumnValue = rank.ToString();
                rankedRows.Add(row);
            }
            returnValue.Add(headerRow);
            returnValue.AddRange(rankedRows);
            return returnValue;
        }
    }
}
