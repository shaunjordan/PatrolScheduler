using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Services
{
    public class GetCustomerData
    {
        private CapstoneDatabase _context = new CapstoneDatabase();

        public async Task<List<CapstoneCustomer>> GetAllCustomersAsync()
        {
            using (_context)
            {
                return await _context.CapstoneCustomers.AsNoTracking().ToListAsync();
            }
        }
    }
}
