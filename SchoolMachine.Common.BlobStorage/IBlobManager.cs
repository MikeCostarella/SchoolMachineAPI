using System.Threading.Tasks;

namespace SchoolMachine.Common.BlobStorage
{
    public interface IBlobManager
    {
        Task DeleteAsync(string blobName);
        Task<bool> ExistsAsync(string blobName);
        Task<string> GetContentsAsync(string blobName);
        Task<bool> StoreAsync(string blobName, string blockContents);
    }
}
