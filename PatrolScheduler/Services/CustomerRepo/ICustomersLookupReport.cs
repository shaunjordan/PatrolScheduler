using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Models;

namespace PatrolScheduler.Services
{
    public interface ICustomersLookupReport
    {
        Task<IEnumerable<CustomerReportModel>> GetCustomerReport();
    }
}