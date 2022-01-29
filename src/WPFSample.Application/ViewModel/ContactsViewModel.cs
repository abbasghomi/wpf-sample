using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using WPFSample.Infrastructure.Interfaces;

namespace WPFSample.Application.ViewModel
{
    public class ContactsViewModel : ObservableObject
    {
        private readonly ICsvHelper CsvHelper = Ioc.Default.GetRequiredService<ICsvHelper>();

        public ContactsViewModel()
        {
            IncrementCounterCommand = new RelayCommand(IncrementCounter);
        }

        /// <summary>
        /// Gets the <see cref="ICommand"/> responsible for incrementing <see cref="Counter"/>.
        /// </summary>
        public ICommand IncrementCounterCommand { get; }

        private int counter;

        /// <summary>
        /// Gets the current value of the counter.
        /// </summary>
        public int Counter
        {
            get => counter;
            private set => SetProperty(ref counter, value);
        }

        /// <summary>
        /// Increments <see cref="Counter"/>.
        /// </summary>
        private void IncrementCounter() => Counter++;
    }
}
