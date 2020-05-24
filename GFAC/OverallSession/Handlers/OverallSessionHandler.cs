using GFAC.Common.Handlers;
using GFAC.OverallCalculationSession.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.OverallCalculationSession.Handlers
{
    public class OverallSessionHandler
    {
        #region Parameters
        private string _fileName;
        private string _filePath;
        private OverallSession _overallSession = null;
        #endregion
        #region Constructors
        public OverallSessionHandler()
        {

        }
        public OverallSessionHandler(string filePath_Name, OverallSession overallSession = null)
        {
            if (!string.IsNullOrEmpty(filePath_Name))
            {
                _filePath = Path.GetDirectoryName(filePath_Name);
                _fileName = Path.GetFileNameWithoutExtension(filePath_Name);
            }
            _overallSession = overallSession;
        }
        #endregion
        #region Public Methods
        public OverallSession ExportOverallSession()
        {
            OverallSession returnValue = null;

            if (_overallSession == null ||
                string.IsNullOrEmpty(_fileName) ||
                string.IsNullOrEmpty(_filePath))
                return returnValue;

            returnValue = _overallSession;
            bool SaveSuccesful = BaseFileHandler.ExportData(_overallSession, _filePath, _fileName);

            if (SaveSuccesful)
            {
                returnValue.LastSaved = DateTime.Now;
                returnValue.FilePath = _filePath;
                returnValue.FileName = _fileName;
            }

            return returnValue;
        }
        public OverallSession ImportOverallSession()
        {
            OverallSession returnValue = null;

            if (string.IsNullOrEmpty(_filePath) ||
                    string.IsNullOrEmpty(_fileName))
                return returnValue;

            try
            {
                returnValue = BaseFileHandler.ImportData<OverallSession>(_filePath, _fileName);
            }
            catch
            {
                returnValue = null;
            }

            return returnValue;
        }
        #endregion
    }
}
