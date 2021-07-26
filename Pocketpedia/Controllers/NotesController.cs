using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Pocketpedia.Models;
using Pocketpedia.Repositories;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepository _notesRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public NotesController(INotesRepository notesRepository, IUserProfileRepository userProfileRepository)
        {
            _notesRepository = notesRepository;
            _userProfileRepository = userProfileRepository;
        }

        // Get all the notes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_notesRepository.GetAll());
        }

        //// Get a user's notes
        //[HttpGet("GetByUser")]
        //public IActionResult GetByUser()
        //{
        //    var user = GetCurrentUserProfile();
        //    if (user == null)
        //    {
        //        return Unauthorized();
        //    }
        //    else
        //    {
        //        var notes = _notesRepository.GetUserNotes(user.FirebaseUserId);
        //        return Ok(notes);
        //    }
        //}

        // Get a notes by an Id
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var notes = _notesRepository.GetNotesById(id);
            if (notes == null)
            {
                return NotFound();
            }
            return Ok(notes);
        }

        // Adding a new note
        [HttpPost]
        public IActionResult CreateNotes(Notes notes)
        {
            var currentUserProfile = GetCurrentUserProfile();

            notes.UserProfileId = currentUserProfile.Id;
            notes.CreateDateTime = DateTime.Now;
 
            _notesRepository.Add(notes);
            return CreatedAtAction(nameof(Get), new { id = notes.Id }, notes);
        }

        // Editting a notes
        [HttpPut("{id}")]
        public IActionResult Put(int id, Notes notes)
        {
            if (id != notes.Id)
            {
                return BadRequest();
            }

            _notesRepository.UpdateNotes(notes);
            return NoContent();
        }

        // Delete an unwated notes
        [HttpDelete("delete/{notesId}")]
        public IActionResult Delete(int notesId)
        {
            _notesRepository.Delete(notesId);
            return NoContent();
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