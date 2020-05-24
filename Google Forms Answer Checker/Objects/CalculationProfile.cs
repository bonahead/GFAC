using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.Objects
{
    public class CalculationProfile
    {
        public string ProfileName { get; set; }
        public ProfileColumns ProfileColumns { get; set; }
        public ProfileColumnType DefaultProfileColumnType { get; set; }

        public CalculationProfile()
        {
            ProfileColumns = new ProfileColumns();
            DefaultProfileColumnType = ProfileColumnType.Score;
        }
    }
    public class CalculationProfiles : List<CalculationProfile> 
    {
        public static CalculationProfiles GetDefault()
        {
            CalculationProfiles returnValue = new CalculationProfiles();

            CalculationProfile defaultProfile = new CalculationProfile()
            {
                ProfileName = "Default",
                DefaultProfileColumnType = ProfileColumnType.Score
            };

            int index = 1;
            ProfileColumn newpc = new ProfileColumn()
            {
                ColumnName = "TimeStamp",
                ProfileColumnType = ProfileColumnType.None,
                ScoreCorrect = 0,
                ColumnOrder = defaultProfile.ProfileColumns.Count
            };
            defaultProfile.ProfileColumns.Add(newpc);
            newpc = new ProfileColumn()
            {
                ColumnName = "Naam",
                ProfileColumnType = ProfileColumnType.Report,
                ScoreCorrect = 0,
                ColumnOrder = defaultProfile.ProfileColumns.Count
            };
            defaultProfile.ProfileColumns.Add(newpc);

            while (index < 11)
            {
                newpc = new ProfileColumn()
                {
                    ColumnName = $"Fragment {index}: Artiest",
                    ProfileColumnType = ProfileColumnType.None,
                    ScoreCorrect = 1,
                    ColumnOrder = defaultProfile.ProfileColumns.Count
                };
                defaultProfile.ProfileColumns.Add(newpc);
                newpc = new ProfileColumn()
                {
                    ColumnName = $"Fragment {index}: Titel",
                    ProfileColumnType = ProfileColumnType.Report,
                    ScoreCorrect = 1,
                    ColumnOrder = defaultProfile.ProfileColumns.Count
                };
                defaultProfile.ProfileColumns.Add(newpc);
                newpc = new ProfileColumn()
                {
                    ColumnName = $"Fragment {index}: Evenement",
                    ProfileColumnType = ProfileColumnType.Report,
                    ScoreCorrect = 1,
                    ColumnOrder = defaultProfile.ProfileColumns.Count
                };
                defaultProfile.ProfileColumns.Add(newpc);
                index++;
            }
            returnValue.Add(defaultProfile);

            return returnValue;
        }
    }
}