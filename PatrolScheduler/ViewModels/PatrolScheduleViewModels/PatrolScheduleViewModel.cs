using PatrolScheduler.Events.ScheduleEvents;
using PatrolScheduler.Services.PatrolRepo;
using PatrolScheduler.ViewModel;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModels.PatrolScheduleViewModels
{
    public class PatrolScheduleViewModel : BaseNotify
    {
        private IEventAggregator _eventAggregator;
        private Func<IPatrolScheduleDetailViewModel> _patrolScheduleDetailViewModelFunc;
        public IPatrolScheduleDataViewModel PatrolDataViewModel { get; }
        private IPatrolScheduleDetailViewModel _patrolScheduleDetailViewModel;

        public PatrolScheduleViewModel(IPatrolScheduleDataViewModel patrolDataViewModel,
            IPatrolRepository patrolRepository,
            Func<IPatrolScheduleDetailViewModel> patrolScheduleDetailViewModelFunc, //detail view model is the combo box selections and whatnot
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _patrolScheduleDetailViewModelFunc = patrolScheduleDetailViewModelFunc;

            //get events

            PatrolDataViewModel = patrolDataViewModel;
            eventAggregator.GetEvent<ScheduleDetailEvent>().Subscribe(ScheduleDetailActivated);

            CreateScheduleCommand = new DelegateCommand(OnCreateSchedule);
        }

        private void OnCreateSchedule()
        {
            ScheduleDetailActivated(null);
        }

        public IPatrolScheduleDetailViewModel PatrolScheduleDetailViewModel
        {
            get { return _patrolScheduleDetailViewModel; }
            private set
            {
                _patrolScheduleDetailViewModel = value; OnPropertyChanged();
            }
        }

        private async void ScheduleDetailActivated(int? scheduleId)
        {
            PatrolScheduleDetailViewModel = _patrolScheduleDetailViewModelFunc();
            await PatrolScheduleDetailViewModel.LoadSchedule(scheduleId);
        }

        public async Task LoadAsync()
        {
            await PatrolDataViewModel.LoadPatrolsAsync();
        }

        public ICommand CreateScheduleCommand { get; }
    }
}
