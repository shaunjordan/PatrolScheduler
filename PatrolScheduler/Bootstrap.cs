using Autofac;
using PatrolScheduler.Database;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using PatrolScheduler.ViewModels;
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
            builder.RegisterType<CustomerDataService>().As<ICustomerDataService>();
            builder.RegisterType<EmployeeDataService>().As<IEmployeeDataService>();
            builder.RegisterType<LookupService>().AsImplementedInterfaces();

            builder.RegisterType<CustomerDetailViewModel>().As<ICustomerDetailViewModel>();
            builder.RegisterType<CustomerListViewModel>().As<ICustomerListViewModel>();
            builder.RegisterType<EmployeeViewModel>().AsSelf();
            builder.RegisterType<CustomerViewModel>().AsSelf();
            builder.RegisterType<CapstoneDatabase>().AsSelf();

            return builder.Build();

        }
    }
}
