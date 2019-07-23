using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Database;

namespace PatrolScheduler.Services
{
    public interface ICustomerDataService
    {
        Task<List<CapstoneCustomer>> GetAllCustomersAsync();
    }
}