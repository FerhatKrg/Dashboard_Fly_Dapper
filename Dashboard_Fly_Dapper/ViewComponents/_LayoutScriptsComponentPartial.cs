using Microsoft.AspNetCore.Mvc;

namespace Dashboard_Fly_Dapper.ViewComponents
{
    public class _LayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
