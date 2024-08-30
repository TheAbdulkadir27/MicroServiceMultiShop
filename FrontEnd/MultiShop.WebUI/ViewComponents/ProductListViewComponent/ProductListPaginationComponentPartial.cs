using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponent
{
    public class ProductListPaginationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
