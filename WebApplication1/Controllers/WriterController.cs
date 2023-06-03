using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DailyBlogUI.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        private readonly UserManager<AppUser> _userManager;

        private readonly Context _db;

        public WriterController(UserManager<AppUser> userManager,Context db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            ViewBag.userMail= userName;

            var writerName= _db.Writers.Where(x=>x.WriterMail== userName).Select(y=>y.WriterName).FirstOrDefault();
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
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel();
            userUpdateViewModel.emailAdress = values.Email;
            userUpdateViewModel.NamesurName = values.NameSurname;
            userUpdateViewModel.imageURL = values.ImageUrl;
            userUpdateViewModel.Username = values.UserName;
        
            return View(userUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdateViewModel)
        {
            var userToUpdate = await _userManager.FindByNameAsync(User.Identity.Name);
            userToUpdate.Email = userUpdateViewModel.emailAdress;
            userToUpdate.UserName = userUpdateViewModel.Username;
            userToUpdate.ImageUrl = userUpdateViewModel.imageURL;
            userToUpdate.NameSurname = userUpdateViewModel.NamesurName;

            if (!userUpdateViewModel.ChangePassword)
            {
                userToUpdate.PasswordHash = _userManager.PasswordHasher.HashPassword(userToUpdate, userUpdateViewModel.userPassword);
            }

            var result= await _userManager.UpdateAsync(userToUpdate);

            return RedirectToAction("Index","Dashboard");
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
