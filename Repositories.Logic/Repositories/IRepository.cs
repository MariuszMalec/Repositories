namespace Repositories.Logic.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Delete(string id, T entity);
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> GetAllQueryable();
        Task<T> GetById(string id);
        Task<bool> Insert(T entity);
        Task<bool> Update(string id, T entity);
    }
}
