namespace GFAC.Common
{
    public class Enumerations
    {
        public class FileType
        {
            public string Value { get; set; }
            public FileType(string value) { Value = value; }
            public static FileType CSV { get { return new FileType("csv files (*.csv)|*.csv"); } }
            public static FileType XML { get { return new FileType("xml files (*.xml)|*.xml"); } }
            public static FileType OverallSession { get { return new FileType("Overall Session files (*.osn)|*.osn"); } }
            public static FileType Session { get { return new FileType("Session files (*.ssn)|*.ssn"); } }
            public static FileType Profile { get { return new FileType("Profile files (*.prf)|*.prf"); } }
        }
    }
}
