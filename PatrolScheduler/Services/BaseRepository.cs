using System.Data.Entity;
using System.Threading.Tasks;

namespace PatrolScheduler.Services
{
    /*
     
        CapstoneDatabse is registered with Bootstrap as dependency injection
         
    */
    public class BaseRepository<T, Context> : IBaseRepository<T>
        where T:class
        where Context:DbContext
    {
        protected readonly Context context;

        protected BaseRepository(Context context)
        {
            this.context = context;
        }
        public void Add(T model)
        {
            context.Set<T>().Add(model);
        }

        public virtual async Task<T> GetModelAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void Remove(T model)
        {
            context.Set<T>().Remove(model);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
