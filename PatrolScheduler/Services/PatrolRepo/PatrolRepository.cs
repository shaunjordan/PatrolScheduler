using PatrolScheduler.Database;
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
            return await context.CapstonePatrols
                .Include(p => p.PatrolId)
                .SingleAsync(p => p.PatrolId == patrolId);

            //from patrol in context.CapstonePatrols
            //join cc in context.CapstoneCustomers on patrol.CustomerId equals cc.CustomerId
            //join ce in context.CapstoneEmployees on patrol.EmployeeId equals ce.EmployeeId
            //select new {}
            
        }
    }
}
