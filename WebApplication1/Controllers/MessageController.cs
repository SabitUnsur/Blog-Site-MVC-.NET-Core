using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class MessageController : Controller
    {
        private readonly Context _db;

        public MessageController(Context db)
        {
            _db = db;
        }

        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());

        [AllowAnonymous]
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = _db.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = _db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(writerID);
            return View(values);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult MessageDetails(int messageID)
        {
          var values= message2Manager.GetByID(messageID);
            return View(values);
        }

    }
}
