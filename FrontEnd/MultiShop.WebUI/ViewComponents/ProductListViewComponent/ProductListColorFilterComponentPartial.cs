using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponent
{
    public class ProductListColorFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
