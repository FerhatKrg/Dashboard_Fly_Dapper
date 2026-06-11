using Microsoft.AspNetCore.Mvc;

namespace Dashboard_Fly_Dapper.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
