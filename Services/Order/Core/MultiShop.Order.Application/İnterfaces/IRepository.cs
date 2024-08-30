using System.Linq.Expressions;
namespace MultiShop.Order.Application.İnterfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetFilterAsync(Expression<Func<T, bool>> filter);
    }
}
