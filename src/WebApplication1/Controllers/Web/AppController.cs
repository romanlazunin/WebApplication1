using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private IConfigurationRoot _config;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService, 
            IConfigurationRoot config,
            IAppRepository repository,
            ILogger<AppController> logger)
        {
            _config = config;
            _mailService = mailService;
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            try
            {
                var trips = _repository.GetAllTrips();

                return View(trips);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get trips in Index page from db: {ex.Message}");
                return Redirect("/error");

            }
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
