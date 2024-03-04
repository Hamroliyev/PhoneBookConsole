using System;

namespace PhoneBookConsole.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogError(string userMessage);
        void LogError(Exception exception);
    }
}
