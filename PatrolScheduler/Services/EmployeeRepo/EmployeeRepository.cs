using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services
{
    public class EmployeeRepository : BaseRepository<CapstoneEmployee, CapstoneDatabase>, IEmployeeRepository
    {
       

        public EmployeeRepository(CapstoneDatabase context) : base(context)
        {
            
        }

        public override async Task<CapstoneEmployee> GetModelAsync(int employeeId)
        {         
            
            return await context.CapstoneEmployees.SingleAsync(emp => emp.EmployeeId == employeeId);
            
        }
              
    }
}
