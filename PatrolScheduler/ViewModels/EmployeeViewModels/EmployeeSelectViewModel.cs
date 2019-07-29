using PatrolScheduler.Events;
using PatrolScheduler.ViewModel;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModels.EmployeeViewModels
{
    public class EmployeeSelectViewModel : BaseNotify
    {

        private string _displayMember;
        private IEventAggregator _eventAggregator;

        public EmployeeSelectViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Id = id;
            DisplayMember = displayMember;

            OpenEmployeeDetailCommand = new DelegateCommand(OpenEmployeeDetailExecute);
        }

        private void OpenEmployeeDetailExecute()
        {
            _eventAggregator.GetEvent<EmployeeDetailEvent>().Publish(Id);
        }

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenEmployeeDetailCommand { get; }
    }
}
