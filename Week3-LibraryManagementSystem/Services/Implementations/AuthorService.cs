using FluentValidation;
using Week3_LibraryManagementSystem.Mappers;
using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;
using Week3_LibraryManagementSystem.Services.Interfaces;

namespace Week3_LibraryManagementSystem.Services.Implementations
{
    public class AuthorService : BaseService, IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IValidator<AuthorDto> _validator;

        public AuthorService(IAuthorRepository repository, IValidator<AuthorDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Author> CreateAsync(AuthorDto dto)
        {
            await ValidateAsync(_validator, dto);
            var entity = AuthorMapper.ToEntity(dto);
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id, AuthorDto dto)
        {
            await ValidateAsync(_validator, dto);
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) 
                return false;

            AuthorMapper.UpdateEntity(entity, dto);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<Author>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Author?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorSummariesAsync()
            => await _repository.GetAuthorSummariesAsync();

        public async Task<IEnumerable<Author>> FindAuthorsByNameAsync(string namePart)
            => await _repository.FindAuthorsByNameAsync(namePart);
    }
}
