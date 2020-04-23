using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.Common.BlobStorage;
using SchoolMachine.Common.FileStorage;
using System;
using System.IO;

namespace SchoolMachine.Testing.Common.BlobStorage
{
    [TestClass]
    public class FileStorageTests
    {
        #region Tests

        [TestMethod]
        public void BlobManagerTest()
        {
            // Arrange
            var hostFileService = new HostFileService();
            var fileDirectoryPath = hostFileService.SubdirectoryPath($"Files");
            var fileName = "TestFile.csv";
            var TestFileData = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(fileDirectoryPath, fileName)));
            var blobName = fileName;
            var blobManager = new BlobManager(
                "testfiles",
                "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;"
            );
            //var blobManager = new BlobManager(
            //    "testfiles",
            //    "DefaultEndpointsProtocol=https;AccountName=latvianvillagestorage;AccountKey=bgsc7zZEExRz0VPe56FOc/xRNxbTfZjv8A9JM6KTHwsXSwQQvhF8c2NQAFiuPi2qdQ0+43GDHmNH8Whncp4Jsg==;EndpointSuffix=core.windows.net;"
            //);
            // Act
            var isSuccessfullyStored = blobManager.StoreAsync(fileName, TestFileData).GetAwaiter().GetResult();
            // Assert
            Assert.IsTrue(isSuccessfullyStored, $"BlobManagerTest: BlobManager.StoreAsync failed for blob named: { fileName }.");
            var savedContents = blobManager.GetContentsAsync(fileName).GetAwaiter().GetResult();
            Assert.IsTrue(!string.IsNullOrEmpty(savedContents), $"BlobManagerTest: BlobManager.GetAsync failed for blob named: { fileName }.");
            var isBlobDeleted = blobManager.DeleteAsync(fileName).GetAwaiter().GetResult();
            Assert.IsTrue(isBlobDeleted, $"BlobManagerTest: BlobManager.ExistsAsync indicated that blob named: { fileName } was not deleted.");
        }

        #endregion Tests
    }
}
