﻿using PatrolScheduler.Database;
using PatrolScheduler.Events;
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
        private Func<ICustomerDetailViewModel> _customerDetailViewModelFunc;
        private IEventAggregator _eventAggregator;


        public CustomerViewModel(ICustomerListViewModel customerListViewModel, 
            ICustomerRepository customerDataService, 
            Func<ICustomerDetailViewModel> customerDetailViewModelFunc, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator; 
            _customerDetailViewModelFunc = customerDetailViewModelFunc;

            eventAggregator.GetEvent<CustomerDetailEvent>().Subscribe(CustomerDetailActivated);
            eventAggregator.GetEvent<CustomerDeletedEvent>().Subscribe(CustomerDeleted);

            CustomerListViewModel = customerListViewModel;

            CreateCustomerCommand = new DelegateCommand(OnCreateCustomer);
        }

        private void CustomerDeleted(int id)
        {
            CustomerDetailViewModel = null;
        }

        private ICustomerDetailViewModel _customerDetailViewModel;

        public ICustomerDetailViewModel CustomerDetailViewModel
        {
            get { return _customerDetailViewModel; }
            private set { _customerDetailViewModel = value; OnPropertyChanged(); }
        }


        public async Task LoadAsync()
        {
            await CustomerListViewModel.LoadCustomerAsync();          
        }

        public ICommand CreateCustomerCommand { get; }

        private void OnCreateCustomer()
        {
            CustomerDetailActivated(null);            
        }

        
        private async void CustomerDetailActivated(int? customerId)
        {
            CustomerDetailViewModel = _customerDetailViewModelFunc();
            await CustomerDetailViewModel.LoadAsync(customerId);
        }

    }
}
