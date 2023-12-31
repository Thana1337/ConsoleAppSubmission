using System;
using Test.Interfaces;
using Test.Models;

namespace Test.Services
{
    public class MenuService : IMenuService
    {
        private readonly IContactService _contactService;

        public MenuService(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Main menu method 
        public void MainMenu()
        {   
            // Infinite loop displaying the menu until the user chooses to exit
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Show Contacts");
                Console.WriteLine("3. Delete Contact by Email");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-----------------------------------------------------------------");

                // Get user input for menu option
                var option = Console.ReadLine();

                // Process user option using a switch statement
                switch (option)
                {
                    case "1":
                        _contactService.AddContact(new Contact());
                        _contactService.SaveContacts();
                        break;
                    case "2":
                        var contacts = _contactService.ShowContact();
                        break;
                    case "3":
                        _contactService.DeleteContactByEmail();
                        _contactService.SaveContacts();
                        break;
                    case "4":
                        _contactService.SaveContacts();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
