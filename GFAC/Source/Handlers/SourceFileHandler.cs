using GFAC.Common.Objects;
using GFAC.Objects;
using GFAC.Source.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GFAC.Source.Handlers
{
    public class SourceFileHandler
    {
        public string _file;
        public char _separator = ',';

        public SourceFileHandler()
        {}
        public SourceFileHandler(string file)
        {
            _file = file;
        }
        public SourceFile ImportFile()
        {
            SourceFile returnValue = null;

            if(!FileIsValid()) { return returnValue; }
            
            try
            {
                returnValue = new SourceFile();
                returnValue.FileName = _file;
                using(StreamReader fileContents = new StreamReader(_file))
                {
                    while(!fileContents.EndOfStream)
                    {
                        string line = fileContents.ReadLine();
                        List<string> values = line.Split(_separator).ToList();

                        Row currentRow = new Row();
                        foreach(string value in values)
                        {
                            string newValue = value.ToUpper().Replace("\"", string.Empty).Trim();
                            currentRow.Columns.Add(new Column() { ColumnValue = newValue });
                        }

                        returnValue.Rows.Add(currentRow);
                    }                   
                }
            }
            catch
            {
                returnValue = null;
            }
            return returnValue;
        }
        private bool FileIsValid()
        {
            bool returnValue = false;
            if (string.IsNullOrEmpty(_file))
            {
                return returnValue;
            }

            if (!File.Exists(_file))
            {
                return returnValue;
            }
            returnValue = true;
            return returnValue;
        }
    }
}
