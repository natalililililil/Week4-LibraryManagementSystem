using FluentValidation;
using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;
using Week3_LibraryManagementSystem.Services.Interfaces;
using Week3_LibraryManagementSystem.Validation;

namespace Week3_LibraryManagementSystem.Services.Implementations
{
    public class AuthorService : BaseService<Author, AuthorDto>, IAuthorService
    {
        public AuthorService(IAuthorRepository repository, IValidator<AuthorDto> validator)
            : base(repository, validator) { }

        protected override Author MapToEntity(AuthorDto dto) => new Author
        {
            Name = dto.Name,
            DateOfBirth = dto.DateOfBirth
        };

        protected override void UpdateEntity(Author entity, AuthorDto dto)
        {
            entity.Name = dto.Name;
            entity.DateOfBirth = dto.DateOfBirth;
        }
    }
}
