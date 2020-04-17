using System.Collections.Generic;

namespace SchoolMachine.Common.FileStorage.Base
{
    public interface IHostFileService
    {
        #region Properties

        string DirectoryPath { get; set; }

        #endregion Properties

        #region Actions

        bool DirectoryExists();
        List<string> GetFilenames();
        List<string> GetSubdirectoryFilenames(string subdirectoryPath);
        void Initialize();
        string SubdirectoryPath(string subdirectoryPath);
        bool SubdirectoryExists(string subdirectoryPath);
        bool SubdirectoryIncludesFile(string subdirectoryPath, string filename);

        #endregion Actions
    }
}
