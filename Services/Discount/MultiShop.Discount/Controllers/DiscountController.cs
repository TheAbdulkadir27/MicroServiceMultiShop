using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountservice;
        public DiscountController(IDiscountService discountservice)
        {
            _discountservice = discountservice;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _discountservice.GetAllCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCoupon(int id)
        {
            var values = await _discountservice.GetByIdCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCoupon)
        {
            await _discountservice.CreateCouponAsync(createCoupon);
            return Ok("Başarıyla Kupon Oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountservice.DeleteCouponAsync(id);
            return Ok("Başarıyla Kupon Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCoupon)
        {
            await _discountservice.UpdateCouponAsync(updateCoupon);
            return Ok("Başarıyla Kupon Başarıyla Güncellendi");
        }
    }
}
