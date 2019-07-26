using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels
{
    public class CustomerDetailViewModel : BaseNotify, ICustomerDetailViewModel
    {
        private readonly ICustomerDataService customerDataService;

        public CustomerDetailViewModel(ICustomerDataService customerDataService)
        {
            this.customerDataService = customerDataService;
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

    }
}
