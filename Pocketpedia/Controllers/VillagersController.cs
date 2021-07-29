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
    public class VillagersController : ControllerBase
    {
        private readonly IVillagersRepository _villagersRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public VillagersController(IVillagersRepository villagersRepository, IUserProfileRepository userProfileRepository)
        {
            _villagersRepository = villagersRepository;
            _userProfileRepository = userProfileRepository;
        }

        // Get All the bugs
        [HttpGet]
        public async Task<IActionResult> GetVillagersFromApi()
        {
            var villager = await _villagersRepository.VillagersFromApi();
            return Ok(villager);
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
