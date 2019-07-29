using PatrolScheduler.Database;
using PatrolScheduler.Events;
using PatrolScheduler.Helpers;
using PatrolScheduler.Services;
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
    public class EmployeeDetailViewModel : BaseNotify, IEmployeeDetailViewModel

    {
        private IEventAggregator eventAggregator;
        private IEmployeeRepository employeeDataService;

        public EmployeeDetailViewModel(IEmployeeRepository employeeDataService,IEventAggregator eventAggregator)
        {
            
            this.employeeDataService = employeeDataService;
            this.eventAggregator = eventAggregator;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            
        }

        private void OnSaveExecute()
        {
            throw new NotImplementedException();
        }

        private bool OnSaveCanExecute()
        {
            throw new NotImplementedException();
        }

        private async void EmployeeDetailActivated(int employeeId)
        {
            await LoadAsync(employeeId);
        }

        public async Task LoadAsync(int? employeeId)
        {
            var employee = employeeId.HasValue ? await employeeDataService.GetEmployeeAsync(employeeId.Value) : CreateEmployee(); 

            Employee = new EmployeeHelper(employee);

            Employee.PropertyChanged += (p, e) =>
            {
                if (e.PropertyName == nameof(Employee.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            if (Employee.EmployeeId == 0)
            {
                Employee.FirstName = "";
            }
        }

        private CapstoneEmployee CreateEmployee()
        {
            var employee = new CapstoneEmployee();
            employeeDataService.Add(employee); //TODO: implement this
            return employee;
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
