using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers.Api
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private ILogger<TripsController> _logger;
        private IAppRepository _repo;

        public TripsController(IAppRepository repo,
            ILogger<TripsController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repo.GetAllTrips();
                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get All Trips: {ex}");
                return BadRequest("Error occured");
            }
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
        public async Task<IActionResult> Post([FromBody]TripViewModel trip)
        {
            if (ModelState.IsValid)
            {
                var newTrip = Mapper.Map<Trip>(trip);
                _repo.AddTrip(newTrip);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/trips/{trip.Name}", Mapper.Map<TripViewModel>(newTrip));
                }
                else
                {
                    return BadRequest("Failed to save changes to the database");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
