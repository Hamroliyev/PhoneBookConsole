using PhoneBookConsole.Models;
using PhoneBookConsole.Services;
using PhoneBookConsole.Services.Contacts;
using System;

namespace PhoneBookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IContactService contactService = new ContactService();

            contactService.ShowContacts();
        }
    }
}
