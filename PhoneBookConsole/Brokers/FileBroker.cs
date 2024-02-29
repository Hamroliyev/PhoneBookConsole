using PhoneBookConsole.Brokers.Interfaces;
using System.IO;

namespace PhoneBookConsole.Brokers
{
    public class FileBroker : IFileBroker
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly string path;
        public FileBroker()
        {
            loggingBroker = new LoggingBroker();
            path = "";
        }
        public void DeleteDataFromFile()
        {
            throw new System.NotImplementedException();
        }

        public void InsertDataToFile(string data)
        {
            
        }

        public void ReadDataFromFile()
        {
            throw new System.NotImplementedException();
        }
    }
}
