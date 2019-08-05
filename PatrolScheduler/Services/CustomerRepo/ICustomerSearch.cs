using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Models;

namespace PatrolScheduler.Services
{
    public interface ICustomerSearch
    {
        Task<IEnumerable<CustomerReportModel>> SearchCustomers(string customerName);
    }
}