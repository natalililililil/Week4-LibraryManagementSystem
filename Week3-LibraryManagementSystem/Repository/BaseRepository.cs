using Week3_LibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace Week3_LibraryManagementSystem.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected abstract List<T> DbSet { get; }

        public T Create(T entity)
        {
            entity.Id = Guid.NewGuid();
            DbSet.Add(entity);
            return entity;
        }

        public bool Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity == null)
                return false;

            DbSet.Remove(entity);
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public T? GetById(Guid id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public abstract bool Update(T entity);
    }
}