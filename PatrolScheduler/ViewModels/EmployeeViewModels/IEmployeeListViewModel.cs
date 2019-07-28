using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels.EmployeeViewModels
{
    public interface IEmployeeListViewModel
    {
        Task LoadEmployeeAsync();
    }
}