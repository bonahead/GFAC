using GFAC.CalulationSession.Objects;
using GFAC.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.OverallCalculationSession.Objects
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
                    return $"{this.FilePath}\\{this.FileName}.prf";
            }
        }
    }
}
