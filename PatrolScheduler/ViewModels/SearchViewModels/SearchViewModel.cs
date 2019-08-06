using PatrolScheduler.Models;
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

namespace PatrolScheduler.ViewModels.SearchViewModels
{
    public class SearchViewModel : BaseNotify, ISearchViewModel
    {        
        
        private ICustomerSearch _customerLookup;
        private IEmployeeSearch _employeeSearch;

        public SearchViewModel(ICustomerSearch customerLookup, IEmployeeSearch employeeSearch)
        {
            _customerLookup = customerLookup;
            _employeeSearch = employeeSearch;

            SearchCommand = new DelegateCommand(async () => await PopulateResults());
            SearchEmployees = new DelegateCommand(async () => await PopulateEmployees());
        
            Customers = new ObservableCollection<CustomerReportModel>();
            Employees = new ObservableCollection<EmployeeSearchModel>();

            EmpSearch = "Enter employee name";
            Search = "Enter customer name";
        }

        private async Task PopulateEmployees()
        {
            var lookup = await _employeeSearch.SearchEmployees(EmpSearch);
            Employees.Clear();
            foreach (var item in lookup)
            {
                Employees.Add(item);
            }
        }


        public ObservableCollection<CustomerReportModel> Customers { get; }
        public ObservableCollection<EmployeeSearchModel> Employees { get; }

        public async Task PopulateResults()
        {
            var lookup = await _customerLookup.SearchCustomers(Search);
            Customers.Clear();
            foreach (var item in lookup)
            {
                Customers.Add(item);
            }
        }

        private string _search;

        public string Search
        {
            get { return _search; }
            set { _search = value; OnPropertyChanged(); }
        }

        private string _empSearch;

        public string EmpSearch
        {
            get { return _empSearch; }
            set
            {
                _empSearch = value;
                OnPropertyChanged();
            }
        }


        public ICommand SearchCommand { get; }
        public ICommand SearchEmployees { get; }
    }
}
