using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace GFAC
{
    public class BaseGFAC
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FilePath_Name
        {
            get
            {
                string fileExtension = GetExtension(this.GetType());
                if (string.IsNullOrEmpty(this.FilePath) ||
                string.IsNullOrEmpty(this.FileName))
                    return string.Empty;
                else

                    return $"{this.FilePath}\\{this.FileName}.osn";
            }
        }
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
        internal static T ExportData<T>(T exportData, string filePath, string fileName) where T : BaseGFAC
        {
            T returnValue = null;
            string fileExtension = GetExtension(typeof(T));
            string newFileName = $"{filePath}\\{fileName}.{fileExtension}";
            string tempFileName = GetTempFileName(filePath, fileName, fileExtension);

            if (string.IsNullOrEmpty(tempFileName))
                return returnValue;

            exportData.LastSaved = DateTime.Now;
            exportData.FilePath = filePath;
            exportData.FileName = fileName;

            StreamWriter file = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                file = new StreamWriter(tempFileName);
                serializer.Serialize(file, exportData);
                file.Close();
                if (newFileName != tempFileName)
                    RenameExportedFile(tempFileName, newFileName, filePath, fileName, fileExtension);
                returnValue = exportData;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
            return returnValue;
        }
        internal static T ImportData<T>(string filePath, string fileName) where T : BaseGFAC
        {
            T returnValue = null;
            StreamReader file = null;
            string filePath_name = $"{filePath}\\{fileName}.{GetExtension(typeof(T))}";
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                file = new StreamReader(filePath_name);
                returnValue = (T)xmlSerializer.Deserialize(file);
            }
            catch
            {
                returnValue = null;
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
            return returnValue;
        }
        private static string GetExtension(Type t)
        {
            switch (t.Name)
            {
                case "Session":
                    return "ssn";
                case "Profile":
                    return "prf";
                case "OverallSession":
                    return "osn";
                case "SourceFile":
                    return "csv";
                default:
                    return string.Empty;
            }
        }
        private static void RenameExportedFile(string tempFileName, string newFileName, string filePath, string fileName, string fileExtension)
        {
            if (string.IsNullOrEmpty(tempFileName) ||
                string.IsNullOrEmpty(newFileName) ||
                string.IsNullOrEmpty(filePath) ||
                string.IsNullOrEmpty(fileName))
                throw new Exception("No File To Be Saved.");

            string newTempFileName = GetTempFileName(filePath, fileName, fileExtension);
            if (string.IsNullOrEmpty(newTempFileName))
                throw new Exception("Temp Filename could not be determined");

            try
            {
                File.Copy(newFileName, newTempFileName);
                File.Delete(newFileName);
                File.Copy(tempFileName, newFileName);
                File.Delete(tempFileName);
                File.Delete(newTempFileName);
            }
            catch
            {
                if (!File.Exists(newFileName))
                {
                    if (File.Exists(newTempFileName))
                        File.Copy(newTempFileName, newFileName);
                }
                if (!File.Exists(tempFileName))
                    File.Delete(tempFileName);
                if (!File.Exists(newTempFileName))
                    File.Delete(newTempFileName);

                throw new Exception("Unable to save File");
            }
        }
        private static string GetTempFileName(string filePath, string fileName, string fileExtension)
        {
            string returnValue = string.Empty;
            int tryIndex = 0;
            if (string.IsNullOrEmpty(filePath) ||
                string.IsNullOrEmpty(fileName))
                return returnValue;

            string filePath_Name = $"{filePath}\\{fileName}.{fileExtension}";
            if (!File.Exists(filePath_Name))
                returnValue = filePath_Name;
            else
            {
                returnValue = $"{filePath}\\{fileName}{tryIndex.ToString()}.{fileExtension}";
                while (File.Exists(returnValue))
                {
                    tryIndex++;
                    returnValue = $"{filePath}\\{fileName}{tryIndex.ToString()}.{fileExtension}";
                }
            }
            return returnValue;
        }
    }
}
