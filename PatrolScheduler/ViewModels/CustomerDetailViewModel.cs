using PatrolScheduler.Database;
using PatrolScheduler.Events;
using PatrolScheduler.Helpers;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModels
{
    /*
     * This class loads customer details into their appropriate textboxes so they can be altered and saved
     * It subscribes to the CustomerDetailActivate in order to Load the full details of the selected Customer
     *  
     */

    public class CustomerDetailViewModel : BaseNotify, ICustomerDetailViewModel
    {
        private readonly ICustomerDataService customerDataService;
        private readonly IEventAggregator eventAggregator;

        public CustomerDetailViewModel(ICustomerDataService customerDataService, IEventAggregator eventAggregator)
        {
            this.customerDataService = customerDataService;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<CustomerDetailEvent>().Subscribe(CustomerDetailActivated);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private async void OnSaveExecute()
        {
            //Customer.Customer is the CapstoneCustomer declared in the CustomerHelper class
            await customerDataService.SaveAsync(Customer.Model);
            eventAggregator.GetEvent<CustomerSavedEvent>().Publish(new CustomerSavedEventArgs
            {
                CustomerId = Customer.CustomerId,
                DisplayMember = Customer.CustomerName
            });
        }

        private bool OnSaveCanExecute()
        {
            //TODO: is friend valid
            return true;
        }


        private async void CustomerDetailActivated(int customerId)
        {
            await LoadAsync(customerId);
        }

        public async Task LoadAsync(int customerId)
        {
            var customer = await customerDataService.GetCustomerAsync(customerId);

            Customer = new CustomerHelper(customer);
        }
        
        /*
         * CustomerHelper allows for data validation here to prevent the viewmodel from growing too large
         * 
         */
        private CustomerHelper _customer;

        public CustomerHelper Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

    }
}
