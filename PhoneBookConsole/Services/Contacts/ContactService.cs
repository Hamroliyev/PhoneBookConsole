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
            throw new System.NotImplementedException();
        }
    }
}
