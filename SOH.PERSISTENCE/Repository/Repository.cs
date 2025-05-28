using Microsoft.EntityFrameworkCore;
using SOH.CORE.Interfaces;
using System.Linq.Expressions;

namespace SOH.PERSISTENCE.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _DbSet;
        public Repository(DbContext context)
        {
            _DbSet = context.Set<T>();
        }

        public async Task<T> AddValue(T t)
        {
            var result = await _DbSet.AddAsync(t);
            return result.Entity;
        }

        public async Task<bool> DeleteValue(T t)
        {
            var estado = await Task.Run(() =>
            {
                return _DbSet.Remove(t).Entity;
            });

            if(estado != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<T>> GetAllValues(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _DbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetOneValue(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _DbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> UpdateValue(T t)
        {
            return await Task.Run(() =>
            {
                var result =  _DbSet.Remove(t);
                return result.Entity;
            });
        }
    }
}
