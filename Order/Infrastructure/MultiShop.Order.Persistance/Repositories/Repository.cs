using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Persistance.Context;
using System.Linq.Expressions;
namespace MultiShop.Order.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _ordercontext;
        public Repository(OrderContext ordercontext)
        {
            _ordercontext = ordercontext;
        }
        public async Task CreateAsync(T entity)
        {
            _ordercontext.Set<T>().Add(entity);
            await _ordercontext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _ordercontext.Set<T>().Remove(entity);
            await _ordercontext.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsync()
        {
            var values = await _ordercontext.Set<T>().ToListAsync();
            return values;
        }
        public async Task<T> GetByIDAsync(int id)
        {
            var value = await _ordercontext.Set<T>().FindAsync(id);
            return value!;
        }
        public async Task<T> GetFilterAsync(Expression<Func<T, bool>> filter)
        {
            var value = await _ordercontext.Set<T>().Where(filter).FirstOrDefaultAsync();
            return value!;
        }
        public async Task UpdateAsync(T entity)
        {
            _ordercontext.Set<T>().Update(entity);
            await _ordercontext.SaveChangesAsync();
        }
    }
}
