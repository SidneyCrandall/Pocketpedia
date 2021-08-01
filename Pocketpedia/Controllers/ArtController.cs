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
    public class ArtController : ControllerBase
    {
        private readonly IArtRepository _artRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public ArtController(IArtRepository artRepository, IUserProfileRepository userProfileRepository)
        {
            _artRepository = artRepository;
            _userProfileRepository = userProfileRepository;
        }

        // Get All the art
        [HttpGet]
        public async Task<IActionResult> GetArtFromApi()
        {
            var art = await _artRepository.ArtsFromApi();
            return Ok(art);
        }

        [HttpPost]
        public IActionResult Create(Art art)
        {
            var currentUserProfile = GetCurrentUserProfile();

            art.UserProfileId = currentUserProfile.Id;

            _artRepository.Add(art);

            return CreatedAtAction(nameof(GetAllArt), new { id = art.Id }, art);
        }

        [HttpGet("GetAllArt")]
        public IActionResult GetAllArt()
        {
            return Ok(_artRepository.GetAllArt());
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