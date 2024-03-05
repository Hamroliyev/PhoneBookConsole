using PhoneBookConsole.Models;

namespace PhoneBookConsole.Services.Contacts
{
    public interface IContactService
    {
        Contact AddContact(Contact contact);
        void ShowContacts();
        Contact UpdateContact(Contact contact);
        bool DeleteContactById(int id);
    }
}
