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
        private IAppRepository _repo;

        public TripsController(IAppRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            if (false)
            {
                return BadRequest("Bad things happened");
            }

            return Ok(_repo.GetAllTrips());
        }

        [HttpGet("{id}")]
        public JsonResult GetById(string id)
        {
            return Json(new Trip() {
                Id = int.Parse(id),
                Name = "My Trip"
            });
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]Trip trip)
        {
            return Ok(new Trip{
                Id = trip.Id,
                Name = trip.Name,
                DateCreated = DateTime.UtcNow
            });
        }
    }
}
