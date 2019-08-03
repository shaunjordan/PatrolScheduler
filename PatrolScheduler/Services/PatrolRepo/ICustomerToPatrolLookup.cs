using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Models;

namespace PatrolScheduler.Services.PatrolRepo
{
    public interface ICustomerToPatrolLookup
    {
        Task<IEnumerable<LookupModel>> GetCustomerDetails();
        
    }
}