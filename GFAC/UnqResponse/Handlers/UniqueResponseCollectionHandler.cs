using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GFAC.CalculationProfile.Objects;
using GFAC.UnqResponse.Objects;
using GFAC.Source.Objects;
using GFAC.Common.Objects;

namespace GFAC.UnqResponse.Handlers
{
    public class UniqueResponseCollectionHandler
    {
        private SourceFile _sourceFile;
        private Profile _profile;
        private bool _defaultCorrectAnswer = true;
        public UniqueResponseCollectionHandler()
        {
            _sourceFile = new SourceFile();
        }
        
        public UniqueResponseCollectionHandler(SourceFile sourceFile,
            Profile calculationProfile)
        {
            _sourceFile = sourceFile;
            _profile = calculationProfile;
        }
        public UniqueResponseCollection CollectUniqueResponses()
        {
            UniqueResponseCollection returnValue = new UniqueResponseCollection();

            if (_sourceFile == null ||
                    _profile == null)
                return returnValue;

            bool firstRow = true;
            int colIndex = 0;
            foreach (Row row in _sourceFile.Rows)
            {
                if (firstRow)
                {
                    colIndex = 0;
                    foreach (Common.Objects.Column column in row.Columns)
                    {
                        ColumnType columnType = _profile.Columns.Count + 1 > colIndex ?
                            _profile.Columns[colIndex].Type :
                            _profile.DefaultType;

                        if (columnType.Equals(ColumnType.Score))
                        {
                            returnValue.UniqueRepsonses.Add(new UniqueResponses());
                        }
                        colIndex++;
                    }
                    firstRow = false;
                }
                else
                {
                    colIndex = 0;
                    int respIndex = 0;
                    foreach (Common.Objects.Column column in row.Columns)
                    {
                        ColumnType columnType = _profile.Columns.Count + 1 > colIndex ?
                            _profile.Columns[colIndex].Type :
                            _profile.DefaultType;

                        if (columnType.Equals(ColumnType.Score))
                        {
                            if (!string.IsNullOrEmpty(column.ColumnValue))
                            { 
                                if (!returnValue.UniqueRepsonses[respIndex].Any(ur => ur.Response.Equals(column.ColumnValue))) // new UniqueResponse() { Response = column.ColumnValue }))
                                {
                                    returnValue.UniqueRepsonses[respIndex].Add(new UniqueResponse()
                                    {
                                        Response = column.ColumnValue,
                                        Correct = _defaultCorrectAnswer
                                    });
                                }
                            }                       
                            respIndex++;
                        }
                        colIndex++;
                    }
                }
            }
            return returnValue;
        }
    }
}
