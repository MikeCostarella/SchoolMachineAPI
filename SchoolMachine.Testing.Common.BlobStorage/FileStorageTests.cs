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
            var repairJobsFileData = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(fileDirectoryPath, fileName)));
            var blobName = fileName;
            var blobManager = new BlobManager(
                "testfiles",
                "DefaultEndpointsProtocol=https;AccountName=latvianvillagestorage;AccountKey=bgsc7zZEExRz0VPe56FOc/xRNxbTfZjv8A9JM6KTHwsXSwQQvhF8c2NQAFiuPi2qdQ0+43GDHmNH8Whncp4Jsg==;EndpointSuffix=core.windows.net;"
            );
            // Act
            var isSuccessful = blobManager.StoreAsync(fileName, repairJobsFileData).Result;
            // Assert
            Assert.IsTrue(isSuccessful, $"BlobManagerTest: BlobManager.StoreAsync failed for blob named: { fileName }.");
            var savedContents = blobManager.GetContentsAsync(fileName).Result;
            Assert.IsTrue(!string.IsNullOrEmpty(savedContents), $"BlobManagerTest: BlobManager.GetAsync failed for blob named: { fileName }.");
            blobManager.DeleteAsync(fileName).Wait();
            Assert.IsTrue(!blobManager.ExistsAsync(fileName).Result, $"BlobManagerTest: BlobManager.ExistsAsync indicated that blob named: { fileName } was not deleted.");
        }

        #endregion Tests
    }
}
