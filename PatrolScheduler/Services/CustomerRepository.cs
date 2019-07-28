using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services
{
    /*
     
        CapstoneDatabse is registered with Bootstrap as dependency injection
         
    */

    public class CustomerRepository : ICustomerRepository
    {
        private CapstoneDatabase _capstoneDbContext;

        public CustomerRepository(CapstoneDatabase capstoneDbContext)
        {
            _capstoneDbContext = capstoneDbContext;
        }

        public void Add(CapstoneCustomer customer)
        {
            _capstoneDbContext.CapstoneCustomers.Add(customer);
        }

        public async Task<CapstoneCustomer> GetCustomerAsync(int customerId)
        {

            return await _capstoneDbContext.CapstoneCustomers.SingleAsync(customer => customer.CustomerId == customerId);

        }

        public void Remove(CapstoneCustomer model)
        {
             _capstoneDbContext.CapstoneCustomers.Remove(model);
        }

        public async Task SaveAsync()
        {

            await _capstoneDbContext.SaveChangesAsync();

        }
    }
}
