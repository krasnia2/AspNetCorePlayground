using Microsoft.Extensions.Logging;

namespace Schools.Web.Brokers
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger logger;
        public LoggingBroker(ILogger logger) => this.logger = logger;
        public void Error(string message) => this.logger.LogError(message);
    }
}
