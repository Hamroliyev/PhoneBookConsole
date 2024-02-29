using PhoneBookConsole.Brokers.Interfaces;
using System;

namespace PhoneBookConsole.Brokers
{
    public class LoggingBroker : ILoggingBroker
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void LogError(string errorMessage)
        {
            Console.WriteLine(errorMessage + " [ERROR]");
        }

        public void LogInformation(string informationMessage)
        {
            Console.WriteLine(informationMessage + " [INF]");
        }
    }
}
