using FluentValidation;
using Week3_LibraryManagementSystem.Mappers;
using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;
using Week3_LibraryManagementSystem.Services.Interfaces;

namespace Week3_LibraryManagementSystem.Services.Implementations
{
    public class BookService : BaseService, IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IValidator<BookDto> _validator;

        public BookService(IBookRepository repository, IValidator<BookDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Book> CreateAsync(BookDto dto)
        {
            await ValidateAsync(_validator, dto);
            var entity = BookMapper.ToEntity(dto);
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id, BookDto dto)
        {
            await ValidateAsync(_validator, dto);
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) 
                return false;

            BookMapper.UpdateEntity(entity, dto);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<Book>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Book?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Book>> GetBooksAfterYearAsync(int year)
            => await _repository.GetBooksAfterYearAsync(year);
    }
}
