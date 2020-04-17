using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMachine.Common.BlobStorage
{
    public class BlobManager : IBlobManager
    {
        #region Member Variables

        private string _blobStorageKey;
        private CloudBlobClient cloudBlobClient;
        private CloudBlobContainer cloudBlobContainer;
        private CloudStorageAccount cloudStorageAccount;
        private bool containerDoesExist;
        private string _containerName;

        #endregion Member Variables

        #region Constructors

        public BlobManager(string containerName, string blobStorageKey)
        {
            _blobStorageKey = blobStorageKey;
            _containerName = containerName;
            InitializeBlobContainer().Wait();
        }

        #endregion Constructors

        #region Actions

        public async Task DeleteAsync(string blobName)
        {
            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
            var doesBlobExist = await cloudBlockBlob.ExistsAsync();
            if (doesBlobExist)
            {
                await cloudBlockBlob.DeleteAsync();
            }
        }

        public async Task<bool> ExistsAsync(string blobName)
        {
            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
            return await cloudBlockBlob.ExistsAsync();
        }

        public async Task<string> GetContentsAsync(string blobName)
        {
            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
            var doesBlobExist = await cloudBlockBlob.ExistsAsync();
            if (doesBlobExist)
            {
                return await cloudBlockBlob.DownloadTextAsync();
            }
            return string.Empty; // ToDo: should we be throwing an exception here?
        }

        public async Task<bool> StoreAsync(string blobName, string blobContents)
        {
            try
            {
                var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
                await cloudBlockBlob.ExistsAsync();
                await UploadTextAsync(cloudBlockBlob, blobContents);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Actions

        #region Utilities

        private async Task InitializeBlobContainer()
        {
            cloudStorageAccount = CloudStorageAccount.Parse(_blobStorageKey);
            cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            cloudBlobContainer = cloudBlobClient.GetContainerReference(_containerName);
            containerDoesExist = await cloudBlobContainer.CreateIfNotExistsAsync();

        }

        private async Task UploadTextAsync(ICloudBlob blob, string text)
        {
            blob.Properties.ContentEncoding = "UTF-8";
            blob.Properties.ContentType = "text/plain";
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
            {
                await blob.UploadFromStreamAsync(stream);
            }
        }

        #endregion Utilities
    }
}
