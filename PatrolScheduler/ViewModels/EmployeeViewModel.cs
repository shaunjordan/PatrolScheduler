using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
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

        private IEmployeeDataService _employeeDataService;
        private CapstoneEmployee _selectedEmployee;

        public EmployeeViewModel(IEmployeeDataService employeeDataService)
        {
            CapstoneEmployees = new ObservableCollection<CapstoneEmployee>();

            _employeeDataService = employeeDataService;
        }
        
        public ObservableCollection<CapstoneEmployee> CapstoneEmployees { get; set; }

        public async Task LoadEmployeesAsync()
        {
            var employees = await _employeeDataService.GetAllEmployeesAsync();

            CapstoneEmployees.Clear();

            foreach (var employee in employees)
            {
                CapstoneEmployees.Add(employee);
            }
        }

        

        public CapstoneEmployee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

    }
}
