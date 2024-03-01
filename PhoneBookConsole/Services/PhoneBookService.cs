using PhoneBookConsole.Brokers;
using PhoneBookConsole.Brokers.Interfaces;
using PhoneBookConsole.Models;
using System;

namespace PhoneBookConsole.Services
{
    class PhoneBookService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IFileBroker fileBroker;
        private const int MaxContacts = 100;
        private Contact[] contacts { get; set; } = new Contact[MaxContacts];
        private int contactCount = 0;

        public PhoneBookService()
        {
            loggingBroker = new LoggingBroker();
            fileBroker = new FileBroker();
            ReadContactsFromFile();
        }

        private void ReadContactsFromFile()
        {
            string[] lines = fileBroker.ReadDataFromFile();

            foreach (string line in lines)
            {
                string[] contactInfo = line.Split(' ');

                if (contactInfo.Length == 3)
                {
                    Contact contact = new Contact
                    {
                        Id = contactInfo[0],
                        Name = contactInfo[1],
                        Number = contactInfo[2]
                    };

                    contacts[contactCount] = contact;
                    contactCount++;
                }
            }
        }

        private void DisplayContactDetails(Contact contact)
        {
            loggingBroker.Log($"Contact : {contact.Name} , {contact.Number}");
        }
        private void DisplayContactDetails(Contact[] contacts)
        {
            for (int iteration = 0; iteration < contactCount; iteration++)
            {
                if (contacts[iteration] is not null)
                {
                    DisplayContactDetails(contacts[iteration]);
                }
            }
        }
        
        public void DisplayContactById(string id)
        {
            ReadContactsFromFile();
            var contact = Array.Find(contacts, c => c.Id == id);

            if (contact == null)
            {
                loggingBroker.LogError("Contact is not found");
            }
            else
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayAllContact()
        {
            DisplayContactDetails(contacts);
        }

        public void DisplayMatchingContacts(string searchPharse)
        {
            ReadContactsFromFile();
            Contact[] foundContacts = Array.FindAll(contacts, c => c.Name.Contains(searchPharse));

            if (foundContacts.Length > 0)
            {
                loggingBroker.LogInformation("Matching contacts:");
                DisplayContactDetails(foundContacts);
            }
            else
            {
                loggingBroker.LogInformation("No matching contacts found.");
            }
        }

        public void AddContact(Contact contact)
        {
            if (contactCount < MaxContacts)
            {
                fileBroker.InsertDataToFile($"{contact.Id} {contact.Name} {contact.Number}");
                contactCount++;
                loggingBroker.LogInformation("Contact added successfully.");
            }
            else
            {
                loggingBroker.LogInformation("Phonebook is full. Cannot add more contacts.");
            }
            ReadContactsFromFile();
        }

        public void DeleteContactById(int id)
        {
            if (id > 0 && id <= contactCount)
            {
                for (int i = id - 1; i < contactCount - 1; i++)
                {
                    contacts[i] = contacts[i + 1];
                }
                contactCount--;
                loggingBroker.LogInformation("Contact deleted successfully.");
            }
            else
            {
                loggingBroker.LogInformation("Invalid contact ID.");
            }
        }

        public void UpdateContact(int id, Contact contact)
        {
            if (id > 0 && id <= contactCount)
            {
                contacts[id - 1].Name = contact.Name;
                contacts[id - 1].Number = contact.Number;
                loggingBroker.LogInformation("Contact updated successfully.");
            }
            else
            {
                loggingBroker.LogInformation("Invalid contact ID.");
            }
        }
    }
}

