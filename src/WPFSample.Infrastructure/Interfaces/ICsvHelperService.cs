using WPFSample.Infrastructure.Models;

namespace WPFSample.Infrastructure.Interfaces
{
    public interface ICsvHelperService
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
