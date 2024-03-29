﻿using PatrolScheduler.Events;
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

            eventAggregator.GetEvent<EmployeeSavedEvent>().Subscribe(EmployeeSaved);
            eventAggregator.GetEvent<EmployeeDeletedEvent>().Subscribe(EmployeeDeleted);

        }

        private void EmployeeDeleted(int employeeId)
        {
            var employee = Employees.SingleOrDefault(emp => emp.Id == employeeId);
            if (employee != null)
            {
                Employees.Remove(employee);
            }
        }

        private void EmployeeSaved(EmployeeSavedEventArgs obj)
        {
            var item = Employees.SingleOrDefault(lookup => lookup.Id == obj.EmployeeId);

            if (item == null)
            {
                Employees.Add(new EmployeeSelectViewModel(obj.EmployeeId, obj.DisplayMember, _eventAggregator));
            }
            else
            {
                item.DisplayMember = obj.DisplayMember;
            }
        }        

        public async Task LoadEmployeeAsync()
        {
            var lookup = await _employeeLookupService.EmployeeLookupAsync();
            Employees.Clear();

            foreach (var employee in lookup)
            {
                Employees.Add(new EmployeeSelectViewModel(employee.Id, employee.DisplayMember, _eventAggregator));
            }
        }

        public ObservableCollection<EmployeeSelectViewModel> Employees { get; }

    }
}
