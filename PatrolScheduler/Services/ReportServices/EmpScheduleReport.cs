using PatrolScheduler.Database;
using PatrolScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services.ReportServices
{
    public class EmpScheduleReport : IEmpScheduleReport
    {
        private Func<CapstoneDatabase> _context;

        public EmpScheduleReport(Func<CapstoneDatabase> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpScheduleModel>> EmpScheduleLookup()
        {
            using (var context = _context())
            {
                var report = from emp in context.CapstoneEmployees
                             join pat in context.CapstonePatrols on emp.EmployeeId equals pat.EmployeeId
                             join cust in context.CapstoneCustomers on pat.CustomerId equals cust.CustomerId
                             select new EmpScheduleModel()
                             {
                                 EmployeeName = emp.FirstName + " " + emp.LastName,
                                 CustomerName = cust.CustomerName,
                                 PatrolStart = pat.PatrolStart,
                                 PatrolEnd = pat.PatrolEnd
                             };
                return await report.ToListAsync();
            }
        }
    }
}
