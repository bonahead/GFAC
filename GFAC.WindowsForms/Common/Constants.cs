using System.CodeDom;

namespace GFAC.Common
{
    public class Constants
    {
        #region Common Constants
        public const string DefaultProfile = "Default";
        #endregion
    }
    public class Messages
    {
        //OverallSession
        public const string OverallSession_UnableToLoad = "Unable to load GFAC Session";

        //Session
        public const string Session_UnableToLoad = "Unable to load Session";
        public const string Session_UniqueName = "Session Name should be Unique";
        public const string Session_NoProfile = "There seems to be no profile selected. Would you like to make a new profile based on the sourcefile?";

        //Profile
        public const string Profile_UnableToLoad = "Unable to load Profile";
    }
    public class Captions
    {
        //OverallSession
        public const string OverallSession_Load = "GFAC Session Load Message";

        //Session
        public const string Session_Load = "Session Load Message";

        //Profile
        public const string Profile_Load = "Profile Load Message";
    }
}
