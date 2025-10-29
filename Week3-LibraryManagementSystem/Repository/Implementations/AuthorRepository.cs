using Week3_LibraryManagementSystem.Data;
using System.Linq;
using System.Threading.Tasks;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Week3_LibraryManagementSystem.Models.DTOs;

namespace Week3_LibraryManagementSystem.Repository.Implementations
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext context) : base(context) { }

        public override async Task<bool> UpdateAsync(Author newAuthorData)
        {
            var oldAuthorData = await DbSet.FirstOrDefaultAsync(a => a.Id == newAuthorData.Id);
            if (oldAuthorData == null)
                return false;

            oldAuthorData.Name = newAuthorData.Name;
            oldAuthorData.DateOfBirth = newAuthorData.DateOfBirth;

            await _context.SaveChangesAsync();
            return true;
        }

        public async override Task<Author?> GetByIdAsync(int id)
        {
            return await DbSet.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await DbSet.Include(a => a.Books).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorsWithBookCountAsync() =>
            await DbSet.Select(a => new AuthorWithBookCountDto
            {
                Name = a.Name,
                BookCount = a.Books!.Count
            }).ToListAsync();

        public async Task<IEnumerable<Author>> FindAuthorsByNameAsync(string namePart) =>
            await DbSet.Where(a => a.Name.Contains(namePart) || a.Name.StartsWith(namePart))
                .Include(a => a.Books)
                .AsNoTracking()
                .ToListAsync();


    }
}
