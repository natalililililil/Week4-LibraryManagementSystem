using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(Guid id);
        Task<Author> CreateAsync(AuthorDto dto);
        Task<bool> UpdateAsync(Guid id, AuthorDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
