using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week3_LibraryManagementSystem.Data;
using Week3_LibraryManagementSystem.Models.Entities;
using Week3_LibraryManagementSystem.Repository.Interfaces;

namespace Week3_LibraryManagementSystem.Repository.Implementations
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly LibraryContext _context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(LibraryContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return false;

            DbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async virtual Task<T?> GetByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public abstract Task<bool> UpdateAsync(T entity);
    }
}
