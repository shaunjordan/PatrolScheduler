using PatrolScheduler.Database;
using PatrolScheduler.Events;
using PatrolScheduler.Helpers;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModels.EmployeeViewModels
{
    public class EmployeeDetailViewModel : BaseNotify, IEmployeeDetailViewModel

    {
        private IEventAggregator eventAggregator;
        private IEmployeeDataService employeeDataService;

        public EmployeeDetailViewModel(IEmployeeDataService employeeDataService,IEventAggregator eventAggregator)
        {
            
            this.employeeDataService = employeeDataService;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<EmployeeDetailEvent>().Subscribe(EmployeeDetailActivated);
            //TODO: add subscribe and save methods
        }

        private async void EmployeeDetailActivated(int employeeId)
        {
            await LoadAsync(employeeId);
        }

        public async Task LoadAsync(int employeeId)
        {
            var employee = await employeeDataService.GetEmployeeAsync(employeeId);

            Employee = new EmployeeHelper(employee);
            //add employee
        }

        private EmployeeHelper _employee;

        public EmployeeHelper Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
    }
}
