using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargodetaildal;
        public CargoDetailManager(ICargoDetailDal cargodetaildal)
        {
            _cargodetaildal = cargodetaildal;
        }
        public void TDelete(int id)
        {
            _cargodetaildal.Delete(id);
        }

        public IQueryable<CargoDetail> TGetAll()
        {
            return _cargodetaildal.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return _cargodetaildal.GetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            _cargodetaildal.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargodetaildal.Update(entity);
        }
    }
}
