using Microsoft.EntityFrameworkCore;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId);

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            var author1Id = Guid.NewGuid();
            var author2Id = Guid.NewGuid();
                
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Лю Цысинь",
                    DateOfBirth = new DateTime(1963, 6, 23)
                },
                new Author
                {
                    Id = 2,
                    Name = "Мэттью Уолкер",
                    DateOfBirth = new DateTime(1974, 11, 1)
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Задача трёх тел",
                    PublishedYear = 2006,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Темный лес",
                    PublishedYear = 2008,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "Зачем мы спим",
                    PublishedYear = 2017,
                    AuthorId = 2
                }
            );
        }
    }
}
