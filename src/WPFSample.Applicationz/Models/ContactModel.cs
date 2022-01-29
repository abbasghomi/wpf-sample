using CommunityToolkit.Mvvm.ComponentModel;

namespace WPFSample.Applicationz.Models
{
    public class ContactModel : ObservableObject
    {
        private int id;
        private string email;
        private string phone2;
        private string phone1;
        private string zip;
        private string city;
        private string state;
        private string country;
        private string address;
        private string companyName;
        private string lastName;
        private string firstName;

        public int Id { get => id; set => SetProperty(ref id, value); }
        public string FirstName { get => firstName; set => SetProperty(ref firstName, value); }
        public string LastName { get => lastName; set => SetProperty(ref lastName, value); }
        public string CompanyName { get => companyName; set => SetProperty(ref companyName, value); }
        public string Address { get => address; set => SetProperty(ref address, value); }
        public string Country { get => country; set => SetProperty(ref country, value); }
        public string State { get => state; set => SetProperty(ref state, value); }
        public string City { get => city; set => SetProperty(ref city, value); }
        public string Zip { get => zip; set => SetProperty(ref zip, value); }
        public string Phone1 { get => phone1; set => SetProperty(ref phone1, value); }
        public string Phone2 { get => phone2; set => SetProperty(ref phone2, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
    }
}
