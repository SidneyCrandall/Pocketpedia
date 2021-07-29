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
    public class FishController : ControllerBase
    {

        private readonly IFishRepository _fishRepository;

        private readonly IUserProfileRepository _userProfileRepository;

        public FishController(IFishRepository fishRepository, IUserProfileRepository userProfileRepository)
        {
            _fishRepository = fishRepository;
            _userProfileRepository = userProfileRepository;
        }

        // Get all fish from API
        [HttpGet]
        public async Task<IActionResult> GetFishFromApi()
        {
            var fish = await _fishRepository.FishesFromApi();
            return Ok(fish);
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
