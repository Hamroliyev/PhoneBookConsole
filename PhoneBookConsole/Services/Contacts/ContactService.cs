using PhoneBookConsole.Brokers.Loggings;
using PhoneBookConsole.Brokers.Storages;
using PhoneBookConsole.Models;
using System;

namespace PhoneBookConsole.Services.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ContactService()
        {
            this.storageBroker = new FileStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }
        public Contact AddContact(Contact contact)
        {
            return contact is null
                ? CreateAndLogInvalidContact()
                : ValidateAndAddContact(contact);
        }

        public void ShowContacts()
        {
            Contact[] contacts = this.storageBroker.ReadAllContacts();

            if (contacts.Length == 0)
            {
                this.loggingBroker.LogError("Contacts is empty");

                return;
            }

            foreach (Contact contact in contacts)
            {
                this.loggingBroker.LogInformation($"{contact.Id}. {contact.Name} - {contact.Phone}");
            }

            this.loggingBroker.LogInformation("=== End of contacts ===");
        }

        private Contact CreateAndLogInvalidContact()
        {
            this.loggingBroker.LogError("Contact is invalid");

            return new Contact();
        }

        private Contact ValidateAndAddContact(Contact contact)
        {
            if (contact.Id is 0
                || String.IsNullOrWhiteSpace(contact.Name)
                || String.IsNullOrWhiteSpace(contact.Phone))
            {
                this.loggingBroker.LogError("Contact details missing.");

                return new Contact();
            }
            else
            {
                return this.storageBroker.AddContact(contact);
            }
        }
    }
}
