using System;
using System.Collections.Generic;
using System.IO;

namespace GFAC
{
    public class Session : BaseGFAC
    {
        public string Name { get; set; }
        public SourceFile SourceFile { get; set; }
        public Profile Profile { set; get; }
        public Responders Responders { get; set; }
        public UniqueResponses UniqueResponses { get; set; }
        public string FilePath_Name
        {
            get
            {
                if (string.IsNullOrEmpty(this.FilePath) ||
                string.IsNullOrEmpty(this.FileName))
                    return string.Empty;
                else
                    return $"{this.FilePath}\\{this.FileName}.ssn";
            }
        }
        public Session()
        {
            SourceFile = new SourceFile();
            Profile = new Profile();
            Responders = new Responders();
            UniqueResponses = new UniqueResponses();
        }
        public Session ExportSession(string filePath_Name)
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
        public Session ImportSession(string filePath_Name)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            FilePath = Path.GetDirectoryName(filePath_Name);
            FileName = Path.GetFileName(filePath_Name);

            try
            {
                return ImportData<Session>(FilePath, FileName);
            }
            catch
            {
                return null;
            }
        }
    }
    public class Sessions : List<Session> { }
}

