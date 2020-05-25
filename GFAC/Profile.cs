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
            string FileName = Path.GetFileNameWithoutExtension(filePath_Name);

            profile = ExportData(profile, FilePath, FileName);

            return profile;
        }
        public static Profile ImportProfile(string filePath_Name)
        {
            if (string.IsNullOrEmpty(filePath_Name))
                return null;

            string FilePath = Path.GetDirectoryName(filePath_Name);
            string FileName = Path.GetFileNameWithoutExtension(filePath_Name);

            try
            {
                return ImportData<Profile>(FilePath, FileName);
            }
            catch
            {
                return null;
            }
        }
        public static Profile GetDefault()
        {
            Profile returnValue = null;

            returnValue = new Profile()
            {
                Name = "Default",
                DefaultType = ColumnType.Score
            };

            int index = 1;
            ProfileColumn newpc = new ProfileColumn()
            {
                Name = "TimeStamp",
                Type = ColumnType.None,
                Score = 0,
                Order = returnValue.Columns.Count
            };
            returnValue.Columns.Add(newpc);
            newpc = new ProfileColumn()
            {
                Name = "Naam",
                Type = ColumnType.Report,
                Score = 0,
                Order = returnValue.Columns.Count
            };
            returnValue.Columns.Add(newpc);

            while (index < 11)
            {
                newpc = new ProfileColumn()
                {
                    Name = $"Fragment {index}: Artiest",
                    Type = ColumnType.Score,
                    Score = 1,
                    Order = returnValue.Columns.Count,
                    CorrectResponses = new System.Collections.Generic.List<string>() { "Yello".ToUpper() }
                };
                returnValue.Columns.Add(newpc);
                newpc = new ProfileColumn()
                {
                    Name = $"Fragment {index}: Titel",
                    Type = ColumnType.Score,
                    Score = 1,
                    Order = returnValue.Columns.Count,
                    CorrectResponses = new System.Collections.Generic.List<string>() { "The Race".ToUpper() }

                };
                returnValue.Columns.Add(newpc);
                newpc = new ProfileColumn()
                {
                    Name = $"Fragment {index}: Evenement",
                    Type = ColumnType.Score,
                    Score = 1,
                    Order = returnValue.Columns.Count,
                    CorrectResponses = new System.Collections.Generic.List<string>() { "Formule 1 Grand Prix Zandvoort".ToUpper() }
                };
                returnValue.Columns.Add(newpc);
                index++;
            }
            return returnValue;


        }
    }
}