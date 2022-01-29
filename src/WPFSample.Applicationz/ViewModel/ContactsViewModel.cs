using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using WPFSample.Applicationz.Models;
using WPFSample.Infrastructure.Interfaces;
using WPFSample.Applicationz.Mappers;

namespace WPFSample.Applicationz.ViewModel
{
    public class ContactsViewModel : ObservableObject
    {
        private readonly ICsvHelper CsvHelper = Ioc.Default.GetRequiredService<ICsvHelper>();

        #region properties

        private List<ContactModel> contacts = new List<ContactModel>();
        public List<ContactModel> Contacts
        {
            get => contacts;
            set => SetProperty(ref contacts, value);
        }

        #endregion

        public ContactsViewModel()
        {
            LoadContactsCommand = new RelayCommand(LoadContacts);
            InitializeDataCommand = new RelayCommand(LoadContacts);
        }

        #region commands

        public ICommand InitializeDataCommand { get; }
        public ICommand LoadContactsCommand { get; }
        private void LoadContacts() 
        {
            var contactsDataTemp = CsvHelper.GetContacts();

            contacts = contactsDataTemp.ToContactModels();

            OnPropertyChanged(nameof(Contacts));
        } 


        #endregion
    }
}
