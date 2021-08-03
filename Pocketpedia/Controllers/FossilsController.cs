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
        public async Task<IActionResult> GetFossilsFromApi()
        {
            var fossil = await _fossilsRepository.FossilsFromApi();
            return Ok(fossil);
        }


        [HttpPost]
        public IActionResult Create(Fossil fossil)
        {
            var currentUserProfile = GetCurrentUserProfile();

            fossil.UserProfileId = currentUserProfile.Id;

            _fossilsRepository.Add(fossil);

            return CreatedAtAction(nameof(GetUserFossil), new { id = fossil.Id }, fossil);
        }

        [HttpGet("GetUserFossil")]
        public IActionResult GetUserFossil()
        {
            var user = GetCurrentUserProfile();
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var fossil = _fossilsRepository.GetFossilsByUserId(user.FirebaseUserId);
                return Ok(fossil);
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