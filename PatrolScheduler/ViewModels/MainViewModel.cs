using PatrolScheduler.Database;
using PatrolScheduler.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModel
{
    public class MainViewModel : BaseNotify
    {
        private ICustomerDataService _customerDataService;
        private CapstoneCustomer _selectedCustomer;
                

        public MainViewModel(ICustomerDataService customerDataService)
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
