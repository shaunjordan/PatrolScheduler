using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        
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
    }
}
