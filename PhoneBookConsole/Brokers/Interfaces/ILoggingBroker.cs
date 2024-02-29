namespace PhoneBookConsole.Brokers.Interfaces
{
    public interface ILoggingBroker
    {
        void LogInformation(string informationMessage);
        void LogError(string errorMessage);
        void Log(string message);
    }
}
