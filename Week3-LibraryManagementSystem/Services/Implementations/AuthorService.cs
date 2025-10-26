using FluentValidation;
using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;
using Week3_LibraryManagementSystem.Services.Interfaces;
using Week3_LibraryManagementSystem.Validation;

namespace Week3_LibraryManagementSystem.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IValidator<AuthorDto> _authorValidator;
        public AuthorService(IAuthorRepository authorRepository, IValidator<AuthorDto> authorValidator)
        {
            _authorRepository = authorRepository;
            _authorValidator = authorValidator;
        }

        public async Task<Author> CreateAsync(AuthorDto dto)
        {
            var validation = await _authorValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var author = new Author
            {
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth
            };

            return await _authorRepository.CreateAsync(author);
        }

        public async Task<bool> DeleteAsync(Guid id) => await _authorRepository.DeleteAsync(id);

        public async Task<IEnumerable<Author>> GetAllAsync() => await _authorRepository.GetAllAsync();

        public async Task<Author?> GetByIdAsync(Guid id) => await _authorRepository.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(Guid id, AuthorDto dto)
        {
            var validation = await _authorValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                return false;

            author.Name = dto.Name;
            author.DateOfBirth = dto.DateOfBirth;
            return await _authorRepository.UpdateAsync(author);
        }
    }
}
