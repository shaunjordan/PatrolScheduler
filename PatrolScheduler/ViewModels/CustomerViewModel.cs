using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using PatrolScheduler.Wrappers;
using Prism.Commands;
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
    public class CustomerViewModel : BaseNotify, INotifyDataErrorInfo
    {
        //private ICustomerDataService _customerDataService;
        //private CapstoneCustomer _selectedCustomer;

        // ICustomerDataService customerDataService param for viewmodel


        public ICustomerListViewModel CustomerListViewModel { get; }
        public ICustomerDetailViewModel CustomerDetailViewModel { get; }

        public CustomerViewModel(ICustomerListViewModel customerListViewModel, 
            ICustomerDataService customerDataService, 
            ICustomerDetailViewModel customerDetailViewModel)
        {

            CustomerListViewModel = customerListViewModel;
            CustomerDetailViewModel = customerDetailViewModel;
            //CapstoneCustomers = new ObservableCollection<CapstoneCustomer>();
            //_customerDataService = customerDataService;

            //SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        //private async void OnSaveExecute()
        //{
        //    await _customerDataService.SaveAsync(SelectedCustomer);
        //}

        //private bool OnSaveCanExecute()
        //{
        //    //TODO: is friend valid
        //    return true;
        //}

        //public CustomerViewModel()
        //{
        //    CapstoneCustomers = new ObservableCollection<CapstoneCustomer>();

        //    //_customerDataService = customerDataService;
        //}

        public async Task LoadAsync()
        {

            await CustomerListViewModel.LoadCustomerAsync();
            //var customers = await _customerDataService.GetAllCustomersAsync();                       

            //CapstoneCustomers.Clear();

            //foreach (var customer in customers)
            //{
            //    CapstoneCustomers.Add(customer);
            //}
        }

       

        //public ObservableCollection<CapstoneCustomer> CapstoneCustomers { get; set; }


        //public CapstoneCustomer SelectedCustomer
        //{
        //    get { return _selectedCustomer; }
        //    set
        //    {
        //        _selectedCustomer = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public CapstoneCustomer SelectedCustomer
        //{
        //    get { return _selectedCustomer; }
        //    set
        //    {
        //        _selectedCustomer = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string _custName;

        

        //public string CustName
        //{
        //    get { return _custName; }
        //    set
        //    {
        //        _custName = SelectedCustomer.CustomerName;
        //        OnPropertyChanged();
        //        ValidateProperty(nameof(_custName));

        //    }
        //}

        //private void ValidateProperty(string propertyName)
        //{
        //    ClearErrors(propertyName);

        //    switch (propertyName)
        //    {
        //        case nameof(_custName):
        //            if (string.Equals(_custName, "Robot"))
        //            {
        //                AddErrors(propertyName, "Robots are not valid friends");
        //            }
        //            break;
        //    }

        //}

        public ICommand SaveCommand { get; }

        /// <summary>
        /// /////////////////////
        /// </summary>

        private Dictionary<string, List<string>> _errorDictionary = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => _errorDictionary.Any();

        public IEnumerable GetErrors(string propertyName)
        {            
            if (_errorDictionary.ContainsKey(propertyName))
            {
                return _errorDictionary[propertyName];
            }
            else
            {
                return null;
            }
        }

        private void OnErrorDictChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddErrors(string propertyName, string error)
        {
            if (!_errorDictionary.ContainsKey(propertyName))
            {
                _errorDictionary[propertyName] = new List<string>();
            }
            if (!_errorDictionary[propertyName].Contains(error))
            {
                _errorDictionary[propertyName].Add(error);
                OnErrorDictChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errorDictionary.ContainsKey(propertyName))
            {
                _errorDictionary.Remove(propertyName);
                OnErrorDictChanged(propertyName);
            }
        }
    }
}
