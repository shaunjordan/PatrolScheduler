using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Helpers
{
    public class ScheduleHelper : ModelWrapper<CapstonePatrol>
    {

        public ScheduleHelper(CapstonePatrol model) : base(model)
        {
        }

        public int PatrolId
        {
            get { return GetValue<int>(); }
            set
            {
                Model.PatrolId = value;
                OnPropertyChanged();
            }

        }

        public int CustomerId
        {
            get { return GetValue<int>(); }
            set
            {
                SetValue(value);
            }
        }

        public int EmployeeId
        {
            get { return GetValue<int>(); }
            set
            {
                SetValue(value);
            }
        }
                

        public DateTime PatrolStart
        {
            get { return GetValue<DateTime>(); }
            set
            {
                SetValue(value);
            }
        }

        public DateTime PatrolEnd
        {
            get { return GetValue<DateTime>(); }
            set
            {
                SetValue(value);
            }
        }
    }
}
