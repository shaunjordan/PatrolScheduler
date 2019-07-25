using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly Func<CapstoneDatabase> _capstoneDbContext;

        public EmployeeDataService(Func<CapstoneDatabase> capstoneDbContext)
        {
            _capstoneDbContext = capstoneDbContext;
        }

       public async Task<List<CapstoneEmployee>> GetAllEmployeesAsync()
        {
            using (var context = _capstoneDbContext())
            {
                return await context.CapstoneEmployees.AsNoTracking().ToListAsync();
            }
        }
    }
}
