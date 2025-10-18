using common.Entities;
using System.Linq.Expressions;

namespace common.MongoDB.Interface
{
    public interface IMongoRepository<T> where T : EntityBase
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Guid id);

        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
