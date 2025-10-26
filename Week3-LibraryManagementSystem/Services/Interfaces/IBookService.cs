using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task<Book> CreateAsync(BookDto dto);
        Task<bool> UpdateAsync(Guid id, BookDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
