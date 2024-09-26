namespace library.data.Repositories.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
