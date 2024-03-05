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

        public Contact[] ReadAllContacts()
        {
            string[] contactLines = File.ReadAllLines(FilePath);
            int contactLength = contactLines.Length;
            Contact[] contacts = new Contact[contactLength];

            for (int iterator = 0; iterator < contactLength; iterator++)
            {
                string contactLine = contactLines[iterator];
                string[] contactProperties = contactLine.Split("*");

                Contact contact = new Contact
                {
                    Id = Convert.ToInt32(contactProperties[0]),
                    Name = contactProperties[1],
                    Phone = contactProperties[2]
                };

                contacts[iterator] = contact;
            }

            return contacts;
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
