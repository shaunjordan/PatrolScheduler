using System.Collections.Generic;
using PatrolScheduler.Database;

namespace PatrolScheduler.Services
{
    public interface ICustomerDataService
    {
        IEnumerable<CapstoneCustomer> GetAllCustomers();
    }
}