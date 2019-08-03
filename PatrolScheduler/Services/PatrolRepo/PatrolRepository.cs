using PatrolScheduler.Database;
using PatrolScheduler.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services.PatrolRepo
{
    public class PatrolRepository : BaseRepository<CapstonePatrol, CapstoneDatabase>, IPatrolRepository
    {
        public PatrolRepository(CapstoneDatabase context) : base(context)
        {
        }

        public override async Task<CapstonePatrol> GetModelAsync(int patrolId)
        {
            return await context.CapstonePatrols.SingleAsync(p => p.PatrolId == patrolId);

            //TODO:  remove all of this
            //var result = context.CapstonePatrols
            //    .Where(p => p.PatrolId == patrolId)
            //    .Include(c => c.CapstoneCustomer.CustomerName)
            //    .Include(e => e.CapstoneEmployee.FirstName + " " + e.CapstoneEmployee.LastName)
            //    .SingleAsync();

            //return await result;

            //from patrol in context.CapstonePatrols
            //join cc in context.CapstoneCustomers on patrol.CustomerId equals cc.CustomerId
            //join ce in context.CapstoneEmployees on patrol.EmployeeId equals ce.EmployeeId
            //select new {}

            //var result = from p in context.CapstonePatrols
            //             join c in context.CapstoneCustomers on p.CustomerId equals c.CustomerId
            //             join e in context.CapstoneEmployees on p.EmployeeId equals e.EmployeeId
            //             select new ScheduleHelper()
            //             {
            //                 PatrolId = p.PatrolId,
            //                 CustomerName = c.CustomerName,
            //                 EmployeeName = e.FirstName + " " + e.LastName,
            //                 PatrolStart = p.PatrolStart,
            //                 PatrolEnd = p.PatrolEnd
            //             };

            //return await result;

        }
    }
}
