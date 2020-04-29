using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMachine.Common.Queueing;
using System;

namespace SchoolMachine.Testing.Common.Queueing
{
    [TestClass]
    public class QueueingServiceTests
    {
        #region Member Variables

        private string serviceBusConnectionString = "Endpoint=sb://latvianvillage-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=pzW5MFKceTdEBZNpURyhSEE7eFC0fvqKwaE/kf0Znqg=";
        private string queueName = "latvianvillage-queue-0001";

        #endregion Member Variables

        #region Tests

        [TestMethod]
        public void QueueMessage()
        {
            // Arrange

            var queueService = new QueueingService(serviceBusConnectionString, queueName);
            var message = $"This is a message with Id = { Guid.NewGuid() }";

            // Act

            queueService.QueueMessage(message).GetAwaiter().GetResult();

            // Assert
        }

        #endregion Tests
    }
}
