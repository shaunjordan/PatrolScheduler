using PatrolScheduler.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PatrolScheduler.Helpers
{
    public class ErrorValidation : BaseNotify, INotifyDataErrorInfo
    {
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

        protected virtual void ErrorDictChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void AddErrors(string propertyName, string error)
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

        protected void ClearErrors(string propertyName)
        {
            if (_errorDictionary.ContainsKey(propertyName))
            {
                _errorDictionary.Remove(propertyName);
                ErrorDictChanged(propertyName);
            }
        }
    }
}
