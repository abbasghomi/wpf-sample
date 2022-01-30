using WPFSample.Applicationz.Models;

namespace WPFSample.Applicationz.Common.Extensions
{
    public static class ValidateContactModel
    {
        public static bool AreFieldsFilled(this ContactModel contact)
        {
            if (string.IsNullOrEmpty(contact.FirstName) ||
                string.IsNullOrEmpty(contact.LastName) ||
                string.IsNullOrEmpty(contact.CompanyName) ||
                string.IsNullOrEmpty(contact.Address) ||
                string.IsNullOrEmpty(contact.Country) ||
                string.IsNullOrEmpty(contact.State) ||
                string.IsNullOrEmpty(contact.City) ||
                string.IsNullOrEmpty(contact.Zip) ||
                string.IsNullOrEmpty(contact.Phone1) ||
                string.IsNullOrEmpty(contact.Phone) ||
                string.IsNullOrEmpty(contact.Email))
            {
                return false;
            }
            return true;
        }
    }
}
