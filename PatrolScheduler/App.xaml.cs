using Autofac;
using PatrolScheduler.Services;
using PatrolScheduler.ViewModel;
using PatrolScheduler.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PatrolScheduler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            //try
            //{
            //    if (new LoginWindow().ShowDialog() == true)
            //    {
            //        var bootstrap = new Bootstrap();
            //        var container = bootstrap.Bootstrapper();

            //        var mainWindow = container.Resolve<MainWindow>();


            //        mainWindow.ShowDialog();
            //    }
            //}
            //finally
            //{

            //    Shutdown();
            //}

            var bootstrap = new Bootstrap();
            var container = bootstrap.Bootstrapper();

            var mainWindow = container.Resolve<MainWindow>();


            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Oops! Something went wrong. Please contact your administrator. Message: " + e.Exception.Message);
            e.Handled = true;
        }
    }
}
