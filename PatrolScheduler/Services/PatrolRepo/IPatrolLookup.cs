using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatrolScheduler.Models;

namespace PatrolScheduler.Services.PatrolRepo
{
    public interface IPatrolLookup
    {
        Task<List<PatrolLookupModel>> PatrolLookupAsync();
    }
}