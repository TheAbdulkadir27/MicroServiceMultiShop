using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailPreviewsPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
