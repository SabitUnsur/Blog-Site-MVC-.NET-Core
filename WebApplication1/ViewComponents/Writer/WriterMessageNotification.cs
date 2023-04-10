using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {  
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
