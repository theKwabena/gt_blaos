using NLog;
namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        // A class that manages and provides dependencies to classes through constructors are containers or Inversion of Control Containers.
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
        }
    }
}
