using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Database;

namespace PatrolScheduler.Services
{
    public interface IEmployeeDataService
    {
        Task<List<CapstoneEmployee>> GetAllEmployeesAsync();
    }
}