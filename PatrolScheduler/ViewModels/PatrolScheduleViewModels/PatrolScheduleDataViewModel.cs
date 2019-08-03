using PatrolScheduler.Database;
using PatrolScheduler.Models;
using PatrolScheduler.Services.PatrolRepo;
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
    public class PatrolScheduleDataViewModel : BaseNotify, IPatrolScheduleDataViewModel
    {
        private IEventAggregator eventAggregator;
        private IPatrolLookup patrolLookup;

        public PatrolScheduleDataViewModel(IPatrolLookup patrolLookup,IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.patrolLookup = patrolLookup;

            //Patrols = new ObservableCollection<LookupModel>();

            Patrols = new ObservableCollection<PatrolLookupModel>();
        }

        public ObservableCollection<PatrolLookupModel> Patrols { get; }

        //public async Task LoadPatrolsAsync()
        //{
        //    var lookup = await patrolLookup.PatrolLookupAsync();
        //    Patrols.Clear();
        //    foreach (var patrol in lookup)
        //    {
        //        Patrols.Add(patrol);
        //    }
        //}

        public async Task LoadPatrolsAsync()
        {
            var lookup = await patrolLookup.PatrolLookupAsync();
            Patrols.Clear();
            foreach (var patrol in lookup)
            {
                Patrols.Add(patrol);
            }
        }

    }
}
