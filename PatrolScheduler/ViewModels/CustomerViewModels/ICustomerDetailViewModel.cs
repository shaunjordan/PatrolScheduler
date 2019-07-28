using PatrolScheduler.Database;
using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels
{
    public interface ICustomerDetailViewModel
    {
        Task LoadAsync(int? customerId);
        
    }
}