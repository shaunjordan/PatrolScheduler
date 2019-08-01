using System.Threading.Tasks;

namespace PatrolScheduler.Services
{
    public interface IBaseRepository<T>
    {
        Task<T> GetModelAsync(int id);

        Task SaveAsync();
        void Add(T model);
        void Remove(T model);
    }
}