using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        public List<CapstoneCustomer> GetAllCustomers()
        {
            //yield return new CapstoneCustomer { CustomerId = 1, CustomerName = "Test These Industries" };
            using (var context = new CapstoneDatabase())
            {
                return context.CapstoneCustomer.AsNoTracking().ToList();
            }
        }
    }
}
