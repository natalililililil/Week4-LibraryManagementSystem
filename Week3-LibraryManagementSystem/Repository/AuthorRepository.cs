using Week3_LibraryManagementSystem.Models;
using Week3_LibraryManagementSystem.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Week3_LibraryManagementSystem.Repository
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        protected override List<Author> DbSet => DataStore.Authors;

        public override Task<bool> UpdateAsync(Author newAuthorData)
        {
            var oldAuthorData = DbSet.FirstOrDefault(a => a.Id == newAuthorData.Id);
            if (oldAuthorData == null) 
                return Task.FromResult(false);

            oldAuthorData.Name = newAuthorData.Name;
            oldAuthorData.DateOfBirth = newAuthorData.DateOfBirth;
            return Task.FromResult(true);
        }
    }
}
