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
        private ICustomerRepository customerDataService;
        private IEventAggregator eventAggregator;

        public CustomerDetailViewModel(ICustomerRepository customerDataService, IEventAggregator eventAggregator)
        {
            this.customerDataService = customerDataService;
            this.eventAggregator = eventAggregator;
            //eventAggregator.GetEvent<CustomerDetailEvent>().Subscribe(CustomerDetailActivated);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute);

        }

        private async void OnDeleteExecute()
        {
            customerDataService.Remove(Customer.Model);
            await customerDataService.SaveAsync();
            eventAggregator.GetEvent<CustomerDeletedEvent>().Publish(Customer.CustomerId);
        }

        private async void OnSaveExecute()
        {
            //Customer.Customer is the CapstoneCustomer declared in the CustomerHelper class
            await customerDataService.SaveAsync();
            eventAggregator.GetEvent<CustomerSavedEvent>().Publish(new CustomerSavedEventArgs
            {
                CustomerId = Customer.CustomerId,
                DisplayMember = Customer.CustomerName
            });
        }

        private bool OnSaveCanExecute()
        {
            //TODO: is customer valid
            return Customer != null && !Customer.HasErrors;
        }
        
        public async Task LoadAsync(int? customerId)
        {
            var customer = customerId.HasValue ? await customerDataService.GetCustomerAsync(customerId.Value) : CreateCustomer();
                

            Customer = new CustomerHelper(customer);

            Customer.PropertyChanged += (p, c) =>
            {
                if (c.PropertyName == nameof(Customer.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            if (Customer.CustomerId == 0)
            {
                Customer.CustomerName = "";
            }
        }

        private CapstoneCustomer CreateCustomer()
        {
            var customer = new CapstoneCustomer();
            customerDataService.Add(customer);
            return customer;
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

        public ICommand DeleteCommand { get; }

    }
}
