using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels
{
    public interface ICustomerListViewModel
    {
        Task LoadCustomerAsync();
    }
}