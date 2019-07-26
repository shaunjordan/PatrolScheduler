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
           var item = Customers.Single(lookup => lookup.Id == obj.Id);
            item.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadCustomerAsync()
        {
            var lookup = await lookupService.CustomerLookupAsync();
            Customers.Clear();
            foreach (var customer in lookup)
            {
                Customers.Add(new CustomerSelectViewModel(customer.Id, customer.DisplayMember));
            }
        }

        public ObservableCollection<CustomerSelectViewModel> Customers { get; }

        private CustomerSelectViewModel _selectedCustomer;

        public CustomerSelectViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
                if (_selectedCustomer != null)
                {
                    eventAggregator.GetEvent<CustomerDetailEvent>().Publish(_selectedCustomer.Id);
                }
            }
        }
    }
    
}
