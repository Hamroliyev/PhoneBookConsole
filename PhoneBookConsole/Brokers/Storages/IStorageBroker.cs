using PhoneBookConsole.Models;

namespace PhoneBookConsole.Brokers.Storages
{
    public interface IStorageBroker
    {
        Contact AddContact(Contact contact);
        Contact[] ReadAllContacts();
    }
}
