using PatrolScheduler.Database;
using PatrolScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services.PatrolRepo
{
    public class PatrolLookup : IPatrolLookup, ICustomerToPatrolLookup, IEmployeeToPatrolLookup
    {
        private Func<CapstoneDatabase> _context;

        public PatrolLookup(Func<CapstoneDatabase> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatrolLookupModel>> PatrolLookupAsync()
        {
            using (var dbContext = _context())
            {

                var result = from p in dbContext.CapstonePatrols
                             join c in dbContext.CapstoneCustomers on p.CustomerId equals c.CustomerId
                             join e in dbContext.CapstoneEmployees on p.EmployeeId equals e.EmployeeId
                             select new PatrolLookupModel()
                             {
                                 Id = p.PatrolId,
                                 CustomerName = c.CustomerName,
                                 EmployeeName = e.FirstName + " " + e.LastName,
                                 Start = p.PatrolStart,
                                 End = p.PatrolEnd
                             };

                return await result.ToListAsync();

            }
        }


        public async Task<IEnumerable<LookupModel>> GetCustomerDetails()
        {
            using (var dbContext = _context())
            {

                return await dbContext.CapstoneCustomers.AsNoTracking().Select(customer => new LookupModel
                {
                    Id = customer.CustomerId,
                    DisplayMember = customer.CustomerName
                }).ToListAsync(); ;

            }
        }

        public async Task<IEnumerable<LookupModel>> GetEmployeeDetails()
        {
            using (var dbContext = _context())
            {

                return await dbContext.CapstoneEmployees.AsNoTracking().Select(emp => new LookupModel
                {
                    Id = emp.EmployeeId,
                    DisplayMember = emp.FirstName + " " + emp.LastName
                }).ToListAsync(); ;

            }
        }

    }
}
