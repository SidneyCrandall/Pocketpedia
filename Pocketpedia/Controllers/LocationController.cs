using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pocketpedia.Models;
using Pocketpedia.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pocketpedia.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }


        [HttpGet]
        public IActionResult GetLocations()
        {
            return Ok(_locationRepository.GetLocations());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var location = _locationRepository.GetById(id);
            return Ok(location);
        }
    }
}
