using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            _mailService.SendMail("rlazunin@gmail.com", model.Email, "Contact form", $"{model.Message}");
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
