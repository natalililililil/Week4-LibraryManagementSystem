using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Mappers
{
    public static class AuthorMapper
    {
        public static Author ToEntity(AuthorDto dto) => new Author
        {
            Name = dto.Name,
            DateOfBirth = dto.DateOfBirth
        };

        public static void UpdateEntity(Author entity, AuthorDto dto)
        {
            entity.Name = dto.Name;
            entity.DateOfBirth = dto.DateOfBirth;
        }
    }
}
