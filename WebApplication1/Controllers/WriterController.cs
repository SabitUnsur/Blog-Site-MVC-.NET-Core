using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.userMail=userMail;
            Context db= new Context();
            var writerName=db.Writers.Where(x=>x.WriterMail==userMail).Select(y=>y.WriterName).FirstOrDefault();
            ViewBag.userName=writerName;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var userMail = User.Identity.Name;
            Context db = new Context();
            var writerID = db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var writerValues= writerManager.GetByID(writerID);
            return View(writerValues);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult results = validationRules.Validate(writer);
            if(results.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("Index","Dashboard");
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage writerProfileImage)
        {
            Writer writer= new Writer();
            if(writerProfileImage!=null)
            {
                var extension = Path.GetExtension(writerProfileImage.WriterImage.FileName);
                var newImageName=Guid.NewGuid()+extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                writerProfileImage.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = writerProfileImage.WriterMail;
            writer.WriterName = writerProfileImage.WriterName;
            writer.WriterPassword = writerProfileImage.WriterPassword;
            writer.ConfirmWriterPassword = writerProfileImage.ConfirmWriterPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = writerProfileImage.WriterAbout;
            writerManager.Add(writer);
            return View("Index","Dashboard");
        }
    }
}
