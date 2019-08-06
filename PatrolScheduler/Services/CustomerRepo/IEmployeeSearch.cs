using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Models;

namespace PatrolScheduler.Services
{
    public interface IEmployeeSearch
    {
        Task<IEnumerable<EmployeeSearchModel>> SearchEmployees(string empName);
    }
}