using PhoneBookConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
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
    }
}

