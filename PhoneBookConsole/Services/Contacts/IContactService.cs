﻿using PhoneBookConsole.Models;

namespace PhoneBookConsole.Services.Contacts
{
    public interface IContactService
    {
        Contact AddContact(Contact contact);
    }
}