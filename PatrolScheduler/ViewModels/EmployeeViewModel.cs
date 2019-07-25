using PatrolScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels
{
    public class EmployeeViewModel : BaseNotify
    {
        ObservableCollection<string> Employees = new ObservableCollection<string> { "one", "two", "three" };
    }
}
