using Week3_LibraryManagementSystem.Data;
using Week3_LibraryManagementSystem.Models;

namespace Week3_LibraryManagementSystem.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        protected override List<Book> DbSet => DataStore.Books;

        public override bool Update(Book newBookData)
        {
            var oldBookData = GetById(newBookData.Id);

            if (oldBookData == null)
                return false;

            oldBookData.Title = newBookData.Title;
            oldBookData.PublishedYear = newBookData.PublishedYear;
            oldBookData.AuthorId = newBookData.AuthorId;
            return true;
        }
    }
}
