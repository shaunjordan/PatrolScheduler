using PatrolScheduler.Services.PatrolRepo;
using PatrolScheduler.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels.PatrolScheduleViewModels
{
    public class PatrolScheduleViewModel : BaseNotify
    {
        private IEventAggregator _eventAggregator;
        private Func<IPatrolScheduleDetailViewModel> _patrolScheduleDetailViewModelFunc;
        public IPatrolScheduleDataViewModel PatrolDataViewModel { get; }

        public PatrolScheduleViewModel(IPatrolScheduleDataViewModel patrolDataViewModel,
            IPatrolRepository patrolRepository,
            Func<IPatrolScheduleDetailViewModel> patrolScheduleDetailViewModelFunc, //detail view model is the combo box selections and whatnot
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _patrolScheduleDetailViewModelFunc = patrolScheduleDetailViewModelFunc;

            //get events

            PatrolDataViewModel = patrolDataViewModel;
        }

        public async Task LoadAsync()
        {
            await PatrolDataViewModel.LoadPatrolsAsync();
        }
    }
}
