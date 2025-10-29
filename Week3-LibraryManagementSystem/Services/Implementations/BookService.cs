using FluentValidation;
using Week3_LibraryManagementSystem.Models.DTOs;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Implementations;
using Week3_LibraryManagementSystem.Repository.Interfaces;
using Week3_LibraryManagementSystem.Services.Interfaces;

namespace Week3_LibraryManagementSystem.Services.Implementations
{
    public class BookService : BaseService<Book, BookDto, int>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository repository, IValidator<BookDto> validator)
            : base(repository, validator) 
        {
            _bookRepository = repository;
        }

        protected override Book MapToEntity(BookDto dto) => new Book
        {
            Title = dto.Title,
            PublishedYear = dto.PublishedYear,
            AuthorId = dto.AuthorId
        };

        protected override void UpdateEntity(Book entity, BookDto dto)
        {
            entity.Title = dto.Title;
            entity.PublishedYear = dto.PublishedYear;
            entity.AuthorId = dto.AuthorId;
        }
        public async Task<IEnumerable<Book>> GetBooksAfterYearAsync(int year) => await _bookRepository.GetBooksAfterYearAsync(year);
    }
}
