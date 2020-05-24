using System;
using System.IO;

namespace GFAC
{
    public class Profile : BaseGFAC
    {
        public string Name { get; set; }
        public ProfileColumns Columns { get; set; }
        public ColumnType DefaultType { get; set; }
        public Profile()
        {
            Columns = new ProfileColumns();
            DefaultType = ColumnType.Score;
        }
        public string FilePath_Name
        {
            get
            {
                if (string.IsNullOrEmpty(this.FilePath) ||
                string.IsNullOrEmpty(this.FileName))
                    return string.Empty;
                else
                    return $"{this.FilePath}\\{this.FileName}.prf";
            }
        }
        public Profile ExportProfile(string filePath_Name)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            FilePath = Path.GetDirectoryName(filePath_Name);
            FileName = Path.GetFileName(filePath_Name);

            bool SaveSuccesful = ExportData(this, FilePath, FileName);

            if (SaveSuccesful)
            {
                this.LastSaved = DateTime.Now;
                this.FilePath = FilePath;
                this.FileName = FileName;
            }

            return this;
        }
        public Profile ImportProfile(string filePath_Name)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            FilePath = Path.GetDirectoryName(filePath_Name);
            FileName = Path.GetFileName(filePath_Name);

            try
            {
                return ImportData<Profile>(FilePath, FileName);
            }
            catch
            {
                return null;
            }
        }
    }
}