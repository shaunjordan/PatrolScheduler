using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services
{

    public class CustomerRepository : BaseRepository<CapstoneCustomer, CapstoneDatabase>, ICustomerRepository
    {
        

        public CustomerRepository(CapstoneDatabase context) : base(context)
        {            
        }
               

        public override async Task<CapstoneCustomer> GetModelAsync(int customerId)
        {

            return await context.CapstoneCustomers.SingleAsync(customer => customer.CustomerId == customerId);

        }

        
    }
}
