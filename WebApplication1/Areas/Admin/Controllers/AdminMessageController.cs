using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DailyBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _db;
        public AdminMessageController(UserManager<AppUser> userManager, Context db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult InBox()
        {
           
                var userName = User.Identity.Name;
                var userMail = _db.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
                var writerID = _db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
                var values = message2Manager.GetInboxListByWriter(writerID);
                return View(values);
           
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = _db.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = _db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetSendboxListByWriter(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View(Tuple.Create<Message2, AppUser>(new Message2(), new AppUser()));
        }
        [HttpPost]
        public async Task<IActionResult> ComposeMessage([Bind(Prefix = "Item1")] Message2 message, [Bind(Prefix = "Item2")] AppUser writer)
        {
            var userName = User.Identity.Name;
            var userMail = _db.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = _db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            message.SenderID = writerID;
            message.ReceiverID = 2;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = true;
            message2Manager.Add(message);
            return RedirectToAction("SendBox");
        }

    }
}
