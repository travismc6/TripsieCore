using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripsieCore.Models;
using Microsoft.Extensions.Configuration;
using TripsieCore.Services;

namespace TripsieCore.Controllers
{
    [Route("api/trips")]
    public class TripsController : Controller
    {
        private IConfigurationRoot _config;
        private ITripService _tripService;
        private ITripsieRepository _repository;

        public TripsController(ITripsieRepository repository, IConfigurationRoot config, ITripService tripService)
        {
            _config = config;
            _tripService = tripService;
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_repository.GetTrips());

            if(false)
            {
                return BadRequest();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]Trip trip)
        {
            if(ModelState.IsValid)
            {
                _repository.AddTrip(trip);

                //var newTrip = AutoMapper.Mapper.Map<Trip>(trip); // @TODO use view model for "trip"
                if (await _repository.SaveChangesAsync())
                {

                    return Created("api/trip/" + trip.Id, trip);
                }
            }

            return BadRequest();
        }
    }
}