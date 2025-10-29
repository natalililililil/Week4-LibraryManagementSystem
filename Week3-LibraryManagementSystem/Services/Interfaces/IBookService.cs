using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> CreateAsync(BookDto dto);
        Task<bool> UpdateAsync(int id, BookDto dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Book>> GetBooksAfterYearAsync(int year);
    }
}
