using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author> CreateAsync(AuthorDto dto);
        Task<bool> UpdateAsync(int id, AuthorDto dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorSummariesAsync();
        Task<IEnumerable<Author>> FindAuthorsByNameAsync(string namePart);
    }
}
