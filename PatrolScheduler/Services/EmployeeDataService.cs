using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private CapstoneDatabase _capstoneDbContext;

        public EmployeeRepository(CapstoneDatabase capstoneDbContext)
        {
            _capstoneDbContext = capstoneDbContext;
        }

        public void Add(CapstoneEmployee employee)
        {
            _capstoneDbContext.CapstoneEmployees.Add(employee);
        }

        public async Task<CapstoneEmployee> GetEmployeeAsync(int employeeId)
        {            
            
            return await _capstoneDbContext.CapstoneEmployees.SingleAsync(emp => emp.EmployeeId == employeeId);
            
        }


    }
}
