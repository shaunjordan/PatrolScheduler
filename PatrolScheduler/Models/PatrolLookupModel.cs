using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Models
{
    public class PatrolLookupModel
    {

        public int Id { get; set; }

        public string CustomerName { get; set; }

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
