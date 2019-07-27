using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Helpers
{
    public class CustomerHelper : ModelWrapper<CapstoneCustomer>
    {
        public CustomerHelper(CapstoneCustomer model) : base(model)
        {
        }

        public int CustomerId
        {
            get { return GetValue<int>(); }
            set
            {
                Model.CustomerId = value;
                OnPropertyChanged();
            }
        }

        public string CustomerName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);

            }
        }



        public string Address1
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public string Address2
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public string City
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public string ZipCode
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public string State
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }
                    

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(CustomerName):
                    if (string.Equals(CustomerName, "Robot"))
                    {
                        yield return "Robots are not valid friends";
                    }
                    break;
            }
        }
    }
}
