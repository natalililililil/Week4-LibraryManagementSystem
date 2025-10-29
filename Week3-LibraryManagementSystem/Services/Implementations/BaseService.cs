using FluentValidation;

namespace Week3_LibraryManagementSystem.Services.Implementations
{
    public abstract class BaseService
    {
        protected async Task ValidateAsync<TDto>(IValidator<TDto> validator, TDto dto) 
            where TDto : class
        {
            var validation = await validator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);
        }
    }
}
