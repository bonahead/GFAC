using System;
using System.IO;

namespace GFAC
{
    public class OverallSession : BaseGFAC
    {
        public string Name { get; set; }
        public Sessions Sessions { get; set; }
        public OverallSession()
        {
            Sessions = new Sessions();
        }
        public string FilePath_Name
        {
            get
            {
                if (string.IsNullOrEmpty(this.FilePath) ||
                string.IsNullOrEmpty(this.FileName))
                    return string.Empty;
                else
                    return $"{this.FilePath}\\{this.FileName}.osn";
            }
        }
        public OverallSession ExportOverallSession(string filePath_Name)
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
        public OverallSession ImportOverallSession(string filePath_Name)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            FilePath = Path.GetDirectoryName(filePath_Name);
            FileName = Path.GetFileName(filePath_Name);

            try
            {
                return ImportData<OverallSession>(FilePath, FileName);
            }
            catch
            {
                return null;
            }
        }
    }
}
