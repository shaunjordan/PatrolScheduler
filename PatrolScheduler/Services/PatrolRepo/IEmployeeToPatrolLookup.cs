using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Models;

namespace PatrolScheduler.Services.PatrolRepo
{
    public interface IEmployeeToPatrolLookup
    {
        Task<IEnumerable<LookupModel>> GetEmployeeDetails();
    }
}