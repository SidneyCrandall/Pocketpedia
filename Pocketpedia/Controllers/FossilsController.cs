using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pocketpedia.Models;
using Pocketpedia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pocketpedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FossilsController : ControllerBase
    {
        private readonly IFossilsRepository _fossilsRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public FossilsController(IFossilsRepository fossilsRepository, IUserProfileRepository userProfileRepository)
        {
            _fossilsRepository = fossilsRepository;
            _userProfileRepository = userProfileRepository;
        }

        // Get All the fossils
        [HttpGet]
        public async Task<IActionResult> GetBugsFromApi()
        {
            var fossil = await _fossilsRepository.FossilsFromApi();
            return Ok(fossil);
        }

        //[HttpGet("Get")]
        //public IActionResult Get

        // Get the current user
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (firebaseUserId != null)
            {
                return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
            }
            else
            {
                return null;
            }
        }
    }
}
