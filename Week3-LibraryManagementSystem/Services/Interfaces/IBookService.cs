using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Services.Interfaces
{
    public interface IBookService : IBaseService<Book, BookDto> 
    {
        Task<IEnumerable<Book>> GetBooksAfterYearAsync(int year);
    }
}
