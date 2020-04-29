using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMachine.Common.Queueing
{
    public class QueueingService
    {
        #region Member Variables

        private string serviceBusConnectionString;
        private QueueClient queueClient;
        private string queueName;

        #endregion Member Variables

        #region Constructors

        public QueueingService(string serviceBusConnectionString, string queueName)
        {
            this.serviceBusConnectionString = serviceBusConnectionString;
            this.queueName = queueName;
            queueClient = new QueueClient(serviceBusConnectionString, queueName);
        }

        #endregion Constructors

        #region Actions

        public async Task QueueMessage(string messageBody)
        {
            try
            {
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                Console.WriteLine($"Message Added in Queue: {messageBody}");
                await queueClient.SendAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"QueueingService.QueueMessage generated exception : { ex }");
            }
        }

        #endregion Actions

    }
}
