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
    public class SeaCreaturesController : ControllerBase
    {
        private readonly ISeaCreaturesRepository _seaCreaturesRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public SeaCreaturesController(ISeaCreaturesRepository seaCreaturesRepository, IUserProfileRepository userProfileRepository)
        {
            _seaCreaturesRepository = seaCreaturesRepository;
            _userProfileRepository = userProfileRepository;
        }

        // Get All the bugs
        [HttpGet]
        public async Task<IActionResult> GetBugsFromApi()
        {
            var seaCreature = await _seaCreaturesRepository.SeaCreaturesFromApi();

            return Ok(seaCreature);
        }

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
