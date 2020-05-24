using GFAC.CalculationProfile.Objects;
using GFAC.Common.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GFAC.CalculationProfile.Handlers
{
    public class ProfileHandler
    {
        #region Parameters
        private string _fileName;
        private string _filePath;
        private Profiles _Profiles = null;
        private Profile _profile = null;
        #endregion
        #region Constructors
        public ProfileHandler() {
            _Profiles = ImportProfiles();
        }
        public ProfileHandler(Profiles profiles)
        {
            _Profiles = profiles;;
        }
        public ProfileHandler(string filePath_Name, Profile profile = null)
        {
            if (!string.IsNullOrEmpty(filePath_Name))
            {
                _filePath = Path.GetDirectoryName(filePath_Name);
                _fileName = Path.GetFileNameWithoutExtension(filePath_Name);
            }
            _profile = profile;
        }
        #endregion
        #region Public Methods
        public Profile ExportProfile()
        {
            Profile returnValue = null;

            if (_profile == null ||
                string.IsNullOrEmpty(_fileName) ||
                string.IsNullOrEmpty(_filePath))
                return returnValue;

            returnValue = _profile;
            bool SaveSuccesful = BaseFileHandler.ExportData(_profile, _filePath, _fileName);

            if (SaveSuccesful)
            {
                returnValue.LastSaved = DateTime.Now;
                returnValue.FilePath = _filePath;
                returnValue.FileName = _fileName;
            }

            return returnValue;
        }
        public Profile ImportProfile()
        {
            Profile returnValue = null;

            if (string.IsNullOrEmpty(_filePath) ||
                    string.IsNullOrEmpty(_fileName))
                return returnValue;

            try
            {
                returnValue = BaseFileHandler.ImportData<Profile>(_filePath, _fileName);
            }
            catch
            {
                returnValue = null;
            }

            return returnValue;
        }
        public void SetProfile(string ProfileName)
        {

        }
        public List<string> GetProfiles()
        {
            return _Profiles.OrderBy(cp => cp.Name).Select(cp => cp.Name).ToList();
        }
        public Profiles ImportProfiles()
        {
            Profiles returnValue = new Profiles();
            StreamReader file = null;
            string filename = $"{_filePath}{_fileName}.prf";
            
            try
            {
                XmlSerializer profileReader = new XmlSerializer(typeof(Profiles));
                file = new StreamReader(filename);
                returnValue = (Profiles)profileReader.Deserialize(file);
            }
            catch (Exception e) {
                returnValue = new Profiles();
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
            return returnValue;
        }
        public void ExportProfiles()
        {
            if (_Profiles == null) 
                return;

            BaseFileHandler.ExportData(_Profiles, _filePath, _fileName);
        }
        #endregion
        #region Internal Methods
        internal void SetProfileOnSourceFile()
        {

        }
        #endregion
    }
}
