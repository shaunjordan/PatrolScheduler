using System.Threading.Tasks;

namespace PatrolScheduler.ViewModels.SearchViewModels
{
    public interface ISearchViewModel
    {
        Task PopulateResults();
    }
}