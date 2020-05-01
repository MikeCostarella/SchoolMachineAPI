using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolMachine.Common.Queueing
{
    public class QueueingService
    {
        #region Member Variables

        private string serviceBusConnectionString;
        private QueueClient queueClient;
        private string queueName;
        private MessageHandlerOptions messageHandlerOptions;

        #endregion Member Variables

        #region Constructors

        public QueueingService(string serviceBusConnectionString, string queueName)
        {
            this.serviceBusConnectionString = serviceBusConnectionString;
            this.queueName = queueName;
            queueClient = new QueueClient(serviceBusConnectionString, queueName);
            messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };
        }

        #endregion Constructors

        #region Actions

        public async Task ReceiveMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine($"Received message: {Encoding.UTF8.GetString(message.Body)}");

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        public async Task RegisterMessageHandler()
        {
            try
            {
                queueClient.RegisterMessageHandler(ReceiveMessagesAsync, messageHandlerOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

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

        #region Utilities

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine(exceptionReceivedEventArgs.Exception);
            return Task.CompletedTask;
        }

        #endregion Utilities
    }
}
