using PhoneBookConsole.Brokers.Loggings;
using PhoneBookConsole.Brokers.Storages;
using PhoneBookConsole.Models;

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
            return this.storageBroker.AddContact(contact);
        }

        public void ShowContacts()
        {
            Contact[] contacts = this.storageBroker.ReadAllContacts();

            foreach (Contact contact in contacts)
            {
                this.loggingBroker.LogInformation($"{contact.Id}. {contact.Name} - {contact.Phone}");
            }

            this.loggingBroker.LogInformation("=== End of contacts ===");
        }
    }
}
