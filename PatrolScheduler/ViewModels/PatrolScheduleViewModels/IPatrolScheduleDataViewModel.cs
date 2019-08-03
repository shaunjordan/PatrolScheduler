using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels.PatrolScheduleViewModels
{
    public interface IPatrolScheduleDataViewModel
    {
        Task LoadPatrolsAsync();
    }
}