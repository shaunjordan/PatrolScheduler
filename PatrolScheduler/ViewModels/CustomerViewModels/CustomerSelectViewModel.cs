﻿using PatrolScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels
{
    public class CustomerSelectViewModel : BaseNotify
    {
        
        private string _displayMember;

        public CustomerSelectViewModel(int id, string displayMember)
        {
            Id = id;
            DisplayMember = displayMember;
        }

        public int Id { get; }


        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

    }
}