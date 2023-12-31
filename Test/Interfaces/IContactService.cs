using Test.Models;

public interface IContactService
{
    void AddContact(Contact contact);
    void DeleteContactByEmail();
    void SaveContacts();
    IEnumerable<IContact> ShowContact();
}