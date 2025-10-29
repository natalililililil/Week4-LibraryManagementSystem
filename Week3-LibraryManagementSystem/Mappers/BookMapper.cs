using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Mappers
{
    public static class BookMapper
    {
        public static Book ToEntity(BookDto dto) => new Book
        {
            Title = dto.Title,
            PublishedYear = dto.PublishedYear,
            AuthorId = dto.AuthorId
        };

        public static void UpdateEntity(Book entity, BookDto dto)
        {
            entity.Title = dto.Title;
            entity.PublishedYear = dto.PublishedYear;
            entity.AuthorId = dto.AuthorId;
        }
    }
}
