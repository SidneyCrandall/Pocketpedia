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

    public class BugsController : ControllerBase
    {
        private readonly IBugsRepository _bugsRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public BugsController(IBugsRepository bugsRepository, IUserProfileRepository userProfileRepository)
        {
            _bugsRepository = bugsRepository;
            _userProfileRepository = userProfileRepository;
        }

        // Get All the bugs from the API
        [HttpGet]
        public async Task<IActionResult> GetBugsFromApi()
        {
            var bug = await _bugsRepository.BugsFromApi();

            return Ok(bug);
        }

        // GetAllBugs from the local database
        [HttpGet("GetAllBugs")]
        public IActionResult GetAllBugs()
        {
            return Ok(_bugsRepository.GetAllBugs());
        }

        // Add a bug to the Bug local database
        [HttpPost]
        public IActionResult Create(Bug bug)
        {
            var currentUserProfile = GetCurrentUserProfile();

            bug.UserProfileId = currentUserProfile.Id;

            _bugsRepository.Add(bug);

            return CreatedAtAction(nameof(GetAllBugs), new { id = bug.Id }, bug);
        }

        [HttpGet("GetUserBugs")]
        public IActionResult GetUserBugs()
        {
            var user = GetCurrentUserProfile();
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var bug = _bugsRepository.GetBugsByUserId(user.FirebaseUserId);
                return Ok(bug);
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
