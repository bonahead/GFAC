using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace GFAC
{
    public class SourceFile : BaseGFAC
    {
        public char _separator = ',';
        public SourceFile()
        {
            Rows = new Rows();
        }
        public SourceFile(string filePath_Name, bool toUpper = true, bool trimValue = true)
        {
            if (!string.IsNullOrEmpty(filePath_Name))
            {
                FileName = filePath_Name;
                //FilePath = Path.GetDirectoryName(filePath_Name);
                //FileName = Path.GetFileNameWithoutExtension(filePath_Name);
            }

            ToUpper = toUpper;
            TrimValue = trimValue;
        }
        private bool ToUpper { get; set; }
        private bool TrimValue { get; set; }
        public Rows Rows { get; set; }
        public DataTable DataTable
        {
            get
            {
                return RowsToDataTable(this.Rows);
            }
        }
        public SourceFile Import()
        {
            SourceFile returnValue = null;
            if (!FileIsValid()) { return returnValue; }

            try
            {
                returnValue = new SourceFile();
                returnValue.FileName = FileName;
                using (StreamReader fileContents = new StreamReader(FileName))
                {
                    while (!fileContents.EndOfStream)
                    {
                        string line = fileContents.ReadLine();
                        List<string> values = line.Split(_separator).ToList();

                        Row currentRow = new Row();
                        foreach (string value in values)
                        {
                            string newValue = ConvertValue(value);
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
            if (string.IsNullOrEmpty(FileName))
                return returnValue;

            returnValue = File.Exists(FileName);
            return returnValue;
        }
        private string ConvertValue(string value)
        {
            string returnValue = value.Replace("\"", string.Empty);

            if (ToUpper) returnValue = returnValue.ToUpper();
            if (TrimValue) returnValue = returnValue.Trim();

            return returnValue;
        }
    }
}
