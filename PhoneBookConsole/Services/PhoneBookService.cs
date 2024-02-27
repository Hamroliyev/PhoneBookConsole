using PhoneBookConsole.Models;
using System;
using System.Linq;

namespace PhoneBookConsole.Services
{
    class PhoneBookService
    {
        private const int MaxContacts = 100;
        private Contact[] contacts { get; set; } = new Contact[MaxContacts];
        private int contactCount = 0;
        private void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine($"Contact : {contact.Name} , {contact.Number}");
        }
        private void DisplayContactDetails(Contact[] contacts)
        {
            for (int iteration = 0; iteration < contactCount; iteration++)
            {
                DisplayContactDetails(contacts[iteration]);
            }
        }
        
        public void DisplayContact(int Id)
        {
            var contact = contacts[Id++];
            if (contact == null)
            {
                Console.WriteLine("Contact not found");
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
            var foundContacts = contacts.Where(c => c.Name.ToLower().Contains(searchPharse.ToLower())).ToArray();

            if (foundContacts.Length > 0)
            {
                Console.WriteLine("Matching contacts:");
                DisplayContactDetails(foundContacts);
            }
            else
            {
                Console.WriteLine("No matching contacts found.");
            }
        }

        public void AddContact(Contact contact)
        {
            if (contactCount < MaxContacts)
            {
                contacts[contactCount] = new Contact(contact.Name, contact.Number);
                contactCount++;
                Console.WriteLine("Contact added successfully.");
            }
            else
            {
                Console.WriteLine("Phonebook is full. Cannot add more contacts.");
            }
        }

        public void DeleteContact(int id)
        {
            if (id > 0 && id <= contactCount)
            {
                for (int i = id - 1; i < contactCount - 1; i++)
                {
                    contacts[i] = contacts[i + 1];
                }
                contactCount--;
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid contact ID.");
            }
        }

        public void UpdateContact(int id, Contact contact)
        {
            if (id > 0 && id <= contactCount)
            {
                contacts[id - 1].Name = contact.Name;
                contacts[id - 1].Number = contact.Number;
                Console.WriteLine("Contact updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid contact ID.");
            }
        }

    }
}

