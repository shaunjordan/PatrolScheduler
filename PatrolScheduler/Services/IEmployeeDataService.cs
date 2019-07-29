using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Database;

namespace PatrolScheduler.Services
{
    public interface IEmployeeRepository
    {
        Task<CapstoneEmployee> GetEmployeeAsync(int employeeId);
        void Add(CapstoneEmployee employee);
    }
}