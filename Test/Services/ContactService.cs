using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Test.Models;
using Test.Utilities;


public class ContactService : IContactService
{

    private const string FileName = @"D:\Projects\Test\contacts.json";
    private List<Contact> contacts;
    public ContactService()
    {
        // Load contacts from the file
        contacts = LoadContacts();
    }

        // Adding Contact Method
    public void AddContact()
    {   
        Console.Clear();
        Console.Write("Enter a name: ");
        var firstName = Console.ReadLine();

        Console.Write("Enter an lastname: ");

        var lastName = Console.ReadLine();

        Console.Write("Enter an email: ");
        var email = Console.ReadLine();

        Console.Write("Enter a phone number: ");
        var PhoneNumber = Console.ReadLine();

        Console.Write("Enter an adress: ");
        var address = Console.ReadLine();

        // Check for valid input and use regular expressions for email and phone number validation
        if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(email) && RegularExpression.IsValidEmail(email) && RegularExpression.IsValidPhoneNumber(PhoneNumber = null!))
        {
            // If valid create a new contact and add it to the list
            var newContact = new Contact
            {
                Firstname = firstName,
                Lastname = lastName,
                Email = email,
                Phonenumber = PhoneNumber,
                Address = address
            };
            contacts.Add(newContact);
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Contact added successfully!");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.ReadKey();
        }
            // Else show error message
        else
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Invalid email or phone number. Press any key to continue...");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.ReadKey();
        }
    }

    // Show Contact Method
    public void ShowContacts()
    {
        Console.Clear();
        Console.WriteLine("Contacts:");
        Console.WriteLine("-----------------------------------------------------------------");
        // Check if there are any contact
        if (contacts.Any())
        {
            // Display each contact's information
            foreach (var contact in contacts)
            {
                Console.WriteLine($" Name: {contact.Firstname} {contact.Lastname}\n Email: {contact.Email}\n Phone: {contact.Phonenumber}\n Address: {contact.Address}\n-----------------------------------------------------------------");
            }
        }
        // Else show error message
        else
        {
            Console.WriteLine("There is currently no users");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    // Delete by Email Method
    public void DeleteContactByEmail()
    {
        Console.Clear ();
        Console.Write("Enter the email of the contact to delete: ");
        Console.WriteLine("\n-----------------------------------------------------------------");

        // Get the email to delete
        var emailToDelete = Console.ReadLine();

        // Find the email to delete
        var contactToDelete = contacts.FirstOrDefault(c => c.Email == emailToDelete);

        // If found delete
        if (contactToDelete != null)
        {
            contacts.Remove(contactToDelete);
            Console.WriteLine("Contact deleted successfully!");
        }
        // Else show error message
        else
        {
            Console.WriteLine("Contact not found. Press any key to continue...");
        }

        Console.ReadKey();
    }

    // Save Contact Method
    public void SaveContacts()
    {
        var contact = JsonConvert.SerializeObject(contacts);
        File.WriteAllText(FileName, contact);
    }
    // Load Contact From File Method
    private List<Contact> LoadContacts()
    {
        // If file exist
        if (File.Exists(FileName))
        {
            // If exist then read file and deserialize 
            var contact = File.ReadAllText(FileName);
            return JsonConvert.DeserializeObject<List<Contact>>(contact) ?? new List<Contact>();
        }
        // If not exist, return new empty file.
        return new List<Contact>();
    }
}
