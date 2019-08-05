using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Models
{
    public class EmpScheduleModel
    {
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public DateTime PatrolStart { get; set; }
        public DateTime PatrolEnd { get; set; }

    }
}
