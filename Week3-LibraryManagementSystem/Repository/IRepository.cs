using Week3_LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Week3_LibraryManagementSystem.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
