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
    public class PatrolLookup : IPatrolLookup
    {
        private Func<CapstoneDatabase> _context;

        public PatrolLookup(Func<CapstoneDatabase> context)
        {
            _context = context;
        }

        public async Task<List<PatrolLookupModel>> PatrolLookupAsync()
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

                //return await (from patrols in dbContext.CapstonePatrols
                //              join cust in dbContext.CapstoneCustomers on patrols.CustomerId equals cust.CustomerId
                //              join emp in dbContext.CapstoneEmployees on patrols.EmployeeId equals emp.EmployeeId
                //              select new
                //              {
                //                  cust.CustomerName,
                //                  emp.FirstName,
                //                  Patrol = patrols.CapstoneCustomer
                //             }).ToListAsync();

               
                //return await dbContext.CapstonePatrols.AsNoTracking().Select(patrol => new LookupModel
                //{
                //    Id = patrol.PatrolId,
                //    DisplayMember = "Patrol"
                //}).ToListAsync();
            }
        }

        /*
         * private Func<CapstoneDatabase> _context;

        public PatrolLookupModel(Func<CapstoneDatabase> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patrol>>
         * 
         */
    }
}
