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
    [Authorize]
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

        [HttpGet("GetVillagers")]
        public IActionResult GetVillagers()
        {
            return Ok(_villagersRepository.GetVillagers());
        }

        [HttpPost]
        public IActionResult Create(Villager villager)
        {
            var currentUserProfile = GetCurrentUserProfile();
            villager.UserProfileId = currentUserProfile.Id;
            _villagersRepository.Add(villager);
            return CreatedAtAction(nameof(GetVillagers), new { id = villager.Id }, villager);
        }

        [HttpGet("GetUserVillagers")]
        public IActionResult GetUserVillagers()
        {
            var user = GetCurrentUserProfile();
            if (user == null)
            {
                return Unauthorized();
            }
            else 
            {
                var villagers = _villagersRepository.GetVillagersByUser(user.FirebaseUserId);
                return Ok(villagers);
            }
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
