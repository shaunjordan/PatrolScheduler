using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Events
{
    public class EmployeeDeletedEvent : PubSubEvent<int>
    {
    }
}
