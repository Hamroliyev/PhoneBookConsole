using PhoneBookConsole.Models;
using PhoneBookConsole.Services;
using System;

namespace PhoneBookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t --- Hello from the PhoneBook app --- ");
            Console.WriteLine("\t : Select Operation : ");
            Console.WriteLine("1 - Add contact");
            Console.WriteLine("2 - Display contact by number");
            Console.WriteLine("3 - View all contacts");
            Console.WriteLine("4 - Search for contacts for a given name");
            Console.WriteLine("5 - Update contact");
            Console.WriteLine("6 - Delete contect");
            Console.WriteLine("Press 'x' to exit");
            Console.Write("Enter your choice : ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

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
                        phoneBook.DisplayContactById(id);
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
                        phoneBook.DeleteContactById(idDeleted);
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
        }
    }
}
