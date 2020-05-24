using GFAC.CalulationSession.Objects;
using GFAC.Common.Handlers;
using GFAC.Objects;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace GFAC.CalulationSession.Handlers
{
    public class SessionHandler
    {
        #region Parameters
        private string _fileName;
        private string _filePath;
        private Session _session = null;
        #endregion
        #region Constructors
        public SessionHandler()
        {

        }
        public SessionHandler(string filePath_Name, Session session = null)
        {
            if (!string.IsNullOrEmpty(filePath_Name))
            {
                _filePath = Path.GetDirectoryName(filePath_Name);
                _fileName = Path.GetFileNameWithoutExtension(filePath_Name);
            }
            _session = session;
        }
        #endregion
        #region Public Methods
        public Session ExportSession()
        {
            Session returnValue = null;
            
            if (_session == null ||
                string.IsNullOrEmpty(_fileName) ||
                string.IsNullOrEmpty(_filePath))
                return returnValue;

            returnValue = _session;
            bool SaveSuccesful = BaseFileHandler.ExportData(_session, _filePath, _fileName);

            if (SaveSuccesful)
            {
                returnValue.LastSaved = DateTime.Now;
                returnValue.FilePath = _filePath;
                returnValue.FileName = _fileName;
            }

            return returnValue;           
        }
        public Session ImportSession()
        {
            Session returnValue = null;

            if (string.IsNullOrEmpty(_filePath) ||
                    string.IsNullOrEmpty(_fileName))
                return returnValue;

            try
            {
                returnValue = BaseFileHandler.ImportData<Session>(_filePath, _fileName);
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
