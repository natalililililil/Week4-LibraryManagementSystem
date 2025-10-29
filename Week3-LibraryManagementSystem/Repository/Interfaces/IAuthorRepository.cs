using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Repository.Interfaces
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
        Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorsWithBookCountAsync();
        Task<IEnumerable<Author>> FindAuthorsByNameAsync(string namePart);
    }
}
