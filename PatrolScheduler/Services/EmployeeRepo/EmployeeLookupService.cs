using PatrolScheduler.Database;
using PatrolScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services
{
    public class EmployeeLookupService : IEmployeeLookupService
    {
        private Func<CapstoneDatabase> _context;

        public EmployeeLookupService(Func<CapstoneDatabase> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LookupModel>> EmployeeLookupAsync()
        {
            using (var context = _context())
            {
                return await context.CapstoneEmployees.AsNoTracking().Select(emp => new LookupModel
                {
                    Id = emp.EmployeeId,
                    DisplayMember = emp.FirstName + " " + emp.LastName
                }).ToListAsync();
            }
        }
    }
}
