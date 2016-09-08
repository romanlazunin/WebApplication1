using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IAppRepository _repository;

        public AppController(IMailService mailService, IAppRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var trips = _repository.GetAllTrips();

            return View(trips);
        }

        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("Email", "We don't support AOL addresses");
            }

            if (ModelState.IsValid)
            {

            }
            _mailService.SendMail("abc@example.com", model.Email, "Contact form", $"{model.Message}");
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
