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
        public Session()
        {
            SourceFile = new SourceFile();
            Profile = new Profile();
            Responders = new Responders();
            UniqueResponses = new UniqueResponses();
        }
        public static Session ExportSession(string filePath_Name, Session session)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            string FilePath = Path.GetDirectoryName(filePath_Name);
            string FileName = Path.GetFileName(filePath_Name);

            session =  ExportData(session, FilePath, FileName);
            
            return session;
        }
        public static Session ImportSession(string filePath_Name)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            string FilePath = Path.GetDirectoryName(filePath_Name);
            string FileName = Path.GetFileName(filePath_Name);

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

