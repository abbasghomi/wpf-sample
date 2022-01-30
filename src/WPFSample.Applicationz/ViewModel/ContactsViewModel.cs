using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using WPFSample.Applicationz.Common.Extensions;
using WPFSample.Applicationz.Mappers;
using WPFSample.Applicationz.Models;
using WPFSample.Infrastructure.Interfaces;

namespace WPFSample.Applicationz.ViewModel
{
    public class ContactsViewModel : ObservableRecipient
    {
        enum SaveType
        {
            Create,
            Update
        };

        private readonly ICsvHelperService CsvHelper = Ioc.Default.GetRequiredService<ICsvHelperService>();

        #region properties
        private SaveType saveType = SaveType.Create;

        private string saveButtonText = "Add";
        public string SaveButtonText
        {
            get => saveButtonText;
            set => SetProperty(ref saveButtonText, value);
        }

        private bool isSaveButtonEnabled = false;
        public bool IsSaveButtonEnabled
        {
            get => isSaveButtonEnabled;
            set => SetIsSaveButtonEnabled(value);
        }

        private void SetIsSaveButtonEnabled(bool value)
        {
            isSaveButtonEnabled = value;
            OnPropertyChanged(nameof(IsSaveButtonEnabled));
        }

        private ContactModel contactToUpdate = new ContactModel();
        public ContactModel  ContactToUpdate
        {
            get => contactToUpdate;
            set => SetContactToUpdate(value);
        }

        private void SetContactToUpdate(ContactModel value)
        {
            contactToUpdate = value;
            OnPropertyChanged(nameof(ContactToUpdate));
        }

        private ContactModel selectedContact = new ContactModel();
        public ContactModel SelectedContact
        {
            get => selectedContact;
            set { SetTemporaryContact(value); }
        }

        private void SetTemporaryContact(ContactModel value)
        {

            if (value == null)
            {
                saveType = SaveType.Create;
                saveButtonText = "Add";
                contactToUpdate = new ContactModel();
            }
            else
            {
                saveType = SaveType.Update;
                contactToUpdate = new ContactModel(value);
                saveButtonText = "Update";
            }

            OnPropertyChanged(nameof(SaveButtonText));
            OnPropertyChanged(nameof(ContactToUpdate));
            IsSaveButtonEnabled = ContactToUpdate.AreFieldsFilled();
        }

        private List<ContactModel> contacts = new List<ContactModel>();
        public List<ContactModel> Contacts
        {
            get => contacts;
            set => SetProperty(ref contacts, value);
        }

        #endregion

        public ContactsViewModel()
        {
            InitializeDataCommand = new RelayCommand(LoadContacts);
            LoadContactsCommand = new RelayCommand(LoadContacts);
            DeleteContactCommand = new RelayCommand<int>(DeleteContact);
            SaveContactCommand = new RelayCommand(SaveContact);
            CancelSaveContactCommand = new RelayCommand(CancelSaveContact);

            Messenger.Register<ContactsViewModel, ValidityChangedMessage>(this, (r, m) => r.IsSaveButtonEnabled = m.Value);
        }

        public bool CanSaveContact
        {
            get { return ContactToUpdate.AreFieldsFilled(); }
        }

        #region commands

        public ICommand InitializeDataCommand { get; }
        public ICommand LoadContactsCommand { get; }
        private void LoadContacts()
        {
            var contactsDataTemp = CsvHelper.GetContacts();

            contacts = contactsDataTemp.ToContactModels();

            OnPropertyChanged(nameof(Contacts));
            IsSaveButtonEnabled = false;
        }

        public ICommand DeleteContactCommand { get; }
        private void DeleteContact(int id)
        {
            CsvHelper.DeleteContactById(id);

            var contactsDataTemp = CsvHelper.GetContacts();

            contacts = contactsDataTemp.ToContactModels();

            OnPropertyChanged(nameof(Contacts));
        }

        public ICommand SaveContactCommand { get; }
        private void SaveContact()
        {
            if (saveType == SaveType.Create)
            {
                CsvHelper.CreateContact(contactToUpdate.ToContactData());
            }
            else
            {
                CsvHelper.UpdateContact(contactToUpdate.ToContactData());
            }

            saveType = SaveType.Create;
            saveButtonText = "Add";
            contactToUpdate = new ContactModel();

            OnPropertyChanged(nameof(SaveButtonText));
            OnPropertyChanged(nameof(ContactToUpdate));

            LoadContacts();
        }

        public ICommand CancelSaveContactCommand { get; }
        private void CancelSaveContact()
        {
            saveType = SaveType.Create;
            saveButtonText = "Add";
            contactToUpdate = new ContactModel();

            OnPropertyChanged(nameof(SaveButtonText));
            OnPropertyChanged(nameof(ContactToUpdate));
            IsSaveButtonEnabled = ContactToUpdate.AreFieldsFilled();
        }
        #endregion
    }
}
