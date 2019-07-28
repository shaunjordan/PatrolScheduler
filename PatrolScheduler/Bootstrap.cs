﻿using Autofac;
using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using PatrolScheduler.ViewModels;
using PatrolScheduler.ViewModels.EmployeeViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler
{
    public class Bootstrap
    {
        public IContainer Bootstrapper()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<EmployeeDataService>().As<IEmployeeDataService>();
            builder.RegisterType<LookupService>().AsImplementedInterfaces();
            builder.RegisterType<EmployeeLookupService>().AsImplementedInterfaces();

            builder.RegisterType<CustomerDetailViewModel>().As<ICustomerDetailViewModel>();
            builder.RegisterType<CustomerListViewModel>().As<ICustomerListViewModel>();
            builder.RegisterType<EmployeeDetailViewModel>().As<IEmployeeDetailViewModel>();
            builder.RegisterType<EmployeeListViewModel>().As<IEmployeeListViewModel>();

            builder.RegisterType<EmployeeViewModel>().AsSelf();
            builder.RegisterType<CustomerViewModel>().AsSelf();
            builder.RegisterType<CapstoneDatabase>().AsSelf();

            return builder.Build();

        }
    }
}
