using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager _mesageManager = new Message2Manager(new EfMessage2Repository());

        private readonly Context _db;

        public WriterMessageNotification(Context db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userMail = _db.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = _db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = _mesageManager.GetInboxListByWriter(writerID);
            return View(values);
        }
    }
}
