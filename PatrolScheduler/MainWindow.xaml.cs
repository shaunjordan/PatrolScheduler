using PatrolScheduler.Database;
using PatrolScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PatrolScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            _mainViewModel = viewModel;

            DataContext = _mainViewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _mainViewModel.LoadAsync();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var context = new CapstoneDatabase())
        //    {

        //        var result = context.GetUser("test", "test");

        //        if (result != null)
        //        {
        //            MessageBox.Show(result.ToString());
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid Username or Password");
        //        }
        //    }
        //}

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
