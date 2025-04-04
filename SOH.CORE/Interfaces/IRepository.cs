namespace SOH.CORE.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllValues();
        Task<T> GetOneValue(int t);
        Task<T> AddValue(T t);
        Task<T> UpdateValue(T t);
        Task<bool> DeleteValue(T t);
    }
}
