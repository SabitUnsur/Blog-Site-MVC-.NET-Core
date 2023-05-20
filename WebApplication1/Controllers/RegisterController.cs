using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager _writerManager = new WriterManager(new EfWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			WriterValidator validation = new WriterValidator();
			ValidationResult validationResult = validation.Validate(writer);
			if(validationResult.IsValid)
			{
				writer.WriterStatus = true;
				writer.WriterAbout = "Test";

				_writerManager.Add(writer);

				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			return View();
		}

	}
}
