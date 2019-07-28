using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModels;
using Prism.Events;
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
    /*
     * 
     * Code behind of main CustomerView loads the appropriate viewmodels for the two main sections
     * 
     */
    public partial class CustomerView : UserControl
    {
        //TODO: add better comments throughout and remove old commented code
        private ICustomerRepository CustomerDataService;
        private ICustomerListViewModel CustomerListViewModel;
        private Func<ICustomerDetailViewModel> CustomerDetailViewlModel;
        private IEventAggregator EventAggregator;
        private CustomerViewModel _customerViewModel;


        public CustomerView(ICustomerListViewModel _customerListViewModel,
            ICustomerRepository _customerDataService,
            Func<ICustomerDetailViewModel> _customerDetailViewModel, IEventAggregator _eventAggregator)
        {
            InitializeComponent();
            CustomerDataService = _customerDataService;
            CustomerListViewModel = _customerListViewModel;
            CustomerDetailViewlModel = _customerDetailViewModel;
            EventAggregator = _eventAggregator;

            _customerViewModel = new CustomerViewModel(CustomerListViewModel, CustomerDataService, CustomerDetailViewlModel, EventAggregator);
            this.DataContext = _customerViewModel;
                       
            Loaded += CustomerView_Loaded;
        }

        private async void CustomerView_Loaded(object sender, RoutedEventArgs e)
        {
            await _customerViewModel.LoadAsync();            
        }

        

    }
}
