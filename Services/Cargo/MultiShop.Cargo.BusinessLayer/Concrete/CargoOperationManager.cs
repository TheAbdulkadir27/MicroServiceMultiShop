using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationdal;
        public CargoOperationManager(ICargoOperationDal cargoOperationdal)
        {
            _cargoOperationdal = cargoOperationdal;
        }

        public void TDelete(int id)
        {
            _cargoOperationdal.Delete(id);
        }

        public IQueryable<CargoOperation> TGetAll()
        {
            return _cargoOperationdal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoOperationdal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOperationdal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationdal.Update(entity);
        }
    }
}
