using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }
        public async Task DeleteBasket(string userid)
        {
            await _redisService.GetDb().KeyDeleteAsync(userid);
        }
        public async Task<BasketTotalDto> GetBasket(string userid)
        {
            var existhbasket = await _redisService.GetDb().StringGetAsync(userid);
            return JsonSerializer.Deserialize<BasketTotalDto>(existhbasket);
        }

        public async Task SaveBasket(BasketTotalDto baskettotaldto)
        {
            await _redisService.GetDb().StringSetAsync(baskettotaldto.UserId, JsonSerializer.Serialize(baskettotaldto));
        }
    }
}
