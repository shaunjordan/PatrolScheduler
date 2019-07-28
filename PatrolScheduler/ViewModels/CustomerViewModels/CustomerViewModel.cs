using PatrolScheduler.Database;
using PatrolScheduler.Models;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModels
{
    public class CustomerViewModel : BaseNotify
    {      
        
        /*
         * This class is responsible for loading the separate ViewModels in the main CustomerView
         * which are CustomerListViewModel and CustomerDetailViewModel
         * Each are passed arguments from the MainViewModelClass onload
         * 
         */

        public ICustomerListViewModel CustomerListViewModel { get; }
        public ICustomerDetailViewModel CustomerDetailViewModel { get; }

        public CustomerViewModel(ICustomerListViewModel customerListViewModel, 
            ICustomerDataService customerDataService, 
            ICustomerDetailViewModel customerDetailViewModel)
        {

            CustomerListViewModel = customerListViewModel;
            CustomerDetailViewModel = customerDetailViewModel;            
        }

       

        public async Task LoadAsync()
        {
            await CustomerListViewModel.LoadCustomerAsync();          
        }
        
        
    }
}
