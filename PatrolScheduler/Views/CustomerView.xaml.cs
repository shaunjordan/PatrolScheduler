﻿using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PatrolScheduler.Views
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        //TODO: add better comments throughout and remove old commented code
        private ICustomerDataService CustomerDataService;
        private ICustomerListViewModel CustomerListViewModel;
        private ICustomerDetailViewModel CustomerDetailViewlModel;
        private CustomerViewModel _customerViewModel;


        public CustomerView(ICustomerListViewModel _customerListViewModel, 
            ICustomerDataService _customerDataService,
            ICustomerDetailViewModel _customerDetailViewModel)
        {
            InitializeComponent();
            CustomerDataService = _customerDataService;
            CustomerListViewModel = _customerListViewModel;
            CustomerDetailViewlModel = _customerDetailViewModel;
            
            _customerViewModel = new CustomerViewModel(CustomerListViewModel, CustomerDataService, CustomerDetailViewlModel);
            this.DataContext = _customerViewModel;

            //_customerViewModel = customerViewModel;

            //CustomerViewModel _customerViewModel = new CustomerViewModel();

            //DataContext = _customerViewModel;


            Loaded += CustomerView_Loaded;
        }

        private async void CustomerView_Loaded(object sender, RoutedEventArgs e)
        {
            await _customerViewModel.LoadAsync();
            
        }


        //public CustomerView(CustomerViewModel customerViewModel)
        //{
        //    InitializeComponent();

        //    _customerViewModel = customerViewModel;

        //    DataContext = _customerViewModel;

        //}



    }
}
