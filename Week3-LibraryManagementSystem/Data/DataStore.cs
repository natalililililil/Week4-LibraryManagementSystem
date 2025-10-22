using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Data
{
    public static class DataStore
    {
        public static List<Author> Authors { get; set; }
        public static List<Book> Books { get; set; }

        static DataStore()
        {
            var author1Id = Guid.NewGuid();
            var author2Id = Guid.NewGuid();

            Authors = new List<Author>
            {
                new Author 
                { 
                    Id = author1Id, 
                    Name = "Лю Цысинь", 
                    DateOfBirth = new DateTime(1963, 6, 23) 
                },
                new Author 
                { 
                    Id = author2Id, 
                    Name = "Мэттью Уолкер", 
                    DateOfBirth = new DateTime(1974, 11, 1) 
                }
            };

            Books = new List<Book>
            {
                new Book 
                { 
                    Id = Guid.NewGuid(), 
                    Title = "Задача трёх тел", 
                    PublishedYear = 2006, 
                    AuthorId = author1Id 
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Темный лес",
                    PublishedYear = 2008,
                    AuthorId = author1Id
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Темный лес",
                    PublishedYear = 2017,
                    AuthorId = author2Id
                }
            };
        }

    }
}
