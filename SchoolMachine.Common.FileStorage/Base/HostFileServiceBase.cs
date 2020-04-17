using System.Collections.Generic;
using System.IO;

namespace SchoolMachine.Common.FileStorage.Base
{
    public class HostFileServiceBase : IHostFileService
    {
        #region Properties

        public string DirectoryPath { get; set; }

        #endregion Properties

        #region Constructors

        public HostFileServiceBase(string directoryPath)
        {
            DirectoryPath = directoryPath;
            Initialize();
        }

        #endregion Constructors

        #region Public Actions

        public virtual bool DirectoryExists()
        {
            if (string.IsNullOrEmpty(DirectoryPath)) return false;
            return Directory.Exists(DirectoryPath);
        }

        public virtual List<string> GetFilenames()
        {
            var fileNamesArray = Directory.GetFiles(DirectoryPath);
            var list = new List<string>();
            for (var i = 0; i < fileNamesArray.Length; ++i)
            {
                list.Add(fileNamesArray[i]);
            }
            return list;
        }

        public virtual List<string> GetSubdirectoryFilenames(string subdirectoryPath)
        {
            var fullPath = Path.Combine(DirectoryPath, subdirectoryPath);
            var fileNamesArray = Directory.GetFiles(fullPath);
            var list = new List<string>();
            for (var i = 0; i < fileNamesArray.Length; ++i)
            {
                list.Add(fileNamesArray[i]);
            }
            return list;
        }

        public virtual bool IncludesFileNamed(string filename)
        {
            var fileNamesArray = Directory.GetFiles(DirectoryPath);
            string combinedPath = Path.Combine(DirectoryPath, filename);
            for (var i = 0; i < fileNamesArray.Length; ++i)
            {
                if (fileNamesArray[i] == combinedPath) return true;
            }
            return false;
        }

        public virtual void Initialize()
        {
        }

        public virtual string SubdirectoryPath(string subdirectoryPath)
        {
            return Path.Combine(DirectoryPath, subdirectoryPath);
        }

        public virtual bool SubdirectoryExists(string subdirectoryPath)
        {
            var fullPath = Path.Combine(DirectoryPath, subdirectoryPath);
            if (string.IsNullOrEmpty(fullPath)) return false;
            return Directory.Exists(fullPath);
        }

        public virtual bool SubdirectoryIncludesFile(string subdirectoryPath, string filename)
        {
            var fullPath = Path.Combine(DirectoryPath, subdirectoryPath);
            var fileNamesArray = Directory.GetFiles(fullPath);
            string combinedPath = Path.Combine(fullPath, filename);
            for (var i = 0; i < fileNamesArray.Length; ++i)
            {
                if (fileNamesArray[i] == combinedPath) return true;
            }
            return false;
        }

        #endregion Public Actions
    }
}
