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
            PatrolStart = DateTime.Parse("01/01/2019");
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
                if (PatrolEnd < PatrolStart)
                {
                    PatrolEnd = PatrolStart;
                }
            }
        }

        public DateTime PatrolEnd
        {
            get { return GetValue<DateTime>(); }
            set
            {
                SetValue(value);
                if (PatrolEnd < PatrolStart)
                {
                    PatrolStart = PatrolEnd;
                }
            }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(PatrolStart):
                    if (PatrolStart > PatrolEnd)
                    {
                        yield return "Start date cannot be after end date";
                    }
                    break;
                case nameof(PatrolEnd):
                    if (PatrolStart > PatrolEnd)
                    {
                        yield return "End date cannot be before start date";
                    }
                    break;

            }
        }
    }
}
