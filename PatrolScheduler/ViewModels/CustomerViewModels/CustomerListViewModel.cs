using PatrolScheduler.Events;
using PatrolScheduler.Models;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels
{
    public class CustomerListViewModel : BaseNotify, ICustomerListViewModel
    {
        /*
         * This ViewModel provides a list of customers via a LookupService in "Services"
         * which returns a CustomerId and CustomerName - no need to load the entire customer
         * into a small list item
         * 
         */

        private readonly ILookupService lookupService;
        private readonly IEventAggregator eventAggregator;

        public CustomerListViewModel(ILookupService lookupService, IEventAggregator eventAggregator)
        {
            this.lookupService = lookupService;
            this.eventAggregator = eventAggregator;
            Customers = new ObservableCollection<CustomerSelectViewModel>();
            eventAggregator.GetEvent<CustomerSavedEvent>().Subscribe(CustomerSaved);
        }

        private void CustomerSaved(CustomerSavedEventArgs obj)
        {
           var item = Customers.SingleOrDefault(lookup => lookup.Id == obj.CustomerId);

            if (item == null)
            {
                Customers.Add(new CustomerSelectViewModel(obj.CustomerId, obj.DisplayMember, eventAggregator));
            }
            else
            {
                item.DisplayMember = obj.DisplayMember;
            }
            
        }

        public async Task LoadCustomerAsync()
        {
            var lookup = await lookupService.CustomerLookupAsync();
            Customers.Clear();
            foreach (var customer in lookup)
            {
                Customers.Add(new CustomerSelectViewModel(customer.Id, customer.DisplayMember, eventAggregator));
            }
        }

        public ObservableCollection<CustomerSelectViewModel> Customers { get; }

    }
    
}
