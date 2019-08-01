using PatrolScheduler.Database;
using PatrolScheduler.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels.PatrolScheduleViewModels
{
    public class PatrolScheduleDataViewModel : BaseNotify
    {
        private IEventAggregator eventAggregator;

        public PatrolScheduleDataViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            Patrols = new ObservableCollection<CapstonePatrol>();
        }

        public ObservableCollection<CapstonePatrol> Patrols { get; }

        public async Task LoadPatrolsAsync()
        {
            //implement
        }
    }
}
