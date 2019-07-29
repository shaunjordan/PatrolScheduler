using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModels;
using PatrolScheduler.ViewModels.EmployeeViewModels;
using PatrolScheduler.Views;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModel
{
    public class MainViewModel : BaseNotify
    {
        /*
         * 
         * MainViewModel is responsible for loading the application and passing the interfaces to each of the views
         * Views are loaded through a RelayCommand and their appropriate ViewModels are passed as parameters
         * 
         */

        
        private CustomerView _custView;
        private EmployeeView _employeeView;
        private PatrolScheduleView _scheduleView;
        
        public ICommand SelectCustomerView { get; private set; }
        public ICommand SelectEmployeeView { get; private set; }
        public ICommand SelectScheduleView { get; private set; }
        public ICommand ExitCommand { get; private set; }
      
        //SelectedView property bound to the Dockpanel menu items on the MainWindow view
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

        // Views are loaded here via RelayCommand along with their view models and data services        
        public MainViewModel(ICustomerListViewModel _customerListViewModel,
            ICustomerRepository _customerDataService, 
            Func<ICustomerDetailViewModel> _customerDetailViewModel,
            IEmployeeRepository _employeeDataService,
            IEmployeeListViewModel _employeeListViewModel,
            Func<IEmployeeDetailViewModel> _employeeDetailViewModel,IEventAggregator _eventAggregator)
        {
            
            _custView = new CustomerView(_customerListViewModel, _customerDataService, _customerDetailViewModel, _eventAggregator);
            _employeeView = new EmployeeView(_employeeListViewModel, _employeeDataService, _employeeDetailViewModel, _eventAggregator);
            _scheduleView = new PatrolScheduleView();
            
            SelectCustomerView = new RelayCommand(() => SelectedView = _custView);
            SelectEmployeeView = new RelayCommand(() => SelectedView = _employeeView);
            SelectScheduleView = new RelayCommand(() => SelectedView = _scheduleView);
            ExitCommand = new RelayCommand(() => Shutdown());

        }

        private void Shutdown()
        {
            Shutdown();
        }

        
    }
}
