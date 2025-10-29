using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Services.Interfaces
{
    public interface IAuthorService : IBaseService<Author, AuthorDto>
    {
        Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorsWithBookCountAsync();
        Task<IEnumerable<Author>> FindAuthorsByNameAsync(string namePart);
    }

}
