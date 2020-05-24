using GFAC.CalculationProfile.Objects;
using GFAC.Common.Objects;
using GFAC.Objects;
using GFAC.Response.Objects;
using GFAC.Source.Objects;
using GFAC.UnqResponse.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.Response.Handlers
{
    public class ResponderHandler
    {
        private SourceFile _sourceFile;
        private Profile _calculationProfile;
        private UniqueResponseCollection _uniqueResponseCollection;

        public ResponderHandler(SourceFile sourceFile,
            Profile calculationProfile, 
            UniqueResponseCollection uniqueResponseCollection)
        {
            _sourceFile = sourceFile;
            _calculationProfile = calculationProfile;
            _uniqueResponseCollection = uniqueResponseCollection;
        }

        public Responders ExecuteProfileOnSourceFile()
        {
            Responders returnValue = new Responders();

            if (_sourceFile == null ||
                _calculationProfile == null)
                return returnValue;

            bool firstRow = true;
            foreach(Row row in _sourceFile.Rows)
            {
                if (firstRow)
                    firstRow = false;
                else 
                {
                    Responder newResponder = new Responder();
                    int colindex = 0;
                    int respIndex = 0;
                    ColumnType columnType;
                    foreach (Common.Objects.Column column in row.Columns)
                    {
                        columnType = _calculationProfile.Columns.Count + 1 > colindex ?
                            _calculationProfile.Columns[colindex].Type:
                            _calculationProfile.DefaultType;
                        
                        switch (columnType)
                        {
                            case ColumnType.Report:
                                newResponder.ReportColumns.Add(column.ColumnValue);
                                break;
                            case ColumnType.Score:
                                newResponder.ScoreColumns.Add(column.ColumnValue);
                                int responseScore = _uniqueResponseCollection.UniqueRepsonses[respIndex].Any(ur => ur.Response.Equals(column.ColumnValue) && ur.Correct) ?
                                    _calculationProfile.Columns[colindex].Score:
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
    }
}
