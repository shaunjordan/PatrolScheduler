using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Models
{
    public class EmployeeSearchModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BadgeNumber { get; set; }
        public DateTime HireDate { get; set; }
    }
}
