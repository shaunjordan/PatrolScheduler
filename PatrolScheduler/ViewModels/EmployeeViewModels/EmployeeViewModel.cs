using PatrolScheduler.Database;
using PatrolScheduler.Events;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using PatrolScheduler.ViewModels.EmployeeViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels
{
    public class EmployeeViewModel : BaseNotify
    {

        //public IEmployeeDataService _employeeDataService;
        public IEmployeeListViewModel EmployeeListViewModel { get;  }
        private Func<IEmployeeDetailViewModel> _employeeDetailViewModelFunc;
        private IEventAggregator _eventAggregator;

        public EmployeeViewModel(IEmployeeListViewModel employeeListViewModel,
            IEmployeeRepository employeeDataService,
            Func<IEmployeeDetailViewModel> employeeDetailViewModelFunc, IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            _employeeDetailViewModelFunc = employeeDetailViewModelFunc;

            EmployeeListViewModel = employeeListViewModel;

            _eventAggregator.GetEvent<EmployeeDetailEvent>().Subscribe(EmployeeDetailActivated);
            

        }

        

        public async Task LoadAsync()
        {
            await EmployeeListViewModel.LoadEmployeeAsync();
        }

        private IEmployeeDetailViewModel _employeeDetailViewModel;

        public IEmployeeDetailViewModel EmployeeDetailViewModel
        {
            get { return _employeeDetailViewModel; }
            private set
            {
                _employeeDetailViewModel = value; OnPropertyChanged();
            }
        }

        private async void EmployeeDetailActivated(int? employeeId)
        {
            EmployeeDetailViewModel = _employeeDetailViewModelFunc();
            await EmployeeDetailViewModel.LoadAsync(employeeId);
        }

    }
}
