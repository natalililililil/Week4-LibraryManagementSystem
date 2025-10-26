using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Services.Interfaces
{
    public interface IBaseService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity> CreateAsync(TDto entity);
        Task<bool> UpdateAsync(Guid id, TDto entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
