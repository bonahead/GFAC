using GFAC.CalculationProfile.Objects;
using GFAC.CalulationSession.Objects;
using GFAC.Common.Objects;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GFAC.Common.Handlers
{
    internal class BaseFileHandler
    {
        internal static T ImportData<T>(string filePath, string fileName) where T : BaseGFAC
        {
            T returnValue = null;
            StreamReader file = null;
            string filePath_name = $"{filePath}\\{fileName}.{GetExtension(typeof(T))}";
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                file = new StreamReader(filePath_name);
                returnValue = (T)xmlSerializer.Deserialize(file);
            }
            catch
            {
                returnValue = null;
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
            return returnValue;
        }

        private static string GetExtension(Type t)
        {
            switch(t.Name)
            {
                case "Session":
                    return "ssn";
                case "Profile":
                    return "prf";
                default:
                    return string.Empty;
            }
        }

        internal static bool ExportData<T>(T exportData, string filePath, string fileName)
        {
            bool returnValue = false;
            string fileExtension = GetExtension(typeof(T));
            string newFileName = $"{filePath}\\{fileName}.{fileExtension}";
            string tempFileName = GetTempFileName(filePath, fileName, fileExtension);

            if (string.IsNullOrEmpty(tempFileName))
                return returnValue;

            StreamWriter file = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                file = new StreamWriter(tempFileName);
                serializer.Serialize(file, exportData);
                file.Close();
                if (newFileName != tempFileName)
                    RenameExportedFile(tempFileName, newFileName, filePath, fileName, fileExtension);
                returnValue = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
            return returnValue;
        }
        private static void RenameExportedFile(string tempFileName, string newFileName, string filePath, string fileName, string fileExtension)
        {
            if (string.IsNullOrEmpty(tempFileName) ||
                string.IsNullOrEmpty(newFileName) ||
                string.IsNullOrEmpty(filePath) ||
                string.IsNullOrEmpty(fileName))
                throw new Exception("No File To Be Saved.");

            string newTempFileName = GetTempFileName(filePath, fileName, fileExtension);
            if (string.IsNullOrEmpty(newTempFileName))
                throw new Exception("Temp Filename could not be determined");
            
            try
            {
                File.Copy(newFileName, newTempFileName);
                File.Delete(newFileName);
                File.Copy(tempFileName, newFileName);
                File.Delete(tempFileName);
                File.Delete(newTempFileName);
            }   
            catch(Exception e)
            {
                if (!File.Exists(newFileName))
                {
                    if (File.Exists(newTempFileName))
                        File.Copy(newTempFileName, newFileName);
                }
                if (!File.Exists(tempFileName)) 
                    File.Delete(tempFileName);
                if (!File.Exists(newTempFileName))
                    File.Delete(newTempFileName);

                throw new Exception("Unable to save File");
            }
        }
        private static string GetTempFileName(string filePath,string fileName, string fileExtension)
        {
            string returnValue = string.Empty;
            int tryIndex = 0;
            if (string.IsNullOrEmpty(filePath) ||
                string.IsNullOrEmpty(fileName))
                return returnValue;

            string filePath_Name = $"{filePath}\\{fileName}.{fileExtension}";
            if (!File.Exists(filePath_Name))
                returnValue = filePath_Name;
            else
            {
                returnValue = $"{filePath}\\{fileName}{tryIndex.ToString()}.{fileExtension}";
                while (CheckExists(returnValue))
                {
                    tryIndex++;
                    returnValue = $"{filePath}\\{fileName}{tryIndex.ToString()}.{fileExtension}";
                }
            }
            return returnValue;
        } 

        private static bool CheckExists(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}
