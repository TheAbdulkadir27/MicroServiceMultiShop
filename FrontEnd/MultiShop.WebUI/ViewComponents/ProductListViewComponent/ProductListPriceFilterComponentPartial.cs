using Microsoft.AspNetCore.Mvc;
namespace MultiShop.WebUI.ViewComponents.ProductListViewComponent
{
    public class ProductListPriceFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
