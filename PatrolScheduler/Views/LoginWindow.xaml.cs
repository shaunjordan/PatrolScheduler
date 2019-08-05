using PatrolScheduler.Database;
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
using System.Windows.Shapes;

namespace PatrolScheduler.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string user = UserName.Text;
            string pass = Password.ToString();

            //if (user == "test" && pass == "test")
            //{
            //    this.DialogResult = true;
            //    this.Close();
            //}

            using (var context = new CapstoneDatabase())
            {
                var result = context.GetUser(user, pass);
                if (result != null)
                {
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
        }

    }
}
