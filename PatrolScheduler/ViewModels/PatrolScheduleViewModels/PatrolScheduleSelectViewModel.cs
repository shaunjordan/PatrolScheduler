using PatrolScheduler.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels.PatrolScheduleViewModels
{
    public class PatrolScheduleSelectViewModel : BaseNotify
    {
        private IEventAggregator _eventAggregator;
        

        public PatrolScheduleSelectViewModel(int patrolId, string cDisplayMember, string eDisplayMember, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            PatrolId = patrolId;

        }

        public int PatrolId { get; }

        private string _cDisplayMember;

        public string CDisplayMember
        {
            get { return _cDisplayMember; }
            set { _cDisplayMember = value; OnPropertyChanged(); }
        }

        private string _eDisplayMember;

        public string EDisplayMember
        {
            get { return _eDisplayMember; }
            set { _eDisplayMember = value; OnPropertyChanged(); }
        }        

    }
}
