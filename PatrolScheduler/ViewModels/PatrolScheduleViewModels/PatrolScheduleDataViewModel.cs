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
using System.IO;
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

            Patrols = new ObservableCollection<PatrolLookupModel>();
            

            eventAggregator.GetEvent<SavedScheduleEvent>().Subscribe(ScheduleSaved);
        }

        private async void ScheduleSaved(ScheduleSavedEventArgs obj)
        {
            var item = Patrols.SingleOrDefault(s => s.Id == obj.PatrolId);
            Patrols.Clear();
            if (item == null)
            {
                Patrols.Add(new PatrolLookupModel {
                    Id = obj.PatrolId,
                    CustomerName = obj.CustomerName,
                    EmployeeName = obj.EmployeeName,
                    Start = obj.PatrolStart,
                    End = obj.PatrolEnd
                });
            }
            else
            {
                item.CustomerName = obj.CustomerName;
                item.EmployeeName = obj.EmployeeName;
                item.Start = obj.PatrolStart;
                item.End = obj.PatrolEnd;
            }

            await LoadPatrolsAsync();
        }

        
        public ObservableCollection<PatrolLookupModel> Patrols { get; }
        

        public async Task LoadPatrolsAsync()
        {            

            var lookup = await patrolLookup.PatrolLookupAsync();
            Patrols.Clear();
            foreach (var patrol in lookup)
            {
                Patrols.Add(patrol);
            }

            
        }


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
