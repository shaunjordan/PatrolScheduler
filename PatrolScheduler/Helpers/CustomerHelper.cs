﻿using PatrolScheduler.Database;
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
                    if (String.IsNullOrWhiteSpace(CustomerName))
                    {
                        yield return "Customer Name is required";
                    }
                    break;
                case nameof(Address1):
                    if (String.IsNullOrWhiteSpace(Address1))
                    {
                        yield return "Address 1 is required";
                    }
                    break;
                case nameof(City):
                    if (String.IsNullOrWhiteSpace(Address1))
                    {
                        yield return "City is required";
                    }
                    break;
                case nameof(State):
                    if (String.IsNullOrWhiteSpace(State))
                    {
                        yield return "State is required";
                    }
                    if (State.Length != 2)
                    {
                        yield return "State must be 2 characters";
                    }
                    break;
                case nameof(ZipCode):
                    if (String.IsNullOrWhiteSpace(Address1))
                    {
                        yield return "Zip code is required";
                    }
                    break;
            }   
        }
    }
}
