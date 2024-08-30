using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompany;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargocompanyservice;
        public CargoCompaniesController(ICargoCompanyService cargocompanyservice)
        {
            _cargocompanyservice = cargocompanyservice;
        }
        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargocompanyservice.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            };
            _cargocompanyservice.TInsert(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla Oluşturuldu");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargocompanyservice.TDelete(id);
            return Ok("Başarıyla kargo company silindi");
        }
        [HttpGet("{id}")]
        public IActionResult CargoCompanyGetByID(int id)
        {
            return Ok(_cargocompanyservice.TGetById(id));
        }

        [HttpPut]
        public IActionResult CargoCompanyUpdate(UpdateCargoCompanyDto updateCargoCompany)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyID = updateCargoCompany.CargoCompanyID,
                CargoCompanyName = updateCargoCompany.CargoCompanyName
            };
            _cargocompanyservice.TUpdate(cargoCompany);
            return Ok("Başarıyla güncellendi");
        }
    }
}
