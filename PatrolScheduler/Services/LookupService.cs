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
    public class LookupService : ILookupService
    {
        private readonly Func<CapstoneDatabase> _databaseContext;

        public LookupService(Func<CapstoneDatabase> context)
        {
            _databaseContext = context;
        }

        public async Task<IEnumerable<LookupModel>> CustomerLookupAsync()
        {
            using (var context = _databaseContext())
            {
                return await context.CapstoneCustomers.AsNoTracking().Select(customer => new LookupModel
                {
                    Id = customer.CustomerId,
                    DisplayMember = customer.CustomerName
                }).ToListAsync();
            }
        }
    }
}
