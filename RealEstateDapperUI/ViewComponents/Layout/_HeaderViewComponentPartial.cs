using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.ViewComponents
{
    public class _HeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
