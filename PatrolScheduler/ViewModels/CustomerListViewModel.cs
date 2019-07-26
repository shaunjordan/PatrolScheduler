using PatrolScheduler.Models;
using PatrolScheduler.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels
{
    public class CustomerListViewModel : ICustomerListViewModel
    {
        private readonly ILookupService lookupService;

        public CustomerListViewModel(ILookupService lookupService)
        {
            this.lookupService = lookupService;
            Customers = new ObservableCollection<LookupModel>();
        }

        public async Task LoadCustomerAsync()
        {
            var lookup = await lookupService.CustomerLookupAsync();
            Customers.Clear();
            foreach (var customer in lookup)
            {
                Customers.Add(customer);
            }
        }

        public ObservableCollection<LookupModel> Customers { get; }
    }
}
