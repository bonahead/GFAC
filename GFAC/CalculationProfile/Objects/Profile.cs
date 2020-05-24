using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using GFAC.Common.Objects;

namespace GFAC.CalculationProfile.Objects
{
    public class Profile : BaseGFAC
    {
        public string ProfileName { get; set; }
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

        public static Profile GetDefault()
        {
            Profile returnValue = null;

            returnValue = new Profile()
            {
                ProfileName = "Default",
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
                    Order = returnValue.Columns.Count
                };
                returnValue.Columns.Add(newpc);
                newpc = new ProfileColumn()
                {
                    Name = $"Fragment {index}: Titel",
                    Type = ColumnType.Score,
                    Score = 1,
                    Order = returnValue.Columns.Count
                };
                returnValue.Columns.Add(newpc);
                newpc = new ProfileColumn()
                {
                    Name = $"Fragment {index}: Evenement",
                    Type = ColumnType.Score,
                    Score = 1,
                    Order = returnValue.Columns.Count
                };
                returnValue.Columns.Add(newpc);
                index++;
            }
            return returnValue;
        }
    }
    public class Profiles : List<Profile> 
    {
        public static Profiles GetDefault()
        {
            Profiles returnValue = new Profiles();

            Profile defaultProfile = Profile.GetDefault();
            
            returnValue.Add(defaultProfile);

            return returnValue;
        }
    }
}