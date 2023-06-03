using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly Context _db;

        public MessageController(UserManager<AppUser> userManager,Context db)
        {
            _userManager = userManager;
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

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = _db.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = _db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetSendboxListByWriter(writerID);
            return View(values);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult MessageDetails(int messageID)
        {
          var values= message2Manager.GetByID(messageID);
            return View(values);
        }


        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message2 message)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            message.SenderID = value.Id;
            message.ReceiverID = 2;
            message.MessageStatus = true;
            message.MessageDate= DateTime.SpecifyKind(DateTime.Parse(DateTime.Now.ToString()), DateTimeKind.Local);
            message2Manager.Add(message);

            return RedirectToAction("InBox");
        }

    }
}
