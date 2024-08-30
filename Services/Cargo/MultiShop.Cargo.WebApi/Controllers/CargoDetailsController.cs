using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_cargoDetailService.TGetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDetail(CreateCargoDetailDto detailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = detailDto.Barcode,
                SenderCustomer = detailDto.SenderCustomer,
                ReceiverCustomer = detailDto.ReceiverCustomer,
                CargoCompanyId = detailDto.CargoCompanyId
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Başarıyla Kargo Detayı Kayıt edildi");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Başarıyla Kargo Detayı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateDetail(UpdateCargoDetailDto detailDto)
        {
            _cargoDetailService.TUpdate(new CargoDetail()
            {
                Barcode = detailDto.Barcode,
                CargoDetailID = detailDto.CargoDetailID,
                SenderCustomer = detailDto.SenderCustomer,
                ReceiverCustomer = detailDto.ReceiverCustomer,
                CargoCompanyId = detailDto.CargoCompanyId
            });
            return Ok("Başarıyla Kargo Detayı Güncellendi");
        }
    }
}
