using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels.PatrolScheduleViewModels
{
    public interface IPatrolScheduleDetailViewModel
    {
        Task LoadSchedule(int? patrolId);
    }
}