using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Services.Interfaces
{
    public interface IBaseService<TEntity, TDto, TKey>
        where TEntity : class, IEntity<TKey>
        where TDto : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity> CreateAsync(TDto entity);
        Task<bool> UpdateAsync(TKey id, TDto entity);
        Task<bool> DeleteAsync(TKey id);
    }
}
