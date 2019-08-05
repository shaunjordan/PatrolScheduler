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
        

        public SearchViewModel(ICustomerSearch customerLookup)
        {
            _customerLookup = customerLookup;

            SearchCommand = new DelegateCommand(async () => await PopulateResults());
        
            Customers = new ObservableCollection<CustomerReportModel>();
        }

        private ICustomerSearch _customerLookup;

        public ObservableCollection<CustomerReportModel> Customers { get; }
        
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

        public ICommand SearchCommand { get; }
    }
}
