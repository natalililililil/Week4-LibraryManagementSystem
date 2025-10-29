using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Repository.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<object>> GetAuthorsWithBookCountAsync();
        Task<IEnumerable<Author>> FindAuthorsByNameAsync(string namePart);
    }
}
