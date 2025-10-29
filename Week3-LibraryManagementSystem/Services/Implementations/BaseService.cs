using FluentValidation;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;
using Week3_LibraryManagementSystem.Services.Interfaces;

namespace Week3_LibraryManagementSystem.Services.Implementations
{
    public abstract class BaseService<TEntity, TDto, TKey> : IBaseService<TEntity, TDto, TKey>
        where TEntity : class, IEntity<TKey>
        where TDto : class
    {
        protected readonly IRepository<TEntity, TKey> _repository;
        private readonly IValidator<TDto> _validator;

        protected BaseService(IRepository<TEntity, TKey> repository, IValidator<TDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<TEntity> CreateAsync(TDto dto)
        {
            await ValidateAsync(dto);
            var entity = MapToEntity(dto);
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(TKey id, TDto dto)
        {
            await ValidateAsync(dto);
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;

            UpdateEntity(entity, dto);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(TKey id) => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<TEntity?> GetByIdAsync(TKey id) => await _repository.GetByIdAsync(id);

        private async Task ValidateAsync(TDto dto)
        {
            var validation = await _validator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);
        }

        protected abstract TEntity MapToEntity(TDto dto);
        protected abstract void UpdateEntity(TEntity entity, TDto dto);
    }
}
