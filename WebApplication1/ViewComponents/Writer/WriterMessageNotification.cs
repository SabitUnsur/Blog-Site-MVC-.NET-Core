using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager _mesageManager = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int receiverID = 3;
            var values = _mesageManager.GetInboxListByWriter(receiverID);
            return View(values);
        }
    }
}
