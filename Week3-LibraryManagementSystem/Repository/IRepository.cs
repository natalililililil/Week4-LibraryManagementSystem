using Week3_LibraryManagementSystem.Models;

namespace Week3_LibraryManagementSystem.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T? GetById(Guid id);
        T Create(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
    }
}
