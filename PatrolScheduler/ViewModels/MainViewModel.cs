using PatrolScheduler.Database;
using PatrolScheduler.Models;
using PatrolScheduler.Services;
using PatrolScheduler.Services.PatrolRepo;
using PatrolScheduler.Services.ReportServices;
using PatrolScheduler.ViewModels;
using PatrolScheduler.ViewModels.EmployeeViewModels;
using PatrolScheduler.ViewModels.PatrolScheduleViewModels;
using PatrolScheduler.ViewModels.SearchViewModels;
using PatrolScheduler.Views;
using PatrolScheduler.Views.SearchViews;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
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
        private SearchView _searchView;
        private IEmpScheduleReport _empScheduleReport;
        private ICustomersLookupReport _customerLookupReport;

        public ICommand SelectCustomerView { get; private set; }
        public ICommand SelectEmployeeView { get; private set; }
        public ICommand SelectScheduleView { get; private set; }
        public ICommand SelectSearchView { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand GenerateEmployeeSchedules { get; private set; }
        public ICommand GenerateCustomerReport { get; private set; }

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
            Func<IEmployeeDetailViewModel> _employeeDetailViewModel,
            IEventAggregator _eventAggregator, 
            IPatrolScheduleDataViewModel _patrolScheduleDataViewModel,
            IPatrolRepository _patrolRepository,
            Func<IPatrolScheduleDetailViewModel> _patrolScheduleDetailViewModel,
            IEmpScheduleReport empScheduleReport,
            ICustomersLookupReport customerLookupReport,
            ISearchViewModel _searchViewModel)
        {
            
            _custView = new CustomerView(_customerListViewModel, _customerDataService, _customerDetailViewModel, _eventAggregator);
            _employeeView = new EmployeeView(_employeeListViewModel, _employeeDataService, _employeeDetailViewModel, _eventAggregator);
            _scheduleView = new PatrolScheduleView(_patrolScheduleDataViewModel, _patrolRepository, _patrolScheduleDetailViewModel, _eventAggregator);
            _searchView = new SearchView(_searchViewModel);
            _empScheduleReport = empScheduleReport;
            _customerLookupReport = customerLookupReport;

            SelectCustomerView = new RelayCommand(() => SelectedView = _custView);
            SelectEmployeeView = new RelayCommand(() => SelectedView = _employeeView);
            SelectScheduleView = new RelayCommand(() => SelectedView = _scheduleView);
            SelectSearchView = new RelayCommand(() => SelectedView = _searchView);

            GenerateEmployeeSchedules = new RelayCommand(async () => await RunEmpScheduleReport());
            GenerateCustomerReport = new RelayCommand(async () => await RunCustomerReport());


            EmpSchedules = new ObservableCollection<EmpScheduleModel>();
            Customers = new ObservableCollection<CustomerReportModel>();


            ExitCommand = new RelayCommand(() => Shutdown());

        }

        private async Task RunCustomerReport()
        {
            string writePath = AppDomain.CurrentDomain.BaseDirectory + @"\CustomersReport.csv";

            var lookup = await _customerLookupReport.GetCustomerReport();
            Customers.Clear();

            foreach (var cust in lookup)
            {
                Customers.Add(cust);
            }


            using (StreamWriter file = new StreamWriter(writePath, false))
            {
                string title = "Customers Report";

                file.WriteLine(title); //Title
                file.WriteLine(DateTime.Now); //Timestamp
                file.WriteLine("Customer Id,Customer Name,Address1,Address2,City,State,Zip Code"); //Headers


                foreach (CustomerReportModel cust in Customers)
                {
                    file.WriteLine(cust.CustomerId.ToString() + "," + cust.CustomerName + "," + cust.Address1 + "," + cust.Address2 + "," + cust.City + "," + cust.State + "," + cust.ZipCode);
                }
                file.Close();
                MessageBox.Show(title + " successfuly created in " + AppDomain.CurrentDomain.BaseDirectory.ToString());
            }
        }

        public ObservableCollection<EmpScheduleModel> EmpSchedules { get; }
        public ObservableCollection<CustomerReportModel> Customers { get; }

        public async Task RunEmpScheduleReport()
        {

            string writePath = AppDomain.CurrentDomain.BaseDirectory + @"\EmployeeSchedule.csv";

            var lookup = await _empScheduleReport.EmpScheduleLookup();
            EmpSchedules.Clear();

            foreach (var empSch in lookup)
            {
                EmpSchedules.Add(empSch);
            }


            using (StreamWriter file = new StreamWriter(writePath, false))
            {
                string title = "Employee Schedule Report";

                file.WriteLine(title); //Title
                file.WriteLine(DateTime.Now); //Timestamp
                file.WriteLine("Employee Name,Customer Name,PatrolStart,PatrolEnd"); //Headers
                

                foreach (EmpScheduleModel empSchedule in EmpSchedules)
                {
                    file.WriteLine(empSchedule.EmployeeName + "," + empSchedule.CustomerName + "," + empSchedule.PatrolStart + "," + empSchedule.PatrolEnd);
                }
                file.Close();
                MessageBox.Show(title + " successfuly created in " + AppDomain.CurrentDomain.BaseDirectory.ToString());
            }           

        }

        private void Shutdown()
        {
            Shutdown();
        }

        
    }
}
