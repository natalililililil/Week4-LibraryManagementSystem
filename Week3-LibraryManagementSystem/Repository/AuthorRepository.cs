using Week3_LibraryManagementSystem.Models;
using Week3_LibraryManagementSystem.Data;

namespace Week3_LibraryManagementSystem.Repository
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        protected override List<Author> DbSet => DataStore.Authors;

        public override bool Update(Author newAuthorData)
        {
            var oldAuthorData = GetById(newAuthorData.Id);

            if (oldAuthorData == null)
                return false;

            oldAuthorData.Name = newAuthorData.Name;
            oldAuthorData.DateOfBirth = newAuthorData.DateOfBirth;
            return true;
        }
    }
}
