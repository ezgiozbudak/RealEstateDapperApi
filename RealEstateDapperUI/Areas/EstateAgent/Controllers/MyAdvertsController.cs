using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
