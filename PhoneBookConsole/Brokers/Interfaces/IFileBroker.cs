using System;
using System.IO;

namespace PhoneBookConsole.Brokers.Interfaces
{
    public interface IFileBroker
    {
        void InsertDataToFile(string data);
        void DeleteDataFromFile();
        void ReadDataFromFile();
    }
}
