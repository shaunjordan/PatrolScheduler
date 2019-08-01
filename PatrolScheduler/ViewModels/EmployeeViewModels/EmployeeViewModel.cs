using PatrolScheduler.Database;
using PatrolScheduler.Events;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using PatrolScheduler.ViewModels.EmployeeViewModels;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModels
{
    public class EmployeeViewModel : BaseNotify
    {

       
        public IEmployeeListViewModel EmployeeListViewModel { get;  }
        private Func<IEmployeeDetailViewModel> _employeeDetailViewModelFunc;
        private IEventAggregator _eventAggregator;

        public EmployeeViewModel(IEmployeeListViewModel employeeListViewModel,
            IEmployeeRepository employeeDataService,
            Func<IEmployeeDetailViewModel> employeeDetailViewModelFunc, IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            _employeeDetailViewModelFunc = employeeDetailViewModelFunc;

            _eventAggregator.GetEvent<EmployeeDetailEvent>().Subscribe(EmployeeDetailActivated);
            _eventAggregator.GetEvent<EmployeeDeletedEvent>().Subscribe(EmployeeDeleted);

            CreateEmployeeCommand = new DelegateCommand(OnCreateEmployee);
            EmployeeListViewModel = employeeListViewModel;          
            

        }

        private void EmployeeDeleted(int id)
        {
            EmployeeDetailViewModel = null;
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


        private void OnCreateEmployee()
        {
            EmployeeDetailActivated(null);
        }

        public ICommand CreateEmployeeCommand { get; }

    }
}
