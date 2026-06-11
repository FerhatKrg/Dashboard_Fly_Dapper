using Microsoft.AspNetCore.Mvc;

namespace Dashboard_Fly_Dapper.ViewComponents
{
    public class _LayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
