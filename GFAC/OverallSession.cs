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
        public static OverallSession ExportOverallSession(string filePath_Name, OverallSession overallSession)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            string FilePath = Path.GetDirectoryName(filePath_Name);
            string FileName = Path.GetFileName(filePath_Name);

            overallSession = ExportData(overallSession, FilePath, FileName);
            
            return overallSession;
        }
        public static OverallSession ImportOverallSession(string filePath_Name)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            string FilePath = Path.GetDirectoryName(filePath_Name);
            string FileName = Path.GetFileName(filePath_Name);

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
