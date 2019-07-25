using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModels
{
    public class CustomerViewModel : BaseNotify
    {
        private ICustomerDataService _customerDataService;
        private CapstoneCustomer _selectedCustomer;


        public CustomerViewModel(ICustomerDataService customerDataService)
        {
            CapstoneCustomers = new ObservableCollection<CapstoneCustomer>();
            _customerDataService = customerDataService;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private async void OnSaveExecute()
        {
            await _customerDataService.SaveAsync(SelectedCustomer);
        }

        private bool OnSaveCanExecute()
        {
            //TODO: is friend valid
            return true;
        }

        //public CustomerViewModel()
        //{
        //    CapstoneCustomers = new ObservableCollection<CapstoneCustomer>();

        //    //_customerDataService = customerDataService;
        //}

        public async Task LoadAsync()
        {
            var customers = await _customerDataService.GetAllCustomersAsync();                       

            CapstoneCustomers.Clear();

            foreach (var customer in customers)
            {
                CapstoneCustomers.Add(customer);
            }
        }

        public ObservableCollection<CapstoneCustomer> CapstoneCustomers { get; set; }


        public CapstoneCustomer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

    }
}
