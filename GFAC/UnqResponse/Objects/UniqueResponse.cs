using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.UnqResponse.Objects
{
    public class UniqueResponse
    {
        public string Response { get; set; }
        public bool Correct { get; set; }
    }
    public class UniqueResponses : List<UniqueResponse> { }
}
