using WPFSample.Infrastructure.Models;

namespace WPFSample.Infrastructure.Interfaces
{
    public interface ICsvHelper
    {
        List<ContactModel> GetContacts();
        ContactModel ReadContact(int id);
        bool UpdateContact(ContactModel contact);
        bool DeleteContact(ContactModel contact);
        bool CreateContact(ContactModel contact);
        int GetNewId();
    }
}
