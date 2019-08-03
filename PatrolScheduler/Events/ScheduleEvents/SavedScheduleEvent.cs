using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Events.ScheduleEvents
{
    public class SavedScheduleEvent : PubSubEvent<ScheduleSavedEventArgs>
    {
    }

    public class ScheduleSavedEventArgs
    {
        public int PatrolId { get; set; }
        public string DisplayMember { get; set; }
    }
}
