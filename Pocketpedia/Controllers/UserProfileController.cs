using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pocketpedia.Models;
using Pocketpedia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet("{firebaseUserId}")]
        public IActionResult GetByFirebaseUserId(string firebaseUserId)
        {
            var userProfile = _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpGet("DoesUserExist/{firebaseUserId}")]
        public IActionResult DoesUserExist(string firebaseUserId)
        {
            var userProfile = _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // Get a list of all the users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userProfileRepository.GetAll());
        }

        // Grab a single user from the id requested 
        // Parameter added to the HTTP request
        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var userProfile = _userProfileRepository.GetUserById(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        // Adding a new user
        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            _userProfileRepository.Add(userProfile);

            return CreatedAtAction("Get", new { id = userProfile.Id }, userProfile);
        }

        // Editting/Updating the user's profile
        //// We only need to edit the one we have asked to edit
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, UserProfile userProfile)
        //{
        //    if (id != userProfile.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _userProfileRepository.Update(userProfile);
        //    return NoContent();
        //}

        //// Removing/Deleting a UserProfile
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _userProfileRepository.Delete(id);
        //    return NoContent();
        //}
    }
}