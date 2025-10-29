using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Repository.Interfaces
{
    public interface IRepository<T, TKey> where T : class, IEntity<TKey>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(TKey id);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(TKey id);
    }
}
