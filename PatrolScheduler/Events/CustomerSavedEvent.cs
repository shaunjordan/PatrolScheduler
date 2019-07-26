using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Events
{
    class CustomerSavedEvent : PubSubEvent<CustomerSavedEventArgs>
    {
    }

    public class CustomerSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
