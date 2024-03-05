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

        public Contact UpdateContact(Contact contact)
        {
            return contact is null
                ? CreateAndLogInvalidContact()
                : ValidateAndUpdateContact(contact);
        }

        public bool DeleteContactById(int id)
        {
            if (id is 0)
            {
                this.loggingBroker.LogError("Id is invalid.");

                return false;
            }
            else
            {
                return this.storageBroker.DeleteContactById(id);
            }

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

        private Contact ValidateAndUpdateContact(Contact contact)
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
                return this.storageBroker.UpdateContact(contact);
            }
        }
    }
}
