using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string userid);
        Task SaveBasket(BasketTotalDto baskettotaldto);
        Task DeleteBasket(string userid);
    }
}
