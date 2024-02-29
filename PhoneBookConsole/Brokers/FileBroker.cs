using PhoneBookConsole.Brokers.Interfaces;
using System;
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
            path = @"C:\Users\ahmad\source\repos\PhoneBookConsole\PhoneBookConsole\Assets\CallSets.txt";
        }
        public void DeleteDataFromFile()
        {
            if (path is null)
            {
                loggingBroker.LogError("This file path is null");
            }

            throw new System.NotImplementedException();
        }

        public void InsertDataToFile(string data)
        {
            if (path is null)
            {
                loggingBroker.LogError("This file path is null");
            }
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine(data);
                }
            }
            catch (ArgumentException argumentException)
            {
                loggingBroker.LogError("Stream is not writable");
            }
        }

        public string[] ReadDataFromFile()
        {
            string[] lines = new string[100];
            if (path is null)
            {
                loggingBroker.LogError("This file path is null");
            }

            try
            {
                lines = File.ReadAllLines(path);
            }
            catch (ArgumentException argumentExeption)
            {
                loggingBroker.LogError("Stream is not writable");
            }
            return lines;
        }

        public bool FileExists()
        {
            if (path is null)
            {
                loggingBroker.LogError("This file path is null");
            }

            return File.Exists(path);
        }
    }
}
