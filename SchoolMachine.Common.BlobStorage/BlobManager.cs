using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
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

        public async Task<bool> DeleteAllAsync()
        {
            var names = await GetBlobNames();
            foreach (var name in names)
            {
                var success = await DeleteAsync(name);
                if (!success) return false;
            }
            return true;
        }

        public async Task<bool> DeleteAsync(string blobName)
        {
            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
            var doesBlobExist = await cloudBlockBlob.ExistsAsync();
            if (doesBlobExist)
            {
                await cloudBlockBlob.DeleteAsync();
            }
            return !(await cloudBlockBlob.ExistsAsync());
        }

        public async Task<bool> ExistsAsync(string blobName)
        {
            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
            return await cloudBlockBlob.ExistsAsync();
        }

        public async Task<List<string>> GetBlobNames()
        {
            var cloudBlockBlobs = await ListBlobsAsync(null);
            List<string> names = new List<string>();
            foreach (var cloudBlockBlob in cloudBlockBlobs)
            {
                names.Add(cloudBlockBlob.Name);
            }
            return names;
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
                return await UploadTextAsync(cloudBlockBlob, blobContents);
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

        private async Task<List<CloudBlockBlob>> ListBlobsAsync(BlobContinuationToken currentToken)
        {
            BlobContinuationToken continuationToken = null;
            var results = new List<CloudBlockBlob>();
            do
            {
                var response = await cloudBlobContainer.ListBlobsSegmentedAsync(continuationToken);
                continuationToken = response.ContinuationToken;
                foreach (var iListBlobItem in response.Results)
                {
                    results.Add((CloudBlockBlob)iListBlobItem);
                }
            }
            while (continuationToken != null);
            return results;
        }

        private async Task<bool> UploadTextAsync(ICloudBlob blob, string text)
        {
            blob.Properties.ContentEncoding = "UTF-8";
            blob.Properties.ContentType = "text/plain";
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
            {
                await blob.UploadFromStreamAsync(stream);
            }
            return await blob.ExistsAsync();
        }

        #endregion Utilities
    }
}
