using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _cargoContext;
        public GenericRepository(CargoContext cargoContext)
        {
            this._cargoContext = cargoContext;
            _cargoContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Delete(int id)
        {
            var value = _cargoContext.Set<T>().Find(id);
            _cargoContext.Remove(value!);
            _cargoContext.SaveChanges();
        }
        public IQueryable<T> GetAll()
        {
            var values = _cargoContext.Set<T>().AsNoTracking().ToList();
            return values.AsQueryable<T>();
        }
        public T GetById(int id)
        {
            var value = _cargoContext.Set<T>().Find(id);
            return value!;
        }

        public void Insert(T entity)
        {
            _cargoContext.Set<T>().Add(entity);
            _cargoContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _cargoContext.Set<T>().Update(entity);
            _cargoContext.SaveChanges();
        }
    }
}
