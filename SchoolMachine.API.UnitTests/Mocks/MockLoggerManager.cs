using SchoolMachine.Contracts;

namespace SchoolMachine.API.UnitTests.Mocks
{
    public class MockLoggerManager : ILoggerManager
    {
        public void LogDebug(string message)
        {
        }

        public void LogError(string message)
        {
        }

        public void LogInfo(string message)
        {
        }

        public void LogWarn(string message)
        {
        }
    }
}
