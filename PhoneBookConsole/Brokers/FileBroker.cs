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

            using (FileStream fileStream = new FileStream(path,FileMode.OpenOrCreate))
            {
                fileStream.Flush();
            }
        }

        public void InsertDataToFile(string data)
        {
            if (path is null)
            {
                loggingBroker.LogError("This file path is null");
            }
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine(data);
                    }
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

        private bool FileExists()
        {
            if (path is null)
            {
                loggingBroker.LogError("This file path is null");
            }

            return File.Exists(path);
        }
    }
}
