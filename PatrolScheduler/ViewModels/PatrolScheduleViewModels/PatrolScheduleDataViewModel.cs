using PatrolScheduler.Database;
using PatrolScheduler.Events.ScheduleEvents;
using PatrolScheduler.Models;
using PatrolScheduler.Services.PatrolRepo;
using PatrolScheduler.ViewModel;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

            //Patrols = new ObservableCollection<PatrolLookupModel>();
            Patrols = new ObservableCollection<PatrolScheduleSelectViewModel>();
            //EditCommand = new DelegateCommand(EditScheduleActivated);

            eventAggregator.GetEvent<SavedScheduleEvent>().Subscribe(ScheduleSaved);
        }

        private void ScheduleSaved(ScheduleSavedEventArgs obj)
        {
            var item = Patrols.SingleOrDefault(s => s.PatrolId == obj.PatrolId);
            if (item == null)
            {
                //Patrols.Add()
            }
            else
            {
                item.CDisplayMember = obj.DisplayMember;
            }
        }

        //private void EditScheduleActivated()
        //{
        //    eventAggregator.GetEvent<ScheduleDetailEvent>().Publish();
        //}

        //public ObservableCollection<PatrolLookupModel> Patrols { get; }
        public ObservableCollection<PatrolScheduleSelectViewModel> Patrols { get; }

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
            //foreach (var patrol in lookup)
            //{
            //    Patrols.Add(patrol);
            //}
            foreach (var patrol in lookup)
            {
                Patrols.Add(new PatrolScheduleSelectViewModel(patrol.Id, patrol.CustomerName, patrol.EmployeeName, eventAggregator));
            }
        }

        //private PatrolLookup _patrol;

        //public PatrolLookup Patrol
        //{
        //    get { return _patrol; }
        //    set
        //    {
        //        _patrol = value;
        //        OnPropertyChanged();
        //    }
        //}

        private PatrolLookupModel selectedPatrol;

        public PatrolLookupModel SelectedPatrol
        {
            get { return selectedPatrol; }
            set
            {
                selectedPatrol = value;
                OnPropertyChanged();
                eventAggregator.GetEvent<ScheduleDetailEvent>().Publish(selectedPatrol.Id);
            }
        }

        public ICommand EditCommand { get; }


    }
}
