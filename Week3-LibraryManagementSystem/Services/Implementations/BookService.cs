using FluentValidation;
using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;
using Week3_LibraryManagementSystem.Services.Interfaces;

namespace Week3_LibraryManagementSystem.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IValidator<BookDto> _bookValidator;
        public BookService(IBookRepository bookRepository, IValidator<BookDto> bookValidator)
        {
            _bookRepository = bookRepository;
            _bookValidator = bookValidator;
        }

        public async Task<Book> CreateAsync(BookDto dto)
        {
            var validation = await _bookValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var book = new Book
            {
                Title = dto.Title,
                PublishedYear = dto.PublishedYear,
                AuthorId = dto.AuthorId
            };

            return await _bookRepository.CreateAsync(book);
        }

        public async Task<bool> DeleteAsync(Guid id) => await _bookRepository.DeleteAsync(id);

        public async Task<IEnumerable<Book>> GetAllAsync() => await _bookRepository.GetAllAsync();

        public async Task<Book?> GetByIdAsync(Guid id) => await _bookRepository.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(Guid id, BookDto dto)
        {
            var validation = await _bookValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) 
                return false;

            book.Title = dto.Title;
            book.PublishedYear = dto.PublishedYear;
            book.AuthorId = dto.AuthorId;

            return await _bookRepository.UpdateAsync(book);
        }
    }
}
