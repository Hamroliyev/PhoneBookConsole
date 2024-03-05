using PhoneBookConsole.Models;

namespace PhoneBookConsole.Brokers.Storages
{
    public interface IStorageBroker
    {
        Contact AddContact(Contact contact);
        Contact[] ReadAllContacts();
        Contact UpdateContact(Contact contact);
        bool DeleteContactById(int id);
    }
}
