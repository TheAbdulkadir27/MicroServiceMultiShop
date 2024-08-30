using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponent
{
    public class ProductListSizeFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
