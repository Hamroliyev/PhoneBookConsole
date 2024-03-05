using PhoneBookConsole.Models;
using System;
using System.IO;

namespace PhoneBookConsole.Brokers.Storages
{
    public class FileStorageBroker : IStorageBroker
    {
        private const string FilePath = "../../../Assets/Contacts.txt";

        public FileStorageBroker()
        {
            EnsureFileExists();
        }


        public Contact AddContact(Contact contact)
        {
            string contactLine = $"{contact.Id}*{contact.Name}*{contact.Phone}\n";
            File.AppendAllText(FilePath, contactLine);

            return contact;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);

            if (fileExists is false)
            {
                File.Create(FilePath).Close();
            }
        }
    }
}
