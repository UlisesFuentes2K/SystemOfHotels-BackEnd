using Microsoft.EntityFrameworkCore;
using SOH.CORE.Interfaces;

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
            await _DbSet.AddAsync(t);
            return t;
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

        public async Task<List<T>> GetAllValues()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<T> GetOneValue(int t)
        {
            return await _DbSet.FirstOrDefaultAsync();
        }

        public async Task<T> UpdateValue(T t)
        {
            return await Task.Run(() =>
            {
                _DbSet.Remove(t);
                return t;
            });
        }
    }
}
