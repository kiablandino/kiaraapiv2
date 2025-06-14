using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CUR.Api.Data;

namespace CUR.Api.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CurDbContext _ctx;
        public GenericRepository(CurDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _ctx.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) =>
            await _ctx.Set<T>().FindAsync(id);

        public async Task<T> CreateAsync(T entity)
        {
            _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id);
            if (e is null) throw new KeyNotFoundException($"No se encontró registro con id {id}");
            _ctx.Set<T>().Remove(e);
            await _ctx.SaveChangesAsync();
        }
    }
}
