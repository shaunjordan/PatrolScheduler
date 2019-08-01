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
            DeleteCommand = new DelegateCommand(OnDeleteExecute);
            
        }

        private async void OnDeleteExecute()
        {
            employeeDataService.Remove(Employee.Model);
            await employeeDataService.SaveAsync();

            eventAggregator.GetEvent<EmployeeDeletedEvent>().Publish(Employee.EmployeeId);
        }

        private async void OnSaveExecute()
        {
            await employeeDataService.SaveAsync();
            eventAggregator.GetEvent<EmployeeSavedEvent>().Publish(new EmployeeSavedEventArgs
            {
                EmployeeId = Employee.EmployeeId,
                DisplayMember = Employee.FirstName + " " + Employee.LastName
            });
        }

        private bool OnSaveCanExecute()
        {
            return Employee != null && !Employee.HasErrors;
        }
        

        public async Task LoadAsync(int? employeeId)
        {
            CapstoneEmployee employee;

            if (employeeId.HasValue)
            {
                employee = await employeeDataService.GetModelAsync(employeeId.Value);
            }
            else
            {
                employee = CreateEmployee();
            }

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
            employeeDataService.Add(employee);
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

        public ICommand DeleteCommand { get; }
    }
}
