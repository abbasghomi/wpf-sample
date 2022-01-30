using WPFSample.Infrastructure.Models;

namespace WPFSample.Infrastructure.Interfaces
{
    public interface ICsvHelper
    {
        List<ContactData> GetContacts();
        ContactData ReadContact(int id);
        bool UpdateContact(ContactData contact);
        bool DeleteContact(ContactData contact);
        bool DeleteContactById(int id);
        bool CreateContact(ContactData contact);
        int GetNewId();
    }
}
