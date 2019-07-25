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

    public class CustomerDataService : ICustomerDataService
    {
        private Func<CapstoneDatabase> _capstoneDbContext;

        public CustomerDataService(Func<CapstoneDatabase> capstoneDbContext)
        {
            _capstoneDbContext = capstoneDbContext;
        }
                

        public async Task<List<CapstoneCustomer>> GetAllCustomersAsync()
        {          
            using (var context = _capstoneDbContext())
            {
                return await context.CapstoneCustomers.AsNoTracking().ToListAsync();
            }
        }

        public async Task SaveAsync(CapstoneCustomer capstoneCustomer)
        {
            using (var context = _capstoneDbContext())
            {
                context.CapstoneCustomers.Attach(capstoneCustomer);
                context.Entry(capstoneCustomer).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
