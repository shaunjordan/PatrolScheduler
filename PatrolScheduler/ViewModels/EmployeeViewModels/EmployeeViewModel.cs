using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using PatrolScheduler.ViewModels.EmployeeViewModels;
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
        public IEmployeeDetailViewModel EmployeeDetailViewModel { get; }

        public EmployeeViewModel(IEmployeeListViewModel employeeListViewModel,
            IEmployeeDataService employeeDataService,
            IEmployeeDetailViewModel employeeDetailViewModel)
        {
            EmployeeListViewModel = employeeListViewModel;
            EmployeeDetailViewModel = employeeDetailViewModel;
            
        }

        public async Task LoadAsync()
        {
            await EmployeeListViewModel.LoadEmployeeAsync();
        }        
        

    }
}
