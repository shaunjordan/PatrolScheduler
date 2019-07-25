using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModels;
using PatrolScheduler.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModel
{
    public class MainViewModel : BaseNotify
    {

        //private CustomerViewModel customerViewModel;
        private CustomerView _custView;
        private EmployeeView _employeeView;
        
        //private ICustomerDataService _customerDataService;

        object selectedView;
        

        public object SelectedView
        {
            get { return selectedView; }
            private set
            {
                selectedView = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectCustomerView { get; private set; }
        public ICommand SelectEmployeeView { get; private set; }

        // load user control views into the content control and pass the data service into the code behind
        
        public MainViewModel(ICustomerDataService _customerDataService)
        {
            //customerViewModel = new CustomerViewModel(_customerDataService);
            //customerViewModel = new CustomerViewModel();
            _custView = new CustomerView(_customerDataService);
            _employeeView = new EmployeeView();
            //SelectCustomerView = new RelayCommand(() => SelectedView = customerViewModel);
            SelectCustomerView = new RelayCommand(() => SelectedView = _custView);
            SelectEmployeeView = new RelayCommand(() => SelectedView = _employeeView);

        }
        //private ICustomerDataService _customerDataService;
        //private CapstoneCustomer _selectedCustomer;


        //public MainViewModel(ICustomerDataService customerDataService)
        //{
        //    CapstoneCustomers = new ObservableCollection<CapstoneCustomer>();
        //    _customerDataService = customerDataService;
        //}

        //public async Task LoadAsync()
        //{
        //    var customers = await _customerDataService.GetAllCustomersAsync();

        //    CapstoneCustomers.Clear();

        //    foreach (var customer in customers)
        //    {
        //        CapstoneCustomers.Add(customer);
        //    }
        //}

        //public ObservableCollection<CapstoneCustomer> CapstoneCustomers { get; set; }


        //public CapstoneCustomer SelectedCustomer
        //{
        //    get { return _selectedCustomer; }
        //    set
        //    {
        //        _selectedCustomer = value;
        //        OnPropertyChanged();
        //    }
        //}

    }
}
