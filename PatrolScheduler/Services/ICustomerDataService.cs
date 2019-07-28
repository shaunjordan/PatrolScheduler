using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Database;

namespace PatrolScheduler.Services
{
    public interface ICustomerRepository
    {
        Task<CapstoneCustomer> GetCustomerAsync(int customerId);

        Task SaveAsync();
        void Add(CapstoneCustomer customer);
    }
}