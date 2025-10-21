using FluentValidation;
using Week3_LibraryManagementSystem.Models;
using Week3_LibraryManagementSystem.Repository;

namespace Week3_LibraryManagementSystem.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator(IAuthorRepository authorRepository)
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Название книги не может быть пустым")
                .MaximumLength(200).WithMessage("Название книги не должно превышать 200 символов");

            RuleFor(b => b.PublishedYear)
                .InclusiveBetween(1500, DateTime.Now.Year)
                .WithMessage($"Год публикации должен быть в диапазоне от 1500 до {DateTime.Now.Year}");

            RuleFor(b => b.AuthorId)
                .NotEmpty().WithMessage("AuthorId не может быть пустым")
                .Must(authorId => authorRepository.GetById(authorId) != null)
                .WithMessage("Автор с таким Id не найден");
        }
    }
}