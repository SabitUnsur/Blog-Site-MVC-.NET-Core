using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents.Writer
{
    public class WriterNotifications:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
