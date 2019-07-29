using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels.EmployeeViewModels
{
    public interface IEmployeeDetailViewModel
    {
        Task LoadAsync(int? employeeId);
    }
}