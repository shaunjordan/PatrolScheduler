using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PatrolScheduler.Helpers
{
    public class ModelWrapper<T> : ErrorValidation
    {
        public ModelWrapper(T model)
        {
            Model = model;
        }

        public T Model { get; }

        protected virtual Tv GetValue<Tv>([CallerMemberName]string propertyName = null)
        {
            return (Tv)typeof(T).GetProperty(propertyName).GetValue(Model);
        }

        protected virtual void SetValue<Tval>(Tval val, [CallerMemberName]string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model, val);
            OnPropertyChanged();
            ValidateThisProperty(propertyName);
        }

        private void ValidateThisProperty(string propertyName)
        {
            ClearErrors(propertyName);

            var errors = ValidateProperty(propertyName);
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    AddErrors(propertyName, error);
                }
            }
        }

        protected virtual IEnumerable<string> ValidateProperty(string propertyName)
        {
            return null;   
        }
    }
}
