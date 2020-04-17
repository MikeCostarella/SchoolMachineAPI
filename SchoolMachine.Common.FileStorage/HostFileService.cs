using SchoolMachine.Common.FileStorage.Base;

namespace SchoolMachine.Common.FileStorage
{
    public class HostFileService : HostFileServiceBase
    {
        #region Constructors

        public HostFileService(string clientStorageDirectoryPath) : base(clientStorageDirectoryPath)
        {

        }

        public HostFileService() : base(string.Empty)
        {
            DirectoryPath = @"C:\TestStorage";
        }

        #endregion Constructors
    }
}
