using System.Linq.Expressions;

namespace SOH.CORE.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllValues(params Expression<Func<T, object>>[] includes);
        Task<T> GetOneValue(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<T> AddValue(T t);
        Task<T> UpdateValue(T t);
        Task<bool> DeleteValue(T t);
    }
}
