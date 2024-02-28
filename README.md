# PhoneBook App

The PhoneBook app is a simple console-based application that allows users to manage a list of contacts. It provides basic functionalities for adding, searching, updating,
and deleting contacts within a phone book.

## Features
- Add Contact: Users can add a new contact with a name and phone number.
- View All Contacts: Users can view the list of all contacts in the phone book.
- Search Contacts: Users can search for contacts based on a given name.
- Update Contact: Users can update the phone number of an existing contact.
- Delete Contact: Users can delete a contact from the phone book.

## Technologies Used
- C# programming language
- .NET Framework

## How to Use
1. Clone the repository to your local machine.
2. Open the solution in your preferred C# development environment.
3. Build the solution and run the application.
4. Follow the on-screen instructions to use the phone book functionalities.

## Contributors
- Hamroliyev

Feel free to customize the information based on your specific app details and development environment.

---

## Parts of Code.

1 - Menu
    ![Menu](https://github.com/Hamroliyev/PhoneBookConsole/blob/master/PhoneBookConsole/Assets/menu.png)

2 - Main
     
        PhoneBookService phoneBook = new PhoneBookService();
            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.Write("Contact name : ");
                        var name = Console.ReadLine();
                        Console.Write("Contact number : ");
                        var number = Console.ReadLine();
                        var newContact = new Contact(name, number);
                        phoneBook.AddContact(newContact);
                        break;

                    case "2":
                        Console.Write("Contact id to search ");
                        string idInput = Console.ReadLine();
                        int id = Convert.ToInt32(idInput);
                        phoneBook.DisplayContact(id);
                        break;

                    case "3":
                        phoneBook.DisplayAllContact();
                        break;

                    case "4":
                        Console.Write("Name search phrase : ");
                        var searchPhrase = Console.ReadLine();
                        phoneBook.DisplayMatchingContacts(searchPhrase);
                        break;

                    case "5":
                        Console.Write("Enter the id you wanna update : ");
                        string idUpdatedInput = Console.ReadLine();
                        int idUpdated = Convert.ToInt32(idUpdatedInput);
                        Console.Write("Contact name : ");
                        var nameUpdated = Console.ReadLine();
                        Console.Write("Contact number : ");
                        var numberUpdated = Console.ReadLine();
                        var contactUpdated = new Contact(nameUpdated, numberUpdated);
                        phoneBook.UpdateContact(idUpdated, contactUpdated);
                        break;

                    case "6":
                        Console.Write("Enter the id you wanna delete : ");
                        string idDeletedInput = Console.ReadLine();
                        int idDeleted = Convert.ToInt32(idDeletedInput);
                        phoneBook.DeleteContact(idDeleted);
                        break;

                    case "x":
                        return;

                    default:
                        Console.WriteLine("Select Valid operation");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("\t : Select Operation : ");
                userInput = Console.ReadLine();
            }

3 - Contact Model.
![Contact Model](https://github.com/Hamroliyev/PhoneBookConsole/blob/master/PhoneBookConsole/Assets/contactModel.png)

4 - PhoneBookService

    using PhoneBookConsole.Models;
    using System;

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
                for (int iteration = 0; iteration < contactCount; iteration++)
                {
                    DisplayContactDetails(contacts[iteration]);
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
                Contact[] foundContacts = Array.FindAll(contacts, c => c.Name.Contains(searchPharse));

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

            public void DeleteContact(int id)
            {
                if (id > 0 && id <= contactCount)
                {
                    for (int i = id - 1; i < contactCount - 1; i++)
                    {
                        contacts[i] = contacts[i + 1];
                    }
                    contactCount--;
                    Console.WriteLine("Contact deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid contact ID.");
                }
            }

            public void UpdateContact(int id, Contact contact)
            {
                if (id > 0 && id <= contactCount)
                {
                    contacts[id - 1].Name = contact.Name;
                    contacts[id - 1].Number = contact.Number;
                    Console.WriteLine("Contact updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid contact ID.");
                }
            }

        }
    }

4 - Result
![Result](https://github.com/Hamroliyev/PhoneBookConsole/blob/master/PhoneBookConsole/Assets/result.gif)

