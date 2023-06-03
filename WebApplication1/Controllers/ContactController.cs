using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EfContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate = DateTime.SpecifyKind(DateTime.Parse(DateTime.Now.ToString()), DateTimeKind.Local);
            contact.ContactStatus = true;
            _contactManager.AddContact(contact);
            return RedirectToAction("Index","Blog");
        }
    }
}
