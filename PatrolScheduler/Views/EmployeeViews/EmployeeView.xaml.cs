using PatrolScheduler.Services;
using PatrolScheduler.ViewModels;
using PatrolScheduler.ViewModels.EmployeeViewModels;
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
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        private IEmployeeRepository EmployeeDataService;
        private IEmployeeListViewModel EmployeeListViewModel;
        private Func<IEmployeeDetailViewModel> EmployeeDetailViewModel;
        private IEventAggregator EventAggregator;
        private EmployeeViewModel _employeeViewModel;

        public EmployeeView(IEmployeeListViewModel _employeeListViewModel,
            IEmployeeRepository _employeeDataService,
            Func<IEmployeeDetailViewModel> _employeeDetailViewModel,
            IEventAggregator _eventAggregator)
        {
            InitializeComponent();

            EmployeeDataService = _employeeDataService;
            EmployeeListViewModel = _employeeListViewModel;
            EmployeeDetailViewModel = _employeeDetailViewModel;
            EventAggregator = _eventAggregator;

            _employeeViewModel = new EmployeeViewModel(EmployeeListViewModel, EmployeeDataService, EmployeeDetailViewModel, EventAggregator);
            this.DataContext = _employeeViewModel;

            Loaded += EmployeeView_Loaded;
        }

        private async void EmployeeView_Loaded(object sender, RoutedEventArgs e)
        {
            await _employeeViewModel.LoadAsync();
        }
    }
}
