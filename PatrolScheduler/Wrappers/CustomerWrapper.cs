using PatrolScheduler.Database;
using PatrolScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Wrappers
{
    public class CustomerWrapper : BaseNotify
    {
        public CustomerWrapper(CapstoneCustomer customer)
        {
            Customer = customer;
        }

        public CapstoneCustomer Customer { get; set; }

        public int CustomerId { get { return Customer.CustomerId; } }
                

        public string CustomerName
        {
            get { return Customer.CustomerName; }
            set
            {
                Customer.CustomerName = value;
                OnPropertyChanged();
            }
        }

    }
}
