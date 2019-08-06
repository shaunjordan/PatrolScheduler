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
    public class LookupService : ILookupService, ICustomersLookupReport, ICustomerSearch, IEmployeeSearch
    {
        private Func<CapstoneDatabase> _databaseContext;

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

        public async Task<IEnumerable<CustomerReportModel>> GetCustomerReport()
        {
            using (var context = _databaseContext())
            {
                return await context.CapstoneCustomers.AsNoTracking().Select(customer => new CustomerReportModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    Address1 = customer.Address1,
                    Address2 = customer.Address2,
                    City = customer.City,
                    State = customer.State,
                    ZipCode = customer.ZipCode

                }).ToListAsync();
            }
        }

        public async Task<IEnumerable<CustomerReportModel>> SearchCustomers(string customerName)
        {
            using (var context = _databaseContext())
            {
                var result = from c in context.CapstoneCustomers
                             .Where(c => c.CustomerName.Contains(customerName))
                             select new CustomerReportModel()
                             {
                                 CustomerId = c.CustomerId,
                                 CustomerName = c.CustomerName,
                                 Address1 = c.Address1,
                                 Address2 = c.Address2,
                                 City = c.City,
                                 State = c.State,
                                 ZipCode = c.ZipCode
                             };

                return await result.ToListAsync();
            }
        }

        public async Task<IEnumerable<EmployeeSearchModel>> SearchEmployees(string empName)
        {
            using (var context = _databaseContext())
            {
                var result = from e in context.CapstoneEmployees
                             .Where(e => e.FirstName.Contains(empName))                             
                             select new EmployeeSearchModel()
                             {
                                 EmployeeId = e.EmployeeId,
                                 FirstName = e.FirstName,
                                 LastName = e.LastName,
                                 BadgeNumber = e.BadgeNumber.Value,
                                 HireDate = e.HireDate.Value
                             };

                return await result.ToListAsync();
            }
        }
    }
}
