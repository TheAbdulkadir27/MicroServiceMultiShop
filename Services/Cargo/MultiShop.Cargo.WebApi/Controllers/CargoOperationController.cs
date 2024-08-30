using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_cargoOperationService.TGetById(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_cargoOperationService.TGetAll());
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {
            _cargoOperationService.TInsert(new CargoOperation()
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate
            });
            return Ok("Başarıyla Kargo İşlemleri Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Başarıyla Kargo İşlemi Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            var cargoOperation = new CargoOperation()
            {
                Barcode = dto.Barcode,
                CargoOperationID = dto.CargoOperationID,
                Description = dto.Description,
                OperationDate = dto.OperationDate
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Başarıyla Cargo İşlemi Güncellendi");
        }
    }
}
