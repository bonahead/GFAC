using GFAC.CalculationProfile.Objects;
using GFAC.Common.Objects;
using GFAC.Objects;
using GFAC.Source.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.CalulationSession.Objects
{
    public class Session : BaseGFAC
    {
        public string SessionName { get; set; }
        public SourceFile SourceFile { get; set; }
        public Profile CalculationProfile { set; get; }
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
    }
}
