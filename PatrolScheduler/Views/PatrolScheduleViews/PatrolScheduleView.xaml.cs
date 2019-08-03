using PatrolScheduler.Services.PatrolRepo;
using PatrolScheduler.ViewModels.PatrolScheduleViewModels;
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
    /// Interaction logic for PatrolScheduleView.xaml
    /// </summary>
    public partial class PatrolScheduleView : UserControl
    {
        private IPatrolScheduleDataViewModel PatrolScheduleDataViewModel;
        private IPatrolRepository PatrolRepository;
        private Func<IPatrolScheduleDetailViewModel> PatrolScheduleDetailViewModel;
        private IEventAggregator EventAggregator;
        private PatrolScheduleViewModel _patrolScheduleViewModel;

        public PatrolScheduleView(IPatrolScheduleDataViewModel _patrolScheduleDataViewModel,
            IPatrolRepository _patrolRepository,
            Func<IPatrolScheduleDetailViewModel> _patrolScheduleDetailViewModel, 
            IEventAggregator _eventAggregator)
        {
            InitializeComponent();

            PatrolRepository = _patrolRepository;
            PatrolScheduleDataViewModel = _patrolScheduleDataViewModel;
            PatrolScheduleDetailViewModel = _patrolScheduleDetailViewModel;
            EventAggregator = _eventAggregator;

            _patrolScheduleViewModel = new PatrolScheduleViewModel(_patrolScheduleDataViewModel,
                _patrolRepository,
                _patrolScheduleDetailViewModel,
                _eventAggregator);

            DataContext = _patrolScheduleViewModel;

            Loaded += PatrolScheduleView_Loaded;

        }

        private async void PatrolScheduleView_Loaded(object sender, RoutedEventArgs e)
        {
            await _patrolScheduleViewModel.LoadAsync();
        }
    }
}
