using System.Collections.Generic;
using System.Threading.Tasks;
using PatrolScheduler.Models;

namespace PatrolScheduler.Services.ReportServices
{
    public interface IEmpScheduleReport
    {
        Task<IEnumerable<EmpScheduleModel>> EmpScheduleLookup();
    }
}