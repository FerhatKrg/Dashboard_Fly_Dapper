using Microsoft.AspNetCore.Mvc;

namespace Dashboard_Fly_Dapper.ViewComponents
{
    public class _LayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
