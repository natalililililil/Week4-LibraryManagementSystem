using Week3_LibraryManagementSystem.Data;
using System.Linq;
using System.Threading.Tasks;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;

namespace Week3_LibraryManagementSystem.Repository.Implementations
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        protected override List<Book> DbSet => DataStore.Books;

        public override Task<bool> UpdateAsync(Book newBookData)
        {
            var oldBookData = DbSet.FirstOrDefault(b => b.Id == newBookData.Id);
            if (oldBookData == null) 
                return Task.FromResult(false);

            oldBookData.Title = newBookData.Title;
            oldBookData.PublishedYear = newBookData.PublishedYear;
            oldBookData.AuthorId = newBookData.AuthorId;
            return Task.FromResult(true);
        }
    }
}
