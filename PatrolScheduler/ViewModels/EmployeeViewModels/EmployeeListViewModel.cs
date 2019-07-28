using PatrolScheduler.Events;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels.EmployeeViewModels
{
    public class EmployeeListViewModel : BaseNotify, IEmployeeListViewModel
    {
        private IEmployeeLookupService _employeeLookupService;
        private IEventAggregator _eventAggregator;

        public EmployeeListViewModel(IEmployeeLookupService employeeLookupService, IEventAggregator eventAggregator)
        {
            this._employeeLookupService = employeeLookupService;
            this._eventAggregator = eventAggregator;

            Employees = new ObservableCollection<EmployeeSelectViewModel>();
            //Add customer saved event here

        }

        public ObservableCollection<EmployeeSelectViewModel> Employees { get; }

        public async Task LoadEmployeeAsync()
        {
            var lookup = await _employeeLookupService.EmployeeLookupAsync();
            Employees.Clear();

            foreach (var employee in lookup)
            {
                Employees.Add(new EmployeeSelectViewModel(employee.Id, employee.DisplayMember));
            }
        }

        private EmployeeSelectViewModel _selectedEmployee;

        public EmployeeSelectViewModel SelectedeEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
                if (_selectedEmployee != null)
                {
                    _eventAggregator.GetEvent<EmployeeDetailEvent>().Publish(_selectedEmployee.Id);
                }
            }
        }
    }
}
