using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace RealEstateDapperUI.ViewComponents.HomePage
{
    public class _DefaultFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
