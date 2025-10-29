using Week3_LibraryManagementSystem.Data;
using System.Linq;
using System.Threading.Tasks;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Week3_LibraryManagementSystem.Repository.Implementations
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context) { }

        public override async Task<bool> UpdateAsync(Book newBookData)
        {
            var oldBookData = await DbSet.FirstOrDefaultAsync(b => b.Id == newBookData.Id);
            if (oldBookData == null)
                return false;

            oldBookData.Title = newBookData.Title;
            oldBookData.PublishedYear = newBookData.PublishedYear;
            oldBookData.AuthorId = newBookData.AuthorId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Book>> GetBooksAfterYearAsync(int year) =>
            await DbSet
                .Where(b => b.PublishedYear > year)
                .Include(b => b.Author)
                .AsNoTracking()
                .ToListAsync();
    }
}
