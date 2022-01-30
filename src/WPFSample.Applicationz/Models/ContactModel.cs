using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using WPFSample.Applicationz.Common.Extensions;

namespace WPFSample.Applicationz.Models
{
    public class ContactModel : ObservableRecipient
    {
        private int id;
        private string firstName;
        private string lastName;
        private string companyName;
        private string address;
        private string country;
        private string state;
        private string city;
        private string zip;
        private string phone1;
        private string phone;
        private string email;
        private string starred;

        public ContactModel()
        {
            Messenger.Register<ContactModel, CurrentValidityRequestMessage>(this, (r, m) => m.Reply(r.AreFieldsFilled));
        }

        public ContactModel(ContactModel value)
        {
            Messenger.Register<ContactModel, CurrentValidityRequestMessage>(this, (r, m) => m.Reply(r.AreFieldsFilled));

            this.id = value.Id;
            this.email = value.email;
            this.phone = value.phone;
            this.phone1 = value.phone1;
            this.zip = value.zip;
            this.city = value.city;
            this.state = value.state;
            this.country = value.country;
            this.address = value.address;
            this.companyName = value.companyName;
            this.lastName = value.lastName;
            this.firstName = value.firstName;
            this.Starred = "StarOutline";
        }

        public bool AreFieldsFilled
        {
            get
            {
                return this.AreFieldsFilled();
            }
        }

        public int Id { get => id; set => SetProperty(ref id, value); }
        public string FirstName { get => firstName; set => UpdateFirstName(value); }

        private void UpdateFirstName(string value)
        {
            firstName = value;
            OnPropertyChanged(nameof(FirstName));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string LastName { get => lastName; set => UpdateLastName(value); }

        private void UpdateLastName(string value)
        {
            lastName = value;
            OnPropertyChanged(nameof(LastName));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string CompanyName { get => companyName; set => UpdateCompanyName(value); }

        private void UpdateCompanyName(string value)
        {
            companyName = value;
            OnPropertyChanged(nameof(CompanyName));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string Address { get => address; set => UpdateAddress(value); }

        private void UpdateAddress(string value)
        {
            address = value;
            OnPropertyChanged(nameof(Address));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string Country { get => country; set => UpdateCountry(value); }

        private void UpdateCountry(string value)
        {
            country = value;
            OnPropertyChanged(nameof(Country));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string State { get => state; set => UpdateState(value); }

        private void UpdateState(string value)
        {
            state = value;
            starred = state.ToLower().CompareTo("tx") == 0 ? "Star" : "StarOutline";
            OnPropertyChanged(nameof(Starred));
            OnPropertyChanged(nameof(State));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string City { get => city; set => UpdateCity(value); }

        private void UpdateCity(string value)
        {
            city = value;
            OnPropertyChanged(nameof(City));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string Zip { get => zip; set => UpdateZip(value); }

        private void UpdateZip(string value)
        {
            zip = value;
            OnPropertyChanged(nameof(Zip));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string Phone1 { get => phone1; set => UpdatePhone1(value); }

        private void UpdatePhone1(string value)
        {
            phone1 = value;
            OnPropertyChanged(nameof(Phone1));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string Phone { get => phone; set => UpdatePhone(value); }

        private void UpdatePhone(string value)
        {
            phone = value;
            OnPropertyChanged(nameof(Phone));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string Email { get => email; set => UpdateEemail(value); }

        private void UpdateEemail(string value)
        {
            email = value;
            OnPropertyChanged(nameof(Email));
            Messenger.Send(new ValidityChangedMessage(AreFieldsFilled));
        }

        public string Starred { get => starred; set => SetProperty(ref starred, value); }

    }

    public sealed class CurrentValidityRequestMessage : RequestMessage<bool>
    {
    }

    public sealed class ValidityChangedMessage : ValueChangedMessage<bool>
    {
        public ValidityChangedMessage(bool value) : base(value)
        {
        }
    }
}
