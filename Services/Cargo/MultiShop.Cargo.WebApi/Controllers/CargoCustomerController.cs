using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerByID(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomersDtos create)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                City = create.City,
                Address = create.Address,
                District = create.District,
                Email = create.Email,
                Name = create.Name,
                Phone = create.Phone,
                Surname = create.Surname
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Başarıyla Cargo Customer Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Müşterisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDtos update)
        {
            _cargoCustomerService.TUpdate(new CargoCustomer()
            {
                Address = update.Address,
                District = update.District,
                Email = update.Email,
                Name = update.Name,
                Phone = update.Phone,
                Surname = update.Surname,
                City = update.City,
                CargoCustomerID = update.CargoCustomerID
            });
            return Ok("Başarıyla Kargo Müşterisi Güncellendi");
        }
    }
}
