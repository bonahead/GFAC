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
        public static Profile ExportProfile(string filePath_Name, Profile profile)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            string FilePath = Path.GetDirectoryName(filePath_Name);
            string FileName = Path.GetFileName(filePath_Name);

            profile = ExportData(profile, FilePath, FileName);

            return profile;
        }
        public static Profile ImportProfile(string filePath_Name)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            string FilePath = Path.GetDirectoryName(filePath_Name);
            string FileName = Path.GetFileName(filePath_Name);

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