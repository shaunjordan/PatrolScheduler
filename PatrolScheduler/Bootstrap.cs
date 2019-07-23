using Autofac;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
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

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<CustomerDataService>().As<ICustomerDataService>();

            return builder.Build();

        }
    }
}
