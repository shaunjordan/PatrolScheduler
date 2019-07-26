using PatrolScheduler.Database;
using PatrolScheduler.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Helpers
{
    public class CustomerHelper : BaseNotify, INotifyDataErrorInfo
    {
        public CustomerHelper(CapstoneCustomer customer)
        {
            Customer = customer;
        }

        public CapstoneCustomer Customer { get; }

        public int CustomerId
        {
            get { return Customer.CustomerId; }
            set
            {
                Customer.CustomerId = value;
                OnPropertyChanged();
            }
        }

        public string CustomerName
        {
            get { return Customer.CustomerName; }
            set
            {
                Customer.CustomerName = value;
                OnPropertyChanged();
                ValidateProperty(nameof(CustomerName));
            }
        }        

        public string Address1
        {
            get { return Customer.Address1; }
            set
            {
                Customer.Address1 = value;
                OnPropertyChanged();
            }
        }

        public string Address2
        {
            get { return Customer.Address2; }
            set
            {
                Customer.Address2 = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get { return Customer.City; }
            set
            {
                Customer.City = value;
                OnPropertyChanged();
            }
        }       

        public string ZipCode
        {
            get { return Customer.ZipCode; }
            set
            {
                Customer.ZipCode = value;
                OnPropertyChanged();
            }
        }

        public string State
        {
            get { return Customer.State; }
            set
            {
                Customer.State = value;
                OnPropertyChanged();
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);

            switch (propertyName)
            {
                case nameof(CustomerName):
                    if (string.Equals(CustomerName, "Robot"))
                    {
                        AddErrors(propertyName, "Robots are not valid friends");
                    }
                    break;
            }
        }

        private Dictionary<string, List<string>> _errorDictionary = new Dictionary<string, List<string>>();

        public bool HasErrors => _errorDictionary.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

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

        private void ErrorDictChanged(string propertyName)
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
                ErrorDictChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errorDictionary.ContainsKey(propertyName))
            {
                _errorDictionary.Remove(propertyName);
                ErrorDictChanged(propertyName);
            }
        }
    }
}
