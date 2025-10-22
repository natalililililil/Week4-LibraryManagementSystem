using Week3_LibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week3_LibraryManagementSystem.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected abstract List<T> DbSet { get; }

        public Task<T> CreateAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            DbSet.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var entity = DbSet.FirstOrDefault(x => x.Id == id);
            if (entity == null) 
                return Task.FromResult(false);

            DbSet.Remove(entity);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(DbSet.AsEnumerable());
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(DbSet.FirstOrDefault(x => x.Id == id));
        }

        public abstract Task<bool> UpdateAsync(T entity);
    }
}
