using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Api
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        public JsonResult Get()
        {
            return Json(new Trip() { Name = "My Trip" });
        }

        [HttpGet("{id}")]
        public JsonResult GetById(string id)
        {
            return Json(new Trip() {
                Id = int.Parse(id),
                Name = "My Trip"
            });
        }

    }
}
