using PatrolScheduler.Database;
using PatrolScheduler.Events;
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
            await customerDataService.SaveAsync(Customer);
            eventAggregator.GetEvent<CustomerSavedEvent>().Publish(new CustomerSavedEventArgs
            {
                Id = Customer.CustomerId,
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
            Customer = await customerDataService.GetCustomerAsync(customerId);
        }
        

        private CapstoneCustomer _customer;

        public CapstoneCustomer Customer
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
