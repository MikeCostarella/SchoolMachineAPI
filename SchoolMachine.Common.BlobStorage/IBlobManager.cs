using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMachine.Common.BlobStorage
{
    public interface IBlobManager
    {
        Task<bool> DeleteAllAsync();
        Task<bool> DeleteAsync(string blobName);
        Task<bool> ExistsAsync(string blobName);
        Task<List<string>> GetBlobNames();
        Task<string> GetContentsAsync(string blobName);
        Task<bool> StoreAsync(string blobName, string blockContents);
    }
}
