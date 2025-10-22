using FluentValidation;
using Week3_LibraryManagementSystem.Models;

namespace Week3_LibraryManagementSystem.Validation
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Имя автора не может быть пустым")
                .MaximumLength(100).WithMessage("Имя автора не должно превышать 100 символов");

            RuleFor(a => a.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Дата рождения должна быть в прошлом");
        }
    }

}
