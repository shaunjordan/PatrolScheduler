using PatrolScheduler.Database;
using PatrolScheduler.Events.ScheduleEvents;
using PatrolScheduler.Helpers;
using PatrolScheduler.Models;
using PatrolScheduler.Services.PatrolRepo;
using PatrolScheduler.ViewModel;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatrolScheduler.ViewModels.PatrolScheduleViewModels
{
    public class PatrolScheduleDetailViewModel : BaseNotify, IPatrolScheduleDetailViewModel
    {
        private IPatrolRepository _patrolRepository;
        private IEventAggregator _eventAggregator;
        private ICustomerToPatrolLookup _customerToPatrolLookup;
        private IEmployeeToPatrolLookup _employeeToPatrolLookup;

        public PatrolScheduleDetailViewModel(IPatrolRepository patrolRepository, 
            IEventAggregator eventAggregator,
            ICustomerToPatrolLookup customerToPatrolLookup,
            IEmployeeToPatrolLookup employeeToPatrolLookup)
        {
            _patrolRepository = patrolRepository;
            _eventAggregator = eventAggregator;
            _customerToPatrolLookup = customerToPatrolLookup;
            _employeeToPatrolLookup = employeeToPatrolLookup;

            _eventAggregator.GetEvent<ScheduleDetailEvent>().Subscribe(ScheduleDetailActivated);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute);

            Customers = new ObservableCollection<LookupModel>();
            Employees = new ObservableCollection<LookupModel>();

            
            
        }

        private async void ScheduleDetailActivated(int? patrolId)
        {
            await LoadSchedule(patrolId);
        }

        private async void OnDeleteExecute()
        {
            _patrolRepository.Remove(Schedule.Model);
            await _patrolRepository.SaveAsync();
            _eventAggregator.GetEvent<ScheduleDeletedEvent>().Publish(Schedule.PatrolId);
        }

        private async void OnSaveExecute()
        {
            await _patrolRepository.SaveAsync();
            _eventAggregator.GetEvent<SavedScheduleEvent>().Publish(new ScheduleSavedEventArgs {
                PatrolId = Schedule.PatrolId
            });
        }

        private bool OnSaveCanExecute()
        {
            return Schedule != null && !Schedule.HasErrors;
        }

        public ObservableCollection<LookupModel> Customers { get; }
        public ObservableCollection<LookupModel> Employees { get; }

        public async Task LoadSchedule(int? patrolId)
        {
            //CapstonePatrol patrol;

            //if (patrolId.HasValue)
            //{
            //    await _patrolRepository.GetModelAsync(patrolId.Value);
            //}
            //else
            //{
            //    //implement create customer
            //}

            var patrol = patrolId.HasValue ? await _patrolRepository.GetModelAsync(patrolId.Value) : CreatePatrol();

            Schedule = new ScheduleHelper(patrol);

            Schedule.PropertyChanged += (p, s) =>
            {
                if (s.PropertyName == nameof(Schedule.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            if (Schedule.PatrolId == 0)
            {
                Schedule.PatrolStart = DateTime.Now;
                Schedule.PatrolEnd = DateTime.Now.AddDays(1);
            }

            Customers.Clear();
            Employees.Clear();

            var customerLookup = await _customerToPatrolLookup.GetCustomerDetails();

            foreach (var cust in customerLookup)
            {
                Customers.Add(cust);
            }

            var employeeLookup = await _employeeToPatrolLookup.GetEmployeeDetails();

            foreach (var emp in employeeLookup)
            {
                Employees.Add(emp);
            }
        }

        private CapstonePatrol CreatePatrol()
        {
            var patrol = new CapstonePatrol();
            _patrolRepository.Add(patrol);
            return patrol;
        }

        private ScheduleHelper _schedule; //Patrol helper model

        public ScheduleHelper Schedule
        {
            get { return _schedule; }
            set
            {
                _schedule = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        
    }
}
