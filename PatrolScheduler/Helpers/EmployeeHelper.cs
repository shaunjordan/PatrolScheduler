﻿using PatrolScheduler.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.Helpers
{
    public class EmployeeHelper : ModelWrapper<CapstoneEmployee>
    {
        public EmployeeHelper(CapstoneEmployee model) : base(model)
        {
            
        }

        
        public int EmployeeId
        {
            get { return GetValue<int>(); }
            set
            {
                Model.EmployeeId = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public string LastName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public DateTime HireDate
        {
            get { return GetValue<DateTime>(); }
            set
            {
                SetValue(value);
            }
        }

        public int BadgeNumber
        {
            get { return GetValue<int>(); }
            set
            {
                SetValue(value);
            }
        }

        public int PatrolCar
        {
            get { return GetValue<int>(); }
            set
            {
                SetValue(value);
            }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (String.IsNullOrWhiteSpace(FirstName))
                    {
                        yield return "First Name is required";
                    }
                    break;
                case nameof(LastName):
                    if (String.IsNullOrWhiteSpace(LastName))
                    {
                        yield return "Last Name is required";
                    }
                    break;
                
            }
        }
    }
}
